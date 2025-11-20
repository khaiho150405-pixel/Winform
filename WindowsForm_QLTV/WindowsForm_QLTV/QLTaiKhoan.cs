using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormQLTaiKhoan : Form
    {
        public FormQLTaiKhoan()
        {
            InitializeComponent();
            this.Load += FormQLTaiKhoan_Load;

            // Gán sự kiện cho các nút chức năng
            btnTaoMoi.Click += BtnTaoMoi_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnTimKiem.Click += BtnTimKiem_Click;

            // Tinh chỉnh DataGridView
            SetupDataGridView();
        }

        private void FormQLTaiKhoan_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu ban đầu
            LoadDataTaiKhoan();
            // LoadComboboxData(); // KHÔNG CẦN GỌI NỮA vì cboDonVi đã bị xóa
            // Đặt các trường về trạng thái "Tạo mới"
            ClearInputFields();
        }

        private void SetupDataGridView()
        {
            // Cài đặt tên cột (ví dụ)
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Add("MaTK", "Mã TK");
            dgvTaiKhoan.Columns.Add("HoVaTen", "Họ và Tên");
            dgvTaiKhoan.Columns.Add("GioiTinh", "Giới tính");
            dgvTaiKhoan.Columns.Add("SDT", "Số điện thoại");
            dgvTaiKhoan.Columns.Add("Email", "Email");
            dgvTaiKhoan.Columns.Add("Role", "Chức vụ");

            // Tinh chỉnh UI cho DGV
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Dock = DockStyle.Fill;

            // Xử lý sự kiện khi click vào một hàng
            dgvTaiKhoan.CellClick += DgvTaiKhoan_CellClick;
        }

        private void LoadDataTaiKhoan()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("MaTK", typeof(int));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("GioiTinh", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Role", typeof(string));

            // Dữ liệu giả lập
            dt.Rows.Add(101, "Nguyễn Văn Tài", "Nam", "0912345678", "tai@example.com", "Admin");
            dt.Rows.Add(102, "Trần Thị Minh", "Nữ", "0987654321", "minh@example.com", "Thủ thư");

            dgvTaiKhoan.DataSource = dt;
            lblTrangHienTai.Text = "Trang: 1/1"; // Cập nhật phân trang
        }

        // Đã xóa hàm LoadComboboxData() vì cboDonVi không còn tồn tại

        private void ClearInputFields()
        {
            txtMaTK.Text = "Tự động";
            txtHoVaTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Clear();
            txtEmail.Clear();
            cboRole.SelectedIndex = -1;
        }

        // --- Event Handlers ---

        private void DgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên Input Panel
                txtMaTK.Text = row.Cells["MaTK"].Value.ToString();
                txtHoVaTen.Text = row.Cells["HoVaTen"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                // dtpNgaySinh.Value = (DateTime)row.Cells["NgaySinh"].Value; // Cần kiểm tra kiểu dữ liệu thực tế
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cboRole.Text = row.Cells["Role"].Value.ToString();
            }
        }

        private void BtnTaoMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Sẵn sàng nhập thông tin tài khoản mới.");
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTK.Text == "Tự động" || string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản Mã TK: {txtMaTK.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thực hiện logic xóa CSDL
                MessageBox.Show("Đã xóa thành công (giả lập).");
                LoadDataTaiKhoan(); // Tải lại dữ liệu
                ClearInputFields();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Thực hiện logic kiểm tra và lưu CSDL (Thêm mới hoặc Cập nhật)
            if (string.IsNullOrEmpty(txtHoVaTen.Text))
            {
                MessageBox.Show("Họ và tên không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMaTK.Text == "Tự động")
            {
                // Logic Thêm mới
                MessageBox.Show("Đã thêm mới tài khoản thành công (giả lập).");
            }
            else
            {
                // Logic Cập nhật
                MessageBox.Show($"Đã cập nhật tài khoản Mã TK: {txtMaTK.Text} thành công (giả lập).");
            }

            LoadDataTaiKhoan();
            ClearInputFields();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string query = txtTimKiem.Text.Trim();

            // Xóa biến donVi và dangLam, chỉ giữ lại logic tìm kiếm

            // Thực hiện logic lọc và tìm kiếm CSDL dựa trên query
            MessageBox.Show($"Thực hiện tìm kiếm theo Họ và tên: '{query}'.");

            // Ví dụ: Sau khi tìm kiếm, tải lại DataGridView với kết quả lọc
            // LoadDataTaiKhoan(query); 
        }
    }
}