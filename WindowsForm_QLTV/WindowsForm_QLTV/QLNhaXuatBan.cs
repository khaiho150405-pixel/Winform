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
        // Biến trạng thái Mã NXB (0 nếu là Thêm mới)
        private int currentMaNXB = 0;

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

            // Cột Mã NXB (Dùng ẩn để lưu ID)
            // SỬA LỖI MinimumWidth: Đặt thành 2
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

        private void LoadDataNXB()
        {
            try
            {
                using (var db = new Model1()) // SỬ DỤNG ENTITY FRAMEWORK
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
                MessageBox.Show("Lỗi tải dữ liệu NXB: " + ex.Message + "\nKiểm tra ConnectionString và dữ liệu trong bảng NHAXUATBAN.", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvNXB.DataSource = null;
            }
        }

        private void ClearInputFields()
        {
            currentMaNXB = 0; // Reset trạng thái về Thêm mới
            txtMaNXB.Text = string.Empty; // Xóa Mã hiển thị
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            btnLuu.Text = "LƯU (Thêm mới)";
        }

        // --- Event Handlers ---

        private void DgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNXB.Rows[e.RowIndex];
                var nxb = row.DataBoundItem as NHAXUATBAN;

                if (nxb != null)
                {
                    // Load dữ liệu lên Input Panel
                    currentMaNXB = nxb.MANXB; // Lấy Mã NXB đang được chọn (int)
                    txtMaNXB.Text = nxb.MANXB.ToString(); // HIỂN THỊ MÃ
                    txtTenNXB.Text = nxb.TENNXB;
                    txtDiaChi.Text = nxb.DIACHI;
                    txtSDT.Text = nxb.SDT;

                    btnLuu.Text = "LƯU (Sửa)";
                }
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
            }
            else if (action.StartsWith("LƯU"))
            {
                // Logic kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTenNXB.Text))
                {
                    MessageBox.Show("Tên Nhà Xuất Bản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var db = new Model1())
                    {
                        if (currentMaNXB == 0) // THÊM MỚI
                        {
                            var newNXB = new NHAXUATBAN
                            {
                                TENNXB = txtTenNXB.Text.Trim(),
                                DIACHI = txtDiaChi.Text.Trim(),
                                SDT = txtSDT.Text.Trim()
                            };
                            db.NHAXUATBANs.Add(newNXB);
                            db.SaveChanges();
                            MessageBox.Show($"Thêm mới NXB {newNXB.TENNXB} thành công!", "Thành công");
                        }
                        else // CẬP NHẬT
                        {
                            var nxbToUpdate = db.NHAXUATBANs.Find(currentMaNXB);
                            if (nxbToUpdate != null)
                            {
                                nxbToUpdate.TENNXB = txtTenNXB.Text.Trim();
                                nxbToUpdate.DIACHI = txtDiaChi.Text.Trim();
                                nxbToUpdate.SDT = txtSDT.Text.Trim();

                                db.Entry(nxbToUpdate).State = EntityState.Modified;
                                db.SaveChanges();
                                MessageBox.Show($"Cập nhật NXB ID {currentMaNXB} thành công!", "Thành công");
                            }
                        }
                    }

                    LoadDataNXB();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi Lưu dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (action == "XÓA")
            {
                if (currentMaNXB == 0)
                {
                    MessageBox.Show("Vui lòng chọn NXB cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Xác nhận xóa NXB {txtTenNXB.Text}? Thao tác này sẽ xóa tất cả sách liên quan!", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new Model1())
                        {
                            var nxbToDelete = db.NHAXUATBANs.Find(currentMaNXB);
                            if (nxbToDelete != null)
                            {
                                // Xóa vật lý
                                db.NHAXUATBANs.Remove(nxbToDelete);
                                db.SaveChanges();
                                MessageBox.Show("Đã xóa NXB thành công.");
                            }
                        }
                        LoadDataNXB();
                        ClearInputFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi Xóa dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}