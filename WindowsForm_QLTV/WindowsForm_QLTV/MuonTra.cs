using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class MuonTra : Form
    {
        public MuonTra()
        {
            InitializeComponent();
            this.Load += FormTraSachCoNut_Load;

            btnTimKiem.Click += BtnTimKiem_Click;
            dgvSachDangMuon.CellContentClick += DgvSachDangMuon_CellContentClick;

            SetupDataGridView();
        }

        private void FormTraSachCoNut_Load(object sender, EventArgs e)
        {
            LoadDataSachDangMuon();
        }

        private void SetupDataGridView()
        {
            dgvSachDangMuon.AutoGenerateColumns = false;
            dgvSachDangMuon.Columns.Clear();

            // 1. Cột dữ liệu (Giả định: Mã Phiếu, Mã Sách, Tên Sách, Độc Giả, Hẹn Trả)
            dgvSachDangMuon.Columns.Add(CreateTextColumn("MaPhieuMuon", "Mã PM", 80));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("TenDocGia", "Độc Giả", 150));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("TenSach", "Tên Sách", 250));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("NgayMuon", "Ngày Mượn", 100));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("HenTra", "Hẹn Trả", 100));

            // 2. Cột Nút "Trả Sách"
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "Thao tác";
            btnCol.Text = "Trả Sách";
            btnCol.Name = "btnTraSach";
            btnCol.UseColumnTextForButtonValue = true; // Hiển thị "Trả Sách" trên tất cả các nút
            btnCol.Width = 100;
            dgvSachDangMuon.Columns.Add(btnCol);

            dgvSachDangMuon.AllowUserToAddRows = false;
            dgvSachDangMuon.ReadOnly = true;
            dgvSachDangMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width
            };
        }

        private void LoadDataSachDangMuon()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế (Lấy sách có Tình trạng = Đang mượn)
            DataTable dt = new DataTable();
            dt.Columns.Add("MaPhieuMuon", typeof(string));
            dt.Columns.Add("TenDocGia", typeof(string));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("NgayMuon", typeof(string));
            dt.Columns.Add("HenTra", typeof(string));

            // Dữ liệu giả lập
            dt.Rows.Add("PM001", "Nguyễn Văn A", "Lập Trình C# Cơ Bản", "10/01/2025", "24/01/2025");
            dt.Rows.Add("PM002", "Trần Thị B", "Cơ Sở Dữ Liệu SQL", "01/11/2025", "15/11/2025"); // Quá hạn
            dt.Rows.Add("PM003", "Lê Văn C", "Thiết Kế UI/UX", "15/11/2025", "29/11/2025");

            dgvSachDangMuon.DataSource = dt;
        }

        // --- Event Handlers ---

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadDataSachDangMuon(); // Tải lại toàn bộ nếu không có keyword
                return;
            }

            // TODO: Thực hiện lọc dữ liệu trong DataGridView
            MessageBox.Show($"Thực hiện tìm kiếm sách/phiếu mượn với từ khóa: {keyword}", "Tìm kiếm");
        }

        private void DgvSachDangMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải là cột nút "Trả Sách" được click không
            if (dgvSachDangMuon.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSachDangMuon.Rows[e.RowIndex];
                string maPhieuMuon = row.Cells["MaPhieuMuon"].Value.ToString();
                string tenSach = row.Cells["TenSach"].Value.ToString();

                if (MessageBox.Show($"Xác nhận TRẢ SÁCH '{tenSach}' (Mã PM: {maPhieuMuon})?", "Xác Nhận Trả", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Mở Form TraSach chi tiết hoặc gọi logic Trả Sách ngay lập tức

                    MessageBox.Show($"Đã xử lý yêu cầu trả sách cho PM: {maPhieuMuon}", "Hoàn thành");
                    // Sau khi xử lý xong, tải lại dữ liệu
                    LoadDataSachDangMuon();
                }
            }
        }
    }
}