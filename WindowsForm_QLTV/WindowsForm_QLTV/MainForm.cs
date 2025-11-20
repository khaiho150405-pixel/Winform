using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class MainForm : Form
    {
        // Constructor mặc định
        public MainForm()
        {
            InitializeComponent();
        }

        // Constructor quan trọng để truyền dữ liệu người dùng
        public MainForm(string username, string role) : this()
        {
            // Cập nhật thông tin vào Header Sidebar
            lblUserNameHeader.Text = $"MÃ TK: {username}";
            lblUserRoleHeader.Text = $"Vai trò: {role}";
            tsslUsername.Text = $"Đang đăng nhập: {username} | Quyền: {role}";

            ApplyUserPermissions(role);
            AttachMenuEventHandlers();

            // Tải nội dung mặc định (Trang chủ)
            ShowContentControl("Trang chủ");
            HighlightButton(btnTrangChu);
        }

        private void ApplyUserPermissions(string role)
        {
            string normalizedRole = role.Trim().ToUpper();

            bool isAdminOrThuThu = normalizedRole == "ADMIN" || normalizedRole == "THỦ THƯ";

            btnTaiKhoan.Visible = isAdminOrThuThu;

            // Phân quyền cho hai nút Mượn Trả
            bool canMuonTra = isAdminOrThuThu || normalizedRole == "ĐỘC GIẢ";
            btnMuonTra.Visible = canMuonTra;   // Mượn trả sách (chức năng trực tiếp)
            btnQLMuonTra.Visible = isAdminOrThuThu; // Quản lý mượn trả (dashboard)
        }

        private void AttachMenuEventHandlers()
        {
            // Gán sự kiện Click cho các nút Sidebar
            btnTrangChu.Click += BtnItem_Click;
            btnSach.Click += BtnItem_Click;
            btnQLMuonTra.Click += BtnItem_Click; // QUẢN LÝ CHUNG (Dashboard)
            btnMuonTra.Click += BtnItem_Click;   // MƯỢN TRẢ SÁCH (Chức năng trực tiếp)
            btnTaiKhoan.Click += BtnItem_Click;
            btnThongTinCaNhan.Click += BtnItem_Click;

            // Nút Thoát
            btnThoat.Click += BtnThoat_Click;

            // Đặt lại Text cho các Button
            btnTaiKhoan.Text = " 🔑 Quản lý tài khoản";
            btnSach.Text = " 📖 Quản lý sách";
            btnQLMuonTra.Text = " 📜 Quản lý mượn trả"; // Tên hiển thị QL chung
            btnMuonTra.Text = " 📚 Mượn trả sách";   // Tên hiển thị chức năng phụ
            btnTrangChu.Text = " 🏠 Trang chủ";
            btnThongTinCaNhan.Text = " 👤 Thông tin cá nhân";
            btnThoat.Text = " 🚪 Thoát";
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            Button btnItem = sender as Button;
            if (btnItem != null)
            {
                // Lấy tên chức năng chính xác
                string controlName = btnItem.Text.Trim();
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
        // HÀM TẠO VÀ HIỂN THỊ NỘI DUNG
        // ********************************************************
        private void ShowContentControl(string controlName)
        {
            pnlContent.Controls.Clear();

            string statusText = tsslUsername.Text;
            string username = statusText.Contains("Đang đăng nhập:") ? statusText.Split('|')[0].Replace("Đang đăng nhập:", "").Trim() : "N/A";
            string role = statusText.Contains("Quyền:") ? statusText.Split('|')[1].Replace("Quyền:", "").Trim() : "N/A";

            Control newContent;

            switch (controlName)
            {
                case "Trang chủ":
                    newContent = CreateManagementControl("WELCOME TO HUFI", Color.WhiteSmoke, true);
                    break;
                case "Quản lý sách":
                    try
                    {
                        newContent = new FormQLSach();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý sách. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Quản lý mượn trả": // Case cho btnQLMuonTra (Dashboard)
                    try
                    {
                        newContent = new FormQLMuonTra();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý mượn trả. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Mượn trả sách": // Case cho btnMuonTra (Chức năng trực tiếp)
                    // Mở FormQLMuonTra Dashboard 
                    try
                    {
                        newContent = new MuonTra();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Mượn trả sách. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Quản lý tài khoản":
                    // Dùng FormQLTaiKhoan
                    try
                    {
                        newContent = new FormQLTaiKhoan();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý tài khoản. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Thông tin cá nhân":
                    // Dùng UserInfoForm cho thông tin cá nhân
                    try
                    {
                        newContent = new UserInfoForm(username, role);
                    }
                    catch
                    {
                        newContent = CreateManagementControl("THÔNG TIN CÁ NHÂN (PLACEHOLDER)", Color.LightPink);
                    }
                    break;
                default:
                    newContent = new Label { Text = "Chức năng không xác định.", AutoSize = true, Location = new Point(20, 20) };
                    break;
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

        // --- CÁC HÀM TẠO CONTROL MẪU ---
        private Control CreateBookListingControl()
        {
            // Hàm tạo DataGridView mẫu
            DataGridView dgvSach = new DataGridView();
            // ... (code)
            dgvSach.AllowUserToAddRows = false;
            dgvSach.ReadOnly = true;
            dgvSach.Font = new Font("Segoe UI", 10F);
            dgvSach.Dock = DockStyle.Fill;

            dgvSach.Columns.Add("MASACH", "Mã Sách");
            dgvSach.Columns.Add("TENSACH", "Tên Sách");
            dgvSach.Rows.Add(1, "Lập trình C#");

            Panel pnlMain = new Panel();
            pnlMain.Controls.Add(dgvSach);
            return pnlMain;
        }

        private Control CreateManagementControl(string title, Color backColor, bool isHomepage = false)
        {
            Panel pnl = new Panel();
            pnl.BackColor = backColor;
            pnl.Dock = DockStyle.Fill;

            if (isHomepage)
            {
                Label lbl = new Label();
                lbl.Text = title;
                lbl.Font = new Font("Segoe UI", 72F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(52, 152, 219);
                lbl.AutoSize = true;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;

                pnl.Controls.Add(lbl);
            }
            else
            {
                Label lbl = new Label();
                lbl.Text = title;
                lbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                lbl.ForeColor = Color.DarkBlue;
                lbl.AutoSize = true;
                lbl.Location = new Point(20, 20);
                pnl.Controls.Add(lbl);
            }

            return pnl;
        }
    }
}