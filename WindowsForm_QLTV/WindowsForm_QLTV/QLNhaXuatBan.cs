using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace WindowsForm_QLTV
{
    public partial class FormQLNXB : Form
    {
        // Biến trạng thái để xác định thao tác là Thêm mới hay Sửa
        private string currentMaNXB = string.Empty;

        public FormQLNXB()
        {
            InitializeComponent();
            this.Load += FormQLNXB_Load;

            // Gán sự kiện cho các nút
            btnThem.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;
            btnLuu.Click += BtnCRUD_Click;
            btnHuy.Click += BtnHuy_Click;

            // Xử lý sự kiện DataGrid
            dgvNXB.CellClick += DgvNXB_CellClick;

            SetupDataGridView();
        }

        private void FormQLNXB_Load(object sender, EventArgs e)
        {
            LoadDataNXB();
            ClearInputFields();
        }

        private void SetupDataGridView()
        {
            dgvNXB.AutoGenerateColumns = false;
            dgvNXB.Columns.Clear();

            // Thêm lại cột MaNXB ẩn để sử dụng trong logic
            dgvNXB.Columns.Add(CreateColumn("MaNXB", "Mã NXB (Ẩn)", 0));
            dgvNXB.Columns["MaNXB"].Visible = false;

            dgvNXB.Columns.Add(CreateColumn("TenNXB", "Tên NXB", 250));
            dgvNXB.Columns.Add(CreateColumn("DiaChi", "Địa Chỉ", 350));
            dgvNXB.Columns.Add(CreateColumn("SDT", "Số Điện Thoại", 150));

            dgvNXB.AllowUserToAddRows = false;
            dgvNXB.ReadOnly = true;
            dgvNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void LoadDataNXB()
        {
            // Thay thế bằng logic truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNXB", typeof(string));
            dt.Columns.Add("TenNXB", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("SDT", typeof(string));

            // Dữ liệu giả lập
            dt.Rows.Add("NXB01", "Kim Đồng", "Quận 3, TP.HCM", "028 1234 5678");
            dt.Rows.Add("NXB02", "Nhã Nam", "Quận Đống Đa, Hà Nội", "024 9876 5432");
            dt.Rows.Add("NXB03", "Trẻ", "Quận 1, TP.HCM", "028 2222 3333");

            dgvNXB.DataSource = dt;
        }

        private void ClearInputFields()
        {
            currentMaNXB = string.Empty; // Reset trạng thái
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            btnLuu.Text = "LƯU (Thêm mới)"; // Đổi Text cho nút Lưu
        }

        // --- Event Handlers ---

        private void DgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNXB.Rows[e.RowIndex];

                // Load dữ liệu lên Input Panel
                currentMaNXB = row.Cells["MaNXB"].Value.ToString(); // Lấy Mã NXB ẩn
                txtTenNXB.Text = row.Cells["TenNXB"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();

                btnLuu.Text = "LƯU (Sửa)";
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

            if (action == "THÊM")
            {
                ClearInputFields();
                currentMaNXB = "[Đang tạo mới]";

            }
            else if (action.StartsWith("LƯU"))
            {
                // Logic kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTenNXB.Text))
                {
                    MessageBox.Show("Tên Nhà Xuất Bản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentMaNXB == "[Đang tạo mới]" || string.IsNullOrEmpty(currentMaNXB))
                {
                    // THÊM MỚI
                    MessageBox.Show($"Thêm mới NXB {txtTenNXB.Text}...", "Thêm mới");
                    // TODO: Thực hiện CSDL INSERT
                }
                else
                {
                    // CẬP NHẬT (Sửa)
                    MessageBox.Show($"Cập nhật NXB ID {currentMaNXB}...", "Cập nhật");
                    // TODO: Thực hiện CSDL UPDATE
                }

                LoadDataNXB();
                ClearInputFields();

            }
            else if (action == "XÓA")
            {
                if (string.IsNullOrWhiteSpace(currentMaNXB) || currentMaNXB == "[Đang tạo mới]")
                {
                    MessageBox.Show("Vui lòng chọn NXB cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show($"Xác nhận xóa NXB {txtTenNXB.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // TODO: Thực hiện CSDL DELETE
                    MessageBox.Show("Đã xóa (giả lập).");
                    LoadDataNXB();
                    ClearInputFields();
                }
            }
        }
    }
}