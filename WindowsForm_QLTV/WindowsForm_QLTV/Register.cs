using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            // Cài đặt cho DatePicker
            dtpNgaySinh.Value = DateTime.Today.AddYears(-10); // Mặc định đủ 10 tuổi

            // Gán sự kiện cho các nút
            btnDangKy.Click += BtnDangKy_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            // --- 1. Kiểm tra trường bắt buộc ---
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMK.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text)) // Kiểm tra SDT
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc (*), bao gồm cả SĐT.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. Kiểm tra xác nhận mật khẩu ---
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus();
                return;
            }

            // --- 3. Kiểm tra ngày sinh (ví dụ: người dùng phải đủ 10 tuổi)
            if (dtpNgaySinh.Value > DateTime.Today.AddYears(-10))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Bạn phải đủ 10 tuổi để đăng ký.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 4. Thu thập dữ liệu ---
            string hoTen = txtHoTen.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string sdt = txtSDT.Text.Trim(); // Lấy SDT
            string email = txtEmail.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;

            // TODO: Thêm logic lưu dữ liệu vào CSDL tại đây

            MessageBox.Show($"Đăng ký thành công!\nTài khoản {tenDangNhap} của {hoTen} đã được tạo.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Đóng form sau khi đăng ký
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy bỏ đăng ký không?", "Xác nhận Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}