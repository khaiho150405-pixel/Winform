using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class EditSach : Form
    {
        // Biến lưu trữ tên file ảnh đã chọn (chỉ tên file, không phải full path)
        private string currentSelectedFileName = string.Empty;

        public EditSach()
        {
            InitializeComponent();
            this.Load += FormQLTatCaSach_Load;

            // Gán sự kiện cho 3 nút CRUD chính
            btnThem.Click += BtnCRUD_Click;
            btnCapNhat.Click += BtnCRUD_Click;
            btnXoa.Click += BtnCRUD_Click;

            btnTimKiem.Click += BtnTimKiem_Click;
            btnChooseFile.Click += BtnChooseFile_Click;

            // >> THÊM SỰ KIỆN ĐỂ HIỂN THỊ TÊN TÁC GIẢ/NXB
            cboMaTacGia.SelectedIndexChanged += CboMaTacGia_SelectedIndexChanged;
            cboMaNXB.SelectedIndexChanged += CboMaNXB_SelectedIndexChanged;

            // Thiết lập DataGridView
            SetupDataGridView();
        }

        private void FormQLTatCaSach_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataSach();
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN COMBOBOX (Giữ nguyên)
        // ====================================================================

        private void CboMaTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaTacGia.SelectedItem != null && cboMaTacGia.SelectedItem is TACGIA selectedTacGia)
            {
                lblTenTacGia.Text = selectedTacGia.TENTG;
            }
            else
            {
                lblTenTacGia.Text = string.Empty;
            }
        }

        private void CboMaNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNXB.SelectedItem != null && cboMaNXB.SelectedItem is NHAXUATBAN selectedNXB)
            {
                lblTenNXB.Text = selectedNXB.TENNXB;
            }
            else
            {
                lblTenNXB.Text = string.Empty;
            }
        }

        // ====================================================================
        // KHỞI TẠO DATAGRIDVIEW (Đã thêm cột Mô tả)
        // ====================================================================
        private void SetupDataGridView()
        {
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Columns.Clear();

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Ảnh";
            imgCol.Name = "Anh";
            imgCol.DataPropertyName = "CoverImage";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgCol.Width = 80;
            dgvSach.Columns.Add(imgCol);

            // Thêm các cột còn lại
            dgvSach.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvSach.Columns.Add(CreateColumn("TenSach", "Tên Sách", 200));
            dgvSach.Columns.Add(CreateColumn("TheLoai", "Thể Loại", 100));
            dgvSach.Columns.Add(CreateColumn("TenTacGia", "Tác Giả", 120));
            dgvSach.Columns.Add(CreateColumn("TenNXB", "NXB", 120));
            dgvSach.Columns.Add(CreateColumn("GiaMuon", "Giá Mượn", 80));
            dgvSach.Columns.Add(CreateColumn("SoLuongTon", "SL Tồn", 80));
            dgvSach.Columns.Add(CreateColumn("TrangThai", "Trạng Thái", 100));
            dgvSach.Columns.Add(CreateColumn("MoTa", "Mô tả", 150)); // MỚI: Cột Mô tả

            dgvSach.AllowUserToAddRows = false;
            dgvSach.ReadOnly = true;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.RowTemplate.Height = 80;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.Columns["TenSach"].FillWeight = 150;

            dgvSach.CellClick += DgvSach_CellClick;
        }

        private DataGridViewTextBoxColumn CreateColumn(string name, string header, int minWidth)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                MinimumWidth = minWidth
            };
        }

        // ====================================================================
        // TẢI DỮ LIỆU VÀO COMBOBOX (Giữ nguyên)
        // ====================================================================
        private void LoadComboboxData()
        {
            cboMaTacGia.Items.Clear();
            cboMaNXB.Items.Clear();

            try
            {
                using (var db = new Model1())
                {
                    var tacGiaList = db.TACGIAs.AsNoTracking().ToList();
                    cboMaTacGia.DataSource = tacGiaList;
                    cboMaTacGia.DisplayMember = "MATG";
                    cboMaTacGia.ValueMember = "MATG";

                    var nxbList = db.NHAXUATBANs.AsNoTracking().ToList();
                    cboMaNXB.DataSource = nxbList;
                    cboMaNXB.DisplayMember = "MANXB";
                    cboMaNXB.ValueMember = "MANXB";
                }

                CboMaTacGia_SelectedIndexChanged(cboMaTacGia, EventArgs.Empty);
                CboMaNXB_SelectedIndexChanged(cboMaNXB, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ComboBox: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // TẢI DỮ LIỆU SÁCH VÀO DATAGRIDVIEW
        // ====================================================================
        private void LoadDataSach(string keyword = null)
        {
            try
            {
                using (var db = new Model1())
                {
                    IQueryable<SACH> query = db.SACHes.AsNoTracking();

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query = query.Where(s => s.TENSACH.Contains(keyword) || s.MASACH.ToString() == keyword);
                    }

                    // Thực hiện Join và Projection sang ViewModel
                    var sachList = query.Select(s => new SachDetailItem
                    {
                        MaSach = s.MASACH,
                        TenSach = s.TENSACH,
                        TenTacGia = s.TACGIA.TENTG,
                        TenNXB = s.NHAXUATBAN.TENNXB,
                        TheLoai = s.THELOAI,
                        SoLuongTon = s.SOLUONGTON,
                        GiaMuon = s.GIAMUON,
                        TrangThai = s.TRANGTHAI,
                        MoTa = s.MOTA, // LẤY MÔ TẢ
                        HinhAnhPath = s.HINHANH, // Giữ lại đường dẫn
                        MaTacGiaFK = s.MATG,
                        MaNXBFK = s.MANXB
                    }).ToList();

                    // VÒNG LẶP TẢI ẢNH THỰC TẾ
                    foreach (var item in sachList)
                    {
                        item.CoverImage = LoadImageFromLocalFolder(item.HinhAnhPath);
                    }

                    dgvSach.DataSource = sachList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sách: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // HÀM TẢI ẢNH TỪ THƯ MỤC CỤC BỘ
        // ====================================================================
        private Image LoadImageFromLocalFolder(string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) return null;

            string fullPath = string.Empty;

            try
            {
                // Tùy chọn 1: Thử đường dẫn Project Root (..\..\images)
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);

                // Tùy chọn 2: Thử đường dẫn Executable Root (images)
                string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", imageFileName);

                if (File.Exists(path1))
                {
                    fullPath = path1;
                }
                else if (File.Exists(path2))
                {
                    fullPath = path2;
                }
                else
                {
                    return null;
                }

                // Load ảnh từ MemoryStream để không khóa file
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Position = 0;
                        return Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                return null; // Trả về null nếu lỗi
            }
        }

        // ====================================================================
        // XỬ LÝ SỰ KIỆN CLICK VÀO DÒNG DATAGRIDVIEW
        // ====================================================================
        private void DgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSach.Rows[e.RowIndex];
                var sachDetail = row.DataBoundItem as SachDetailItem;

                if (sachDetail != null)
                {
                    txtTenSach.Text = sachDetail.TenSach;
                    txtSoLuong.Text = sachDetail.SoLuongTon.ToString();
                    txtGiaMuon.Text = sachDetail.GiaMuon.ToString();
                    txtTrangThai.Text = sachDetail.TrangThai;
                    txtTheLoai.Text = sachDetail.TheLoai;
                    txtMoTa.Text = sachDetail.MoTa; // HIỂN THỊ MÔ TẢ

                    // Gán giá trị cho ComboBox dựa trên ValueMember (ID)
                    cboMaTacGia.SelectedValue = sachDetail.MaTacGiaFK;
                    cboMaNXB.SelectedValue = sachDetail.MaNXBFK;

                    // Hiển thị ảnh lớn bên trái (pnlImage)
                    pnlImage.BackgroundImage = sachDetail.CoverImage;
                    pnlImage.BackgroundImageLayout = ImageLayout.Zoom;

                    // Lưu tên file để dùng cho Cập nhật (nếu không chọn file mới)
                    currentSelectedFileName = sachDetail.HinhAnhPath ?? string.Empty;
                }
            }
        }

        private void BtnCRUD_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int maSach = 0;
            if (dgvSach.SelectedRows.Count > 0 && dgvSach.SelectedRows[0].DataBoundItem is SachDetailItem selectedSach)
            {
                maSach = selectedSach.MaSach;
            }

            // Lấy các giá trị cần thiết từ input
            string tenSach = txtTenSach.Text;
            int maTacGia = (int)cboMaTacGia.SelectedValue;
            int maNXB = (int)cboMaNXB.SelectedValue;
            string theLoai = txtTheLoai.Text;
            if (!int.TryParse(txtSoLuong.Text, out int soLuongTon)) soLuongTon = 0;
            if (!decimal.TryParse(txtGiaMuon.Text, out decimal giaMuon)) giaMuon = 0;
            string trangThai = txtTrangThai.Text;
            string moTa = txtMoTa.Text; // LẤY MÔ TẢ

            // Tên file ảnh sẽ được cập nhật trong hàm BtnChooseFile_Click
            string hinhAnhFileName = currentSelectedFileName;

            // TODO: Bổ sung validation cho các trường bắt buộc khác

            try
            {
                using (var db = new Model1())
                {
                    switch (btn.Text)
                    {
                        case "Nhập Sách": // CREATE
                            var newSach = new SACH
                            {
                                TENSACH = tenSach,
                                MATG = maTacGia,
                                MANXB = maNXB,
                                THELOAI = theLoai,
                                SOLUONGTON = soLuongTon,
                                GIAMUON = giaMuon,
                                TRANGTHAI = trangThai,
                                MOTA = moTa, // LƯU MÔ TẢ
                                HINHANH = hinhAnhFileName // LƯU TÊN FILE
                            };
                            db.SACHes.Add(newSach);
                            MessageBox.Show("Thêm sách mới thành công!", "Thông báo");
                            break;
                        case "Cập Nhật": // UPDATE
                            if (maSach > 0)
                            {
                                var sachToUpdate = db.SACHes.Find(maSach);
                                if (sachToUpdate != null)
                                {
                                    sachToUpdate.TENSACH = tenSach;
                                    sachToUpdate.MATG = maTacGia;
                                    sachToUpdate.MANXB = maNXB;
                                    sachToUpdate.THELOAI = theLoai;
                                    sachToUpdate.SOLUONGTON = soLuongTon;
                                    sachToUpdate.GIAMUON = giaMuon;
                                    sachToUpdate.TRANGTHAI = trangThai;
                                    sachToUpdate.MOTA = moTa; // CẬP NHẬT MÔ TẢ
                                    sachToUpdate.HINHANH = hinhAnhFileName; // CẬP NHẬT TÊN FILE
                                    db.Entry(sachToUpdate).State = EntityState.Modified;
                                    MessageBox.Show($"Cập nhật sách {maSach} thành công!", "Thông báo");
                                }
                            }
                            break;
                        case "Thanh Lý": // DELETE/DISABLE
                            if (maSach > 0 && MessageBox.Show($"Xác nhận thanh lý sách mã {maSach}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                var sachToDelete = db.SACHes.Find(maSach);
                                if (sachToDelete != null)
                                {
                                    db.SACHes.Remove(sachToDelete);
                                    MessageBox.Show($"Thanh lý sách {maSach} thành công!", "Thông báo");
                                }
                            }
                            break;
                    }
                    db.SaveChanges(); // Thực hiện thay đổi vào DB
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CRUD: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadDataSach(); // Tải lại lưới
            // Reset trạng thái file sau khi CRUD
            currentSelectedFileName = string.Empty;
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            LoadDataSach(keyword);
        }

        // HÀM CHỌN VÀ LƯU FILE ẢNH
        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourcePath = open.FileName;
                    string fileName = Path.GetFileName(sourcePath);

                    // 1. Xác định thư mục đích (Project Root/image)
                    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                    string targetDirectory = Path.Combine(projectRoot, "images");

                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    string destinationPath = Path.Combine(targetDirectory, fileName);

                    // 2. Copy file (Ghi đè nếu đã tồn tại)
                    File.Copy(sourcePath, destinationPath, true);

                    // 3. Cập nhật UI và biến state
                    pnlImage.BackgroundImage = Image.FromFile(destinationPath);
                    pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
                    currentSelectedFileName = fileName; // LƯU TÊN FILE VÀO STATE

                    MessageBox.Show($"Đã chọn và lưu file: {fileName} vào thư mục project.", "Chọn ảnh thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}