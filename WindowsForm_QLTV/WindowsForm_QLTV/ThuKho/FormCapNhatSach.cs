using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormCapNhatSach : Form
    {
        private string currentSelectedFileName = string.Empty;
        private int currentMaSach = 0;

        // Controls
        private DataGridView dgvSach;
        private TextBox txtTimKiem, txtTenSach, txtTheLoai, txtMoTa, txtSoLuong, txtGiaMuon;
        private ComboBox cboMaTacGia, cboMaNXB, cboTrangThai;
        private Button btnTimKiem, btnCapNhat, btnChooseFile, btnDong, btnLamMoi;
        private Panel pnlImage;
        private Label lblMaSach;

        public FormCapNhatSach()
        {
            InitializeComponent();
            this.Load += FormCapNhatSach_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "CẬP NHẬT THÔNG TIN SÁCH";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            Label lblTitle = new Label
            {
                Text = "📝 CẬP NHẬT THÔNG TIN SÁCH",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            this.Controls.Add(lblTitle);

            // Search Panel
            Panel pnlSearch = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(400, 40),
                BackColor = Color.Transparent
            };
            Label lblSearch = new Label { Text = "Tìm kiếm:", Location = new Point(0, 8), AutoSize = true };
            txtTimKiem = new TextBox { Location = new Point(80, 5), Size = new Size(220, 25) };
            btnTimKiem = new Button
            {
                Text = "🔍",
                Location = new Point(310, 3),
                Size = new Size(40, 30),
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += btnTimKiem_Click;
            pnlSearch.Controls.AddRange(new Control[] { lblSearch, txtTimKiem, btnTimKiem });
            this.Controls.Add(pnlSearch);

            // DataGridView
            dgvSach = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(580, 480),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 30 }
            };
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã Sách", DataPropertyName = "MaSach", Width = 70 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach", Width = 200 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenTacGia", HeaderText = "Tác Giả", DataPropertyName = "TenTacGia", Width = 120 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "SL Tồn", DataPropertyName = "SoLuongTon", Width = 70 });
            dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 100 });
            dgvSach.CellClick += dgvSach_CellClick;
            this.Controls.Add(dgvSach);

            // Panel thông tin cập nhật
            GroupBox grpCapNhat = new GroupBox
            {
                Text = "Thông tin cần cập nhật",
                Location = new Point(620, 60),
                Size = new Size(450, 470),
                Font = new Font("Segoe UI", 10F)
            };

            int y = 30;
            Label lbl0 = new Label { Text = "Mã Sách:", Location = new Point(15, y), AutoSize = true };
            lblMaSach = new Label { Text = "...", Location = new Point(130, y), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(192, 57, 43) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl0, lblMaSach });

            y += 35;
            Label lbl1 = new Label { Text = "Tên Sách*:", Location = new Point(15, y), AutoSize = true };
            txtTenSach = new TextBox { Location = new Point(130, y - 3), Size = new Size(280, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl1, txtTenSach });

            y += 35;
            Label lbl2 = new Label { Text = "Tác Giả*:", Location = new Point(15, y), AutoSize = true };
            cboMaTacGia = new ComboBox { Location = new Point(130, y - 3), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            grpCapNhat.Controls.AddRange(new Control[] { lbl2, cboMaTacGia });

            y += 35;
            Label lbl3 = new Label { Text = "NXB*:", Location = new Point(15, y), AutoSize = true };
            cboMaNXB = new ComboBox { Location = new Point(130, y - 3), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            grpCapNhat.Controls.AddRange(new Control[] { lbl3, cboMaNXB });

            y += 35;
            Label lbl4 = new Label { Text = "Thể Loại:", Location = new Point(15, y), AutoSize = true };
            txtTheLoai = new TextBox { Location = new Point(130, y - 3), Size = new Size(150, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl4, txtTheLoai });

            y += 35;
            Label lbl5 = new Label { Text = "Số Lượng:", Location = new Point(15, y), AutoSize = true };
            txtSoLuong = new TextBox { Location = new Point(130, y - 3), Size = new Size(100, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl5, txtSoLuong });

            y += 35;
            Label lbl6 = new Label { Text = "Giá Mượn:", Location = new Point(15, y), AutoSize = true };
            txtGiaMuon = new TextBox { Location = new Point(130, y - 3), Size = new Size(100, 25) };
            grpCapNhat.Controls.AddRange(new Control[] { lbl6, txtGiaMuon });

            y += 35;
            Label lbl7 = new Label { Text = "Trạng Thái:", Location = new Point(15, y), AutoSize = true };
            cboTrangThai = new ComboBox
            {
                Location = new Point(130, y - 3),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTrangThai.Items.AddRange(new string[] { "Có sẵn", "Đã hết" });
            cboTrangThai.SelectedIndex = 0;
            grpCapNhat.Controls.AddRange(new Control[] { lbl7, cboTrangThai });

            y += 35;
            Label lbl8 = new Label { Text = "Mô Tả:", Location = new Point(15, y), AutoSize = true };
            txtMoTa = new TextBox { Location = new Point(130, y - 3), Size = new Size(280, 50), Multiline = true };
            grpCapNhat.Controls.AddRange(new Control[] { lbl8, txtMoTa });

            // Panel ảnh
            y += 60;
            pnlImage = new Panel
            {
                Location = new Point(15, y),
                Size = new Size(100, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };
            btnChooseFile = new Button
            {
                Text = "📷 Chọn Ảnh",
                Location = new Point(130, y + 30),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnChooseFile.FlatAppearance.BorderSize = 0;
            btnChooseFile.Click += btnChooseFile_Click;
            grpCapNhat.Controls.AddRange(new Control[] { pnlImage, btnChooseFile });

            this.Controls.Add(grpCapNhat);

            // Buttons
            btnCapNhat = new Button
            {
                Text = "✅ CẬP NHẬT",
                Location = new Point(620, 545),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.Click += btnCapNhat_Click;
            this.Controls.Add(btnCapNhat);

            btnLamMoi = new Button
            {
                Text = "🔄 Làm Mới",
                Location = new Point(785, 545),
                Size = new Size(120, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => ClearInputs();
            this.Controls.Add(btnLamMoi);

            btnDong = new Button
            {
                Text = "✖ Đóng",
                Location = new Point(920, 545),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();
            this.Controls.Add(btnDong);
        }

        private void FormCapNhatSach_Load(object sender, EventArgs e)
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
                    cboMaTacGia.DataSource = tacGiaList;
                    cboMaTacGia.DisplayMember = "TENTG";
                    cboMaTacGia.ValueMember = "MATG";

                    var nxbList = db.NHAXUATBANs.AsNoTracking().ToList();
                    cboMaNXB.DataSource = nxbList;
                    cboMaNXB.DisplayMember = "TENNXB";
                    cboMaNXB.ValueMember = "MANXB";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var sachDetail = dgvSach.Rows[e.RowIndex].DataBoundItem as SachDetailItem;
                if (sachDetail != null)
                {
                    currentMaSach = sachDetail.MaSach;
                    lblMaSach.Text = sachDetail.MaSach.ToString();
                    txtTenSach.Text = sachDetail.TenSach;
                    txtTheLoai.Text = sachDetail.TheLoai;
                    txtMoTa.Text = sachDetail.MoTa;
                    txtSoLuong.Text = sachDetail.SoLuongTon.ToString();
                    txtGiaMuon.Text = sachDetail.GiaMuon.ToString();
                    
                    // Chọn trạng thái trong ComboBox
                    int trangThaiIndex = cboTrangThai.Items.IndexOf(sachDetail.TrangThai);
                    cboTrangThai.SelectedIndex = trangThaiIndex >= 0 ? trangThaiIndex : 0;
                    
                    cboMaTacGia.SelectedValue = sachDetail.MaTacGiaFK;
                    cboMaNXB.SelectedValue = sachDetail.MaNXBFK;
                    currentSelectedFileName = sachDetail.HinhAnhPath ?? "";

                    // Load ảnh
                    pnlImage.BackgroundImage = LoadImageFromLocalFolder(currentSelectedFileName);
                    pnlImage.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }

        private Image LoadImageFromLocalFolder(string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) return null;
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);
                string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", imageFileName);

                string fullPath = File.Exists(path1) ? path1 : (File.Exists(path2) ? path2 : null);
                if (fullPath == null) return null;

                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch { return null; }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataSach(txtTimKiem.Text.Trim());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (currentMaSach <= 0)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Tên sách không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaMuon.Text, out decimal giaMuon) || giaMuon < 0)
            {
                MessageBox.Show("Giá mượn phải là số không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Có sẵn";

            // Nếu chọn "Đã hết" thì bắt buộc số lượng tồn phải = 0,
            // nếu không trigger TG_TRANGTHAI_SACH sẽ tự đổi lại TRANGTHAI = "Có sẵn"
            if (trangThai == "Đã hết" && soLuong > 0)
            {
                var confirm = MessageBox.Show(
                    "Bạn đang chọn trạng thái 'Đã hết' nhưng số lượng tồn > 0.\n\nHệ thống sẽ tự đặt Số lượng tồn = 0 để phù hợp trạng thái.\nBạn có muốn tiếp tục?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                soLuong = 0;
                txtSoLuong.Text = "0";
            }

            // Nếu số lượng tồn = 0 thì ép trạng thái về "Đã hết" để đồng bộ hiển thị ở mọi form
            if (soLuong == 0)
            {
                trangThai = "Đã hết";
                cboTrangThai.SelectedItem = "Đã hết";
            }

            try
            {
                using (var db = new Model1())
                {
                    var sachToUpdate = db.SACHes.Find(currentMaSach);
                    if (sachToUpdate != null)
                    {
                        sachToUpdate.TENSACH = txtTenSach.Text.Trim();
                        sachToUpdate.MATG = (int)cboMaTacGia.SelectedValue;
                        sachToUpdate.MANXB = (int)cboMaNXB.SelectedValue;
                        sachToUpdate.THELOAI = txtTheLoai.Text.Trim();
                        sachToUpdate.SOLUONGTON = soLuong;
                        sachToUpdate.GIAMUON = giaMuon;
                        sachToUpdate.TRANGTHAI = trangThai;
                        sachToUpdate.MOTA = txtMoTa.Text.Trim();
                        sachToUpdate.HINHANH = currentSelectedFileName;

                        db.Entry(sachToUpdate).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show($"✅ Cập nhật sách \"{sachToUpdate.TENSACH}\" thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataSach();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Lỗi sao chép file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            currentMaSach = 0;
            lblMaSach.Text = "...";
            txtTenSach.Text = "";
            txtTheLoai.Text = "";
            txtMoTa.Text = "";
            txtSoLuong.Text = "";
            txtGiaMuon.Text = "";
            cboTrangThai.SelectedIndex = 0;
            currentSelectedFileName = "";
            pnlImage.BackgroundImage = null;
        }
    }
}
