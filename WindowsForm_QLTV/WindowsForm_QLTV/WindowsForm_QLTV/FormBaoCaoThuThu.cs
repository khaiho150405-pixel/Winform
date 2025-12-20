using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    /// <summary>
    /// Form Báo cáo dành cho TH? TH? - T?o và g?i báo cáo cho Admin
    /// </summary>
    public partial class FormBaoCaoThuThu : Form
    {
        private Model1 db = new Model1();
        private string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        // Controls
        private Panel pnlHeader;
        private Panel pnlFilters;
        private TabControl tabControl;
        private DateTimePicker dtpTuNgay, dtpDenNgay;
        private ComboBox cboLoaiBaoCao;
        private Button btnTaoBaoCao, btnGuiBaoCao, btnLamMoi;
        private TextBox txtGhiChu;
        private DataGridView dgvChiTiet, dgvMuonTheoNgay, dgvTheLoai, dgvTopSach;
        private Label lblTongMuon, lblTongTra, lblSachConMuon, lblDocGiaHoatDong;
        private Label lblTrangThai;

        public FormBaoCaoThuThu()
        {
            InitializeComponent();
            this.Load += FormBaoCaoThuThu_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "T?O BÁO CÁO TH?NG KÊ - TH? TH?";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // ============ HEADER ============
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(41, 128, 185)
            };

            Label lblTitle = new Label
            {
                Text = "?? T?O BÁO CÁO TH?NG KÊ",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 22)
            };
            pnlHeader.Controls.Add(lblTitle);

            lblTrangThai = new Label
            {
                Text = "Vai tro: Thu Thu",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(900, 30)
            };
            pnlHeader.Controls.Add(lblTrangThai);

            this.Controls.Add(pnlHeader);

            // ============ FILTER PANEL ============
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 130,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            // Row 1: Filters
            Label lblTuNgay = new Label { Text = "Tu ngay:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpTuNgay = new DateTimePicker
            {
                Location = new Point(90, 17),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };

            Label lblDenNgay = new Label { Text = "Den ngay:", Location = new Point(260, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpDenNgay = new DateTimePicker
            {
                Location = new Point(340, 17),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            Label lblLoai = new Label { Text = "Loai bao cao:", Location = new Point(510, 20), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            cboLoaiBaoCao = new ComboBox
            {
                Location = new Point(610, 17),
                Size = new Size(180, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cboLoaiBaoCao.Items.AddRange(new object[] { "Tong quan", "Muon sach theo ngay", "The loai pho bien", "Top sach muon nhieu", "Doc gia tich cuc" });
            cboLoaiBaoCao.SelectedIndex = 0;

            btnTaoBaoCao = new Button
            {
                Text = "?? Tao bao cao",
                Location = new Point(820, 12),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTaoBaoCao.FlatAppearance.BorderSize = 0;
            btnTaoBaoCao.Click += btnTaoBaoCao_Click;

            btnLamMoi = new Button
            {
                Text = "??",
                Location = new Point(960, 12),
                Size = new Size(50, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => LoadBaoCaoTongQuan();

            // Row 2: Ghi chu va Gui bao cao
            Label lblGhiChu = new Label { Text = "Ghi chu:", Location = new Point(20, 70), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            txtGhiChu = new TextBox
            {
                Location = new Point(90, 67),
                Size = new Size(700, 30),
                Font = new Font("Segoe UI", 10F)
            };

            btnGuiBaoCao = new Button
            {
                Text = "?? GUI BAO CAO CHO ADMIN",
                Location = new Point(820, 60),
                Size = new Size(250, 45),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuiBaoCao.FlatAppearance.BorderSize = 0;
            btnGuiBaoCao.Click += btnGuiBaoCao_Click;

            pnlFilters.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, lblLoai, cboLoaiBaoCao, btnTaoBaoCao, btnLamMoi, lblGhiChu, txtGhiChu, btnGuiBaoCao });
            this.Controls.Add(pnlFilters);

            // ============ SUMMARY CARDS ============
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(240, 244, 247),
                Padding = new Padding(20, 10, 20, 10)
            };

            Panel card1 = CreateSummaryCard("?? TONG PHIEU MUON", "0", Color.FromArgb(52, 152, 219), new Point(20, 10));
            lblTongMuon = card1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card2 = CreateSummaryCard("?? TONG PHIEU TRA", "0", Color.FromArgb(46, 204, 113), new Point(290, 10));
            lblTongTra = card2.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card3 = CreateSummaryCard("?? DANG MUON", "0", Color.FromArgb(230, 126, 34), new Point(560, 10));
            lblSachConMuon = card3.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card4 = CreateSummaryCard("?? DOC GIA", "0", Color.FromArgb(155, 89, 182), new Point(830, 10));
            lblDocGiaHoatDong = card4.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            pnlSummary.Controls.AddRange(new Control[] { card1, card2, card3, card4 });
            this.Controls.Add(pnlSummary);

            // ============ TAB CONTROL ============
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            TabPage tabMuonTheoNgay = new TabPage("?? Muon theo ngay");
            dgvMuonTheoNgay = CreateStyledDataGridView();
            tabMuonTheoNgay.Controls.Add(dgvMuonTheoNgay);

            TabPage tabTheLoai = new TabPage("?? The loai pho bien");
            dgvTheLoai = CreateStyledDataGridView();
            tabTheLoai.Controls.Add(dgvTheLoai);

            TabPage tabTopSach = new TabPage("?? Top sach muon nhieu");
            dgvTopSach = CreateStyledDataGridView();
            tabTopSach.Controls.Add(dgvTopSach);

            TabPage tabData = new TabPage("?? Chi tiet phieu muon");
            dgvChiTiet = CreateStyledDataGridView();
            tabData.Controls.Add(dgvChiTiet);

            tabControl.TabPages.AddRange(new TabPage[] { tabMuonTheoNgay, tabTheLoai, tabTopSach, tabData });
            this.Controls.Add(tabControl);

            pnlFilters.BringToFront();
            pnlHeader.BringToFront();
        }

        private DataGridView CreateStyledDataGridView()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true
            };
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgv.RowTemplate.Height = 35;
            return dgv;
        }

        private Panel CreateSummaryCard(string title, string value, Color color, Point location)
        {
            Panel card = new Panel
            {
                Size = new Size(250, 85),
                Location = location,
                BackColor = Color.White
            };

            Panel colorStrip = new Panel
            {
                Size = new Size(6, 85),
                Location = new Point(0, 0),
                BackColor = color
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(15, 12),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Name = "lblValue",
                Text = value,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 38),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { colorStrip, lblTitle, lblValue });
            return card;
        }

        private void FormBaoCaoThuThu_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            LoadBaoCaoTongQuan();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            string loaiBaoCao = cboLoaiBaoCao.SelectedItem?.ToString() ?? "Tong quan";

            switch (loaiBaoCao)
            {
                case "Tong quan":
                    LoadBaoCaoTongQuan();
                    break;
                case "Muon sach theo ngay":
                    LoadBaoCaoMuonTheoNgay();
                    tabControl.SelectedIndex = 0;
                    break;
                case "The loai pho bien":
                    LoadBaoCaoTheLoai();
                    tabControl.SelectedIndex = 1;
                    break;
                case "Top sach muon nhieu":
                    LoadBaoCaoTopSach();
                    tabControl.SelectedIndex = 2;
                    break;
                case "Doc gia tich cuc":
                    LoadBaoCaoDocGiaTichCuc();
                    tabControl.SelectedIndex = 3;
                    break;
            }
        }

        private void LoadBaoCaoTongQuan()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                int tongMuon = db.PHIEUMUONs.Count(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay);
                int tongTra = db.PHIEUTRAs.Count(pt => pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay);
                int dangMuon = db.PHIEUMUONs.Count(pm => pm.TRANGTHAI == "Dang muon" || pm.TRANGTHAI == "Da duyet");
                int docGia = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                                          .Select(pm => pm.MASV).Distinct().Count();

                lblTongMuon.Text = tongMuon.ToString();
                lblTongTra.Text = tongTra.ToString();
                lblSachConMuon.Text = dangMuon.ToString();
                lblDocGiaHoatDong.Text = docGia.ToString();

                LoadBaoCaoMuonTheoNgay();
                LoadBaoCaoTheLoai();
                LoadBaoCaoTopSach();
                LoadChiTietMuonTra(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai bao cao: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaoCaoMuonTheoNgay()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var data = db.PHIEUMUONs
                .Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                .GroupBy(pm => DbFunctions.TruncateTime(pm.NGAYLAPPHIEUMUON))
                .Select(g => new { Ngay = g.Key, SoPhieuMuon = g.Count() })
                .OrderBy(x => x.Ngay)
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ngay", typeof(string));
            dt.Columns.Add("So Phieu Muon", typeof(int));

            foreach (var item in data)
            {
                dt.Rows.Add(item.Ngay.HasValue ? item.Ngay.Value.ToString("dd/MM/yyyy") : "", item.SoPhieuMuon);
            }

            dgvMuonTheoNgay.DataSource = dt;
        }

        private void LoadBaoCaoTheLoai()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var data = (from ct in db.CHITIETPHIEUMUONs
                        join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        group ct by s.THELOAI into g
                        select new { TheLoai = g.Key ?? "Chua phan loai", SoLuong = g.Count() })
                       .OrderByDescending(x => x.SoLuong)
                       .ToList();

            int tongSoLuong = data.Sum(x => x.SoLuong);

            DataTable dt = new DataTable();
            dt.Columns.Add("The Loai", typeof(string));
            dt.Columns.Add("So Luong", typeof(int));
            dt.Columns.Add("Ty Le", typeof(string));

            foreach (var item in data)
            {
                string tyLe = tongSoLuong > 0 ? string.Format("{0:F1}%", item.SoLuong * 100.0 / tongSoLuong) : "0%";
                dt.Rows.Add(item.TheLoai, item.SoLuong, tyLe);
            }

            dgvTheLoai.DataSource = dt;
        }

        private void LoadBaoCaoTopSach()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var data = (from ct in db.CHITIETPHIEUMUONs
                        join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        group ct by new { s.MASACH, s.TENSACH } into g
                        select new { MaSach = g.Key.MASACH, TenSach = g.Key.TENSACH, SoLuotMuon = g.Count() })
                       .OrderByDescending(x => x.SoLuotMuon)
                       .Take(20)
                       .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ma Sach", typeof(int));
            dt.Columns.Add("Ten Sach", typeof(string));
            dt.Columns.Add("So Luot Muon", typeof(int));

            int stt = 1;
            foreach (var item in data)
            {
                dt.Rows.Add(stt++, item.MaSach, item.TenSach, item.SoLuotMuon);
            }

            dgvTopSach.DataSource = dt;
        }

        private void LoadChiTietMuonTra(DateTime tuNgay, DateTime denNgay)
        {
            var data = (from pm in db.PHIEUMUONs
                        join ct in db.CHITIETPHIEUMUONs on pm.MAPM equals ct.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        join sv in db.SINHVIENs on pm.MASV equals sv.MASV
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        orderby pm.NGAYLAPPHIEUMUON descending
                        select new
                        {
                            MaPhieu = pm.MAPM,
                            DocGia = sv.HOVATEN,
                            TenSach = s.TENSACH,
                            NgayMuon = pm.NGAYLAPPHIEUMUON,
                            HanTra = pm.HANTRA,
                            TrangThai = pm.TRANGTHAI
                        }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ma Phieu", typeof(int));
            dt.Columns.Add("Doc Gia", typeof(string));
            dt.Columns.Add("Ten Sach", typeof(string));
            dt.Columns.Add("Ngay Muon", typeof(string));
            dt.Columns.Add("Han Tra", typeof(string));
            dt.Columns.Add("Trang Thai", typeof(string));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaPhieu, item.DocGia, item.TenSach,
                    item.NgayMuon.ToString("dd/MM/yyyy"),
                    item.HanTra.ToString("dd/MM/yyyy"),
                    item.TrangThai);
            }

            dgvChiTiet.DataSource = dt;
        }

        private void LoadBaoCaoDocGiaTichCuc()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var data = (from pm in db.PHIEUMUONs
                        join sv in db.SINHVIENs on pm.MASV equals sv.MASV
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        group pm by new { sv.MASV, sv.HOVATEN } into g
                        select new { MaSV = g.Key.MASV, TenDocGia = g.Key.HOVATEN, SoLuotMuon = g.Count() })
                       .OrderByDescending(x => x.SoLuotMuon)
                       .Take(20)
                       .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ma SV", typeof(int));
            dt.Columns.Add("Ho Ten", typeof(string));
            dt.Columns.Add("So Luot Muon", typeof(int));

            int stt = 1;
            foreach (var item in data)
            {
                dt.Rows.Add(stt++, item.MaSV, item.TenDocGia, item.SoLuotMuon);
            }

            dgvChiTiet.DataSource = dt;
        }

        private void btnGuiBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiem tra du lieu
                if (dgvChiTiet.Rows.Count == 0 && dgvMuonTheoNgay.Rows.Count == 0)
                {
                    MessageBox.Show("Vui long tao bao cao truoc khi gui!", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tao ten file
                string nguoiGui = Session.CurrentUsername ?? "ThuThu";
                string fileName = string.Format("BaoCao_{0}_{1}_{2}.txt",
                    dtpTuNgay.Value.ToString("MMyyyy"),
                    nguoiGui,
                    DateTime.Now.ToString("ddMMyyyy_HHmmss"));

                string fullPath = Path.Combine(reportFolder, fileName);

                // Ghi file bao cao
                using (StreamWriter sw = new StreamWriter(fullPath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("===========================================");
                    sw.WriteLine("       BAO CAO THONG KE THU VIEN");
                    sw.WriteLine("===========================================");
                    sw.WriteLine();
                    sw.WriteLine("Nguoi gui: " + nguoiGui);
                    sw.WriteLine("Ngay gui: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    sw.WriteLine("Thoi gian bao cao: " + dtpTuNgay.Value.ToString("dd/MM/yyyy") + " - " + dtpDenNgay.Value.ToString("dd/MM/yyyy"));
                    sw.WriteLine("Ghi chu: " + (string.IsNullOrEmpty(txtGhiChu.Text) ? "Khong co" : txtGhiChu.Text));
                    sw.WriteLine();
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine("TONG HOP:");
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine("Tong phieu muon: " + lblTongMuon.Text);
                    sw.WriteLine("Tong phieu tra: " + lblTongTra.Text);
                    sw.WriteLine("Dang muon: " + lblSachConMuon.Text);
                    sw.WriteLine("Doc gia hoat dong: " + lblDocGiaHoatDong.Text);
                    sw.WriteLine();

                    // Ghi chi tiet muon theo ngay
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine("CHI TIET MUON THEO NGAY:");
                    sw.WriteLine("-------------------------------------------");
                    foreach (DataGridViewRow row in dgvMuonTheoNgay.Rows)
                    {
                        sw.WriteLine(string.Format("{0}: {1} phieu",
                            row.Cells[0].Value,
                            row.Cells[1].Value));
                    }
                    sw.WriteLine();

                    // Ghi the loai
                    sw.WriteLine("-------------------------------------------");
                    sw.WriteLine("THE LOAI PHO BIEN:");
                    sw.WriteLine("-------------------------------------------");
                    foreach (DataGridViewRow row in dgvTheLoai.Rows)
                    {
                        sw.WriteLine(string.Format("{0}: {1} sach ({2})",
                            row.Cells[0].Value,
                            row.Cells[1].Value,
                            row.Cells[2].Value));
                    }

                    sw.WriteLine();
                    sw.WriteLine("===========================================");
                    sw.WriteLine("          KET THUC BAO CAO");
                    sw.WriteLine("===========================================");
                }

                MessageBox.Show(
                    string.Format("Da gui bao cao thanh cong cho Admin!\n\nFile: {0}\nDuong dan: {1}", fileName, fullPath),
                    "Thanh cong",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtGhiChu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi gui bao cao: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
