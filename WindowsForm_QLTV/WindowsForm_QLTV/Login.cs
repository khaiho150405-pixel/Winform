using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; // Cần thiết cho ADO.NET

namespace WindowsForm_QLTV
{
    public partial class Login : Form
    {
        // 🚨 CHUỖI KẾT NỐI: Cần thay đổi 'YourServerName' thành tên server của bạn
        private const string ConnectionString = "Data Source=DESKTOP-D213BRB; Initial Catalog=ThuVienDB; Integrated Security=True;";

        // Constructor mặc định
        public Login()
        {
            InitializeComponent();

            // Gán sự kiện cho nút Đăng Ký
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTentaikhoan.Text;
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
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ******************************************************
        // 🆕 HÀM XỬ LÝ SỰ KIỆN NÚT ĐĂNG KÝ
        // ******************************************************
        private void btnDangky_Click(object sender, EventArgs e)
        {
            try
            {
                Register registerForm = new Register();
                // Hiển thị form đăng ký dưới dạng Dialog (blocking)
                registerForm.ShowDialog();

                // Khi FormDangKy đóng, Login Form vẫn hiển thị
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở Form Đăng Ký. Lỗi: {ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Xác thực người dùng và lấy Vai trò (TENQUYEN) từ CSDL.
        /// </summary>
        private string ValidateUserAndGetRole(string username, string password)
        {
            string role = null;

            // Truy vấn lấy TENQUYEN từ bảng PHANQUYEN qua bảng TAIKHOAN
            string query = @"
                SELECT pq.TENQUYEN 
                FROM TAIKHOAN tk
                JOIN PHANQUYEN pq ON tk.MAQUYEN = pq.MAQUYEN
                WHERE tk.TENDANGNHAP = @Username 
                  AND tk.MATKHAU = @Password 
                  AND tk.TRANGTHAI = N'Hoạt động'";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // SỬ DỤNG THAM SỐ (@) ĐỂ TRÁNH SQL INJECTION
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            role = result.ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("LỖI CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi Chung", MessageBoxButtons.OK, MessageBoxIcon.Error);
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