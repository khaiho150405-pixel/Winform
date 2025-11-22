using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;         // Dùng cho LINQ
using System.Data.Entity;  // Dùng cho Entity Framework

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
                string.IsNullOrWhiteSpace(txtSDT.Text))
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
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;

            // --- 5. Logic lưu dữ liệu vào CSDL (SỬ DỤNG ENTITY FRAMEWORK) ---
            try
            {
                using (var db = new Model1())
                {
                    // a) Kiểm tra tên đăng nhập đã tồn tại
                    if (db.TAIKHOANs.Any(tk => tk.TENDANGNHAP == tenDangNhap))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // b) Tìm MAQUYEN cho Độc Giả (Giả định vai trò mặc định là "Độc Giả")
                    var docGiaRole = db.PHANQUYENs.SingleOrDefault(pq => pq.TENQUYEN == "Độc Giả");
                    if (docGiaRole == null)
                    {
                        MessageBox.Show("Không tìm thấy quyền 'Độc Giả' trong hệ thống. Vui lòng liên hệ quản trị viên.", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int maQuyenDocGia = docGiaRole.MAQUYEN;

                    // c) Tạo TAIKHOAN
                    var newAccount = new TAIKHOAN
                    {
                        TENDANGNHAP = tenDangNhap,
                        MATKHAU = matKhau,
                        MAQUYEN = maQuyenDocGia,
                        TRANGTHAI = "Hoạt động"
                    };

                    db.TAIKHOANs.Add(newAccount);
                    db.SaveChanges(); // Lưu lần 1: Để có MATAIKHOAN tự sinh

                    // d) Tạo SINHVIEN (Độc Giả)
                    var newSinhVien = new SINHVIEN
                    {
                        MATAIKHOAN = newAccount.MATAIKHOAN, // Lấy ID tự sinh
                        HOVATEN = hoTen,
                        GIOITINH = gioiTinh,
                        NGAYSINH = ngaySinh,
                        SDT = sdt,
                        EMAIL = string.IsNullOrWhiteSpace(email) ? null : email, // Email có thể null
                    };

                    db.SINHVIENs.Add(newSinhVien);
                    db.SaveChanges(); // Lưu lần 2: Hoàn tất đăng ký

                    MessageBox.Show($"Đăng ký thành công!\nTài khoản {tenDangNhap} đã được tạo.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                // Xử lý lỗi validation của EF
                var errorMessages = dbEx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                string fullErrorMessage = string.Join("\n", errorMessages);
                MessageBox.Show("Lỗi kiểm tra dữ liệu (Validation): \n" + fullErrorMessage, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu vào CSDL: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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