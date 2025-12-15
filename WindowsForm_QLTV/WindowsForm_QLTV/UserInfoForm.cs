using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace WindowsForm_QLTV
{
    public partial class UserInfoForm : Form
    {
        private Model1 dbContext = new Model1();

        private int _maTaiKhoan = -1;
        private int _maQuyen = -1;
        private string _tenDangNhap = string.Empty;

        private bool isEditMode = false;

        // Constructor mặc định (dùng cho Designer/Testing)
        public UserInfoForm()
        {
            // Giả định giá trị test cho Designer
            _maTaiKhoan = 4;
            _maQuyen = 4;
            _tenDangNhap = "sv01";

            InitializeComponent();
            this.Load += UserInfoForm_Load;

            this.btnEditSave.Click += BtnEditSave_Click;
            this.btnLogout.Click += BtnLogout_Click;
            this.btnDoiMatKhau.Click += BtnDoiMatKhau_Click;
        }

        // CONSTRUCTOR MỚI: Nhận username và role (string) từ MainForm
        public UserInfoForm(string username, string role)
        {
            InitializeComponent();

            // 1. Gán các giá trị string
            this.lblTenDangNhapValue.Text = username;
            this.lblRoleValue.Text = role;
            this._tenDangNhap = username;

            // 2. Tra cứu ID từ CSDL (Hàm hỗ trợ mới)
            ResolveUserIDs(username);

            this.Load += UserInfoForm_Load;

            this.btnEditSave.Click += BtnEditSave_Click;
            this.btnLogout.Click += BtnLogout_Click;
            this.btnDoiMatKhau.Click += BtnDoiMatKhau_Click;
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            if (_maTaiKhoan == -1)
            {
                MessageBox.Show("Không thể tải thông tin người dùng do thiếu ID.", "Lỗi Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tải thông tin ngay khi form load
            LoadUserInfo();
            SetEditableState(false);
        }

        // ===============================================
        // LOGIC TRA CỨU ID (FIX XUNG ĐỘT)
        // ===============================================
        private void ResolveUserIDs(string username)
        {
            try
            {
                var taiKhoan = dbContext.TAIKHOANs.Include(tk => tk.PHANQUYEN).AsNoTracking().FirstOrDefault(tk => tk.TENDANGNHAP == username);

                if (taiKhoan != null)
                {
                    _maTaiKhoan = taiKhoan.MATAIKHOAN;
                    _maQuyen = taiKhoan.MAQUYEN;
                    // Cập nhật lại nhãn với giá trị đã tra cứu
                    lblTenDangNhapValue.Text = taiKhoan.TENDANGNHAP;
                    lblRoleValue.Text = taiKhoan.PHANQUYEN.TENQUYEN;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu ID người dùng: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================
        // LOGIC TẢI DỮ LIỆU
        // ===============================================
        private void LoadUserInfo()
        {
            try
            {
                // Lấy thông tin chi tiết dựa trên vai trò
                var userDetail = GetUserDetail(_maQuyen);

                lblMaUser.Text = GetUserRoleLabel(_maQuyen);

                if (userDetail != null)
                {
                    // Hiển thị dữ liệu lên các control
                    txtMaUserDetail.Text = userDetail.MaUser.ToString();
                    txtHoVaTen.Text = userDetail.HoVaTen;
                    cboGioiTinh.Text = userDetail.GioiTinh;
                    dtpNgaySinh.Value = userDetail.NgaySinh;
                    txtSDT.Text = userDetail.SDT;
                    txtEmail.Text = userDetail.Email;
                }
                else
                {
                    // Trường hợp Admin không có bảng chi tiết riêng
                    txtMaUserDetail.Text = _maTaiKhoan.ToString();
                    txtHoVaTen.Text = "N/A";
                    txtEmail.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin người dùng: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UserDetailModel GetUserDetail(int maQuyen)
        {
            switch (maQuyen)
            {
                case 2: // Thủ Thư
                    return dbContext.THUTHUs.AsNoTracking().Where(t => t.MATAIKHOAN == _maTaiKhoan).Select(t => new UserDetailModel { MaUser = t.MATT, HoVaTen = t.HOVATEN, GioiTinh = t.GIOITINH, NgaySinh = t.NGAYSINH, SDT = t.SDT, Email = t.EMAIL }).FirstOrDefault();
                case 3: // Thủ Kho
                    return dbContext.THUKHOes.AsNoTracking().Where(t => t.MATAIKHOAN == _maTaiKhoan).Select(t => new UserDetailModel { MaUser = t.MATK, HoVaTen = t.HOVATEN, GioiTinh = t.GIOITINH, NgaySinh = t.NGAYSINH, SDT = t.SDT, Email = t.EMAIL }).FirstOrDefault();
                case 4: // Sinh Viên / Độc Giả
                    return dbContext.SINHVIENs.AsNoTracking().Where(s => s.MATAIKHOAN == _maTaiKhoan).Select(s => new UserDetailModel { MaUser = s.MASV, HoVaTen = s.HOVATEN, GioiTinh = s.GIOITINH, NgaySinh = s.NGAYSINH, SDT = s.SDT, Email = s.EMAIL }).FirstOrDefault();
                default: // Admin/Khác
                    return null;
            }
        }

        private string GetUserRoleLabel(int maQuyen)
        {
            switch (maQuyen)
            {
                case 2: return "Mã Thủ Thư:";
                case 3: return "Mã Thủ Kho:";
                case 4: return "Mã Sinh Viên:";
                default: return "Mã Tài Khoản:";
            }
        }

        // ===============================================
        // LOGIC CHỈNH SỬA & LƯU
        // ===============================================

        private void SetEditableState(bool editable)
        {
            isEditMode = editable;
            txtHoVaTen.ReadOnly = !editable;
            cboGioiTinh.Enabled = editable;
            dtpNgaySinh.Enabled = editable;
            txtSDT.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;

            btnEditSave.Text = editable ? "LƯU Thay Đổi" : "Chỉnh Sửa";
            btnEditSave.BackColor = editable ? System.Drawing.Color.FromArgb(46, 204, 113) : System.Drawing.Color.FromArgb(52, 152, 219);
        }

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Thực hiện lưu
                if (ValidateInputs())
                {
                    SaveUserInfo();
                    SetEditableState(false);
                }
            }
            else
            {
                // Chuyển sang chế độ chỉnh sửa
                SetEditableState(true);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) || cboGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Họ và tên và Giới tính không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Địa chỉ Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Thêm các kiểm tra khác (SDT, NgaySinh)
            return true;
        }

        private void SaveUserInfo()
        {
            try
            {
                // Lấy thông tin mới từ form
                string hoVaTen = txtHoVaTen.Text.Trim();
                string gioiTinh = cboGioiTinh.Text;
                DateTime ngaySinh = dtpNgaySinh.Value.Date;
                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();

                // Cập nhật vào bảng chi tiết tương ứng
                switch (_maQuyen)
                {
                    case 2: // Thủ Thư
                        var tt = dbContext.THUTHUs.FirstOrDefault(t => t.MATAIKHOAN == _maTaiKhoan);
                        if (tt != null) { tt.HOVATEN = hoVaTen; tt.GIOITINH = gioiTinh; tt.NGAYSINH = ngaySinh; tt.SDT = sdt; tt.EMAIL = email; dbContext.Entry(tt).State = EntityState.Modified; }
                        break;
                    case 3: // Thủ Kho
                        var tkho = dbContext.THUKHOes.FirstOrDefault(t => t.MATAIKHOAN == _maTaiKhoan);
                        if (tkho != null) { tkho.HOVATEN = hoVaTen; tkho.GIOITINH = gioiTinh; tkho.NGAYSINH = ngaySinh; tkho.SDT = sdt; tkho.EMAIL = email; dbContext.Entry(tkho).State = EntityState.Modified; }
                        break;
                    case 4: // Sinh Viên / Độc Giả
                        var sv = dbContext.SINHVIENs.FirstOrDefault(s => s.MATAIKHOAN == _maTaiKhoan);
                        if (sv != null) { sv.HOVATEN = hoVaTen; sv.GIOITINH = gioiTinh; sv.NGAYSINH = ngaySinh; sv.SDT = sdt; sv.EMAIL = email; dbContext.Entry(sv).State = EntityState.Modified; }
                        break;
                    default:
                        // Admin: Không có bảng chi tiết để cập nhật
                        break;
                }

                dbContext.SaveChanges();
                MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserInfo(); // Tải lại để đảm bảo dữ liệu mới nhất
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu thông tin: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================
        // CHỨC NĂNG ĐỔI MẬT KHẨU
        // ===============================================
        private void BtnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (FormDoiMatKhau formDoiMK = new FormDoiMatKhau(_tenDangNhap))
            {
                formDoiMK.ShowDialog();
            }
        }

        // ===============================================
        // LOGIC CHỨC NĂNG KHÁC
        // ===============================================

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thao tác Đăng xuất: Đóng form hiện tại và mở form Login
                if (this.ParentForm != null)
                {
                    this.ParentForm.Hide();
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Model tạm thời để lấy dữ liệu chi tiết
        private class UserDetailModel
        {
            public int MaUser { get; set; }
            public string HoVaTen { get; set; }
            public string GioiTinh { get; set; }
            public DateTime NgaySinh { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
        }
    }
}