using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text;

namespace WindowsForm_QLTV
{
    public partial class FormQLTaiKhoan : Form
    {
        private Model1 dbContext = new Model1();
        private const int PAGE_SIZE = 20;
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

            // Sự kiện lọc theo vai trò
            cboLocVaiTro.SelectedIndexChanged += CboLocVaiTro_SelectedIndexChanged;

            // Cho phép tìm kiếm bằng Enter
            txtTimKiem.KeyDown += TxtTimKiem_KeyDown;

            // Tinh chỉnh DataGridView
            SetupDataGridView();
        }

        private void FormQLTaiKhoan_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox lọc vai trò
            SetupComboBoxLocVaiTro();
            // Load Combobox Chức vụ (Role)
            LoadComboboxData();
            // Tải dữ liệu ban đầu
            LoadDataTaiKhoan();
            // Đặt các trường về trạng thái "Tạo mới"
            ClearInputFields();
            // Thiết lập placeholder cho ô tìm kiếm
            SetupSearchPlaceholder();
        }

        private void SetupSearchPlaceholder()
        {
            txtTimKiem.Text = "Nhập từ khóa tìm kiếm...";
            txtTimKiem.ForeColor = Color.Gray;

            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == "Nhập từ khóa tìm kiếm...")
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = "Nhập từ khóa tìm kiếm...";
                    txtTimKiem.ForeColor = Color.Gray;
                }
            };
        }

        private void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnTimKiem_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void SetupComboBoxLocVaiTro()
        {
            cboLocVaiTro.Items.Clear();
            cboLocVaiTro.Items.Add("-- Tất cả --");
            cboLocVaiTro.Items.Add("Admin");
            cboLocVaiTro.Items.Add("Thủ Thư");
            cboLocVaiTro.Items.Add("Thủ Kho");
            cboLocVaiTro.Items.Add("Độc Giả");
            cboLocVaiTro.SelectedIndex = 0;
        }

        private void CboLocVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadDataTaiKhoan();
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

            // Cột trạng thái để dễ quan sát (Tùy chọn)
            dgvTaiKhoan.Columns.Add(CreateTextColumn("TrangThai", "Trạng Thái", 100));

            // Ẩn các cột cần thiết cho logic
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("MaQuyen", "Mã Quyền"));
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("MaUserDetail", "Mã Chi Tiết"));
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("NgaySinh", "Ngày Sinh"));
            dgvTaiKhoan.Columns.Add(CreateHiddenColumn("MatKhau", "Mật Khẩu")); // Ẩn mật khẩu trên grid

            // Tinh chỉnh UI cho DGV
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Dock = DockStyle.Fill;

            // Gán sự kiện click
            dgvTaiKhoan.CellClick += DgvTaiKhoan_CellClick;
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

        private int? GetSelectedMaQuyen()
        {
            string selected = cboLocVaiTro.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected) || selected == "-- Tất cả --")
                return null;

            switch (selected)
            {
                case "Admin": return 1;
                case "Thủ Thư": return 2;
                case "Thủ Kho": return 3;
                case "Độc Giả": return 4;
                default: return null;
            }
        }

        private string[] SplitKeywords(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new string[0];
            return keyword.ToLower()
                          .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                          .Where(w => w.Length > 0)
                          .ToArray();
        }

        private bool MatchesAnyKeyword(string hoVaTen, string[] keywords)
        {
            if (string.IsNullOrWhiteSpace(hoVaTen) || keywords == null || keywords.Length == 0)
                return false;
            string lowerName = hoVaTen.ToLower();
            return keywords.Any(kw => lowerName.Contains(kw));
        }

        private void LoadDataTaiKhoan()
        {
            try
            {
                // Lấy từ khóa tìm kiếm
                string keyword = txtTimKiem.Text.Trim();
                if (keyword == "Nhập từ khóa tìm kiếm...")
                    keyword = null;

                string[] keywords = SplitKeywords(keyword);
                int? maQuyenFilter = GetSelectedMaQuyen();

                // 1. Lấy danh sách tài khoản
                var baseQuery = dbContext.TAIKHOANs
                    .Include(tk => tk.PHANQUYEN)
                    .AsNoTracking()
                    .AsQueryable();

                // Lọc theo vai trò
                if (maQuyenFilter.HasValue)
                {
                    baseQuery = baseQuery.Where(tk => tk.MAQUYEN == maQuyenFilter.Value);
                }

                // 2. Map sang ViewModel (Lấy cả Mật khẩu và Trạng thái)
                var accountList = baseQuery
                    .OrderBy(tk => tk.MATAIKHOAN)
                    .Select(tk => new AccountViewModel
                    {
                        MaTK = tk.MATAIKHOAN,
                        TenDangNhap = tk.TENDANGNHAP,
                        MatKhau = tk.MATKHAU, // Lấy mật khẩu
                        TenQuyen = tk.PHANQUYEN.TENQUYEN,
                        MaQuyen = tk.MAQUYEN,
                        TrangThai = tk.TRANGTHAI // Lấy trạng thái
                    })
                    .ToList();

                // 3. Load chi tiết người dùng và lọc theo từ khóa
                var resultList = new List<AccountViewModel>();
                foreach (var account in accountList)
                {
                    AccountViewModel vm = LoadUserDetail(account);

                    if (keywords != null && keywords.Length > 0)
                    {
                        if (MatchesAnyKeyword(vm.HoVaTen, keywords))
                        {
                            resultList.Add(vm);
                        }
                    }
                    else
                    {
                        resultList.Add(vm);
                    }
                }

                // 4. Phân trang
                int totalItems = resultList.Count;
                totalPages = (int)Math.Ceiling((double)totalItems / PAGE_SIZE);
                if (currentPage > totalPages && totalPages > 0) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                var pagedList = resultList
                    .Skip((currentPage - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();

                dgvTaiKhoan.DataSource = pagedList;
                lblTrangHienTai.Text = $"Trang: {currentPage}/{totalPages} ({totalItems} kết quả)";
                UpdatePaginationControls();

            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI TẢI DỮ LIỆU TÀI KHOẢN: " + ex.Message, "Lỗi Database");
            }
        }

        private AccountViewModel LoadUserDetail(AccountViewModel vm)
        {
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
                default:
                    break;
            }
            return vm;
        }

        private void ChangePage(int newPage)
        {
            if (newPage >= 1 && newPage <= totalPages)
            {
                currentPage = newPage;
                LoadDataTaiKhoan();
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

            // Reset các trường mới
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            chkBiKhoa.Checked = false;
        }

        private void DgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                AccountViewModel vm = row.DataBoundItem as AccountViewModel;
                if (vm == null) return;

                txtMaTK.Text = vm.MaTK.ToString();
                txtHoVaTen.Text = vm.HoVaTen;
                cboGioiTinh.Text = vm.GioiTinh;

                if (vm.NgaySinh.HasValue)
                    dtpNgaySinh.Value = vm.NgaySinh.Value;
                else
                    dtpNgaySinh.Value = DateTime.Now.Date;

                txtSDT.Text = vm.SDT;
                txtEmail.Text = vm.Email;
                cboRole.SelectedValue = vm.MaQuyen;

                // Hiển thị thông tin đăng nhập
                txtTenDangNhap.Text = vm.TenDangNhap;
                txtMatKhau.Text = vm.MatKhau;

                // Hiển thị trạng thái khóa
                chkBiKhoa.Checked = (vm.TrangThai == "Ngừng hoạt động");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) || cboRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ và tên và chọn Chức vụ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ===============================================
        // 4. LOGIC CRUD
        // ===============================================

        private void BtnTaoMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Sẵn sàng nhập thông tin tài khoản mới. Mật khẩu mặc định là '123456' nếu để trống.", "Thông báo");
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

                        DeleteUserDetail(maTK, taiKhoan.MAQUYEN);
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
            switch (maQuyen)
            {
                case 2:
                    var tt = dbContext.THUTHUs.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tt != null) dbContext.THUTHUs.Remove(tt);
                    break;
                case 3:
                    var tkho = dbContext.THUKHOes.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tkho != null) dbContext.THUKHOes.Remove(tkho);
                    break;
                case 4:
                    var sv = dbContext.SINHVIENs.FirstOrDefault(s => s.MATAIKHOAN == maTK);
                    if (sv != null) dbContext.SINHVIENs.Remove(sv);
                    break;
            }
            dbContext.SaveChanges();
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

                    // Lấy mật khẩu và trạng thái từ giao diện
                    string matKhau = txtMatKhau.Text.Trim();
                    if (string.IsNullOrEmpty(matKhau)) matKhau = "123456"; // Mặc định nếu trống

                    string trangThai = chkBiKhoa.Checked ? "Ngừng hoạt động" : "Hoạt động";

                    bool isNew = txtMaTK.Text == "Tự động";
                    TAIKHOAN taiKhoan;

                    if (isNew)
                    {
                        // THÊM MỚI
                        taiKhoan = new TAIKHOAN
                        {
                            TENDANGNHAP = GenerateDefaultUsername(hoVaTen, maQuyen),
                            MATKHAU = matKhau,
                            MAQUYEN = maQuyen,
                            TRANGTHAI = trangThai
                        };
                        dbContext.TAIKHOANs.Add(taiKhoan);
                        dbContext.SaveChanges();

                        CreateUserDetail(taiKhoan.MATAIKHOAN, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email);

                        MessageBox.Show($"Đã thêm mới tài khoản thành công.\nTên đăng nhập: {taiKhoan.TENDANGNHAP}\nMật khẩu: {taiKhoan.MATKHAU}", "Hoàn thành");
                    }
                    else
                    {
                        // CẬP NHẬT
                        int maTK = int.Parse(txtMaTK.Text);
                        taiKhoan = dbContext.TAIKHOANs.Find(maTK);
                        if (taiKhoan == null) throw new Exception("Tài khoản không tồn tại.");

                        // Cập nhật thông tin đăng nhập và trạng thái
                        taiKhoan.MATKHAU = matKhau;
                        taiKhoan.TRANGTHAI = trangThai;

                        // Xử lý chuyển quyền (nếu có thay đổi chức vụ)
                        if (taiKhoan.MAQUYEN != maQuyen)
                        {
                            DeleteUserDetail(maTK, taiKhoan.MAQUYEN);
                            CreateUserDetail(maTK, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email);
                            taiKhoan.MAQUYEN = maQuyen;
                        }
                        else
                        {
                            UpdateUserDetail(maTK, maQuyen, hoVaTen, gioiTinh, ngaySinh, sdt, email);
                        }

                        dbContext.Entry(taiKhoan).State = EntityState.Modified;
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
            LoadDataTaiKhoan();
        }

        // ===============================================
        // 5. HÀM HỖ TRỢ CRUD
        // ===============================================

        private string GenerateDefaultUsername(string hoVaTen, int maQuyen)
        {
            string baseName = new string(hoVaTen.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark && char.IsLetterOrDigit(c)).ToArray()).Replace(" ", "").ToLower();
            string prefix = maQuyen == 2 ? "tt" : maQuyen == 3 ? "tk" : maQuyen == 4 ? "sv" : "ad";

            Random rnd = new Random();
            return prefix + baseName + rnd.Next(100, 999);
        }

        private void CreateUserDetail(int maTK, int maQuyen, string hoVaTen, string gioiTinh, DateTime ngaySinh, string sdt, string email)
        {
            switch (maQuyen)
            {
                case 2:
                    dbContext.THUTHUs.Add(new THUTHU { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
                case 3:
                    dbContext.THUKHOes.Add(new THUKHO { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
                case 4:
                    dbContext.SINHVIENs.Add(new SINHVIEN { MATAIKHOAN = maTK, HOVATEN = hoVaTen, GIOITINH = gioiTinh, NGAYSINH = ngaySinh, SDT = sdt, EMAIL = email });
                    break;
            }
        }

        private void UpdateUserDetail(int maTK, int maQuyen, string hoVaTen, string gioiTinh, DateTime ngaySinh, string sdt, string email)
        {
            switch (maQuyen)
            {
                case 2:
                    var tt = dbContext.THUTHUs.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tt != null) { tt.HOVATEN = hoVaTen; tt.GIOITINH = gioiTinh; tt.NGAYSINH = ngaySinh; tt.SDT = sdt; tt.EMAIL = email; dbContext.Entry(tt).State = EntityState.Modified; }
                    break;
                case 3:
                    var tkho = dbContext.THUKHOes.FirstOrDefault(t => t.MATAIKHOAN == maTK);
                    if (tkho != null) { tkho.HOVATEN = hoVaTen; tkho.GIOITINH = gioiTinh; tkho.NGAYSINH = ngaySinh; tkho.SDT = sdt; tkho.EMAIL = email; dbContext.Entry(tkho).State = EntityState.Modified; }
                    break;
                case 4:
                    var sv = dbContext.SINHVIENs.FirstOrDefault(s => s.MATAIKHOAN == maTK);
                    if (sv != null) { sv.HOVATEN = hoVaTen; sv.GIOITINH = gioiTinh; sv.NGAYSINH = ngaySinh; sv.SDT = sdt; sv.EMAIL = email; dbContext.Entry(sv).State = EntityState.Modified; }
                    break;
            }
        }

        // ===============================================
        // VIEW MODEL
        // ===============================================
        public class AccountViewModel
        {
            public int MaTK { get; set; }
            public int MaUserDetail { get; set; }
            public string HoVaTen { get; set; }
            public string GioiTinh { get; set; }
            public DateTime? NgaySinh { get; set; }
            public string SDT { get; set; }
            public string Email { get; set; }
            public string MatKhau { get; set; } // Thêm trường mật khẩu
            public string TenDangNhap { get; set; }
            public string TenQuyen { get; set; }
            public int MaQuyen { get; set; }
            public string TrangThai { get; set; } // Thêm trường trạng thái
        }
    }
}