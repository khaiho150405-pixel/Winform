using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormNhapSachMoi : Form
    {
        private string currentSelectedFileName = string.Empty;

        // Controls
        private Panel pnlMain;
        private Label lblTitle;
        private GroupBox grpNhapThem, grpThemMoi;
        private DataGridView dgvSach;
        private TextBox txtTimKiem, txtSoLuongNhap;
        private Button btnTimKiem, btnNhapThem, btnThemSachMoi, btnChooseFile, btnDong;
        private Label lblMaSach, lblTenSach, lblSoLuongHienTai;

        // Thêm sách mới
        private TextBox txtTenSachMoi, txtTheLoaiMoi, txtMoTaMoi, txtSoLuongMoi, txtGiaMuonMoi, txtTrangThaiMoi;
        private ComboBox cboMaTacGiaMoi, cboMaNXBMoi;
        private Panel pnlImage;

        public FormNhapSachMoi()
        {
            InitializeComponent();
            this.Load += FormNhapSachMoi_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "NHẬP SÁCH";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            lblTitle = new Label
            {
                Text = "📦 QUẢN LÝ NHẬP SÁCH",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // === TAB CONTROL ===
            TabControl tabControl = new TabControl
            {
                Location = new Point(20, 60),
                Size = new Size(1050, 580),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(tabControl);

            // === TAB 1: NHẬP THÊM SÁCH ĐÃ CÓ ===
            TabPage tabNhapThem = new TabPage("📥 Nhập Thêm Sách Đã Có");
            tabControl.TabPages.Add(tabNhapThem);

            // Search
            Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(20, 20), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(100, 17), Size = new Size(200, 25) };
            btnTimKiem = new Button
            {
                Text = "🔍",
                Location = new Point(310, 15),
                Size = new Size(40, 28),
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += btnTimKiem_Click;
            tabNhapThem.Controls.AddRange(new Control[] { lblSearch, txtTimKiem, btnTimKiem });

            // DataGridView
            dgvSach = new DataGridView
            {
                Location = new Point(20, 55),
                Size = new Size(650, 350),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 30 }
            };
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã Sách", DataPropertyName = "MaSach", Width = 80 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach", Width = 250 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenTacGia", HeaderText = "Tác Giả", DataPropertyName = "TenTacGia", Width = 150 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "SL Tồn", DataPropertyName = "SoLuongTon", Width = 80 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 100 });
            dgvSach.CellClick += dgvSach_CellClick;
            tabNhapThem.Controls.Add(dgvSach);

            // Panel thông tin sách đang chọn
            GroupBox grpSachDangChon = new GroupBox
            {
                Text = "Thông tin sách đang chọn",
                Location = new Point(690, 55),
                Size = new Size(330, 200),
                Font = new Font("Segoe UI", 10F)
            };

            Label lbl1 = new Label { Text = "Mã Sách:", Location = new Point(15, 35), AutoSize = true };
            lblMaSach = new Label { Text = "...", Location = new Point(120, 35), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            Label lbl2 = new Label { Text = "Tên Sách:", Location = new Point(15, 70), AutoSize = true };
            lblTenSach = new Label { Text = "...", Location = new Point(120, 70), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), MaximumSize = new Size(200, 0) };

            Label lbl3 = new Label { Text = "SL Hiện Tại:", Location = new Point(15, 120), AutoSize = true };
            lblSoLuongHienTai = new Label { Text = "...", Location = new Point(120, 120), AutoSize = true, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 152, 219) };

            grpSachDangChon.Controls.AddRange(new Control[] { lbl1, lblMaSach, lbl2, lblTenSach, lbl3, lblSoLuongHienTai });
            tabNhapThem.Controls.Add(grpSachDangChon);

            // Panel nhập số lượng
            GroupBox grpNhapSoLuong = new GroupBox
            {
                Text = "Nhập thêm số lượng",
                Location = new Point(690, 270),
                Size = new Size(330, 140),
                Font = new Font("Segoe UI", 10F)
            };

            Label lbl4 = new Label { Text = "Số lượng nhập thêm:", Location = new Point(15, 40), AutoSize = true };
            txtSoLuongNhap = new TextBox { Location = new Point(160, 37), Size = new Size(100, 25), Text = "0" };

            btnNhapThem = new Button
            {
                Text = "✅ NHẬP THÊM",
                Location = new Point(50, 80),
                Size = new Size(220, 45),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnNhapThem.FlatAppearance.BorderSize = 0;
            btnNhapThem.Click += btnNhapThem_Click;

            grpNhapSoLuong.Controls.AddRange(new Control[] { lbl4, txtSoLuongNhap, btnNhapThem });
            tabNhapThem.Controls.Add(grpNhapSoLuong);

            // === TAB 2: THÊM SÁCH MỚI ===
            TabPage tabThemMoi = new TabPage("📚 Thêm Sách Mới");
            tabControl.TabPages.Add(tabThemMoi);

            GroupBox grpThongTinMoi = new GroupBox
            {
                Text = "Thông tin sách mới",
                Location = new Point(20, 20),
                Size = new Size(600, 400),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 35;
            Label lblTenMoi = new Label { Text = "Tên Sách*:", Location = new Point(15, y), AutoSize = true };
            txtTenSachMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(300, 25) };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblTenMoi, txtTenSachMoi });

            y += 40;
            Label lblTacGiaMoi = new Label { Text = "Tác Giả*:", Location = new Point(15, y), AutoSize = true };
            cboMaTacGiaMoi = new ComboBox { Location = new Point(130, y - 3), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblTacGiaMoi, cboMaTacGiaMoi });

            y += 40;
            Label lblNXBMoi = new Label { Text = "NXB*:", Location = new Point(15, y), AutoSize = true };
            cboMaNXBMoi = new ComboBox { Location = new Point(130, y - 3), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblNXBMoi, cboMaNXBMoi });

            y += 40;
            Label lblTheLoaiMoi = new Label { Text = "Thể Loại:", Location = new Point(15, y), AutoSize = true };
            txtTheLoaiMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(200, 25) };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblTheLoaiMoi, txtTheLoaiMoi });

            y += 40;
            Label lblSLMoi = new Label { Text = "Số Lượng*:", Location = new Point(15, y), AutoSize = true };
            txtSoLuongMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(100, 25) };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblSLMoi, txtSoLuongMoi });

            y += 40;
            Label lblGiaMoi = new Label { Text = "Giá Mượn*:", Location = new Point(15, y), AutoSize = true };
            txtGiaMuonMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(100, 25) };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblGiaMoi, txtGiaMuonMoi });

            y += 40;
            Label lblTTMoi = new Label { Text = "Trạng Thái:", Location = new Point(15, y), AutoSize = true };
            txtTrangThaiMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(150, 25), Text = "Có sẵn" };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblTTMoi, txtTrangThaiMoi });

            y += 40;
            Label lblMoTaMoi = new Label { Text = "Mô Tả:", Location = new Point(15, y), AutoSize = true };
            txtMoTaMoi = new TextBox { Location = new Point(130, y - 3), Size = new Size(300, 60), Multiline = true };
            grpThongTinMoi.Controls.AddRange(new Control[] { lblMoTaMoi, txtMoTaMoi });

            tabThemMoi.Controls.Add(grpThongTinMoi);

            // Panel ảnh
            GroupBox grpHinhAnh = new GroupBox
            {
                Text = "Hình ảnh",
                Location = new Point(640, 20),
                Size = new Size(380, 280),
                Font = new Font("Segoe UI", 10F)
            };

            pnlImage = new Panel
            {
                Location = new Point(90, 30),
                Size = new Size(200, 180),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            btnChooseFile = new Button
            {
                Text = "📷 Chọn Ảnh",
                Location = new Point(115, 225),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnChooseFile.FlatAppearance.BorderSize = 0;
            btnChooseFile.Click += btnChooseFile_Click;

            grpHinhAnh.Controls.AddRange(new Control[] { pnlImage, btnChooseFile });
            tabThemMoi.Controls.Add(grpHinhAnh);

            // Nút thêm sách mới
            btnThemSachMoi = new Button
            {
                Text = "📚 THÊM SÁCH MỚI",
                Location = new Point(640, 320),
                Size = new Size(380, 55),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThemSachMoi.FlatAppearance.BorderSize = 0;
            btnThemSachMoi.Click += btnThemSachMoi_Click;
            tabThemMoi.Controls.Add(btnThemSachMoi);

            // Nút đóng
            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(980, 15),
                Size = new Size(90, 35),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += btnDong_Click;
            this.Controls.Add(btnDong);
        }

        private void FormNhapSachMoi_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadDataSach();
        }

        private void LoadComboboxData()
        {
            try
            {
                using (var db = new Model1())
                {
                    var tacGiaList = db.TACGIAs.AsNoTracking().ToList();
                    cboMaTacGiaMoi.DataSource = tacGiaList;
                    cboMaTacGiaMoi.DisplayMember = "TENTG";
                    cboMaTacGiaMoi.ValueMember = "MATG";

                    var nxbList = db.NHAXUATBANs.AsNoTracking().ToList();
                    cboMaNXBMoi.DataSource = nxbList;
                    cboMaNXBMoi.DisplayMember = "TENNXB";
                    cboMaNXBMoi.ValueMember = "MANXB";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ComboBox: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                        MoTa = s.MOTA,
                        HinhAnhPath = s.HINHANH,
                        MaTacGiaFK = s.MATG,
                        MaNXBFK = s.MANXB
                    }).ToList();

                    dgvSach.DataSource = sachList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var sachDetail = dgvSach.Rows[e.RowIndex].DataBoundItem as SachDetailItem;
                if (sachDetail != null)
                {
                    lblMaSach.Text = sachDetail.MaSach.ToString();
                    lblTenSach.Text = sachDetail.TenSach;
                    lblSoLuongHienTai.Text = sachDetail.SoLuongTon.ToString();
                    txtSoLuongNhap.Text = "0";
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataSach(txtTimKiem.Text.Trim());
        }

        // NHẬP THÊM - Cộng số lượng vào sách ĐÃ CÓ
        private void btnNhapThem_Click(object sender, EventArgs e)
        {
            if (lblMaSach.Text == "...")
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(lblMaSach.Text, out int maSach))
            {
                MessageBox.Show("Mã sách không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSoLuongNhap.Text, out int soLuongNhap) || soLuongNhap <= 0)
            {
                MessageBox.Show("Số lượng nhập thêm phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var existingSach = db.SACHes.Find(maSach);
                    if (existingSach != null)
                    {
                        // CỘNG THÊM số lượng tồn - KHÔNG TẠO ID MỚI
                        existingSach.SOLUONGTON += soLuongNhap;
                        db.Entry(existingSach).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show($"✅ Đã nhập thêm {soLuongNhap} cuốn sách \"{existingSach.TENSACH}\".\nSố lượng tồn mới: {existingSach.SOLUONGTON}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataSach();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập thêm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // THÊM SÁCH MỚI - Thêm sách CHƯA CÓ trong CSDL
        private void btnThemSachMoi_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTenSachMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMaTacGiaMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tác giả!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMaNXBMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn NXB!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuongMoi.Text, out int soLuongMoi) || soLuongMoi <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaMuonMoi.Text, out decimal giaMuonMoi) || giaMuonMoi < 0)
            {
                MessageBox.Show("Giá mượn phải là số không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    string tenSachMoi = txtTenSachMoi.Text.Trim();
                    int maTacGiaMoi = (int)cboMaTacGiaMoi.SelectedValue;
                    int maNXBMoi = (int)cboMaNXBMoi.SelectedValue;

                    // Kiểm tra sách đã tồn tại chưa (theo tên, tác giả và NXB)
                    var sachTonTai = db.SACHes.FirstOrDefault(s => s.TENSACH == tenSachMoi && s.MATG == maTacGiaMoi && s.MANXB == maNXBMoi);

                    if (sachTonTai != null)
                    {
                        // Sách đã tồn tại -> Hỏi cộng thêm số lượng
                        var result = MessageBox.Show(
                            $"Sách \"{tenSachMoi}\" đã tồn tại trong hệ thống với:\n- Mã sách: {sachTonTai.MASACH}\n- Số lượng tồn: {sachTonTai.SOLUONGTON}\n\nBạn có muốn cộng thêm {soLuongMoi} cuốn vào số lượng tồn không?",
                            "Sách đã tồn tại",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // CỘNG THÊM số lượng - KHÔNG TẠO ID MỚI
                            sachTonTai.SOLUONGTON += soLuongMoi;
                            db.Entry(sachTonTai).State = EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show($"✅ Đã cộng thêm {soLuongMoi} cuốn.\nSố lượng tồn mới: {sachTonTai.SOLUONGTON}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Tạo sách mới hoàn toàn
                        var newSach = new SACH
                        {
                            TENSACH = tenSachMoi,
                            MATG = maTacGiaMoi,
                            MANXB = maNXBMoi,
                            THELOAI = txtTheLoaiMoi.Text.Trim(),
                            SOLUONGTON = soLuongMoi,
                            GIAMUON = giaMuonMoi,
                            TRANGTHAI = string.IsNullOrWhiteSpace(txtTrangThaiMoi.Text) ? "Có sẵn" : txtTrangThaiMoi.Text.Trim(),
                            MOTA = txtMoTaMoi.Text.Trim(),
                            HINHANH = currentSelectedFileName
                        };

                        db.SACHes.Add(newSach);
                        db.SaveChanges();
                        MessageBox.Show($"✅ Đã thêm sách mới \"{tenSachMoi}\" với mã sách: {newSach.MASACH}\nSố lượng: {soLuongMoi}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadDataSach();
                    ClearInputsMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourcePath = open.FileName;
                    string fileName = Path.GetFileName(sourcePath);

                    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                    string targetDirectory = Path.Combine(projectRoot, "images");

                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);

                    string destinationPath = Path.Combine(targetDirectory, fileName);
                    File.Copy(sourcePath, destinationPath, true);

                    pnlImage.BackgroundImage = Image.FromFile(destinationPath);
                    pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
                    currentSelectedFileName = fileName;

                    MessageBox.Show($"Đã chọn file: {fileName}", "Chọn ảnh thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            lblMaSach.Text = "...";
            lblTenSach.Text = "...";
            lblSoLuongHienTai.Text = "...";
            txtSoLuongNhap.Text = "0";
        }

        private void ClearInputsMoi()
        {
            txtTenSachMoi.Text = "";
            txtSoLuongMoi.Text = "";
            txtGiaMuonMoi.Text = "";
            txtTrangThaiMoi.Text = "Có sẵn";
            txtTheLoaiMoi.Text = "";
            txtMoTaMoi.Text = "";
            currentSelectedFileName = "";
            pnlImage.BackgroundImage = null;
        }
    }
}
