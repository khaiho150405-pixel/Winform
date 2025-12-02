using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_QLTV.Services
{
    public class Chatbot
    {
        private readonly string apiKey = ".";
        private readonly string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        private string GetLibraryContext()
        {
            try
            {
                using (var db = new Model1())
                {
                    var books = db.SACHes
                        .Include("TACGIA")
                        .Include("NHAXUATBAN")
                        .Take(30)
                        .Select(s => new
                        {
                            Ten = s.TENSACH,
                            TacGia = s.TACGIA.TENTG,
                            TheLoai = s.THELOAI,
                            TrangThai = s.TRANGTHAI,
                            ViTri = s.SOLUONGTON > 0 ? "Có sẵn tại kệ" : "Đang được mượn hết"
                        }).ToList();

                    var sb = new StringBuilder();
                    sb.AppendLine("Dữ liệu thư viện hiện tại:");
                    foreach (var b in books)
                        sb.AppendLine($"- Sách: {b.Ten} | Tác giả: {b.TacGia} | Thể loại: {b.TheLoai} | Tình trạng: {b.TrangThai}");
                    return sb.ToString();
                }
            }
            catch
            {
                return "Không thể kết nối cơ sở dữ liệu.";
            }
        }

        private static string EscapeJson(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                switch (c)
                {
                    case '\\': sb.Append("\\\\"); break;
                    case '"': sb.Append("\\\""); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 32) sb.Append("\\u" + ((int)c).ToString("x4")); else sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        [DataContract]
        private class GeminiResponse
        {
            [DataMember] public List<Candidate> candidates { get; set; }
        }

        [DataContract]
        private class Candidate
        {
            [DataMember] public Content content { get; set; }
            [DataMember] public string finishReason { get; set; }
        }

        [DataContract]
        private class Content
        {
            [DataMember] public List<Part> parts { get; set; }
        }

        [DataContract]
        private class Part
        {
            [DataMember] public string text { get; set; }
        }

        private static string ParseGeminiResponse(string json)
        {
            if (string.IsNullOrEmpty(json)) return "Không có phản hồi.";
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(GeminiResponse));
                using (var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var resp = serializer.ReadObject(ms) as GeminiResponse;
                    if (resp?.candidates == null || resp.candidates.Count == 0)
                        return "Chưa nhận được câu trả lời.";

                    var firstValid = resp.candidates
                        .FirstOrDefault(c => c.content?.parts != null && c.content.parts.Any(p => !string.IsNullOrWhiteSpace(p.text)));

                    if (firstValid == null)
                    {
                        // Kiểm tra lý do kết thúc để đưa thông điệp thân thiện
                        var safety = resp.candidates.FirstOrDefault(c => c.finishReason != null);
                        if (safety != null && (safety.finishReason == "SAFETY" || safety.finishReason == "RECITATION"))
                            return "Câu hỏi bị hệ thống chặn (an toàn nội dung). Vui lòng diễn đạt khác.";
                        return "Không tìm thấy nội dung phản hồi.";
                    }

                    var text = string.Join("\n", firstValid.content.parts
                        .Where(p => !string.IsNullOrWhiteSpace(p.text))
                        .Select(p => p.text.Trim()));

                    return string.IsNullOrWhiteSpace(text) ? "Không tìm thấy nội dung phản hồi." : text;
                }
            }
            catch
            {
                return "Lỗi phân tích dữ liệu phản hồi.";
            }
        }

        public async Task<string> GetResponse(string userMessage)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string context = GetLibraryContext();
                string systemPrompt = "Bạn là trợ lý ảo của thư viện trường Đại học Công Thương. Hãy trả lời ngắn gọn, lịch sự bằng tiếng Việt. Chỉ dựa vào dữ liệu sau (nếu không có hãy khuyên liên hệ thủ thư):\n" + context;
                string user = userMessage ?? string.Empty;

                string payload = "{" +
                                 "\"systemInstruction\":{\"parts\":[{\"text\":\"" + EscapeJson(systemPrompt) + "\"}]}," +
                                 "\"contents\":[{\"parts\":[{\"text\":\"" + EscapeJson(user) + "\"}]}]}";

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var content = new StringContent(payload, Encoding.UTF8, "application/json");
                    var url = $"{apiUrl}?key={apiKey}";

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                        return ParseGeminiResponse(responseString);

                    return "Xin lỗi, hệ thống đang bận. Mã lỗi: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối: " + ex.Message;
            }
        }
    }
}