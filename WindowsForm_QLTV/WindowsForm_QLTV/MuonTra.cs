using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class MuonTra : Form
    {
        // Sử dụng biến Session toàn cục để lấy Mã SV hiện tại
        private int _currentMaSV;

        public MuonTra()
        {
            InitializeComponent();

            // Lấy giá trị từ Session ngay khi khởi tạo
            _currentMaSV = Session.CurrentMaSV;

            this.Load += MuonTra_Load;

            // Gắn sự kiện cho các nút hành động
            btnGuiYeuCauMuon.Click += BtnGuiYeuCauMuon_Click;
            btnGuiYeuCauTra.Click += BtnGuiYeuCauTra_Click;

            SetupDataGridView();
        }

        private void MuonTra_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có thông tin sinh viên trong Session chưa
            // (Lưu ý: Session.CurrentMaSV phải được gán giá trị từ Form Login)
            if (_currentMaSV <= 0)
            {
                MessageBox.Show("Không tìm thấy thông tin Độc Giả. Vui lòng Đăng Xuất và Đăng Nhập lại bằng tài khoản Sinh Viên.",
                                "Lỗi Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không xác định được người dùng
                return;
            }

            // Hiển thị thông tin người dùng trên tiêu đề (Optional)
            this.Text = $"Mượn Trả Sách - Độc giả: {Session.CurrentUsername} (MSV: {_currentMaSV})";

            LoadLoanHistoryForUser();
        }

        private void SetupDataGridView()
        {
            dgvLoanHistory.AutoGenerateColumns = false;
            dgvLoanHistory.Columns.Clear();

            // Cấu trúc DataGridView cho LỊCH SỬ MƯỢN
            dgvLoanHistory.Columns.Add(CreateTextColumn("MaPhieuMuon", "Mã PM", 80));
            dgvLoanHistory.Columns.Add(CreateTextColumn("TenSach", "Tên Sách", 250));
            dgvLoanHistory.Columns.Add(CreateTextColumn("SoLuong", "SL", 50));
            dgvLoanHistory.Columns.Add(CreateTextColumn("NgayMuon", "Ngày Mượn", 100));
            dgvLoanHistory.Columns.Add(CreateTextColumn("HanTra", "Hẹn Trả", 100));
            dgvLoanHistory.Columns.Add(CreateTextColumn("TrangThai", "Trạng Thái", 120));
            dgvLoanHistory.Columns.Add(CreateTextColumn("NgayTraThucTe", "Ngày Trả", 100));

            // Cải tiến UI: Styling
            dgvLoanHistory.AllowUserToAddRows = false;
            dgvLoanHistory.ReadOnly = true;
            dgvLoanHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoanHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoanHistory.AllowUserToResizeRows = false;
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width,
                MinimumWidth = width
            };
        }

        // LOGIC TẢI LỊCH SỬ CHO ĐỘC GIẢ
        private void LoadLoanHistoryForUser()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Truy vấn tất cả các sách đã từng mượn (đang mượn, đã trả, quá hạn)
                    var historyQuery = from pm in db.PHIEUMUONs
                                       join ctpm in db.CHITIETPHIEUMUONs on pm.MAPM equals ctpm.MAPM
                                       join sach in db.SACHes on ctpm.MASACH equals sach.MASACH
                                       // Lấy ngày trả thực tế từ CHITIETPHIEUTRA (Left Join)
                                       from pt in db.PHIEUTRAs.Where(p => p.MAPM == pm.MAPM).DefaultIfEmpty()
                                       from ctpt in db.CHITIETPHIEUTRAs.Where(c => c.MAPT == pt.MAPT && c.MASACH == ctpm.MASACH).DefaultIfEmpty()
                                       where pm.MASV == _currentMaSV
                                       select new LoanHistoryItem
                                       {
                                           MaPhieuMuon = pm.MAPM,
                                           TenSach = sach.TENSACH,
                                           SoLuong = (int)ctpm.SOLUONG,
                                           NgayMuon = pm.NGAYLAPPHIEUMUON,
                                           HanTra = pm.HANTRA,
                                           TrangThai = pm.TRANGTHAI,
                                           NgayTraThucTe = (DateTime?)ctpt.NGAYTRA
                                       };

                    var resultList = historyQuery.OrderByDescending(item => item.NgayMuon).ToList();

                    dgvLoanHistory.DataSource = resultList;
                    HighlightOverdueBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI TẢI LỊCH SỬ MƯỢN/TRẢ: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvLoanHistory.DataSource = null;
            }
        }

        // Cải tiến UI: Đánh dấu dòng quá hạn (áp dụng cho cột Trạng Thái)
        private void HighlightOverdueBooks()
        {
            foreach (DataGridViewRow row in dgvLoanHistory.Rows)
            {
                if (row.Cells["TrangThai"].Value != null && row.Cells["TrangThai"].Value.ToString().Contains("Quá hạn"))
                {
                    // Tô màu cảnh báo (Đỏ nhạt)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // --- Event Handlers Gửi Yêu Cầu ---

        private void BtnGuiYeuCauMuon_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form gửi yêu cầu mượn với Mã SV hiện tại
                FormGuiYeuCauMuon formMuon = new FormGuiYeuCauMuon(_currentMaSV);
                formMuon.ShowDialog();
                LoadLoanHistoryForUser(); // Tải lại lịch sử sau khi đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Form Yêu Cầu Mượn: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private void BtnGuiYeuCauTra_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form gửi yêu cầu trả với Mã SV hiện tại
                FormGuiYeuCauTra formTra = new FormGuiYeuCauTra(_currentMaSV);
                formTra.ShowDialog();
                LoadLoanHistoryForUser(); // Tải lại lịch sử sau khi đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Form Yêu Cầu Trả: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        // --- ViewModel cho Lịch sử Mượn/Trả ---
        public class LoanHistoryItem
        {
            public int MaPhieuMuon { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime HanTra { get; set; }
            public string TrangThai { get; set; }
            public DateTime? NgayTraThucTe { get; set; }
        }
    }

    // =============================================================
    // CLASS SESSION TOÀN CỤC (Global)
    // Nằm ngoài class MuonTra để Login.cs và các form khác đều gọi được
    // =============================================================
    public static class Session
    {
        public static int CurrentMaSV { get; set; } = 0; // Mặc định là 0 (Chưa đăng nhập)
        public static string CurrentUsername { get; set; } = "";
        public static string CurrentRole { get; set; } = "";
    }
}