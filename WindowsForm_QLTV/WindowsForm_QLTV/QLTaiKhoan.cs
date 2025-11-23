using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Security.Cryptography; // Để xử lý mật khẩu (Giả lập)
using System.Text;

namespace WindowsForm_QLTV
{
    public partial class FormQLTaiKhoan : Form
    {
        private Model1 dbContext = new Model1();
        private const int PAGE_SIZE = 20; // Số lượng mục trên mỗi trang
        private int currentPage = 1;
        private int totalPages = 1;

        public FormQLTaiKhoan()
        {
            InitializeComponent();
            this.Load += FormQLTaiKhoan_Load;

            // Gán sự kiện cho các nút chức năng
            btnTaoMoi.Click += BtnTaoMoi_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnTimKiem.Click += BtnTimKiem_Click;

            // Gán sự kiện Phân trang
            btnTrangDau.Click += (s, e) => ChangePage(1);
            btnTrangTruoc.Click += (s, e) => ChangePage(currentPage - 1);
            btnTrangSau.Click += (s, e) => ChangePage(currentPage + 1);
            btnTrangCuoi.Click += (s, e) => ChangePage(totalPages);

            // Tinh chỉnh DataGridView
            SetupDataGridView();
        }

        private void FormQLTaiKhoan_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu ban đầu
            LoadDataTaiKhoan();
            // Load Combobox Chức vụ (Role)
            LoadComboboxData();
            // Đặt các trường về trạng thái "Tạo mới"
            ClearInputFields();
        }

        private void SetupDataGridView()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();

            // Cột dữ liệu từ ViewModel
            dgvTaiKhoan.Columns.Add(CreateTextColumn("MaTK", "Mã TK", 60));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("TenDangNhap", "Tên ĐN", 100));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("HoVaTen", "Họ và Tên", 150));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("GioiTinh", "Giới tính", 80));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("SDT", "SĐT", 100));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("Email", "Email", 150));
            dgvTaiKhoan.Columns.Add(CreateTextColumn("TenQuyen", "Chức vụ", 100));

            // Ẩn các cột cần thiết cho logic
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("MaQuyen", "Mã Quyền"));
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("MaUserDetail", "Mã Chi Tiết"));
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("NgaySinh", "Ngày Sinh"));

            // Tinh chỉnh UI cho DGV
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Dock = DockStyle.Fill;
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn { Name = name, HeaderText = header, DataPropertyName = name, Width = width };
        }

        private DataGridViewTextBoxColumn CreateHiddenColumn(string name, string header)
        {
            return new DataGridViewTextBoxColumn { Name = name, HeaderText = header, DataPropertyName = name, Visible = false };
        }

        // ===============================================
        // 2. LOGIC TẢI DỮ LIỆU & PHÂN TRANG
        // ===============================================
        private void LoadComboboxData()
        {
            try
            {
                var roles = dbContext.PHANQUYENs.ToList();
                cboRole.DataSource = roles;
                cboRole.DisplayMember = "TENQUYEN";
                cboRole.ValueMember = "MAQUYEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu chức vụ: " + ex.Message, "Lỗi Database");
            }
        }

        private IQueryable<AccountViewModel> GetAccountQuery(string keyword = null)
        {
            // Truy vấn lấy tất cả tài khoản
            var query = dbContext.TAIKHOANs
                .Include(tk => tk.PHANQUYEN)
                .AsNoTracking()
                .Select(tk => new AccountViewModel
                {
                    MaTK = tk.MATAIKHOAN,
                    TenDangNhap = tk.TENDANGNHAP,
                    TenQuyen = tk.PHANQUYEN.TENQUYEN,
                    MaQuyen = tk.MAQUYEN,
                    TrangThai = tk.TRANGTHAI
                    // Chi tiết người dùng sẽ được load sau hoặc trong bước tiếp theo
                });

            // Áp dụng tìm kiếm theo tên đăng nhập hoặc tên quyền
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string lowerKeyword = keyword.ToLower();
                query = query.Where(tk => tk.TenDangNhap.ToLower().Contains(lowerKeyword) ||
                                           tk.TenQuyen.ToLower().Contains(lowerKeyword));
            }
            return query;
        }

        private void LoadDataTaiKhoan(string keyword = null)
        {
            try
            {
                // 1. Lấy tổng số lượng và tính tổng số trang
                var baseQuery = GetAccountQuery(keyword);
                int totalItems = baseQuery.Count();
                totalPages = (int)Math.Ceiling((double)totalItems / PAGE_SIZE);
                if (currentPage > totalPages && totalPages > 0) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                // 2. Áp dụng phân trang
                var pagedQuery = baseQuery
                    .OrderBy(tk => tk.MaTK)
                    .Skip((currentPage - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();

                // 3. Load chi tiết người dùng (Thủ Thư/Thủ Kho/Sinh Viên)
                var resultList = new List<AccountViewModel>();
                foreach (var account in pagedQuery)
                {
                    AccountViewModel vm = LoadUserDetail(account);
                    resultList.Add(vm);
                }

                dgvTaiKhoan.DataSource = resultList;
                lblTrangHienTai.Text = $"Trang: {currentPage}/{totalPages}";
                UpdatePaginationControls();

            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI TẢI DỮ LIỆU TÀI KHOẢN: " + ex.Message, "Lỗi Database");
            }
        }

        private AccountViewModel LoadUserDetail(AccountViewModel vm)
        {
            // Dựa vào MaQuyen để join với bảng chi tiết tương ứng
            switch (vm.MaQuyen)
            {
                case 2: // Thủ Thư
                    var tt = dbContext.THUTHUs.AsNoTracking().FirstOrDefault(t => t.MATAIKHOAN == vm.MaTK);
                    if (tt != null) { vm.HoVaTen = tt.HOVATEN; vm.GioiTinh = tt.GIOITINH; vm.NgaySinh = tt.NGAYSINH; vm.SDT = tt.SDT; vm.Email = tt.EMAIL; vm.MaUserDetail = tt.MATT; }
                    break;
                case 3: // Thủ Kho
                    var tkho = dbContext.THUKHOes.AsNoTracking().FirstOrDefault(t => t.MATAIKHOAN == vm.MaTK);
                    if (tkho != null) { vm.HoVaTen = tkho.HOVATEN; vm.GioiTinh = tkho.GIOITINH; vm.NgaySinh = tkho.NGAYSINH; vm.SDT = tkho.SDT; vm.Email = tkho.EMAIL; vm.MaUserDetail = tkho.MATK; }
                    break;
                case 4: // Sinh Viên / Độc Giả
                    var sv = dbContext.SINHVIENs.AsNoTracking().FirstOrDefault(s => s.MATAIKHOAN == vm.MaTK);
                    if (sv != null) { vm.HoVaTen = sv.HOVATEN; vm.GioiTinh = sv.GIOITINH; vm.NgaySinh = sv.NGAYSINH; vm.SDT = sv.SDT; vm.Email = sv.EMAIL; vm.MaUserDetail = sv.MASV; }
                    break;
                // Admin (MaQuyen = 1) có thể không có bảng chi tiết riêng, chỉ cần thông tin từ TAIKHOAN
                default:
                    // Thử lấy thông tin từ TAIKHOAN nếu có
                    //var tk = dbContext.TAIKHOANs.AsNoTracking().Find(vm.MaTK);
                    //if (tk != null) { vm.TenDangNhap = tk.TENDANGNHAP; }
                    break;
            }
            return vm;
        }

        private void ChangePage(int newPage)
        {
            if (newPage >= 1 && newPage <= totalPages)
            {
                currentPage = newPage;
                LoadDataTaiKhoan(txtTimKiem.Text.Trim());
            }
        }

        private void UpdatePaginationControls()
        {
            btnTrangDau.Enabled = currentPage > 1;
            btnTrangTruoc.Enabled = currentPage > 1;
            btnTrangSau.Enabled = currentPage < totalPages;
            btnTrangCuoi.Enabled = currentPage < totalPages;
        }

        // ===============================================
        // 3. LOGIC INPUT & SỰ KIỆN DGV
        // ===============================================
        private void ClearInputFields()
        {
            txtMaTK.Text = "Tự động";
            txtHoVaTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now.Date;
            txtSDT.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = -1;
            // Thêm trường mật khẩu nếu cần: txtMatKhau.Clear();
        }

        private void DgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                // Lấy đối tượng từ DataBoundItem
                AccountViewModel vm = row.DataBoundItem as AccountViewModel;
                if (vm == null) return;

                // Hiển thị dữ liệu lên Input Panel
                txtMaTK.Text = vm.MaTK.ToString();
                txtHoVaTen.Text = vm.HoVaTen;
                cboGioiTinh.Text = vm.GioiTinh;

                if (vm.NgaySinh.HasValue)
                {
                    dtpNgaySinh.Value = vm.NgaySinh.Value;
                }
                else
                {
                    dtpNgaySinh.Value = DateTime.Now.Date;
                }

                txtSDT.Text = vm.SDT;
                txtEmail.Text = vm.Email;
                cboRole.SelectedValue = vm.MaQuyen; // Chọn combobox theo Mã Quyền
                // Có thể thêm hiển thị Tên đăng nhập nếu bạn thêm control cho nó
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) || cboRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ và tên và chọn Chức vụ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Thêm kiểm tra định dạng SDT, Email nếu cần
            return true;
        }

        // ===============================================
        // 4. LOGIC CRUD
        // ===============================================

        private void BtnTaoMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Sẵn sàng nhập thông tin tài khoản mới. Mật khẩu mặc định: '123456'.", "Thông báo");
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTK.Text, out int maTK))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản hợp lệ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản Mã TK: {maTK}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        TAIKHOAN taiKhoan = dbContext.TAIKHOANs.Find(maTK);
                        if (taiKhoan == null) return;

                        // 1. Xóa thông tin chi tiết (THUTHU/THUKHO/SINHVIEN) trước
                        DeleteUserDetail(maTK, taiKhoan.MAQUYEN);

                        // 2. Xóa TAIKHOAN
                        dbContext.TAIKHOANs.Remove(taiKhoan);
                        dbContext.SaveChanges();

                        transaction.Commit();
                        MessageBox.Show("Đã xóa tài khoản thành công.", "Hoàn thành");
                        LoadDataTaiKhoan();
                        ClearInputFields();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("LỖI XÓA TÀI KHOẢN: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteUserDetail(int maTK, int maQuyen)
        {
            // Tìm và xóa bản ghi trong bảng chi tiết tương ứng
            switch (maQuyen)
            {
                case 2: // Thủ Thư
                    var tt = dbContext.THUTHUs.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tt != null) dbContext.THUTHUs.Remove(tt);
                    break;
                case 3: // Thủ Kho
                    var tkho = dbContext.THUKHOes.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tkho != null) dbContext.THUKHOes.Remove(tkho);
                    break;
                case 4: // Sinh Viên / Độc Giả
                    var sv = dbContext.SINHVIENs.FirstOrDefault(s => s.MATAIKHOAN == maTK);
                    if (sv != null) dbContext.SINHVIENs.Remove(sv);
                    break;
            }
            dbContext.SaveChanges(); // Lưu thay đổi trước khi xóa TAIKHOAN chính
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    int maQuyen = (int)cboRole.SelectedValue;
                    string hoVaTen = txtHoVaTen.Text.Trim();
                    string gioiTinh = cboGioiTinh.Text;
                    DateTime ngaySinh = dtpNgaySinh.Value.Date;
                    string sdt = txtSDT.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    bool isNew = txtMaTK.Text == "Tự động";
                    TAIKHOAN taiKhoan;

                    if (isNew)
                    {
                        // 1. TẠO TAIKHOAN MỚI
                        taiKhoan = new TAIKHOAN
                        {
                            TENDANGNHAP = GenerateDefaultUsername(hoVaTen, maQuyen), // Cần logic tạo TENDANGNHAP
                            MATKHAU = HashPassword("123456"), // Mật khẩu mặc định
                            MAQUYEN = maQuyen,
                            TRANGTHAI = "Hoạt động"
                        };
                        dbContext.TAIKHOANs.Add(taiKhoan);
                        dbContext.SaveChanges(); // Lưu để lấy MaTK

                        // 2. TẠO THÔNG TIN CHI TIẾT
                        CreateUserDetail(taiKhoan.MATAIKHOAN, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email);

                        MessageBox.Show("Đã thêm mới tài khoản thành công.", "Hoàn thành");
                    }
                    else
                    {
                        // 1. CẬP NHẬT TAIKHOAN HIỆN TẠI
                        int maTK = int.Parse(txtMaTK.Text);
                        taiKhoan = dbContext.TAIKHOANs.Find(maTK);
                        if (taiKhoan == null) throw new Exception("Tài khoản không tồn tại.");

                        // Xử lý thay đổi vai trò (Nếu thay đổi vai trò, phải xóa chi tiết cũ và tạo chi tiết mới)
                        if (taiKhoan.MAQUYEN != maQuyen)
                        {
                            DeleteUserDetail(maTK, taiKhoan.MAQUYEN); // Xóa chi tiết cũ
                            CreateUserDetail(maTK, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email); // Tạo chi tiết mới
                            taiKhoan.MAQUYEN = maQuyen; // Cập nhật MaQuyen mới
                                                        // Có thể cần cập nhật TENDANGNHAP nếu logic tạo tên đăng nhập phụ thuộc vào MAQUYEN
                        }

                        // 2. CẬP NHẬT THÔNG TIN CHI TIẾT
                        UpdateUserDetail(maTK, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email);

                        dbContext.Entry(taiKhoan).State = EntityState.Modified; // Cập nhật TAIKHOAN

                        MessageBox.Show($"Đã cập nhật tài khoản Mã TK: {maTK} thành công.", "Hoàn thành");
                    }

                    dbContext.SaveChanges();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("LỖI LƯU TÀI KHOẢN: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            LoadDataTaiKhoan();
            ClearInputFields();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDataTaiKhoan(txtTimKiem.Text.Trim());
        }

        // ===============================================
        // 5. HÀM HỖ TRỢ CRUD
        // ===============================================

        private string GenerateDefaultUsername(string hoVaTen, int maQuyen)
        {
            string baseName = new string(hoVaTen.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark && char.IsLetterOrDigit(c)).ToArray()).Replace(" ", "").ToLower();
            string prefix = maQuyen == 2 ? "tt" : maQuyen == 3 ? "tk" : maQuyen == 4 ? "sv" : "ad";
            return prefix + baseName;
        }

        // GIẢ LẬP: Hàm Hash Mật khẩu (Bạn cần dùng thuật toán mạnh hơn như BCrypt/Argon2)
        private string HashPassword(string password)
        {
            // Mật khẩu được lưu dưới dạng Plain Text trong DB script, nhưng EF nên dùng hashing
            // Giả lập SHA256 cho đơn giản
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void CreateUserDetail(int maTK, int maQuyen, string hoVaTen, string gioiTinh, DateTime ngaySinh, string sdt, string email)
        {
            // Tạo bản ghi trong bảng chi tiết tương ứng
            switch (maQuyen)
            {
                case 2: // Thủ Thư
                    dbContext.THUTHUs.Add(new THUTHU { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
                case 3: // Thủ Kho
                    dbContext.THUKHOes.Add(new THUKHO { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
                case 4: // Sinh Viên / Độc Giả
                    dbContext.SINHVIENs.Add(new SINHVIEN { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
            }
            // Không gọi SaveChanges() ở đây, để hàm gọi (BtnLuu_Click) tự gọi
        }

        private void UpdateUserDetail(int maTK, int maQuyen, string hoVaTen, string gioiTinh, DateTime ngaySinh, string sdt, string email)
        {
            // Cập nhật bản ghi trong bảng chi tiết tương ứng
            switch (maQuyen)
            {
                case 2: // Thủ Thư
                    var tt = dbContext.THUTHUs.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tt != null) { tt.HOVATEN = hoVaTen; tt.GIOITINH = gioiTinh; tt.NGAYSINH = ngaySinh; tt.SDT = sdt; tt.EMAIL = email; dbContext.Entry(tt).State = EntityState.Modified; }
                    break;
                case 3: // Thủ Kho
                    var tkho = dbContext.THUKHOes.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tkho != null) { tkho.HOVATEN = hoVaTen; tkho.GIOITINH = gioiTinh; tkho.NGAYSINH = ngaySinh; tkho.SDT = sdt; tkho.EMAIL = email; dbContext.Entry(tkho).State = EntityState.Modified; }
                    break;
                case 4: // Sinh Viên / Độc Giả
                    var sv = dbContext.SINHVIENs.FirstOrDefault(s => s.MATAIKHOAN == maTK);
                    if (sv != null) { sv.HOVATEN = hoVaTen; sv.GIOITINH = gioiTinh; sv.NGAYSINH = ngaySinh; sv.SDT = sdt; sv.EMAIL = email; dbContext.Entry(sv).State = EntityState.Modified; }
                    break;
            }
            // Không gọi SaveChanges() ở đây, để hàm gọi (BtnLuu_Click) tự gọi
        }

        // ===============================================
        // 1. VIEW MODEL
        // ===============================================
        public class AccountViewModel
        {
            public int MaTK { get; set; }
            public int MaUserDetail { get; set; } // Mã liên quan (MASV/MATT/MATK)
            public string HoVaTen { get; set; }
            public string GioiTinh { get; set; }
            public DateTime? NgaySinh { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
            public string TenDangNhap { get; set; }
            public string TenQuyen { get; set; }
            public int MaQuyen { get; set; }
            public string TrangThai { get; set; }
        }

    }
}