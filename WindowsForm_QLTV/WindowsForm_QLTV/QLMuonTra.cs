using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormQLMuonTra : Form
    {
        private Model1 db = new Model1();

        public FormQLMuonTra()
        {
            InitializeComponent();
            this.Load += FormQLMuonTra_Load;

            // Gán sự kiện cho các nút chức năng
            btnMuonSach.Click += BtnMuonTra_Click;
            btnTraSach.Click += BtnMuonTra_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            
            // Cho phép tìm kiếm bằng Enter
            txtSearch.KeyDown += TxtSearch_KeyDown;
            
            // Sự kiện lọc theo trạng thái
            cboTrangThai.SelectedIndexChanged += CboTrangThai_SelectedIndexChanged;
        }

        private void FormQLMuonTra_Load(object sender, EventArgs e)
        {
            // Thiết lập Placeholder cho ô tìm kiếm
            txtSearch.Text = "Nhập tên người mượn...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;

            // Thiết lập ComboBox lọc trạng thái
            SetupComboBoxTrangThai();

            // Mặc định load TẤT CẢ phiếu mượn
            LoadAllLoanSlips();
        }

        // Thiết lập danh sách trạng thái cho ComboBox
        private void SetupComboBoxTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả --");
            cboTrangThai.Items.Add("Chờ duyệt");
            cboTrangThai.Items.Add("Đang mượn");
            cboTrangThai.Items.Add("Chờ trả");
            cboTrangThai.Items.Add("Chờ trả quá hạn");
            cboTrangThai.Items.Add("Đã trả");
            cboTrangThai.Items.Add("Đã trả quá hạn");
            cboTrangThai.Items.Add("Quá hạn");
            cboTrangThai.Items.Add("Thiếu");
            cboTrangThai.Items.Add("Quá hạn và Thiếu");
            cboTrangThai.Items.Add("Từ chối");
            
            cboTrangThai.SelectedIndex = 0; // Mặc định chọn "Tất cả"
        }

        // Sự kiện khi thay đổi lựa chọn trong ComboBox
        private void CboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tự động tải lại dữ liệu khi thay đổi bộ lọc
            LoadAllLoanSlips();
        }

        // Xử lý sự kiện Placeholder
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên người mượn...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Nhập tên người mượn...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        // Cho phép tìm kiếm bằng phím Enter
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTimKiem_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn tiếng "beep"
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
                    targetFormType = typeof(FormMuonSach);
                }
                else if (action == "TRẢ SÁCH")
                {
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
            // Gọi hàm tải dữ liệu (sẽ tự động lọc theo cả tên và trạng thái)
            LoadAllLoanSlips();
        }

        // Phương thức chính: Tải phiếu mượn với bộ lọc
        private void LoadAllLoanSlips()
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    // 1. Truy vấn TẤT CẢ phiếu mượn
                    var query = dbContext.PHIEUMUONs
                        .Include(pm => pm.SINHVIEN)
                        .AsQueryable();

                    // 2. Lọc theo TRẠNG THÁI (từ ComboBox)
                    string selectedStatus = cboTrangThai.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "-- Tất cả --")
                    {
                        query = query.Where(pm => pm.TRANGTHAI == selectedStatus);
                    }

                    // 3. Lọc theo TÊN NGƯỜI MƯỢN (từ TextBox)
                    string keyword = txtSearch.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Nhập tên người mượn...")
                    {
                        string searchKeyword = keyword.ToLower().Trim();
                        query = query.Where(pm => pm.SINHVIEN.HOVATEN.ToLower().Contains(searchKeyword));
                    }

                    // 4. Chọn các trường cần hiển thị và định dạng
                    var loanList = query
                        .OrderByDescending(pm => pm.NGAYLAPPHIEUMUON)
                        .ThenBy(pm => pm.TRANGTHAI)
                        .Select(pm => new
                        {
                            Mã_Phiếu = pm.MAPM,
                            Tên_Sinh_Viên = pm.SINHVIEN.HOVATEN,
                            Ngày_Mượn = pm.NGAYLAPPHIEUMUON,
                            Hạn_Trả = pm.HANTRA,
                            Trạng_Thái = pm.TRANGTHAI,
                            Số_lần_GH = pm.SOLANGIAHAN
                        })
                        .ToList();

                    // 5. Gán dữ liệu vào DataGridView
                    pnlMainContent.Controls.Clear();
                    pnlMainContent.Controls.Add(dgvActiveLoans);
                    dgvActiveLoans.DataSource = loanList;
                    dgvActiveLoans.Dock = DockStyle.Fill;
                    dgvActiveLoans.BringToFront();

                    // 6. Tô màu theo trạng thái
                    HighlightRowsByStatus();

                    // 7. Cập nhật tiêu đề hiển thị kết quả
                    UpdateResultTitle(loanList.Count, selectedStatus, keyword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu mượn: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật tiêu đề hiển thị số lượng kết quả
        private void UpdateResultTitle(int count, string status, string keyword)
        {
            string title = $"Quản Lý Mượn Trả - {count} phiếu";

            if (!string.IsNullOrEmpty(status) && status != "-- Tất cả --")
            {
                title += $" [{status}]";
            }

            if (!string.IsNullOrWhiteSpace(keyword) && keyword != "Nhập tên người mượn...")
            {
                title += $" - Tìm: '{keyword}'";
            }

            this.Text = title;
        }

        // Tô màu các dòng theo trạng thái
        private void HighlightRowsByStatus()
        {
            foreach (DataGridViewRow row in dgvActiveLoans.Rows)
            {
                if (row.Cells["Trạng_Thái"].Value != null)
                {
                    string trangThai = row.Cells["Trạng_Thái"].Value.ToString();

                    if (trangThai.Contains("Quá hạn") && !trangThai.Contains("Đã trả"))
                    {
                        // Màu đỏ nhạt cho quá hạn (chưa trả)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (trangThai == "Đã trả quá hạn")
                    {
                        // Màu cam nhạt cho đã trả quá hạn
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 180);
                        row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                    }
                    else if (trangThai == "Chờ duyệt")
                    {
                        // Màu vàng nhạt cho chờ duyệt
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                    else if (trangThai == "Đang mượn")
                    {
                        // Màu xanh dương nhạt cho đang mượn
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 220, 255);
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                    else if (trangThai == "Đã trả")
                    {
                        // Màu xanh lá nhạt cho đã trả
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (trangThai == "Từ chối")
                    {
                        // Màu xám cho từ chối
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else if (trangThai.Contains("Chờ trả"))
                    {
                        // Màu cam nhạt cho chờ trả
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200);
                        row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                    }
                    else if (trangThai == "Thiếu")
                    {
                        // Màu tím nhạt cho thiếu
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 200, 255);
                        row.DefaultCellStyle.ForeColor = Color.Purple;
                    }
                }
            }
        }

        // Sửa hàm này để gọi LoadAllLoanSlips() mặc định
        private void DisplayDefaultContent()
        {
            LoadAllLoanSlips();
        }
    }
}