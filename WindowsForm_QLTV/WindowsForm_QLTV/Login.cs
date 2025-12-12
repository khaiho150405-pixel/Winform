using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class Login : Form
    {
        // Constructor mặc định
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTentaikhoan.Text.Trim();
            string password = txtMatkhau.Text;

            // 1. Kiểm tra trống
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên tài khoản và Mật khẩu.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi hàm xác thực và lấy quyền hạn
            string userRole = ValidateUserAndGetRole(username, password);

            if (userRole != null)
            {
                // --- BƯỚC QUAN TRỌNG: LƯU THÔNG TIN VÀO SESSION ---
                Session.CurrentUsername = username;
                Session.CurrentRole = userRole;
                Session.CurrentMaSV = 0;

                // Nếu là Độc giả/Sinh viên, cần lấy MASV ngay lập tức
                if (userRole.Equals("Độc giả", StringComparison.OrdinalIgnoreCase) ||
                    userRole.Equals("Sinh viên", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        using (var db = new Model1())
                        {
                            // Tìm sinh viên dựa trên tên đăng nhập
                            var sv = db.SINHVIENs
                                       .AsNoTracking()
                                       .FirstOrDefault(s => s.TAIKHOAN.TENDANGNHAP == username);

                            if (sv != null)
                            {
                                Session.CurrentMaSV = sv.MASV;
                            }
                            else
                            {
                                // Trường hợp có tài khoản nhưng chưa liên kết hồ sơ sinh viên
                                MessageBox.Show("Cảnh báo: Tài khoản này chưa được liên kết với hồ sơ Sinh viên.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
                    }
                }

                // Đăng nhập thành công
                MessageBox.Show($"Đăng nhập thành công! Quyền: {userRole}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở MainForm
                MainForm mainForm = new MainForm(username, userRole);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
                txtTentaikhoan.Clear();
                txtMatkhau.Clear();
                txtTentaikhoan.Focus();
                // Không gọi Close() ở đây
            }
            else
            {
                MessageBox.Show("Tên tài khoản, mật khẩu không đúng hoặc tài khoản đang bị khóa.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ******************************************************
        // HÀM XỬ LÝ SỰ KIỆN NÚT ĐĂNG KÝ
        // ******************************************************
        private void btnDangky_Click(object sender, EventArgs e)
        {
            try
            {
                Register registerForm = new Register();
                registerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở Form Đăng Ký. Lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xác thực người dùng và lấy Vai trò (TENQUYEN) từ CSDL
        /// </summary>
        private string ValidateUserAndGetRole(string username, string password)
        {
            string role = null;

            try
            {
                using (var db = new Model1())
                {
                    var account = db.TAIKHOANs
                                     .AsNoTracking()
                                     .Include(tk => tk.PHANQUYEN)
                                     .SingleOrDefault(tk =>
                                         tk.TENDANGNHAP == username &&
                                         tk.MATKHAU == password &&
                                         tk.TRANGTHAI == "Hoạt động");

                    if (account != null)
                    {
                        role = account.PHANQUYEN.TENQUYEN;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI KẾT NỐI CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return role;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ hỏi thoát nếu người dùng bấm X (UserClosing), không hỏi khi gọi lệnh Hide()
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                    "Xác Nhận Thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}