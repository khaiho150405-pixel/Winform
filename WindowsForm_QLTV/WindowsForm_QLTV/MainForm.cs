using System;
using System.Collections.Generic; // Cần thiết cho List
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm_QLTV.Services; // Namespace chứa GeminiService
using WindowsForm_QLTV.CustomControls;

namespace WindowsForm_QLTV
{
    public partial class MainForm : Form
    {
        // Constructor mặc định
        private Panel pnlChatContainer;
        private FlowLayoutPanel flpChatHistory;
        private TextBox txtChatInput;
        private Button btnSendChat;
        private Button btnToggleChat;
        private Chatbot chatbotService;
        private bool isChatOpen = false;
        public MainForm()
        {
            InitializeComponent();
            InitializeChatbotUI();
        }

        // Constructor quan trọng để truyền dữ liệu người dùng
        public MainForm(string username, string role) : this()
        {
            // Cập nhật thông tin vào Header Sidebar
            lblUserNameHeader.Text = $"MÃ TK: {username}";
            lblUserRoleHeader.Text = $"Vai trò: {role}";
            tsslUsername.Text = $"Đang đăng nhập: {username} | Quyền: {role}";

            AttachMenuEventHandlers();
            ApplyUserPermissions(role); // Áp dụng phân quyền sau khi gán sự kiện

            // Tải nội dung mặc định (Trang chủ)
            ShowContentControl("Trang chủ");
            HighlightButton(btnTrangChu);
        }

        private void ApplyUserPermissions(string role)
        {
            string normalizedRole = role.Trim().ToUpper();

            // Mặc định: Ẩn tất cả các nút quản lý trừ Trang Chủ và Thông tin cá nhân
            btnTrangChu.Visible = true;
            btnThongTinCaNhan.Visible = true;
            btnThoat.Visible = true;

            btnTaiKhoan.Visible = false;
            btnSach.Visible = false;
            btnQLMuonTra.Visible = false;
            btnMuonTra.Visible = false;

            // Các nút bị loại bỏ khỏi thiết kế nhưng vẫn tồn tại trong code logic
            btnBaoCao.Visible = false;
            btnTacGia.Visible = false;
            btnNhaXuatBan.Visible = false;

            switch (normalizedRole)
            {
                case "ADMIN":
                    // ADMIN: Full quyền
                    btnTaiKhoan.Visible = true;
                    btnSach.Visible = true;
                    btnQLMuonTra.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "THỦ THƯ":
                    // THỦ THƯ: Không có Quản lý Tài khoản, Quản lý Sách
                    btnQLMuonTra.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "THỦ KHO":
                    // THỦ KHO: Chỉ có Quản lý Sách, không có Quản lý Tài khoản và QL Mượn Trả
                    btnSach.Visible = true;
                    btnMuonTra.Visible = true;
                    break;

                case "ĐỘC GIẢ":
                    // ĐỘC GIẢ: Chỉ có Trang chủ, Thông tin cá nhân và Mượn trả sách
                    btnMuonTra.Visible = true;
                    break;

                default:
                    // Vai trò không xác định: Hầu hết đều ẩn, chỉ giữ lại các nút cơ bản
                    break;
            }
        }

        private void AttachMenuEventHandlers()
        {
            // Gán sự kiện Click cho các nút Sidebar
            btnTrangChu.Click += BtnItem_Click;
            btnSach.Click += BtnItem_Click;
            btnQLMuonTra.Click += BtnItem_Click;
            btnMuonTra.Click += BtnItem_Click;
            btnTaiKhoan.Click += BtnItem_Click;
            btnThongTinCaNhan.Click += BtnItem_Click;

            // Nút Thoát
            btnThoat.Click += BtnThoat_Click;

            // Đặt lại Text cho các Button (Giữ nguyên)
            btnTaiKhoan.Text = " 🔑 Quản lý tài khoản";
            btnSach.Text = " 📖 Quản lý sách";
            btnQLMuonTra.Text = " 📜 Quản lý mượn trả";
            btnMuonTra.Text = " 📚 Mượn trả sách";
            btnTrangChu.Text = " 🏠 Trang chủ";
            btnThongTinCaNhan.Text = " 👤 Thông tin cá nhân";
            btnThoat.Text = " 🚪 Thoát";
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            Button btnItem = sender as Button;
            if (btnItem != null)
            {
                // Lấy tên chức năng chính xác bằng cách loại bỏ icon và khoảng trắng
                string controlName = btnItem.Text.Trim();
                // Loại bỏ icon (các ký tự không phải chữ cái, số, hoặc khoảng trắng)
                controlName = System.Text.RegularExpressions.Regex.Replace(controlName, @"\s*[\p{Cs}\p{So}][\p{Cs}\p{So}]?\s*", "").Trim();

                ShowContentControl(controlName);
                HighlightButton(btnItem);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống không?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void HighlightButton(Button currentButton)
        {
            Color defaultBackColor = Color.FromArgb(44, 62, 80);
            Color highlightColor = Color.FromArgb(52, 152, 219);

            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = defaultBackColor;
                }
            }

            currentButton.BackColor = highlightColor;
        }

        // ********************************************************
        // HÀM TẠO VÀ HIỂN THỊ NỘI DUNG (CẬP NHẬT)
        // ********************************************************
        private void ShowContentControl(string controlName)
        {
            pnlContent.Controls.Clear();

            // Lấy thông tin người dùng từ StatusStrip để truyền vào các Form con
            string statusText = tsslUsername.Text;
            string username = statusText.Contains("Đang đăng nhập:") ? statusText.Split('|')[0].Replace("Đang đăng nhập:", "").Trim() : "N/A";
            string role = statusText.Contains("Quyền:") ? statusText.Split('|')[1].Replace("Quyền:", "").Trim() : "N/A";

            // KHỞI TẠO BIẾN CỤC BỘ VỚI GIÁ TRỊ MẶC ĐỊNH
            Control newContent = new Label { Text = $"Chức năng '{controlName}' không xác định hoặc không khả dụng.", AutoSize = true, Location = new Point(20, 20) };
            Type formType = null;

            try
            {
                switch (controlName)
                {
                    case "Trang chủ":
                        formType = typeof(TrangChu);
                        break;
                    case "Quản lý sách":
                        formType = typeof(FormQLSach);
                        break;
                    case "Quản lý mượn trả":
                        formType = typeof(FormQLMuonTra);
                        break;
                    case "Mượn trả sách":
                        formType = typeof(MuonTra);
                        break;
                    case "Quản lý tài khoản":
                        formType = typeof(FormQLTaiKhoan);
                        break;
                    case "Thông tin cá nhân":
                        newContent = new UserInfoForm(username, role);
                        break;
                }

                if (formType != null)
                {
                    // Tạo Form từ Type nếu nó là Form
                    newContent = (Form)Activator.CreateInstance(formType);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi trong quá trình Activator.CreateInstance (ví dụ: Form không tồn tại)
                newContent = new Label { Text = $"Lỗi tải Form {controlName}: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
            }


            if (newContent is Form form)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
            }

            newContent.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newContent);
        }

        private void InitializeChatbotUI()
        {
            chatbotService = new Chatbot();

            btnToggleChat = new Button
            {
                Text = "Trợ lý ảo",
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            btnToggleChat.FlatAppearance.BorderSize = 0;
            btnToggleChat.Location = new Point(ClientSize.Width - btnToggleChat.Width - 30, ClientSize.Height - btnToggleChat.Height - 30);
            btnToggleChat.Click += BtnToggleChat_Click;

            pnlChatContainer = new Panel
            {
                Size = new Size(360, 420),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Visible = false
            };
            pnlChatContainer.Location = new Point(ClientSize.Width - pnlChatContainer.Width - 30, ClientSize.Height - pnlChatContainer.Height - 80);

            Label lblChatHeader = new Label
            {
                Text = "Trợ lý thư viện",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            flpChatHistory = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke
            };
            flpChatHistory.SizeChanged += (s, e) => AdjustBubbleWidths();

            Panel pnlChatInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 90,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            txtChatInput = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F),
                ScrollBars = ScrollBars.Vertical
            };
            txtChatInput.KeyDown += TxtChatInput_KeyDown;

            btnSendChat = new Button
            {
                Text = "Gửi",
                Width = 70,
                Dock = DockStyle.Right,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSendChat.FlatAppearance.BorderSize = 0;
            btnSendChat.Click += async (s, e) => await SendMessageAsync();

            pnlChatInput.Controls.Add(txtChatInput);
            pnlChatInput.Controls.Add(btnSendChat);

            pnlChatContainer.Controls.Add(flpChatHistory);
            pnlChatContainer.Controls.Add(pnlChatInput);
            pnlChatContainer.Controls.Add(lblChatHeader);

            Controls.Add(pnlChatContainer);
            Controls.Add(btnToggleChat);

            pnlChatContainer.BringToFront();
            btnToggleChat.BringToFront();
        }

        private void BtnToggleChat_Click(object sender, EventArgs e)
        {
            isChatOpen = !isChatOpen;
            pnlChatContainer.Visible = isChatOpen;
            btnToggleChat.Text = isChatOpen ? "Đóng chat" : "Trợ lý ảo";
            if (isChatOpen)
            {
                pnlChatContainer.BringToFront();
                btnToggleChat.BringToFront();
                txtChatInput?.Focus();
            }
        }

        private async void TxtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            if (txtChatInput == null || chatbotService == null)
            {
                return;
            }

            string userMessage = txtChatInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            txtChatInput.Clear();
            AppendChatBubble(userMessage, BubbleType.Outgoing);

            btnSendChat.Enabled = false;
            var typingIndicator = CreateTypingIndicator();
            flpChatHistory.Controls.Add(typingIndicator);
            ScrollChatToBottom();

            try
            {
                string botReply = await chatbotService.GetResponse(userMessage);
                flpChatHistory.Controls.Remove(typingIndicator);

                if (string.IsNullOrWhiteSpace(botReply))
                {
                    botReply = "Xin lỗi, tôi chưa có dữ liệu để trả lời câu hỏi này.";
                }

                AppendChatBubble(botReply, BubbleType.Incoming);
            }
            catch (Exception ex)
            {
                flpChatHistory.Controls.Remove(typingIndicator);
                AppendChatBubble("Không thể kết nối tới chatbot: " + ex.Message, BubbleType.Incoming);
            }
            finally
            {
                btnSendChat.Enabled = true;
                txtChatInput.Focus();
            }
        }

        private Control CreateTypingIndicator()
        {
            return new Label
            {
                Text = "Trợ lý đang phản hồi...",
                AutoSize = true,
                ForeColor = Color.DimGray,
                MaximumSize = new Size(flpChatHistory.ClientSize.Width - 20, 0),
                Margin = new Padding(0, 0, 0, 10)
            };
        }

        private void AppendChatBubble(string message, BubbleType type)
        {
            if (flpChatHistory == null)
            {
                return;
            }

            var bubble = new ChatBubble(message, type)
            {
                Width = flpChatHistory.ClientSize.Width - 20,
                Margin = new Padding(0, 0, 0, 10)
            };
            flpChatHistory.Controls.Add(bubble);
            AdjustBubbleWidths();
            ScrollChatToBottom();
        }

        private void AdjustBubbleWidths()
        {
            if (flpChatHistory == null)
            {
                return;
            }

            int targetWidth = flpChatHistory.ClientSize.Width - 20;
            foreach (Control ctrl in flpChatHistory.Controls)
            {
                ctrl.Width = targetWidth;
            }
        }

        private void ScrollChatToBottom()
        {
            if (flpChatHistory == null || flpChatHistory.Controls.Count == 0)
            {
                return;
            }

            var lastControl = flpChatHistory.Controls[flpChatHistory.Controls.Count - 1];
            flpChatHistory.ScrollControlIntoView(lastControl);
        }
    }
}