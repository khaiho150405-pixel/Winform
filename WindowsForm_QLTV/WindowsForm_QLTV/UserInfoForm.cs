using System;
using System.Windows.Forms;
using System.Data.SqlClient; // Giả định bạn dùng SQL Server

namespace WindowsForm_QLTV
{
    public partial class UserInfoForm : Form
    {
        private string _username; // MATAIKHOAN hoặc Tên đăng nhập

        // Constructor mới nhận thông tin user
        public UserInfoForm(string username, string role)
        {
            InitializeComponent();
            _username = username;

            // Thiết lập sự kiện cho nút đăng xuất
            this.btnLogout.Click += BtnLogout_Click;

            // Load dữ liệu khi form khởi tạo
            LoadUserInfo(username);
        }

        private void LoadUserInfo(string username)
        {
            // Thay thế bằng logic kết nối CSDL thực tế của bạn
            try
            {
                // Giả định: Bạn có một hàm hoặc lớp truy cập dữ liệu để lấy thông tin chi tiết
                // UserDetail user = DatabaseService.GetUserDetailByUsername(username); 

                // MOCK DATA (Dữ liệu giả lập):
                int maSV = 1001;
                string hoVaTen = "Nguyễn Văn A";
                string gioiTinh = "Nam";
                DateTime ngaySinh = new DateTime(2000, 10, 25);
                string sdt = "0901 234 567";
                string email = "nguyen.van.a@example.com";

                // Hiển thị dữ liệu lên các Label
                lblMaSVValue.Text = maSV.ToString();
                lblHoVaTenValue.Text = hoVaTen;
                lblGioiTinhValue.Text = gioiTinh;
                lblNgaySinhValue.Text = ngaySinh.ToString("dd/MM/yyyy");
                lblSDTValue.Text = sdt;
                lblEmailValue.Text = email;

                // Load ảnh đại diện nếu có
                // pnlImage.BackgroundImage = Image.FromFile("duong_dan_anh.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Dùng thông tin đăng nhập tạm thời nếu lỗi
                lblMaSVValue.Text = "Không có hồ sơ";
                lblHoVaTenValue.Text = username;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 1. Ẩn MainForm
                this.ParentForm.Hide();

                // 2. Mở lại Form Đăng nhập (Giả định LoginScreen là Form đăng nhập của bạn)
                // Form loginForm = new LoginScreen(); 
                // loginForm.Show();

                // Do không có LoginScreen, ta sẽ đóng ứng dụng và thông báo đăng xuất thành công
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}