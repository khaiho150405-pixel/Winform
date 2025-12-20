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
    /// Form Báo cáo dành cho ADMIN - Xem báo cáo v?i bi?u ?? d?ng thanh
    /// </summary>
    public partial class FormBaoCaoAdmin : Form
    {
        private Model1 db = new Model1();
        private string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        // Controls
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Panel pnlSummary;
        private TabControl tabControl;
        private DateTimePicker dtpTuNgay, dtpDenNgay;
        private Button btnXemBaoCao, btnLamMoi, btnXemFile;
        private Panel pnlBarChart, pnlPieChart;
        private DataGridView dgvBaoCaoDaNhan, dgvChiTiet;
        private Label lblTongMuon, lblTongTra, lblSachConMuon, lblDocGiaHoatDong;

        public FormBaoCaoAdmin()
        {
            InitializeComponent();
            this.Load += FormBaoCaoAdmin_Load;
        }

        private void InitializeComponent()
        {
            this.Text = "XEM BAO CAO THONG KE - ADMIN";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // ============ HEADER ============
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(142, 68, 173)
            };

            Label lblTitle = new Label
            {
                Text = "?? XEM BAO CAO THONG KE - ADMIN",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 22)
            };
            pnlHeader.Controls.Add(lblTitle);

            Label lblRole = new Label
            {
                Text = "Vai tro: Administrator",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(950, 30)
            };
            pnlHeader.Controls.Add(lblRole);

            this.Controls.Add(pnlHeader);

            // ============ FILTER PANEL ============
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(20, 15, 20, 15)
            };

            Label lblTuNgay = new Label { Text = "Tu ngay:", Location = new Point(20, 22), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpTuNgay = new DateTimePicker
            {
                Location = new Point(90, 18),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };

            Label lblDenNgay = new Label { Text = "Den ngay:", Location = new Point(260, 22), AutoSize = true, Font = new Font("Segoe UI", 10F) };
            dtpDenNgay = new DateTimePicker
            {
                Location = new Point(340, 18),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            btnXemBaoCao = new Button
            {
                Text = "?? Xem bao cao",
                Location = new Point(520, 13),
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(142, 68, 173),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemBaoCao.FlatAppearance.BorderSize = 0;
            btnXemBaoCao.Click += btnXemBaoCao_Click;

            btnXemFile = new Button
            {
                Text = "?? Xem file bao cao",
                Location = new Point(680, 13),
                Size = new Size(160, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemFile.FlatAppearance.BorderSize = 0;
            btnXemFile.Click += btnXemFile_Click;

            btnLamMoi = new Button
            {
                Text = "?? Lam moi",
                Location = new Point(860, 13),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => LoadData();

            pnlFilters.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnXemBaoCao, btnXemFile, btnLamMoi });
            this.Controls.Add(pnlFilters);

            // ============ SUMMARY CARDS ============
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.FromArgb(240, 244, 247),
                Padding = new Padding(20, 10, 20, 10)
            };

            Panel card1 = CreateSummaryCard("?? TONG PHIEU MUON", "0", Color.FromArgb(52, 152, 219), new Point(20, 10));
            lblTongMuon = card1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card2 = CreateSummaryCard("?? TONG PHIEU TRA", "0", Color.FromArgb(46, 204, 113), new Point(330, 10));
            lblTongTra = card2.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card3 = CreateSummaryCard("?? DANG MUON", "0", Color.FromArgb(230, 126, 34), new Point(640, 10));
            lblSachConMuon = card3.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card4 = CreateSummaryCard("?? DOC GIA", "0", Color.FromArgb(155, 89, 182), new Point(950, 10));
            lblDocGiaHoatDong = card4.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            pnlSummary.Controls.AddRange(new Control[] { card1, card2, card3, card4 });
            this.Controls.Add(pnlSummary);

            // ============ TAB CONTROL ============
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            // Tab 1: Bieu do cot - Muon theo ngay
            TabPage tabBarChart = new TabPage("?? Bieu do cot - Muon theo ngay");
            pnlBarChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabBarChart.Controls.Add(pnlBarChart);

            // Tab 2: Bieu do tron - The loai sach
            TabPage tabPieChart = new TabPage("?? Bieu do tron - The loai sach");
            pnlPieChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabPieChart.Controls.Add(pnlPieChart);

            // Tab 3: Danh sach bao cao da nhan
            TabPage tabBaoCao = new TabPage("?? Bao cao da nhan tu Thu Thu");
            dgvBaoCaoDaNhan = CreateStyledDataGridView();
            dgvBaoCaoDaNhan.CellDoubleClick += dgvBaoCaoDaNhan_CellDoubleClick;
            tabBaoCao.Controls.Add(dgvBaoCaoDaNhan);

            // Tab 4: Chi tiet du lieu
            TabPage tabChiTiet = new TabPage("?? Chi tiet du lieu");
            dgvChiTiet = CreateStyledDataGridView();
            tabChiTiet.Controls.Add(dgvChiTiet);

            tabControl.TabPages.AddRange(new TabPage[] { tabBarChart, tabPieChart, tabBaoCao, tabChiTiet });
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
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
                Size = new Size(290, 85),
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

        private void FormBaoCaoAdmin_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            LoadData();
            LoadDanhSachBaoCao();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                // Summary cards
                int tongMuon = db.PHIEUMUONs.Count(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay);
                int tongTra = db.PHIEUTRAs.Count(pt => pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay);
                int dangMuon = db.PHIEUMUONs.Count(pm => pm.TRANGTHAI == "Dang muon" || pm.TRANGTHAI == "Da duyet");
                int docGia = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                                          .Select(pm => pm.MASV).Distinct().Count();

                lblTongMuon.Text = tongMuon.ToString();
                lblTongTra.Text = tongTra.ToString();
                lblSachConMuon.Text = dangMuon.ToString();
                lblDocGiaHoatDong.Text = docGia.ToString();

                // Load bieu do cot
                LoadBarChart(tuNgay, denNgay);

                // Load bieu do tron
                LoadPieChart(tuNgay, denNgay);

                // Load chi tiet
                LoadChiTiet(tuNgay, denNgay);

                // Load danh sach bao cao
                LoadDanhSachBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai du lieu: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBarChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlBarChart.Controls.Clear();

            var data = db.PHIEUMUONs
                .Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                .GroupBy(pm => DbFunctions.TruncateTime(pm.NGAYLAPPHIEUMUON))
                .Select(g => new { Ngay = g.Key, SoLuong = g.Count() })
                .OrderBy(x => x.Ngay)
                .ToList();

            // Title
            Label lblChartTitle = new Label
            {
                Text = "?? THONG KE MUON SACH THEO NGAY",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 20),
                AutoSize = true
            };
            pnlBarChart.Controls.Add(lblChartTitle);

            int maxValue = data.Count > 0 ? data.Max(x => x.SoLuong) : 1;
            int yPos = 70;
            int barHeight = 35;
            int maxBarWidth = 600;

            foreach (var item in data)
            {
                string ngay = item.Ngay.HasValue ? item.Ngay.Value.ToString("dd/MM/yyyy") : "";
                int barWidth = maxValue > 0 ? (int)(item.SoLuong * maxBarWidth / maxValue) : 0;
                if (barWidth < 30) barWidth = 30;

                // Label ngay
                Label lblNgay = new Label
                {
                    Text = ngay,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(20, yPos + 8),
                    Size = new Size(100, 20)
                };
                pnlBarChart.Controls.Add(lblNgay);

                // Bar
                Panel bar = new Panel
                {
                    BackColor = Color.FromArgb(52, 152, 219),
                    Location = new Point(130, yPos),
                    Size = new Size(barWidth, barHeight - 5)
                };
                pnlBarChart.Controls.Add(bar);

                // Value
                Label lblValue = new Label
                {
                    Text = item.SoLuong.ToString() + " phieu",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(140 + barWidth, yPos + 8),
                    AutoSize = true
                };
                pnlBarChart.Controls.Add(lblValue);

                yPos += barHeight + 10;
            }

            if (data.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "Khong co du lieu trong khoang thoi gian nay",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 70),
                    AutoSize = true
                };
                pnlBarChart.Controls.Add(lblNoData);
            }
        }

        private void LoadPieChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlPieChart.Controls.Clear();

            var data = (from ct in db.CHITIETPHIEUMUONs
                        join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        group ct by s.THELOAI into g
                        select new { TheLoai = g.Key ?? "Khac", SoLuong = g.Count() })
                       .OrderByDescending(x => x.SoLuong)
                       .Take(10)
                       .ToList();

            // Title
            Label lblChartTitle = new Label
            {
                Text = "?? TY LE THE LOAI SACH DUOC MUON",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 20),
                AutoSize = true
            };
            pnlPieChart.Controls.Add(lblChartTitle);

            Color[] colors = {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(230, 126, 34),
                Color.FromArgb(231, 76, 60),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(26, 188, 156),
                Color.FromArgb(149, 165, 166),
                Color.FromArgb(52, 73, 94),
                Color.FromArgb(192, 57, 43)
            };

            int total = data.Sum(x => x.SoLuong);
            int yPos = 70;
            int barHeight = 40;
            int maxBarWidth = 500;
            int i = 0;

            foreach (var item in data)
            {
                double percentage = total > 0 ? (item.SoLuong * 100.0 / total) : 0;
                int barWidth = total > 0 ? (int)(item.SoLuong * maxBarWidth / total) : 0;
                if (barWidth < 20) barWidth = 20;

                // Color box
                Panel colorBox = new Panel
                {
                    BackColor = colors[i % colors.Length],
                    Location = new Point(20, yPos + 10),
                    Size = new Size(20, 20)
                };
                pnlPieChart.Controls.Add(colorBox);

                // Label the loai
                Label lblTheLoai = new Label
                {
                    Text = item.TheLoai,
                    Font = new Font("Segoe UI", 9F),
                    Location = new Point(50, yPos + 10),
                    Size = new Size(150, 20)
                };
                pnlPieChart.Controls.Add(lblTheLoai);

                // Bar
                Panel bar = new Panel
                {
                    BackColor = colors[i % colors.Length],
                    Location = new Point(210, yPos + 5),
                    Size = new Size(barWidth, barHeight - 15)
                };
                pnlPieChart.Controls.Add(bar);

                // Percentage
                Label lblPercent = new Label
                {
                    Text = string.Format("{0} ({1:F1}%)", item.SoLuong, percentage),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(220 + barWidth, yPos + 10),
                    AutoSize = true
                };
                pnlPieChart.Controls.Add(lblPercent);

                yPos += barHeight + 5;
                i++;
            }

            if (data.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "Khong co du lieu trong khoang thoi gian nay",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 70),
                    AutoSize = true
                };
                pnlPieChart.Controls.Add(lblNoData);
            }
        }

        private void LoadChiTiet(DateTime tuNgay, DateTime denNgay)
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
                            TrangThai = pm.TRANGTHAI
                        }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Ma Phieu", typeof(int));
            dt.Columns.Add("Doc Gia", typeof(string));
            dt.Columns.Add("Ten Sach", typeof(string));
            dt.Columns.Add("The Loai", typeof(string));
            dt.Columns.Add("Ngay Muon", typeof(string));
            dt.Columns.Add("Han Tra", typeof(string));
            dt.Columns.Add("Trang Thai", typeof(string));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaPhieu, item.DocGia, item.TenSach, item.TheLoai,
                    item.NgayMuon.ToString("dd/MM/yyyy"),
                    item.HanTra.ToString("dd/MM/yyyy"),
                    item.TrangThai);
            }

            dgvChiTiet.DataSource = dt;
        }

        private void LoadDanhSachBaoCao()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("Ten File", typeof(string));
                dt.Columns.Add("Ngay Nhan", typeof(string));
                dt.Columns.Add("Kich Thuoc", typeof(string));
                dt.Columns.Add("Duong Dan", typeof(string));

                if (Directory.Exists(reportFolder))
                {
                    var files = Directory.GetFiles(reportFolder, "*.txt")
                        .Select(f => new FileInfo(f))
                        .OrderByDescending(f => f.CreationTime)
                        .ToList();

                    int stt = 1;
                    foreach (var file in files)
                    {
                        string kichThuoc = string.Format("{0:F1} KB", file.Length / 1024.0);
                        dt.Rows.Add(stt++, file.Name, file.CreationTime.ToString("dd/MM/yyyy HH:mm"), kichThuoc, file.FullName);
                    }
                }

                dgvBaoCaoDaNhan.DataSource = dt;

                // An cot duong dan
                if (dgvBaoCaoDaNhan.Columns.Contains("Duong Dan"))
                {
                    dgvBaoCaoDaNhan.Columns["Duong Dan"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai danh sach bao cao: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBaoCaoDaNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string filePath = dgvBaoCaoDaNhan.Rows[e.RowIndex].Cells["Duong Dan"].Value?.ToString();
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    try
                    {
                        System.Diagnostics.Process.Start("notepad.exe", filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Khong the mo file: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXemFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(reportFolder))
                {
                    System.Diagnostics.Process.Start("explorer.exe", reportFolder);
                }
                else
                {
                    MessageBox.Show("Thu muc bao cao chua ton tai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the mo thu muc: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
