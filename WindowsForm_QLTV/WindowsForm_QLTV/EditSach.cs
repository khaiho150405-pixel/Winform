using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormQLTatCaSach : Form
    {
        public FormQLTatCaSach()
        {
            InitializeComponent();
            this.Load += FormQLTatCaSach_Load;

            // Gán sự kiện cho 3 nút CRUD chính
            btnThem.Click += BtnCRUD_Click;
            btnCapNhat.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;

            btnTimKiem.Click += BtnTimKiem_Click;
            btnChooseFile.Click += BtnChooseFile_Click;

            // Thiết lập DataGridView
            SetupDataGridView();
        }

        private void FormQLTatCaSach_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataSach();
        }

        private void SetupDataGridView()
        {
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Columns.Clear();

            // Thêm các cột theo thứ tự trong hình ảnh
            dgvSach.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvSach.Columns.Add(CreateColumn("Anh", "Ảnh", 150)); // Cột này sẽ hiển thị ảnh
            dgvSach.Columns.Add(CreateColumn("TenSach", "Tên Sách", 150));
            dgvSach.Columns.Add(CreateColumn("MaTacGia", "Mã Tác Giả", 100));
            dgvSach.Columns.Add(CreateColumn("MaTheLoai", "Mã Thể Loại", 100));
            dgvSach.Columns.Add(CreateColumn("MaNXB", "Mã NXB", 100));
            dgvSach.Columns.Add(CreateColumn("NamXuatBan", "Năm Xuất Bản", 100));
            dgvSach.Columns.Add(CreateColumn("SoLuong", "Số Lượng", 80));

            dgvSach.AllowUserToAddRows = false;
            dgvSach.ReadOnly = true;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.RowTemplate.Height = 100; // Tăng chiều cao hàng để hiển thị ảnh

            // Gán sự kiện cho việc vẽ cell (để vẽ ảnh)
            dgvSach.CellPainting += DgvSach_CellPainting;
            dgvSach.CellClick += DgvSach_CellClick;
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
            cboMaTacGia.Items.AddRange(new string[] { "MaTG01", "MaTG02", "MaTG03" });
            cboMaTheLoai.Items.AddRange(new string[] { "MaTL01", "MaTL02", "MaTL03" });
            cboMaNXB.Items.AddRange(new string[] { "MaNXB01", "MaNXB02", "MaNXB03" });
        }

        private void LoadDataSach()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSach", typeof(string));
            dt.Columns.Add("Anh", typeof(string)); // Lưu đường dẫn ảnh (giả lập)
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("MaTacGia", typeof(string));
            dt.Columns.Add("MaTheLoai", typeof(string));
            dt.Columns.Add("MaNXB", typeof(string));
            dt.Columns.Add("NamXuatBan", typeof(int));
            dt.Columns.Add("SoLuong", typeof(int));

            // Dữ liệu giả lập
            dt.Rows.Add("MS01", "cover1.jpg", "Đừng Lựa Chọn An Nhàn Khi Còn Trẻ", "MaTG01", "MaTL01", "MaNXB01", 2020, 10);
            dt.Rows.Add("MS02", "cover2.jpg", "Sách Hay", "MaTG02", "MaTL02", "MaNXB02", 2021, 5);

            dgvSach.DataSource = dt;
        }

        // --- Event Handlers ---

        private void DgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ lưới lên Input Panel
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
                cboMaTacGia.Text = row.Cells["MaTacGia"].Value.ToString();
                cboMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                cboMaNXB.Text = row.Cells["MaNXB"].Value.ToString();
                txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();

                // TODO: Load ảnh vào pnlImage nếu có đường dẫn ảnh thực tế
            }
        }

        private void DgvSach_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Giả lập vẽ ảnh bìa sách
            if (e.ColumnIndex == dgvSach.Columns["Anh"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Vẽ chữ "Bìa Sách" thay vì ảnh thực
                TextRenderer.DrawText(e.Graphics, "Bìa Sách", e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void BtnCRUD_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show($"Chức năng {btn.Text} được thực hiện.", "Thông báo");
            // TODO: Thêm logic Thêm, Xóa, Sửa
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            MessageBox.Show($"Thực hiện tìm kiếm với từ khóa: {keyword}", "Tìm kiếm");
            // TODO: Lọc dữ liệu trong dgvSach
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Giả lập load ảnh vào pnlImage
                pnlImage.BackgroundImage = Image.FromFile(open.FileName);
                pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
                MessageBox.Show($"Đã chọn file: {open.SafeFileName}", "Chọn ảnh");
            }
        }
    }
}