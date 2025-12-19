using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class FormThanhLySach : Form
    {
        private DataGridView dgvPhieuThanhLy;
        private DataGridView dgvChiTietThanhLy;
        private ComboBox cboSach;
        private NumericUpDown numSoLuong;
        private NumericUpDown numDonGia;
        private Button btnTaoPhieuMoi;
        private Button btnThemChiTiet;
        private Button btnXoaChiTiet;
        private Button btnLuuPhieu;
        private Button btnHuyPhieu;
        private Label lblTongTien;
        private Label lblThongTinPhieu;
        private Label lblSoLuongTon;

        private int? currentMaTL = null; // Mã phi?u thanh lý ?ang làm vi?c

        public FormThanhLySach()
        {
            InitializeComponent();
            this.Load += FormThanhLySach_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Qu?n Lý Thanh Lý Sách";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Panel Tiêu ??
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(192, 57, 43)
            };

            Label lblTitle = new Label
            {
                Text = "??? QU?N LÝ THANH LÝ SÁCH",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // Split Container
            SplitContainer splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 250,
                Panel1MinSize = 200,
                Panel2MinSize = 300
            };
            this.Controls.Add(splitMain);

            // === PANEL 1: Danh sách phi?u thanh lý ===
            Panel pnlPhieuTL = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            Label lblDSPhieu = new Label
            {
                Text = "?? DANH SÁCH PHI?U THANH LÝ",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlPhieuTL.Controls.Add(lblDSPhieu);

            btnTaoPhieuMoi = new Button
            {
                Text = "? T?o phi?u m?i",
                Size = new Size(130, 35),
                Location = new Point(280, 5),
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnTaoPhieuMoi.FlatAppearance.BorderSize = 0;
            btnTaoPhieuMoi.Click += BtnTaoPhieuMoi_Click;
            pnlPhieuTL.Controls.Add(btnTaoPhieuMoi);

            dgvPhieuThanhLy = new DataGridView
            {
                Location = new Point(10, 45),
                Size = new Size(550, 180),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            dgvPhieuThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "MATL", HeaderText = "Mã TL", DataPropertyName = "MATL", Width = 70 });
            dgvPhieuThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenThuKho", HeaderText = "Th? Kho", DataPropertyName = "TenThuKho", Width = 150 });
            dgvPhieuThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "NGAYLAP", HeaderText = "Ngày L?p", DataPropertyName = "NGAYLAP", Width = 100 });
            dgvPhieuThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TONGTIEN", HeaderText = "T?ng Ti?n", DataPropertyName = "TONGTIEN", Width = 120 });
            dgvPhieuThanhLy.CellClick += DgvPhieuThanhLy_CellClick;
            pnlPhieuTL.Controls.Add(dgvPhieuThanhLy);

            // Thông tin phi?u ?ang ch?n
            lblThongTinPhieu = new Label
            {
                Text = "Ch?a ch?n phi?u nào",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(580, 50),
                AutoSize = true
            };
            pnlPhieuTL.Controls.Add(lblThongTinPhieu);

            splitMain.Panel1.Controls.Add(pnlPhieuTL);

            // === PANEL 2: Chi ti?t phi?u thanh lý ===
            Panel pnlChiTiet = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            Label lblChiTiet = new Label
            {
                Text = "?? CHI TI?T PHI?U THANH LÝ",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlChiTiet.Controls.Add(lblChiTiet);

            // Form nh?p chi ti?t
            GroupBox grpNhapChiTiet = new GroupBox
            {
                Text = "Thêm sách c?n thanh lý",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(10, 40),
                Size = new Size(550, 130)
            };

            Label lblSach = new Label { Text = "Sách:", Location = new Point(15, 30), AutoSize = true };
            cboSach = new ComboBox
            {
                Location = new Point(80, 27),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboSach.SelectedIndexChanged += CboSach_SelectedIndexChanged;
            grpNhapChiTiet.Controls.Add(lblSach);
            grpNhapChiTiet.Controls.Add(cboSach);

            lblSoLuongTon = new Label
            {
                Text = "T?n kho: 0",
                Location = new Point(390, 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(52, 152, 219),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            grpNhapChiTiet.Controls.Add(lblSoLuongTon);

            Label lblSL = new Label { Text = "S? l??ng:", Location = new Point(15, 65), AutoSize = true };
            numSoLuong = new NumericUpDown
            {
                Location = new Point(80, 62),
                Size = new Size(80, 25),
                Minimum = 1,
                Maximum = 1000,
                Value = 1
            };
            grpNhapChiTiet.Controls.Add(lblSL);
            grpNhapChiTiet.Controls.Add(numSoLuong);

            Label lblGia = new Label { Text = "??n giá TL:", Location = new Point(180, 65), AutoSize = true };
            numDonGia = new NumericUpDown
            {
                Location = new Point(260, 62),
                Size = new Size(130, 25),
                Minimum = 0,
                Maximum = 100000000,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                Value = 10000
            };
            grpNhapChiTiet.Controls.Add(lblGia);
            grpNhapChiTiet.Controls.Add(numDonGia);

            btnThemChiTiet = new Button
            {
                Text = "? Thêm",
                Size = new Size(80, 30),
                Location = new Point(410, 58),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThemChiTiet.FlatAppearance.BorderSize = 0;
            btnThemChiTiet.Click += BtnThemChiTiet_Click;
            grpNhapChiTiet.Controls.Add(btnThemChiTiet);

            pnlChiTiet.Controls.Add(grpNhapChiTiet);

            // DataGridView chi ti?t
            dgvChiTietThanhLy = new DataGridView
            {
                Location = new Point(10, 180),
                Size = new Size(700, 200),
                AutoGenerateColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            dgvChiTietThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "MASACH", HeaderText = "Mã Sách", DataPropertyName = "MASACH", Width = 80 });
            dgvChiTietThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach", Width = 250 });
            dgvChiTietThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "SOLUONG", HeaderText = "S? L??ng", DataPropertyName = "SOLUONG", Width = 80 });
            dgvChiTietThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "DONGIA", HeaderText = "??n Giá", DataPropertyName = "DONGIA", Width = 100 });
            dgvChiTietThanhLy.Columns.Add(new DataGridViewTextBoxColumn { Name = "THANHTIEN", HeaderText = "Thành Ti?n", DataPropertyName = "THANHTIEN", Width = 120 });
            pnlChiTiet.Controls.Add(dgvChiTietThanhLy);

            // Nút xóa chi ti?t
            btnXoaChiTiet = new Button
            {
                Text = "??? Xóa dòng ?ã ch?n",
                Size = new Size(150, 35),
                Location = new Point(10, 390),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnXoaChiTiet.FlatAppearance.BorderSize = 0;
            btnXoaChiTiet.Click += BtnXoaChiTiet_Click;
            pnlChiTiet.Controls.Add(btnXoaChiTiet);

            // T?ng ti?n
            lblTongTien = new Label
            {
                Text = "?? T?NG TI?N THANH LÝ: 0 VN?",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 57, 43),
                Location = new Point(350, 390),
                AutoSize = true
            };
            pnlChiTiet.Controls.Add(lblTongTien);

            // Nút L?u / H?y
            btnLuuPhieu = new Button
            {
                Text = "?? L?u Phi?u",
                Size = new Size(120, 40),
                Location = new Point(750, 180),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLuuPhieu.FlatAppearance.BorderSize = 0;
            btnLuuPhieu.Click += BtnLuuPhieu_Click;
            pnlChiTiet.Controls.Add(btnLuuPhieu);

            btnHuyPhieu = new Button
            {
                Text = "? H?y Phi?u",
                Size = new Size(120, 40),
                Location = new Point(750, 230),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnHuyPhieu.FlatAppearance.BorderSize = 0;
            btnHuyPhieu.Click += BtnHuyPhieu_Click;
            pnlChiTiet.Controls.Add(btnHuyPhieu);

            splitMain.Panel2.Controls.Add(pnlChiTiet);
        }

        private void FormThanhLySach_Load(object sender, EventArgs e)
        {
            // Ki?m tra quy?n th? kho
            if (Session.CurrentMaTK <= 0 && !Session.IsAdmin())
            {
                MessageBox.Show("B?n c?n ??ng nh?p b?ng tài kho?n Th? kho ?? s? d?ng ch?c n?ng này.",
                    "L?i xác th?c", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadDanhSachSach();
            LoadDanhSachPhieuThanhLy();
            ResetForm();
        }

        private void LoadDanhSachSach()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Ch? hi?n th? sách có t?n kho > 0
                    var sachList = db.SACHes.AsNoTracking()
                        .Where(s => s.SOLUONGTON > 0)
                        .Select(s => new
                        {
                            s.MASACH,
                            DisplayText = s.MASACH + " - " + s.TENSACH + " (T?n: " + s.SOLUONGTON + ")",
                            s.SOLUONGTON
                        })
                        .ToList();

                    cboSach.DataSource = sachList;
                    cboSach.DisplayMember = "DisplayText";
                    cboSach.ValueMember = "MASACH";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i danh sách sách: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue != null)
            {
                try
                {
                    int maSach = (int)cboSach.SelectedValue;
                    using (var db = new Model1())
                    {
                        var sach = db.SACHes.Find(maSach);
                        if (sach != null)
                        {
                            lblSoLuongTon.Text = $"T?n kho: {sach.SOLUONGTON}";
                            numSoLuong.Maximum = sach.SOLUONGTON;
                            if (numSoLuong.Value > sach.SOLUONGTON)
                                numSoLuong.Value = sach.SOLUONGTON;
                        }
                    }
                }
                catch { }
            }
        }

        private void LoadDanhSachPhieuThanhLy()
        {
            try
            {
                using (var db = new Model1())
                {
                    var phieuList = db.THANHLies.AsNoTracking()
                        .Include(p => p.THUKHO)
                        .OrderByDescending(p => p.NGAYLAP)
                        .Select(p => new
                        {
                            p.MATL,
                            TenThuKho = p.THUKHO.HOVATEN,
                            NGAYLAP = p.NGAYLAP,
                            TONGTIEN = p.TONGTIEN
                        })
                        .ToList();

                    dgvPhieuThanhLy.DataSource = phieuList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i danh sách phi?u thanh lý: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietPhieuThanhLy(int maTL)
        {
            try
            {
                using (var db = new Model1())
                {
                    var chiTietList = db.CHITIETTHANHLies.AsNoTracking()
                        .Where(ct => ct.MATL == maTL)
                        .Include(ct => ct.SACH)
                        .Select(ct => new
                        {
                            ct.MASACH,
                            TenSach = ct.SACH.TENSACH,
                            ct.SOLUONG,
                            ct.DONGIA,
                            ct.THANHTIEN
                        })
                        .ToList();

                    dgvChiTietThanhLy.DataSource = chiTietList;
                    UpdateTongTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i chi ti?t phi?u: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTaoPhieuMoi_Click(object sender, EventArgs e)
        {
            try
            {
                int maTK = Session.CurrentMaTK > 0 ? Session.CurrentMaTK : 1; // Fallback cho Admin

                using (var db = new Model1())
                {
                    var phieuMoi = new THANHLY
                    {
                        MATK = maTK,
                        NGAYLAP = DateTime.Now,
                        TONGTIEN = 0
                    };

                    db.THANHLies.Add(phieuMoi);
                    db.SaveChanges();

                    currentMaTL = phieuMoi.MATL;
                    lblThongTinPhieu.Text = $"?? ?ang làm vi?c v?i Phi?u Thanh Lý #{currentMaTL} - Ngày: {phieuMoi.NGAYLAP:dd/MM/yyyy}";
                    lblThongTinPhieu.ForeColor = Color.FromArgb(192, 57, 43);

                    LoadDanhSachPhieuThanhLy();
                    dgvChiTietThanhLy.DataSource = null;
                    lblTongTien.Text = "?? T?NG TI?N THANH LÝ: 0 VN?";

                    MessageBox.Show($"?ã t?o Phi?u Thanh Lý m?i #{currentMaTL}. Hãy thêm sách c?n thanh lý.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?o phi?u m?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (!currentMaTL.HasValue)
            {
                MessageBox.Show("Vui lòng t?o phi?u m?i ho?c ch?n phi?u c?n thêm chi ti?t.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng ch?n sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maSach = (int)cboSach.SelectedValue;
                int soLuong = (int)numSoLuong.Value;
                decimal donGia = numDonGia.Value;

                // Ki?m tra s? l??ng t?n kho
                using (var db = new Model1())
                {
                    var sach = db.SACHes.Find(maSach);
                    if (sach == null || sach.SOLUONGTON < soLuong)
                    {
                        MessageBox.Show($"S? l??ng thanh lý ({soLuong}) v??t quá s? l??ng t?n kho ({sach?.SOLUONGTON ?? 0}).",
                            "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ki?m tra xem sách ?ã có trong phi?u ch?a
                    var existing = db.CHITIETTHANHLies.Find(currentMaTL.Value, maSach);
                    if (existing != null)
                    {
                        // Ki?m tra t?ng s? l??ng
                        if (existing.SOLUONG + soLuong > sach.SOLUONGTON)
                        {
                            MessageBox.Show($"T?ng s? l??ng thanh lý v??t quá t?n kho.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        existing.SOLUONG += soLuong;
                        existing.DONGIA = donGia;
                    }
                    else
                    {
                        // Thêm m?i
                        var chiTiet = new CHITIETTHANHLY
                        {
                            MATL = currentMaTL.Value,
                            MASACH = maSach,
                            SOLUONG = soLuong,
                            DONGIA = donGia
                        };
                        db.CHITIETTHANHLies.Add(chiTiet);
                    }

                    db.SaveChanges();
                }

                LoadChiTietPhieuThanhLy(currentMaTL.Value);
                LoadDanhSachPhieuThanhLy();
                LoadDanhSachSach(); // C?p nh?t l?i t?n kho hi?n th?
                numSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i thêm chi ti?t: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (!currentMaTL.HasValue || dgvChiTietThanhLy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng ch?n dòng c?n xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nh?n xóa dòng này? S? l??ng t?n kho s? ???c hoàn l?i.",
                "Xác nh?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maSach = Convert.ToInt32(dgvChiTietThanhLy.CurrentRow.Cells["MASACH"].Value);

                    using (var db = new Model1())
                    {
                        var chiTiet = db.CHITIETTHANHLies.Find(currentMaTL.Value, maSach);
                        if (chiTiet != null)
                        {
                            db.CHITIETTHANHLies.Remove(chiTiet);
                            db.SaveChanges();
                        }
                    }

                    LoadChiTietPhieuThanhLy(currentMaTL.Value);
                    LoadDanhSachPhieuThanhLy();
                    LoadDanhSachSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i xóa chi ti?t: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (!currentMaTL.HasValue)
            {
                MessageBox.Show("Không có phi?u nào ?? l?u.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Phi?u thanh lý #{currentMaTL} ?ã ???c l?u thành công!\nS? l??ng t?n kho ?ã ???c tr? t? ??ng.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadDanhSachPhieuThanhLy();
            LoadDanhSachSach();
        }

        private void BtnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (!currentMaTL.HasValue)
            {
                ResetForm();
                return;
            }

            if (MessageBox.Show($"B?n có ch?c mu?n h?y phi?u #{currentMaTL}?\nT?t c? chi ti?t s? b? xóa và t?n kho s? ???c hoàn l?i.",
                "Xác nh?n h?y", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        // Xóa chi ti?t tr??c (trigger s? hoàn l?i t?n kho)
                        var chiTietList = db.CHITIETTHANHLies.Where(ct => ct.MATL == currentMaTL.Value).ToList();
                        db.CHITIETTHANHLies.RemoveRange(chiTietList);

                        // Xóa phi?u
                        var phieu = db.THANHLies.Find(currentMaTL.Value);
                        if (phieu != null)
                        {
                            db.THANHLies.Remove(phieu);
                        }

                        db.SaveChanges();
                    }

                    MessageBox.Show("?ã h?y phi?u thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadDanhSachPhieuThanhLy();
                    LoadDanhSachSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i h?y phi?u: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvPhieuThanhLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maTL = Convert.ToInt32(dgvPhieuThanhLy.Rows[e.RowIndex].Cells["MATL"].Value);
                currentMaTL = maTL;

                string ngay = dgvPhieuThanhLy.Rows[e.RowIndex].Cells["NGAYLAP"].Value?.ToString();
                lblThongTinPhieu.Text = $"?? ?ang xem Phi?u #{maTL} - Ngày: {ngay}";
                lblThongTinPhieu.ForeColor = Color.FromArgb(52, 152, 219);

                LoadChiTietPhieuThanhLy(maTL);
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietThanhLy.Rows)
            {
                if (row.Cells["THANHTIEN"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["THANHTIEN"].Value);
                }
            }
            lblTongTien.Text = $"?? T?NG TI?N THANH LÝ: {tongTien:N0} VN?";
        }

        private void ResetForm()
        {
            currentMaTL = null;
            dgvChiTietThanhLy.DataSource = null;
            lblThongTinPhieu.Text = "Ch?a ch?n phi?u nào";
            lblThongTinPhieu.ForeColor = Color.Gray;
            lblTongTien.Text = "?? T?NG TI?N THANH LÝ: 0 VN?";
            numSoLuong.Value = 1;
            numDonGia.Value = 10000;
        }
    }
}
