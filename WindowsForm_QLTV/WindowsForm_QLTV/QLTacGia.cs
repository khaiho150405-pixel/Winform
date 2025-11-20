using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormQLTacGia : Form
    {
        // Biến trạng thái để xác định thao tác là Thêm mới hay Sửa
        private string currentMaTacGia = string.Empty;

        public FormQLTacGia()
        {
            InitializeComponent();
            this.Load += FormQLTacGia_Load;

            // Gán sự kiện cho các nút
            btnThem.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;
            btnLuu.Click += BtnCRUD_Click;
            btnHuy.Click += BtnHuy_Click;

            // Xử lý sự kiện DataGrid
            dgvTacGia.CellClick += DgvTacGia_CellClick;

            SetupDataGridView();
        }

        private void FormQLTacGia_Load(object sender, EventArgs e)
        {
            LoadDataTacGia();
            ClearInputFields();
        }

        private void SetupDataGridView()
        {
            dgvTacGia.AutoGenerateColumns = false;
            dgvTacGia.Columns.Clear();

            // BỎ CỘT MaTacGia
            // Thêm lại cột MaTacGia ẩn để sử dụng trong logic
            dgvTacGia.Columns.Add(CreateColumn("MaTacGia", "Mã TG (Ẩn)", 0));
            dgvTacGia.Columns["MaTacGia"].Visible = false;

            dgvTacGia.Columns.Add(CreateColumn("TenTacGia", "Tên Tác Giả", 200));
            dgvTacGia.Columns.Add(CreateColumn("QuocTich", "Quốc Tịch", 150));
            dgvTacGia.Columns.Add(CreateColumn("MoTa", "Mô Tả", 400));

            dgvTacGia.AllowUserToAddRows = false;
            dgvTacGia.ReadOnly = true;
            dgvTacGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void LoadDataTacGia()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("MaTacGia", typeof(string));
            dt.Columns.Add("TenTacGia", typeof(string));
            dt.Columns.Add("QuocTich", typeof(string));
            dt.Columns.Add("MoTa", typeof(string));

            // Dữ liệu giả lập
            dt.Rows.Add("TG001", "Nguyễn Nhật Ánh", "Việt Nam", "Nhà văn chuyên viết truyện thiếu nhi.");
            dt.Rows.Add("TG002", "J.K. Rowling", "Anh", "Tác giả bộ truyện Harry Potter.");
            dt.Rows.Add("TG003", "Haruki Murakami", "Nhật Bản", "Tiểu thuyết gia nổi tiếng thế giới.");

            dgvTacGia.DataSource = dt;
        }

        private void ClearInputFields()
        {
            currentMaTacGia = string.Empty; // Reset trạng thái
            txtTenTacGia.Clear();
            txtQuocTich.Clear();
            txtMoTa.Clear();
            btnLuu.Text = "Lưu (Thêm mới)"; // Đổi Text cho nút Lưu
        }

        // --- Event Handlers ---

        private void DgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];

                // Load dữ liệu lên Input Panel
                currentMaTacGia = row.Cells["MaTacGia"].Value.ToString(); // Lấy Mã TG ẩn
                txtTenTacGia.Text = row.Cells["TenTacGia"].Value.ToString();
                txtQuocTich.Text = row.Cells["QuocTich"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();

                btnLuu.Text = "Lưu (Sửa)";
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            MessageBox.Show("Đã hủy thao tác, sẵn sàng thêm mới.", "Thông báo");
        }

        private void BtnCRUD_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string action = btn.Text.Trim();

            if (action == "Thêm")
            {
                ClearInputFields();
                currentMaTacGia = "[Đang tạo mới]";

            }
            else if (action == "Lưu (Sửa)" || action == "Lưu (Thêm mới)")
            {
                // Logic kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTenTacGia.Text) || string.IsNullOrWhiteSpace(txtQuocTich.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên Tác Giả và Quốc Tịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentMaTacGia == "[Đang tạo mới]" || string.IsNullOrEmpty(currentMaTacGia))
                {
                    // THÊM MỚI
                    MessageBox.Show($"Thêm mới Tác giả {txtTenTacGia.Text}...", "Thêm mới");
                    // TODO: Thực hiện CSDL INSERT
                }
                else
                {
                    // CẬP NHẬT (Sửa)
                    MessageBox.Show($"Cập nhật Tác giả ID {currentMaTacGia}...", "Cập nhật");
                    // TODO: Thực hiện CSDL UPDATE
                }

                LoadDataTacGia();
                ClearInputFields();

            }
            else if (action == "Xóa")
            {
                if (string.IsNullOrWhiteSpace(currentMaTacGia) || currentMaTacGia == "[Đang tạo mới]")
                {
                    MessageBox.Show("Vui lòng chọn Tác giả cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show($"Xác nhận xóa Tác giả {txtTenTacGia.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Thực hiện CSDL DELETE
                    MessageBox.Show("Đã xóa (giả lập).");
                    LoadDataTacGia();
                    ClearInputFields();
                }
            }
        }
    }
}