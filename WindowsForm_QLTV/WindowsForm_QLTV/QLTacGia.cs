using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class FormQLTacGia : Form
    {
        public FormQLTacGia()
        {
            InitializeComponent();
            this.Load += FormQLTacGia_Load;

            // Gán sự kiện cho các nút - MỞ FORM RIÊNG
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;  // Nút Lưu -> Cập nhật
            btnHuy.Click += BtnHuy_Click;

            // Xử lý sự kiện DataGrid
            dgvTacGia.CellClick += DgvTacGia_CellClick;

            SetupDataGridView();
        }

        private void FormQLTacGia_Load(object sender, EventArgs e)
        {
            LoadDataTacGia();
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN 3 BUTTON CHÍNH - MỞ FORM RIÊNG
        // ====================================================================

        // Nút "THÊM" - Mở Form thêm tác giả mới
        private void BtnThem_Click(object sender, EventArgs e)
        {
            FormThemTacGia formThem = new FormThemTacGia();
            formThem.FormClosed += (s, args) => LoadDataTacGia();
            formThem.ShowDialog();
        }

        // Nút "LƯU" -> Đổi thành "CẬP NHẬT" - Mở Form cập nhật tác giả
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            FormCapNhatTacGia formCapNhat = new FormCapNhatTacGia();
            formCapNhat.FormClosed += (s, args) => LoadDataTacGia();
            formCapNhat.ShowDialog();
        }

        // Nút "XÓA" - Mở Form xóa tác giả
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            FormXoaTacGia formXoa = new FormXoaTacGia();
            formXoa.FormClosed += (s, args) => LoadDataTacGia();
            formXoa.ShowDialog();
        }

        // Nút "HỦY BỎ" - Làm mới danh sách
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            LoadDataTacGia();
            ClearInputFields();
            MessageBox.Show("Đã làm mới danh sách tác giả.", "Thông báo");
        }

        // ====================================================================
        // THIẾT LẬP DATAGRIDVIEW
        // ====================================================================
        private void SetupDataGridView()
        {
            dgvTacGia.AutoGenerateColumns = false;
            dgvTacGia.Columns.Clear();

            // Cột Mã Tác Giả (Dùng ẩn để lưu ID)
            dgvTacGia.Columns.Add(CreateColumn("MATG", "Mã TG (Ẩn)", 2));
            dgvTacGia.Columns["MATG"].Visible = false;
            dgvTacGia.Columns["MATG"].DataPropertyName = "MATG";

            // Cột hiển thị
            dgvTacGia.Columns.Add(CreateColumn("TENTG", "Tên Tác Giả", 200));
            dgvTacGia.Columns.Add(CreateColumn("QUOCTICH", "Quốc Tịch", 150));
            dgvTacGia.Columns.Add(CreateColumn("MOTA", "Mô Tả", 400));

            dgvTacGia.AllowUserToAddRows = false;
            dgvTacGia.ReadOnly = true;
            dgvTacGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataGridViewTextBoxColumn CreateColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                MinimumWidth = width
            };
        }

        // ====================================================================
        // TẢI DỮ LIỆU TÁC GIẢ
        // ====================================================================
        private void LoadDataTacGia()
        {
            try
            {
                using (var db = new Model1())
                {
                    var tacGiaList = db.TACGIAs
                                       .AsNoTracking()
                                       .OrderBy(tg => tg.MATG)
                                       .ToList();

                    dgvTacGia.DataSource = tacGiaList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Tác Giả: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvTacGia.DataSource = null;
            }
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN CLICK VÀO DÒNG DATAGRIDVIEW
        // ====================================================================
        private void DgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTacGia.Rows[e.RowIndex];
                var tacGia = row.DataBoundItem as TACGIA;

                if (tacGia != null)
                {
                    // Hiển thị thông tin lên các textbox
                    txtMaTacGia.Text = tacGia.MATG.ToString();
                    txtTenTacGia.Text = tacGia.TENTG;
                    txtQuocTich.Text = tacGia.QUOCTICH;
                    txtMoTa.Text = tacGia.MOTA;
                }
            }
        }

        private void ClearInputFields()
        {
            txtMaTacGia.Text = string.Empty;
            txtTenTacGia.Clear();
            txtQuocTich.Clear();
            txtMoTa.Clear();
        }
    }
}