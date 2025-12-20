using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormBaoCaoNangCap : Form
    {
        private Model1 db = new Model1();
        private string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        // Controls
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Panel pnlCharts;
        private TabControl tabControl;
        private DateTimePicker dtpTuNgay, dtpDenNgay;
        private ComboBox cboLoaiBaoCao;
        private Button btnTaoBaoCao, btnXuatFile, btnLamMoi;
        private DataGridView dgvChiTiet, dgvMuonTheoNgay, dgvTheLoai, dgvTopSach;
        private Label lblTongMuon, lblTongTra, lblSachConMuon, lblDocGiaHoatDong;

        public FormBaoCaoNangCap()
        {
            InitializeComponent();
            this.Load += FormBaoCaoNangCap_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "BÁO CÁO THỐNG KÊ THƯ VIỆN";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // ============ HEADER ============
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            Label lblTitle = new Label
            {
                Text = "📊 BÁO CÁO THỐNG KÊ THƯ VIỆN",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 22)
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // ============ FILTER PANEL ============
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            Label lblTuNgay = new Label { Text = "Từ ngày:", Location = new Point(20, 28), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpTuNgay = new DateTimePicker
            {
                Location = new Point(90, 25),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };

            Label lblDenNgay = new Label { Text = "Đến ngày:", Location = new Point(260, 28), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpDenNgay = new DateTimePicker
            {
                Location = new Point(340, 25),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            Label lblLoai = new Label { Text = "Loại báo cáo:", Location = new Point(510, 28), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            cboLoaiBaoCao = new ComboBox
            {
                Location = new Point(610, 25),
                Size = new Size(180, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            cboLoaiBaoCao.Items.AddRange(new object[] { "Tổng quan", "Mượn sách theo ngày", "Thể loại phổ biến", "Top sách mượn nhiều", "Độc giả tích cực" });
            cboLoaiBaoCao.SelectedIndex = 0;

            btnTaoBaoCao = new Button
            {
                Text = "📈 Tạo báo cáo",
                Location = new Point(820, 20),
                Size = new Size(130, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnTaoBaoCao.FlatAppearance.BorderSize = 0;
            btnTaoBaoCao.Click += btnTaoBaoCao_Click;

            btnXuatFile = new Button
            {
                Text = "📄 Xuất Excel",
                Location = new Point(960, 20),
                Size = new Size(110, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXuatFile.FlatAppearance.BorderSize = 0;
            btnXuatFile.Click += btnXuatFile_Click;

            btnLamMoi = new Button
            {
                Text = "🔄",
                Location = new Point(1080, 20),
                Size = new Size(50, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => LoadBaoCaoTongQuan();

            pnlFilters.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, lblLoai, cboLoaiBaoCao, btnTaoBaoCao, btnXuatFile, btnLamMoi });
            this.Controls.Add(pnlFilters);

            // ============ SUMMARY CARDS ============
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(240, 244, 247),
                Padding = new Padding(20, 10, 20, 10)
            };

            // Card 1: Tổng mượn
            Panel card1 = CreateSummaryCard("📚 TỔNG PHIẾU MƯỢN", "0", Color.FromArgb(52, 152, 219), new Point(20, 10));
            lblTongMuon = card1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            // Card 2: Tổng trả
            Panel card2 = CreateSummaryCard("📖 TỔNG PHIẾU TRẢ", "0", Color.FromArgb(46, 204, 113), new Point(290, 10));
            lblTongTra = card2.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            // Card 3: Sách đang mượn
            Panel card3 = CreateSummaryCard("📕 ĐANG MƯỢN", "0", Color.FromArgb(230, 126, 34), new Point(560, 10));
            lblSachConMuon = card3.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            // Card 4: Độc giả hoạt động
            Panel card4 = CreateSummaryCard("👥 ĐỘC GIẢ", "0", Color.FromArgb(155, 89, 182), new Point(830, 10));
            lblDocGiaHoatDong = card4.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            pnlSummary.Controls.AddRange(new Control[] { card1, card2, card3, card4 });
            this.Controls.Add(pnlSummary);

            // ============ TAB CONTROL FOR DATA ============
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            // Tab 1: Thống kê mượn theo ngày
            TabPage tabMuonTheoNgay = new TabPage("📊 Mượn theo ngày");
            dgvMuonTheoNgay = CreateStyledDataGridView();
            tabMuonTheoNgay.Controls.Add(dgvMuonTheoNgay);

            // Tab 2: Thể loại phổ biến
            TabPage tabTheLoai = new TabPage("🥧 Thể loại phổ biến");
            dgvTheLoai = CreateStyledDataGridView();
            tabTheLoai.Controls.Add(dgvTheLoai);

            // Tab 3: Top sách mượn nhiều
            TabPage tabTopSach = new TabPage("📈 Top sách mượn nhiều");
            dgvTopSach = CreateStyledDataGridView();
            tabTopSach.Controls.Add(dgvTopSach);

            // Tab 4: Dữ liệu chi tiết
            TabPage tabData = new TabPage("📋 Chi tiết phiếu mượn");
            dgvChiTiet = CreateStyledDataGridView();
            tabData.Controls.Add(dgvChiTiet);

            tabControl.TabPages.AddRange(new TabPage[] { tabMuonTheoNgay, tabTheLoai, tabTopSach, tabData });
            this.Controls.Add(tabControl);

            // Đảm bảo thứ tự controls đúng
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
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
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
                Size = new Size(250, 90),
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            Panel colorStrip = new Panel
            {
                Size = new Size(8, 90),
                Location = new Point(0, 0),
                BackColor = color
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Name = "lblValue",
                Text = value,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(20, 40),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { colorStrip, lblTitle, lblValue });
            return card;
        }

        private void FormBaoCaoNangCap_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            LoadBaoCaoTongQuan();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            string loaiBaoCao = cboLoaiBaoCao.SelectedItem?.ToString() ?? "Tổng quan";

            switch (loaiBaoCao)
            {
                case "Tổng quan":
                    LoadBaoCaoTongQuan();
                    break;
                case "Mượn sách theo ngày":
                    LoadBaoCaoMuonTheoNgay();
                    tabControl.SelectedIndex = 0;
                    break;
                case "Thể loại phổ biến":
                    LoadBaoCaoTheLoai();
                    tabControl.SelectedIndex = 1;
                    break;
                case "Top sách mượn nhiều":
                    LoadBaoCaoTopSach();
                    tabControl.SelectedIndex = 2;
                    break;
                case "Độc giả tích cực":
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

                // Cập nhật summary cards
                int tongMuon = db.PHIEUMUONs.Count(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay);
                int tongTra = db.PHIEUTRAs.Count(pt => pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay);
                int dangMuon = db.PHIEUMUONs.Count(pm => pm.TRANGTHAI == "Đang mượn" || pm.TRANGTHAI == "Đã duyệt");
                int docGia = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                                          .Select(pm => pm.MASV).Distinct().Count();

                lblTongMuon.Text = tongMuon.ToString();
                lblTongTra.Text = tongTra.ToString();
                lblSachConMuon.Text = dangMuon.ToString();
                lblDocGiaHoatDong.Text = docGia.ToString();

                // Load tất cả các tab
                LoadBaoCaoMuonTheoNgay();
                LoadBaoCaoTheLoai();
                LoadBaoCaoTopSach();
                LoadChiTietMuonTra(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaoCaoMuonTheoNgay()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var muonTheoNgay = db.PHIEUMUONs
                .Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                .GroupBy(pm => DbFunctions.TruncateTime(pm.NGAYLAPPHIEUMUON))
                .Select(g => new { 
                    Ngay = g.Key, 
                    SoPhieuMuon = g.Count()
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ngay", typeof(string));
            dt.Columns.Add("So Phieu Muon", typeof(int));

            foreach (var item in muonTheoNgay)
            {
                dt.Rows.Add(
                    item.Ngay.HasValue ? item.Ngay.Value.ToString("dd/MM/yyyy") : "",
                    item.SoPhieuMuon
                );
            }

            dgvMuonTheoNgay.DataSource = dt;
        }

        private void LoadBaoCaoTheLoai()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var theLoaiData = (from ct in db.CHITIETPHIEUMUONs
                               join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                               join s in db.SACHes on ct.MASACH equals s.MASACH
                               where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                               group ct by s.THELOAI into g
                               select new { 
                                   TheLoai = g.Key ?? "Chua phan loai", 
                                   SoLuong = g.Count(),
                                   SoPhieu = g.Select(x => x.MAPM).Distinct().Count()
                               })
                              .OrderByDescending(x => x.SoLuong)
                              .ToList();

            int tongSoLuong = theLoaiData.Sum(x => x.SoLuong);

            DataTable dt = new DataTable();
            dt.Columns.Add("The Loai", typeof(string));
            dt.Columns.Add("So Luong Sach", typeof(int));
            dt.Columns.Add("So Phieu Muon", typeof(int));
            dt.Columns.Add("Ty Le", typeof(string));

            foreach (var item in theLoaiData)
            {
                string tyLe = tongSoLuong > 0 ? string.Format("{0:F1}%", item.SoLuong * 100.0 / tongSoLuong) : "0%";
                dt.Rows.Add(item.TheLoai, item.SoLuong, item.SoPhieu, tyLe);
            }

            dgvTheLoai.DataSource = dt;
        }

        private void LoadBaoCaoTopSach()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var topSach = (from ct in db.CHITIETPHIEUMUONs
                           join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                           join s in db.SACHes on ct.MASACH equals s.MASACH
                           join tg in db.TACGIAs on s.MATG equals tg.MATG
                           where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                           group ct by new { s.MASACH, s.TENSACH, s.THELOAI, tg.TENTG } into g
                           select new
                           {
                               MaSach = g.Key.MASACH,
                               TenSach = g.Key.TENSACH,
                               TacGia = g.Key.TENTG,
                               TheLoai = g.Key.THELOAI,
                               SoLuotMuon = g.Count()
                           })
                          .OrderByDescending(x => x.SoLuotMuon)
                          .Take(20)
                          .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ma Sach", typeof(int));
            dt.Columns.Add("Ten Sach", typeof(string));
            dt.Columns.Add("Tac Gia", typeof(string));
            dt.Columns.Add("The Loai", typeof(string));
            dt.Columns.Add("So Luot Muon", typeof(int));

            int stt = 1;
            foreach (var item in topSach)
            {
                dt.Rows.Add(stt++, item.MaSach, item.TenSach, item.TacGia, item.TheLoai, item.SoLuotMuon);
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
                            TheLoai = s.THELOAI,
                            NgayMuon = pm.NGAYLAPPHIEUMUON,
                            HanTra = pm.HANTRA,
                            SoLuong = ct.SOLUONG,
                            TrangThai = pm.TRANGTHAI
                        }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ma Phieu", typeof(int));
            dt.Columns.Add("Doc Gia", typeof(string));
            dt.Columns.Add("Ten Sach", typeof(string));
            dt.Columns.Add("The Loai", typeof(string));
            dt.Columns.Add("Ngay Muon", typeof(string));
            dt.Columns.Add("Han Tra", typeof(string));
            dt.Columns.Add("So Luong", typeof(int));
            dt.Columns.Add("Trang Thai", typeof(string));

            foreach (var item in data)
            {
                dt.Rows.Add(
                    item.MaPhieu,
                    item.DocGia,
                    item.TenSach,
                    item.TheLoai,
                    item.NgayMuon.ToString("dd/MM/yyyy"),
                    item.HanTra.ToString("dd/MM/yyyy"),
                    item.SoLuong,
                    item.TrangThai
                );
            }

            dgvChiTiet.DataSource = dt;
        }

        private void LoadBaoCaoDocGiaTichCuc()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            var topDocGia = (from pm in db.PHIEUMUONs
                             join sv in db.SINHVIENs on pm.MASV equals sv.MASV
                             where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                             group pm by new { sv.MASV, sv.HOVATEN, sv.EMAIL, sv.SDT } into g
                             select new
                             {
                                 MaSV = g.Key.MASV,
                                 TenDocGia = g.Key.HOVATEN,
                                 Email = g.Key.EMAIL,
                                 SDT = g.Key.SDT,
                                 SoLuotMuon = g.Count()
                             })
                            .OrderByDescending(x => x.SoLuotMuon)
                            .Take(20)
                            .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ma SV", typeof(int));
            dt.Columns.Add("Ho Ten", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("So Luot Muon", typeof(int));

            int stt = 1;
            foreach (var item in topDocGia)
            {
                dt.Rows.Add(stt++, item.MaSV, item.TenDocGia, item.Email ?? "Chua co", item.SDT ?? "Chua co", item.SoLuotMuon);
            }

            dgvChiTiet.DataSource = dt;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt",
                    FileName = string.Format("BaoCao_{0}.csv", DateTime.Now.ToString("ddMMyyyy_HHmmss"))
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    DataGridView currentDgv = null;
                    switch (tabControl.SelectedIndex)
                    {
                        case 0: currentDgv = dgvMuonTheoNgay; break;
                        case 1: currentDgv = dgvTheLoai; break;
                        case 2: currentDgv = dgvTopSach; break;
                        case 3: currentDgv = dgvChiTiet; break;
                    }

                    if (currentDgv != null && currentDgv.Rows.Count > 0)
                    {
                        ExportDataGridViewToCSV(currentDgv, saveDialog.FileName);
                        MessageBox.Show(string.Format("Da xuat bao cao thanh cong!\nFile: {0}", saveDialog.FileName), "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Khong co du lieu de xuat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xuat bao cao: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataGridViewToCSV(DataGridView dgv, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                // Header
                var headers = dgv.Columns.Cast<DataGridViewColumn>()
                    .Select(c => c.HeaderText)
                    .ToArray();
                sw.WriteLine(string.Join(",", headers));

                // Data rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>()
                        .Select(c => string.Format("\"{0}\"", (c.Value != null ? c.Value.ToString().Replace("\"", "\"\"") : "")))
                        .ToArray();
                    sw.WriteLine(string.Join(",", cells));
                }
            }
        }
    }
}
