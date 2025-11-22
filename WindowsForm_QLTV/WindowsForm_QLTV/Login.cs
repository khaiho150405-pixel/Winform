using System;
using System.Data.Entity;  // Dùng cho Entity Framework
using System.Drawing;
using System.Linq;         // Dùng cho LINQ
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class Login : Form
    {
        // Constructor mặc định
        public Login()
        {
            InitializeComponent();

            // Gán sự kiện cho nút Đăng Ký
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
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
                // Đăng nhập thành công, mở MainForm
                MessageBox.Show($"Đăng nhập thành công! Quyền: {userRole}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở MainForm
                MainForm mainForm = new MainForm(username, userRole);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
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
        /// Xác thực người dùng và lấy Vai trò (TENQUYEN) từ CSDL bằng Entity Framework.
        /// </summary>
        private string ValidateUserAndGetRole(string username, string password)
        {
            string role = null;

            try
            {
                using (var db = new Model1()) // SỬ DỤNG ENTITY FRAMEWORK CONTEXT
                {
                    // Sử dụng LINQ để truy vấn (tương đương JOIN trong SQL)
                    var account = db.TAIKHOANs
                                    .AsNoTracking() // Tăng hiệu suất
                                                    // Include PHANQUYEN để truy cập TENQUYEN
                                    .Include(tk => tk.PHANQUYEN)
                                    .SingleOrDefault(tk =>
                                        tk.TENDANGNHAP == username &&
                                        tk.MATKHAU == password &&
                                        tk.TRANGTHAI == "Hoạt động");

                    if (account != null)
                    {
                        // Lấy TENQUYEN từ Navigation Property
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