using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq; // Thêm thư viện Linq
using System.Data.Entity; // Thêm thư viện Entity để dùng Include()

namespace WindowsForm_QLTV
{
    public partial class FormQLMuonTra : Form
    {
        private Model1 db = new Model1(); // Khởi tạo Entity Framework Context

        public FormQLMuonTra()
        {
            InitializeComponent();
            this.Load += FormQLMuonTra_Load;

            // Gán sự kiện cho các nút chức năng
            btnMuonSach.Click += BtnMuonTra_Click;
            btnTraSach.Click += BtnMuonTra_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void FormQLMuonTra_Load(object sender, EventArgs e)
        {
            // Thiết lập Placeholder cho ô tìm kiếm
            txtSearch.Text = "Nhập tên người mượn..."; // Đã sửa
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Mặc định load danh sách phiếu mượn đang hoạt động
            LoadActiveLoanSlips();
        }

        // Xử lý sự kiện Placeholder
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên người mượn...") // Đã sửa
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Nhập tên người mượn..."; // Đã sửa
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void BtnMuonTra_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string action = clickedButton.Text.Trim();
                Type targetFormType = null;

                // Xác định Form cần load
                if (action == "MƯỢN SÁCH")
                {
                    // Giả định FormMuonSach đã được định nghĩa
                    targetFormType = typeof(FormMuonSach);
                }
                else if (action == "TRẢ SÁCH")
                {
                    // Giả định FormTraSach đã được định nghĩa
                    targetFormType = typeof(FormTraSach);
                }

                if (targetFormType != null)
                {
                    try
                    {
                        // 1. Khởi tạo Form mới
                        Form newForm = (Form)Activator.CreateInstance(targetFormType);

                        // 2. Xóa tất cả controls hiện tại (Dashboard, Search, Content)
                        this.pnlBackground.Controls.Clear();

                        // 3. Thiết lập Form con mới
                        newForm.TopLevel = false;
                        newForm.FormBorderStyle = FormBorderStyle.None;
                        newForm.Dock = DockStyle.Fill;

                        // 4. Thêm và hiển thị Form mới, nó sẽ chiếm toàn bộ FormQLMuonTra
                        this.pnlBackground.Controls.Add(newForm);
                        newForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải Form {targetFormType.Name}: {ex.Message}\nĐảm bảo Form đã được biên dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            string defaultPlaceholder = "Nhập tên người mượn...";

            if (keyword == defaultPlaceholder || string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập Tên Người Mượn để tìm kiếm hoặc nhấn OK để xem tất cả phiếu đang hoạt động.", "Thông báo");
                LoadActiveLoanSlips(); // Load lại toàn bộ danh sách đang hoạt động
                return;
            }

            // Gọi hàm tải dữ liệu với từ khóa tìm kiếm
            LoadActiveLoanSlips(keyword);
        }

        // Phương thức mới: Tải các phiếu mượn đang hoạt động
        private void LoadActiveLoanSlips(string keyword = null)
        {
            try
            {
                // Các trạng thái được coi là "đang hoạt động" 
                // (Chờ duyệt/Đang mượn/Quá hạn/Thiếu/Quá hạn và Thiếu)
                var activeStatuses = new[] { "Chờ duyệt", "Đang mượn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu" };

                // 1. Xây dựng truy vấn cơ sở: Lấy các phiếu mượn có trạng thái đang hoạt động
                var query = db.PHIEUMUONs
                    .Include(pm => pm.SINHVIEN) // Bắt buộc phải Include để truy cập SINHVIEN.HOVATEN
                    .Where(pm => activeStatuses.Contains(pm.TRANGTHAI));

                // 2. Lọc theo từ khóa (Tên người mượn)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    // Chuyển từ khóa về chữ thường (hoặc không dấu nếu database hỗ trợ) 
                    // để tìm kiếm không phân biệt chữ hoa/thường (LIKE N'%keyword%')
                    string searchKeyword = keyword.ToLower();

                    query = query.Where(pm => pm.SINHVIEN.HOVATEN.ToLower().Contains(searchKeyword));
                }

                // 3. Chọn các trường cần hiển thị và định dạng
                var loanList = query
                    .OrderBy(pm => pm.TRANGTHAI) // Sắp xếp theo trạng thái để ưu tiên Quá hạn
                    .Select(pm => new
                    {
                        Mã_Phiếu = pm.MAPM,
                        Tên_Sinh_Viên = pm.SINHVIEN.HOVATEN,
                        Ngày_Mượn = pm.NGAYLAPPHIEUMUON,
                        Hạn_Trả_Gốc = pm.HANTRA,
                        Trạng_Thái = pm.TRANGTHAI,
                        Số_lần_GH = pm.SOLANGIAHAN
                    })
                    .ToList();

                // 4. Gán dữ liệu vào DataGridView
                pnlMainContent.Controls.Clear(); // Xóa control cũ (Label Placeholder)
                pnlMainContent.Controls.Add(dgvActiveLoans); // Thêm DataGridView đã được định nghĩa trong Designer
                dgvActiveLoans.DataSource = loanList;
                dgvActiveLoans.Dock = DockStyle.Fill;
                dgvActiveLoans.BringToFront();

                if (!string.IsNullOrWhiteSpace(keyword) && loanList.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy phiếu mượn đang hoạt động nào cho tên '{keyword}'.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu mượn: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa hàm này để gọi LoadActiveLoanSlips() mặc định
        private void DisplayDefaultContent()
        {
            LoadActiveLoanSlips();
        }
    }
}