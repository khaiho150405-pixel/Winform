using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormMuonSach : Form
    {
        public FormMuonSach()
        {
            InitializeComponent();
            this.Load += FormMuonSach_Load;

            // Gán sự kiện
            btnTimKiem.Click += BtnTimKiem_Click;
            btnTimSach.Click += BtnTimSach_Click;
            btnMuon.Click += BtnCRUD_Click;
            btnSua.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;
            btnHuy.Click += BtnCRUD_Click;
            btnLoadDanhSach.Click += BtnLoadDanhSach_Click;
            // Đã bỏ btnHome.Click += BtnHome_Click;

            // Thiết lập DataGridView
            SetupDataGridView();
        }

        private void FormMuonSach_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataMuonSach();

            // Thiết lập Placeholder
            txtTimKiem.Text = "Nhập mã độc giả hoặc mã sách...";
            txtTimKiem.ForeColor = Color.Gray;

            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;

            ClearInputFields();
        }

        private void SetupDataGridView()
        {
            dgvMuonSach.AutoGenerateColumns = false;
            dgvMuonSach.Columns.Clear();

            // Thêm các cột theo thứ tự trong hình ảnh (Đã bỏ SoThe và TenNhanVien)
            dgvMuonSach.Columns.Add(CreateColumn("MaPhieuMuon", "Mã Phiếu", 80));
            // dgvMuonSach.Columns.Add(CreateColumn("SoThe", "Số Thẻ", 80)); // Bỏ
            dgvMuonSach.Columns.Add(CreateColumn("TenDocGia", "Tên Độc Giả", 150));
            dgvMuonSach.Columns.Add(CreateColumn("TenSach", "Tên Sách", 150));
            dgvMuonSach.Columns.Add(CreateColumn("SoLuongMuon", "SL Mượn", 80));
            dgvMuonSach.Columns.Add(CreateColumn("NgayMuon", "Ngày Mượn", 100));
            dgvMuonSach.Columns.Add(CreateColumn("HenTra", "Hẹn Trả", 100));
            dgvMuonSach.Columns.Add(CreateColumn("TinhTrang", "Tình Trạng", 80));
            // dgvMuonSach.Columns.Add(CreateColumn("TenNhanVien", "Tên NV", 100)); // Bỏ

            dgvMuonSach.AllowUserToAddRows = false;
            dgvMuonSach.ReadOnly = true;
            dgvMuonSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMuonSach.CellClick += DgvMuonSach_CellClick;
        }

        private DataGridViewTextBoxColumn CreateColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width
            };
        }

        private void LoadComboboxData()
        {
            // Đã bỏ cboSoThe
            cboMaDocGia.Items.AddRange(new string[] { "MaDG01", "MaDG02" });
            cboMaSach.Items.AddRange(new string[] { "MS01", "MS02", "MS03" });
            cboTenSach.Items.AddRange(new string[] { "Sách Hay", "Lập trình C#" });
            cboTinhTrang.Items.AddRange(new string[] { "Mới", "Quá hạn" });
            // Đã bỏ cboMaNhanVien
        }

        private void LoadDataMuonSach()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhieuMuon", typeof(string));
            // dt.Columns.Add("SoThe", typeof(string)); // Bỏ
            dt.Columns.Add("TenDocGia", typeof(string));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("SoLuongMuon", typeof(int));
            dt.Columns.Add("NgayMuon", typeof(string));
            dt.Columns.Add("HenTra", typeof(string));
            dt.Columns.Add("TinhTrang", typeof(string));
            // dt.Columns.Add("TenNhanVien", typeof(string)); // Bỏ

            // Dữ liệu giả lập (Đã điều chỉnh để khớp với cột mới)
            dt.Rows.Add("PM01", "Nguyễn Kha Nam", "Sách Hay", 10, "1/1/2020", "2/2/2020", "Mới");
            dt.Rows.Add("PM04", "Nguyễn Kha Nam", "Sách Hay", 2, "12/25/2020", "12/29/2020", "Mới");
            dt.Rows.Add("PM02", "Lê Văn Hiếu", "Sách Hay", 3, "12/25/2020", "1/29/2021", "Mới");

            dgvMuonSach.DataSource = dt;
        }

        private void ClearInputFields()
        {
            txtMaPhieuMuon.Clear();
            // Đã bỏ cboSoThe
            cboMaDocGia.SelectedIndex = -1;
            txtSLMuon.Clear();
            dtpNgayMuon.Value = DateTime.Now;
            dtpHenTra.Value = DateTime.Now.AddDays(7);
            cboTinhTrang.Text = "Mới";
            // Đã bỏ cboMaNhanVien

            cboMaSach.SelectedIndex = -1;
            cboTenSach.SelectedIndex = -1;
            txtSoLuongCon.Clear();
            txtTenTacGia.Clear();

            // Đặt lại placeholder
            txtTimKiem.Text = "Nhập mã độc giả hoặc mã sách...";
            txtTimKiem.ForeColor = Color.Gray;
        }

        // Xử lý sự kiện Placeholder
        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập mã độc giả hoặc mã sách...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập mã độc giả hoặc mã sách...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // --- Event Handlers ---

        private void DgvMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMuonSach.Rows[e.RowIndex];

                // Giả lập load dữ liệu lên Input Panel
                txtMaPhieuMuon.Text = row.Cells["MaPhieuMuon"].Value.ToString();
                // Bỏ cboSoThe
                cboMaDocGia.Text = row.Cells["TenDocGia"].Value.ToString(); // Sử dụng tên độc giả để hiển thị

                // Cần thêm logic để load lại thông tin chi tiết
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (keyword == "Nhập mã độc giả hoặc mã sách..." || string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo");
                return;
            }

            MessageBox.Show($"Tìm kiếm theo keyword: {keyword}", "Tìm kiếm");
            // TODO: Lọc dữ liệu trong dgvMuonSach
        }

        private void BtnTimSach_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thực hiện tìm kiếm sách theo mã/tên đã chọn.", "Tìm kiếm sách");
            // TODO: Điền thông tin sách (Tên sách, SL còn, Tên TG) vào Input Panel
        }

        private void BtnLoadDanhSach_Click(object sender, EventArgs e)
        {
            LoadDataMuonSach();
            MessageBox.Show("Đã tải lại toàn bộ danh sách mượn.", "Thông báo");
        }

        private void BtnCRUD_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Text == "Hủy")
                {
                    ClearInputFields();
                    MessageBox.Show("Đã hủy thao tác.", "Thông báo");
                    return;
                }

                // Logic CRUD
                MessageBox.Show($"Thực hiện chức năng: {btn.Text}", "CRUD");
                // Sau khi CRUD thành công, gọi: LoadDataMuonSach(); ClearInputFields();
            }
        }
    }
}