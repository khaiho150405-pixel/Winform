using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// ĐÃ BỎ: using System.Security.Cryptography; 
// ĐÃ BỎ: using System.Text; 
using System.Collections.Generic; // Cần thiết nếu dùng List/IEnumerable

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
                // Đăng nhập thành công
                MessageBox.Show($"Đăng nhập thành công! Quyền: {userRole}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **SỬA LỖI LUỒNG:** Mở MainForm, Ẩn Login Form và đóng nó
                MainForm mainForm = new MainForm(username, userRole);
                this.Hide();
                mainForm.Show();
                // Không gọi Close() ở đây, để hệ thống tự đóng khi MainForm đóng hoặc gọi Application.Exit()
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
                // Giả định có Form Register
                Register registerForm = new Register();
                registerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở Form Đăng Ký. Lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xác thực người dùng và lấy Vai trò (TENQUYEN) từ CSDL bằng Entity Framework (SỬ DỤNG MẬT KHẨU PLAIN TEXT).
        /// </summary>
        private string ValidateUserAndGetRole(string username, string password)
        {
            string role = null;

            try
            {
                using (var db = new Model1()) // SỬ DỤNG ENTITY FRAMEWORK CONTEXT
                {
                    var account = db.TAIKHOANs
                                     .AsNoTracking()
                                     .Include(tk => tk.PHANQUYEN)
                                     .SingleOrDefault(tk =>
                                         tk.TENDANGNHAP == username &&
                                         tk.MATKHAU == password && // SO SÁNH VỚI MẬT KHẨU PLAIN TEXT
                                         tk.TRANGTHAI == "Hoạt động");

                    if (account != null)
                    {
                        role = account.PHANQUYEN.TENQUYEN;
                    }
                }
            }
            catch (Exception ex)
            {
                // Báo lỗi kết nối CSDL chung (bao gồm lỗi EF)
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
            // Giữ lại xác nhận thoát khi người dùng đóng Form bằng nút X
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác Nhận Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}