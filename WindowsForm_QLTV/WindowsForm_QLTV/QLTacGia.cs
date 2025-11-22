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
        // Biến trạng thái để xác định Mã Tác Giả đang được chọn/sửa (0 nếu là Thêm mới)
        private int currentMaTacGia = 0;

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

            // Cột Mã Tác Giả (Dùng ẩn để lưu ID)
            // LƯU Ý: MinimumWidth phải >= 2
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
                MessageBox.Show("Lỗi tải dữ liệu Tác Giả: " + ex.Message + "\nKiểm tra ConnectionString và dữ liệu trong bảng TACGIA.", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvTacGia.DataSource = null;
            }
        }

        private void ClearInputFields()
        {
            currentMaTacGia = 0; // Reset trạng thái về Thêm mới
            txtTenTacGia.Clear();
            txtQuocTich.Clear();
            txtMoTa.Clear();
            btnLuu.Text = "LƯU (Thêm mới)"; // Đổi Text cho nút Lưu
        }

        // --- Event Handlers ---

        private void DgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTacGia.Rows[e.RowIndex];
                var tacGia = row.DataBoundItem as TACGIA;

                if (tacGia != null)
                {
                    // Load dữ liệu lên Input Panel
                    currentMaTacGia = tacGia.MATG; // Lấy Mã TG đang được chọn (int)
                    txtMaTacGia.Text = tacGia.MATG.ToString(); // HIỂN THỊ MÃ TG
                    txtTenTacGia.Text = tacGia.TENTG;
                    txtQuocTich.Text = tacGia.QUOCTICH;
                    txtMoTa.Text = tacGia.MOTA;

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
                if (string.IsNullOrWhiteSpace(txtTenTacGia.Text) || string.IsNullOrWhiteSpace(txtQuocTich.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên Tác Giả và Quốc Tịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var db = new Model1())
                    {
                        if (currentMaTacGia == 0) // THÊM MỚI
                        {
                            var newTacGia = new TACGIA
                            {
                                TENTG = txtTenTacGia.Text.Trim(),
                                QUOCTICH = txtQuocTich.Text.Trim(),
                                MOTA = txtMoTa.Text.Trim()
                            };
                            db.TACGIAs.Add(newTacGia);
                            db.SaveChanges();
                            MessageBox.Show($"Thêm mới Tác giả {newTacGia.TENTG} thành công!", "Thành công");
                        }
                        else // CẬP NHẬT
                        {
                            var tacGiaToUpdate = db.TACGIAs.Find(currentMaTacGia);
                            if (tacGiaToUpdate != null)
                            {
                                tacGiaToUpdate.TENTG = txtTenTacGia.Text.Trim();
                                tacGiaToUpdate.QUOCTICH = txtQuocTich.Text.Trim();
                                tacGiaToUpdate.MOTA = txtMoTa.Text.Trim();

                                db.Entry(tacGiaToUpdate).State = EntityState.Modified;
                                db.SaveChanges();
                                MessageBox.Show($"Cập nhật Tác giả ID {currentMaTacGia} thành công!", "Thành công");
                            }
                        }
                    }

                    LoadDataTacGia();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi Lưu dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (action == "XÓA")
            {
                if (currentMaTacGia == 0)
                {
                    MessageBox.Show("Vui lòng chọn Tác giả cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Xác nhận xóa Tác giả {txtTenTacGia.Text}? Thao tác này sẽ xóa tất cả sách liên quan!", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (var db = new Model1())
                        {
                            var tacGiaToDelete = db.TACGIAs.Find(currentMaTacGia);
                            if (tacGiaToDelete != null)
                            {
                                // Xóa vật lý
                                db.TACGIAs.Remove(tacGiaToDelete);
                                db.SaveChanges();
                                MessageBox.Show("Đã xóa Tác giả thành công.");
                            }
                        }
                        LoadDataTacGia();
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