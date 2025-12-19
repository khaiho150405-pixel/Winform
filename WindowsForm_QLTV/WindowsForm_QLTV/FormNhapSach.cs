using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class FormNhapSach : Form
    {
        private DataGridView dgvPhieuNhap;
        private DataGridView dgvChiTietNhap;
        private ComboBox cboSach;
        private NumericUpDown numSoLuong;
        private NumericUpDown numGiaNhap;
        private Button btnTaoPhieuMoi;
        private Button btnThemChiTiet;
        private Button btnXoaChiTiet;
        private Button btnLuuPhieu;
        private Button btnHuyPhieu;
        private Label lblTongTien;
        private Label lblThongTinPhieu;

        private int? currentMaPN = null; // Mã phi?u nh?p ?ang làm vi?c

        public FormNhapSach()
        {
            InitializeComponent();
            this.Load += FormNhapSach_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "Qu?n Lý Nh?p Sách";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Panel Tiêu ??
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            Label lblTitle = new Label
            {
                Text = "?? QU?N LÝ NH?P SÁCH",
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

            // === PANEL 1: Danh sách phi?u nh?p ===
            Panel pnlPhieuNhap = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            Label lblDSPhieu = new Label
            {
                Text = "?? DANH SÁCH PHI?U NH?P",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlPhieuNhap.Controls.Add(lblDSPhieu);

            btnTaoPhieuMoi = new Button
            {
                Text = "? T?o phi?u m?i",
                Size = new Size(130, 35),
                Location = new Point(250, 5),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnTaoPhieuMoi.FlatAppearance.BorderSize = 0;
            btnTaoPhieuMoi.Click += BtnTaoPhieuMoi_Click;
            pnlPhieuNhap.Controls.Add(btnTaoPhieuMoi);

            dgvPhieuNhap = new DataGridView
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
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "MAPN", HeaderText = "Mã PN", DataPropertyName = "MAPN", Width = 70 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenThuKho", HeaderText = "Th? Kho", DataPropertyName = "TenThuKho", Width = 150 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "NGAYNHAP", HeaderText = "Ngày Nh?p", DataPropertyName = "NGAYNHAP", Width = 100 });
            dgvPhieuNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "TONGTIEN", HeaderText = "T?ng Ti?n", DataPropertyName = "TONGTIEN", Width = 120 });
            dgvPhieuNhap.CellClick += DgvPhieuNhap_CellClick;
            pnlPhieuNhap.Controls.Add(dgvPhieuNhap);

            // Thông tin phi?u ?ang ch?n
            lblThongTinPhieu = new Label
            {
                Text = "Ch?a ch?n phi?u nào",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(580, 50),
                AutoSize = true
            };
            pnlPhieuNhap.Controls.Add(lblThongTinPhieu);

            splitMain.Panel1.Controls.Add(pnlPhieuNhap);

            // === PANEL 2: Chi ti?t phi?u nh?p ===
            Panel pnlChiTiet = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };

            Label lblChiTiet = new Label
            {
                Text = "?? CHI TI?T PHI?U NH?P",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlChiTiet.Controls.Add(lblChiTiet);

            // Form nh?p chi ti?t
            GroupBox grpNhapChiTiet = new GroupBox
            {
                Text = "Thêm sách vào phi?u",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(10, 40),
                Size = new Size(500, 130)
            };

            Label lblSach = new Label { Text = "Sách:", Location = new Point(15, 30), AutoSize = true };
            cboSach = new ComboBox
            {
                Location = new Point(80, 27),
                Size = new Size(300, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            grpNhapChiTiet.Controls.Add(lblSach);
            grpNhapChiTiet.Controls.Add(cboSach);

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

            Label lblGia = new Label { Text = "Giá nh?p:", Location = new Point(180, 65), AutoSize = true };
            numGiaNhap = new NumericUpDown
            {
                Location = new Point(250, 62),
                Size = new Size(130, 25),
                Minimum = 0,
                Maximum = 100000000,
                DecimalPlaces = 0,
                ThousandsSeparator = true,
                Value = 50000
            };
            grpNhapChiTiet.Controls.Add(lblGia);
            grpNhapChiTiet.Controls.Add(numGiaNhap);

            btnThemChiTiet = new Button
            {
                Text = "? Thêm",
                Size = new Size(80, 30),
                Location = new Point(400, 58),
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
            dgvChiTietNhap = new DataGridView
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
            dgvChiTietNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "MASACH", HeaderText = "Mã Sách", DataPropertyName = "MASACH", Width = 80 });
            dgvChiTietNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach", Width = 250 });
            dgvChiTietNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "SOLUONG", HeaderText = "S? L??ng", DataPropertyName = "SOLUONG", Width = 80 });
            dgvChiTietNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "GIANHAP", HeaderText = "Giá Nh?p", DataPropertyName = "GIANHAP", Width = 100 });
            dgvChiTietNhap.Columns.Add(new DataGridViewTextBoxColumn { Name = "THANHTIEN", HeaderText = "Thành Ti?n", DataPropertyName = "THANHTIEN", Width = 120 });
            pnlChiTiet.Controls.Add(dgvChiTietNhap);

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
                Text = "?? T?NG TI?N: 0 VN?",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 57, 43),
                Location = new Point(400, 390),
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

        private void FormNhapSach_Load(object sender, EventArgs e)
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
            LoadDanhSachPhieuNhap();
            ResetForm();
        }

        private void LoadDanhSachSach()
        {
            try
            {
                using (var db = new Model1())
                {
                    var sachList = db.SACHes.AsNoTracking()
                        .Select(s => new { s.MASACH, DisplayText = s.MASACH + " - " + s.TENSACH })
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

        private void LoadDanhSachPhieuNhap()
        {
            try
            {
                using (var db = new Model1())
                {
                    var phieuList = db.PHIEUNHAPs.AsNoTracking()
                        .Include(p => p.THUKHO)
                        .OrderByDescending(p => p.NGAYNHAP)
                        .Select(p => new
                        {
                            p.MAPN,
                            TenThuKho = p.THUKHO.HOVATEN,
                            NGAYNHAP = p.NGAYNHAP,
                            TONGTIEN = p.TONGTIEN
                        })
                        .ToList();

                    dgvPhieuNhap.DataSource = phieuList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i danh sách phi?u nh?p: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietPhieuNhap(int maPN)
        {
            try
            {
                using (var db = new Model1())
                {
                    var chiTietList = db.CHITIETPHIEUNHAPs.AsNoTracking()
                        .Where(ct => ct.MAPN == maPN)
                        .Include(ct => ct.SACH)
                        .Select(ct => new
                        {
                            ct.MASACH,
                            TenSach = ct.SACH.TENSACH,
                            ct.SOLUONG,
                            ct.GIANHAP,
                            ct.THANHTIEN
                        })
                        .ToList();

                    dgvChiTietNhap.DataSource = chiTietList;
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
                    var phieuMoi = new PHIEUNHAP
                    {
                        MATK = maTK,
                        NGAYNHAP = DateTime.Now,
                        TONGTIEN = 0
                    };

                    db.PHIEUNHAPs.Add(phieuMoi);
                    db.SaveChanges();

                    currentMaPN = phieuMoi.MAPN;
                    lblThongTinPhieu.Text = $"?? ?ang làm vi?c v?i Phi?u #{currentMaPN} - Ngày: {phieuMoi.NGAYNHAP:dd/MM/yyyy}";
                    lblThongTinPhieu.ForeColor = Color.FromArgb(39, 174, 96);

                    LoadDanhSachPhieuNhap();
                    dgvChiTietNhap.DataSource = null;
                    lblTongTien.Text = "?? T?NG TI?N: 0 VN?";

                    MessageBox.Show($"?ã t?o Phi?u Nh?p m?i #{currentMaPN}. Hãy thêm sách vào phi?u.",
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
            if (!currentMaPN.HasValue)
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
                decimal giaNhap = numGiaNhap.Value;

                using (var db = new Model1())
                {
                    // Ki?m tra xem sách ?ã có trong phi?u ch?a
                    var existing = db.CHITIETPHIEUNHAPs.Find(currentMaPN.Value, maSach);
                    if (existing != null)
                    {
                        // C?p nh?t s? l??ng
                        existing.SOLUONG += soLuong;
                        existing.GIANHAP = giaNhap;
                    }
                    else
                    {
                        // Thêm m?i
                        var chiTiet = new CHITIETPHIEUNHAP
                        {
                            MAPN = currentMaPN.Value,
                            MASACH = maSach,
                            SOLUONG = soLuong,
                            GIANHAP = giaNhap
                        };
                        db.CHITIETPHIEUNHAPs.Add(chiTiet);
                    }

                    db.SaveChanges();
                }

                LoadChiTietPhieuNhap(currentMaPN.Value);
                LoadDanhSachPhieuNhap(); // C?p nh?t t?ng ti?n hi?n th?
                numSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i thêm chi ti?t: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (!currentMaPN.HasValue || dgvChiTietNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng ch?n dòng c?n xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nh?n xóa dòng này?", "Xác nh?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maSach = Convert.ToInt32(dgvChiTietNhap.CurrentRow.Cells["MASACH"].Value);

                    using (var db = new Model1())
                    {
                        var chiTiet = db.CHITIETPHIEUNHAPs.Find(currentMaPN.Value, maSach);
                        if (chiTiet != null)
                        {
                            db.CHITIETPHIEUNHAPs.Remove(chiTiet);
                            db.SaveChanges();
                        }
                    }

                    LoadChiTietPhieuNhap(currentMaPN.Value);
                    LoadDanhSachPhieuNhap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i xóa chi ti?t: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (!currentMaPN.HasValue)
            {
                MessageBox.Show("Không có phi?u nào ?? l?u.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Phi?u nh?p #{currentMaPN} ?ã ???c l?u thành công!\nS? l??ng t?n kho ?ã ???c c?p nh?t t? ??ng.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadDanhSachPhieuNhap();
        }

        private void BtnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (!currentMaPN.HasValue)
            {
                ResetForm();
                return;
            }

            if (MessageBox.Show($"B?n có ch?c mu?n h?y phi?u #{currentMaPN}?\nT?t c? chi ti?t s? b? xóa.",
                "Xác nh?n h?y", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        // Xóa chi ti?t tr??c
                        var chiTietList = db.CHITIETPHIEUNHAPs.Where(ct => ct.MAPN == currentMaPN.Value).ToList();
                        db.CHITIETPHIEUNHAPs.RemoveRange(chiTietList);

                        // Xóa phi?u
                        var phieu = db.PHIEUNHAPs.Find(currentMaPN.Value);
                        if (phieu != null)
                        {
                            db.PHIEUNHAPs.Remove(phieu);
                        }

                        db.SaveChanges();
                    }

                    MessageBox.Show("?ã h?y phi?u thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadDanhSachPhieuNhap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i h?y phi?u: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maPN = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells["MAPN"].Value);
                currentMaPN = maPN;

                string ngay = dgvPhieuNhap.Rows[e.RowIndex].Cells["NGAYNHAP"].Value?.ToString();
                lblThongTinPhieu.Text = $"?? ?ang xem Phi?u #{maPN} - Ngày: {ngay}";
                lblThongTinPhieu.ForeColor = Color.FromArgb(52, 152, 219);

                LoadChiTietPhieuNhap(maPN);
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.Cells["THANHTIEN"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["THANHTIEN"].Value);
                }
            }
            lblTongTien.Text = $"?? T?NG TI?N: {tongTien:N0} VN?";
        }

        private void ResetForm()
        {
            currentMaPN = null;
            dgvChiTietNhap.DataSource = null;
            lblThongTinPhieu.Text = "Ch?a ch?n phi?u nào";
            lblThongTinPhieu.ForeColor = Color.Gray;
            lblTongTien.Text = "?? T?NG TI?N: 0 VN?";
            numSoLuong.Value = 1;
            numGiaNhap.Value = 50000;
        }
    }
}
