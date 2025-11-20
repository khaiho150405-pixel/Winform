using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormTraSach : Form
    {
        public FormTraSach()
        {
            InitializeComponent();
            this.Load += FormTraSach_Load;

            // Gán sự kiện
            btnTimKiem.Click += BtnTimKiem_Click;
            btnTraSach.Click += BtnCRUD_Click; // Sử dụng lại hàm CRUD
            btnSua.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;
            btnHuy.Click += BtnCRUD_Click;
            btnLoadDanhSach.Click += BtnLoadDanhSach_Click;

            // Thiết lập DataGridView
            SetupDataGridView();
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataPhieuMuon();
            ClearInputFields();

            // Thiết lập Placeholder cho ô tìm kiếm
            txtTimKiem.Text = "Nhập Mã PM hoặc Mã Độc giả...";
            txtTimKiem.ForeColor = Color.Gray;

            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;
        }

        private void SetupDataGridView()
        {
            dgvPhieuMuon.AutoGenerateColumns = false;
            dgvPhieuMuon.Columns.Clear();

            // Cột hiển thị các phiếu mượn chưa trả hoặc quá hạn
            dgvPhieuMuon.Columns.Add(CreateColumn("MaPhieuMuon", "Mã PM", 80));
            dgvPhieuMuon.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvPhieuMuon.Columns.Add(CreateColumn("MaDocGia", "Mã ĐG", 80));
            dgvPhieuMuon.Columns.Add(CreateColumn("NgayMuon", "Ngày Mượn", 100));
            dgvPhieuMuon.Columns.Add(CreateColumn("HenTra", "Hẹn Trả", 100));
            dgvPhieuMuon.Columns.Add(CreateColumn("TinhTrang", "Tình Trạng", 80));
            dgvPhieuMuon.Columns.Add(CreateColumn("SoLuongMuon", "SL Mượn", 80));

            dgvPhieuMuon.AllowUserToAddRows = false;
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuMuon.CellClick += DgvPhieuMuon_CellClick;
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
            // Dữ liệu giả lập cho ComboBox
            cboTinhTrangTra.Items.AddRange(new string[] { "Hoàn thành", "Hư hỏng", "Mất" });
        }

        private void LoadDataPhieuMuon()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế (lấy các phiếu chưa trả)
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhieuMuon", typeof(string));
            dt.Columns.Add("MaSach", typeof(string));
            dt.Columns.Add("MaDocGia", typeof(string));
            dt.Columns.Add("NgayMuon", typeof(string));
            dt.Columns.Add("HenTra", typeof(string));
            dt.Columns.Add("TinhTrang", typeof(string));
            dt.Columns.Add("SoLuongMuon", typeof(int));

            // Dữ liệu giả lập
            dt.Rows.Add("PM01", "MS01", "DG01", "1/1/2025", "1/8/2025", "Đang mượn", 1);
            dt.Rows.Add("PM02", "MS03", "DG02", "11/1/2025", "11/15/2025", "Quá hạn", 2);

            dgvPhieuMuon.DataSource = dt;
        }

        private void ClearInputFields()
        {
            txtMaPhieuMuon.Clear();
            txtMaSach.Clear();
            txtMaDocGia.Clear();
            txtTenSach.Clear();
            txtTenTacGia.Clear();
            txtSoLuongCon.Clear();
            dtpHenTra.Value = DateTime.Now;
            dtpNgayTraThucTe.Value = DateTime.Now;
            cboTinhTrangTra.SelectedIndex = -1;
            txtTienPhat.Text = "0";

            // Đặt lại placeholder
            txtTimKiem.Text = "Nhập Mã PM hoặc Mã Độc giả...";
            txtTimKiem.ForeColor = Color.Gray;
        }

        // Xử lý sự kiện Placeholder
        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập Mã PM hoặc Mã Độc giả...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập Mã PM hoặc Mã Độc giả...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // --- Event Handlers ---

        private void DgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuMuon.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ lưới lên Input Panel
                txtMaPhieuMuon.Text = row.Cells["MaPhieuMuon"].Value.ToString();
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtMaDocGia.Text = row.Cells["MaDocGia"].Value.ToString();
                dtpHenTra.Text = row.Cells["HenTra"].Value.ToString(); // Load ngày hẹn trả

                // TODO: Dùng Mã sách/Độc giả để query thông tin chi tiết (TenSach, TenTacGia, SLCon)
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (keyword == "Nhập Mã PM hoặc Mã Độc giả..." || string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo");
                return;
            }

            MessageBox.Show($"Tìm kiếm phiếu mượn/độc giả với từ khóa: {keyword}", "Tìm kiếm");
            // TODO: Lọc dữ liệu trong dgvPhieuMuon
        }

        private void BtnLoadDanhSach_Click(object sender, EventArgs e)
        {
            LoadDataPhieuMuon();
            MessageBox.Show("Đã tải lại toàn bộ danh sách phiếu mượn chưa trả.", "Thông báo");
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

                if (btn.Text == "Trả")
                {
                    // Logic xử lý trả sách: Cập nhật tình trạng phiếu mượn, cập nhật tồn kho sách, tính tiền phạt
                    MessageBox.Show("Thực hiện chức năng: TRẢ SÁCH và tính tiền phạt.", "TRẢ SÁCH");
                }
                else
                {
                    // Logic Sửa/Xóa (chỉnh sửa phiếu mượn)
                    MessageBox.Show($"Thực hiện chức năng: {btn.Text}", "CRUD");
                }

                LoadDataPhieuMuon();
                ClearInputFields();
            }
        }
    }
}