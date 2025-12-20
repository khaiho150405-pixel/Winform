using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class FormQLNXB : Form
    {
        public FormQLNXB()
        {
            InitializeComponent();
            this.Load += FormQLNXB_Load;

            // Gán sự kiện cho các nút - MỞ FORM RIÊNG
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;  // Nút Lưu -> Cập nhật
            btnHuy.Click += BtnHuy_Click;

            // Xử lý sự kiện DataGrid
            dgvNXB.CellClick += DgvNXB_CellClick;

            SetupDataGridView();
        }

        private void FormQLNXB_Load(object sender, EventArgs e)
        {
            LoadDataNXB();
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN 3 BUTTON CHÍNH - MỞ FORM RIÊNG
        // ====================================================================

        // Nút "THÊM" - Mở Form thêm NXB mới
        private void BtnThem_Click(object sender, EventArgs e)
        {
            FormThemNXB formThem = new FormThemNXB();
            formThem.FormClosed += (s, args) => LoadDataNXB();
            formThem.ShowDialog();
        }

        // Nút "LƯU" -> Đổi thành "CẬP NHẬT" - Mở Form cập nhật NXB
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            FormCapNhatNXB formCapNhat = new FormCapNhatNXB();
            formCapNhat.FormClosed += (s, args) => LoadDataNXB();
            formCapNhat.ShowDialog();
        }

        // Nút "XÓA" - Mở Form xóa NXB
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            FormXoaNXB formXoa = new FormXoaNXB();
            formXoa.FormClosed += (s, args) => LoadDataNXB();
            formXoa.ShowDialog();
        }

        // Nút "HỦY BỎ" - Làm mới danh sách
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            LoadDataNXB();
            ClearInputFields();
            MessageBox.Show("Đã làm mới danh sách NXB.", "Thông báo");
        }

        // ====================================================================
        // THIẾT LẬP DATAGRIDVIEW
        // ====================================================================
        private void SetupDataGridView()
        {
            dgvNXB.AutoGenerateColumns = false;
            dgvNXB.Columns.Clear();

            // Cột Mã NXB (Dùng ẩn để lưu ID)
            dgvNXB.Columns.Add(CreateColumn("MANXB", "Mã NXB", 2));
            dgvNXB.Columns["MANXB"].Visible = false;
            dgvNXB.Columns["MANXB"].DataPropertyName = "MANXB";

            // Cột hiển thị
            dgvNXB.Columns.Add(CreateColumn("TENNXB", "Tên NXB", 250));
            dgvNXB.Columns.Add(CreateColumn("DIACHI", "Địa Chỉ", 350));
            dgvNXB.Columns.Add(CreateColumn("SDT", "Số Điện Thoại", 150));

            dgvNXB.AllowUserToAddRows = false;
            dgvNXB.ReadOnly = true;
            dgvNXB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        // TẢI DỮ LIỆU NXB
        // ====================================================================
        private void LoadDataNXB()
        {
            try
            {
                using (var db = new Model1())
                {
                    var nxbList = db.NHAXUATBANs
                                    .AsNoTracking()
                                    .OrderBy(n => n.MANXB)
                                    .ToList();

                    dgvNXB.DataSource = nxbList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu NXB: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvNXB.DataSource = null;
            }
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN CLICK VÀO DÒNG DATAGRIDVIEW
        // ====================================================================
        private void DgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNXB.Rows[e.RowIndex];
                var nxb = row.DataBoundItem as NHAXUATBAN;

                if (nxb != null)
                {
                    // Hiển thị thông tin lên các textbox
                    txtMaNXB.Text = nxb.MANXB.ToString();
                    txtTenNXB.Text = nxb.TENNXB;
                    txtDiaChi.Text = nxb.DIACHI;
                    txtSDT.Text = nxb.SDT;
                }
            }
        }

        private void ClearInputFields()
        {
            txtMaNXB.Text = string.Empty;
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }
    }
}