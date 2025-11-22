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
            btnMuonTra.Click += BtnItem_Click;    // MƯỢN TRẢ SÁCH (Chức năng trực tiếp)
            btnTaiKhoan.Click += BtnItem_Click;
            btnThongTinCaNhan.Click += BtnItem_Click;

            // Nút Thoát
            btnThoat.Click += BtnThoat_Click;

            // Đặt lại Text cho các Button
            btnTaiKhoan.Text = " 🔑 Quản lý tài khoản";
            btnSach.Text = " 📖 Quản lý sách";
            btnQLMuonTra.Text = " 📜 Quản lý mượn trả"; // Tên hiển thị QL chung
            btnMuonTra.Text = " 📚 Mượn trả sách";    // Tên hiển thị chức năng phụ
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

            string statusText = tsslUsername.Text;
            string username = statusText.Contains("Đang đăng nhập:") ? statusText.Split('|')[0].Replace("Đang đăng nhập:", "").Trim() : "N/A";
            string role = statusText.Contains("Quyền:") ? statusText.Split('|')[1].Replace("Quyền:", "").Trim() : "N/A";

            Control newContent;

            switch (controlName)
            {
                case "Trang chủ":
                    // GỌI FORM TRANG CHỦ MỚI
                    try
                    {
                        newContent = new TrangChu();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Trang Chủ. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Quản lý sách":
                    try
                    {
                        // Giả định FormQLSach đã tồn tại
                        newContent = new FormQLSach();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý sách. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Quản lý mượn trả":
                    try
                    {
                        // Giả định FormQLMuonTra đã tồn tại
                        newContent = new FormQLMuonTra();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý mượn trả. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Mượn trả sách":
                    try
                    {
                        // Giả định MuonTra đã tồn tại
                        newContent = new MuonTra();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Mượn trả sách. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Quản lý tài khoản":
                    try
                    {
                        // Giả định FormQLTaiKhoan đã tồn tại
                        newContent = new FormQLTaiKhoan();
                    }
                    catch (Exception ex)
                    {
                        newContent = new Label { Text = $"Lỗi: Không thể tải Form Quản lý tài khoản. Chi tiết: {ex.Message}", AutoSize = true, ForeColor = Color.Red, Location = new Point(20, 20) };
                    }
                    break;
                case "Thông tin cá nhân":
                    try
                    {
                        // Giả định UserInfoForm đã tồn tại
                        newContent = new UserInfoForm(username, role);
                    }
                    catch
                    {
                        newContent = new Label { Text = "Lỗi: Không thể tải Form Thông tin cá nhân.", AutoSize = true, Location = new Point(20, 20) };
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

        // --- CÁC HÀM TẠO CONTROL MẪU ĐÃ BỊ XÓA ---
    }
}