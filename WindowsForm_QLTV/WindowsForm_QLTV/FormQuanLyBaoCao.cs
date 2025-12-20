using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Entity Framework 6
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D; // Them thu vien ve do hoa
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class FormQuanLyBaoCao : Form
    {
        private Model1 db = new Model1();
        private string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        // Controls
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Panel pnlSummary;
        private TabControl tabControl;
        private Panel pnlBarChart;
        private Panel pnlPieChart; // Panel chua bieu do tron
        private DataGridView dgvBaoCao;
        private DataGridView dgvChiTiet;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXemBaoCao;
        private Button btnMoThuMuc;
        private Button btnLamMoi;
        private Label lblTongMuon;
        private Label lblTongTra;
        private Label lblDangMuon;
        private Label lblDocGia;
        private Label lblTongBaoCao;

        // Mau sac cho bieu do
        private Color[] chartColors = {
            Color.FromArgb(52, 152, 219),  // Blue
            Color.FromArgb(46, 204, 113),  // Green
            Color.FromArgb(155, 89, 182),  // Purple
            Color.FromArgb(230, 126, 34),  // Orange
            Color.FromArgb(231, 76, 60),   // Red
            Color.FromArgb(241, 196, 15),  // Yellow
            Color.FromArgb(26, 188, 156),  // Teal
            Color.FromArgb(149, 165, 166), // Grey
            Color.FromArgb(52, 73, 94),    // Dark Blue
            Color.FromArgb(192, 57, 43)    // Dark Red
        };

        public FormQuanLyBaoCao()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.SuspendLayout();

            this.Text = "QUẢN LÝ BÁO CÁO - ADMIN";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // ============ TAB CONTROL ============
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            // Tab 1: Bieu do cot
            TabPage tabBarChart = new TabPage("📊 Biểu đồ cột - Mượn theo ngày");
            tabBarChart.BackColor = Color.White;
            pnlBarChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabBarChart.Controls.Add(pnlBarChart);

            // Tab 2: Bieu do tron (SUA LAI TEN TAB)
            TabPage tabPieChart = new TabPage("🥧 Biểu đồ tròn - Thể loại sách");
            tabPieChart.BackColor = Color.White;
            pnlPieChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabPieChart.Controls.Add(pnlPieChart);

            // Tab 3: Danh sach bao cao
            TabPage tabBaoCao = new TabPage("📂 Danh sách báo cáo đã nhận");
            tabBaoCao.BackColor = Color.White;
            dgvBaoCao = CreateStyledDataGridView();
            dgvBaoCao.CellDoubleClick += DgvBaoCao_CellDoubleClick;
            tabBaoCao.Controls.Add(dgvBaoCao);

            // Tab 4: Chi tiet du lieu
            TabPage tabChiTiet = new TabPage("📋 Chi tiết mượn trả");
            tabChiTiet.BackColor = Color.White;
            dgvChiTiet = CreateStyledDataGridView();
            tabChiTiet.Controls.Add(dgvChiTiet);

            tabControl.TabPages.AddRange(new TabPage[] { tabBarChart, tabPieChart, tabBaoCao, tabChiTiet });
            this.Controls.Add(tabControl);

            // ============ SUMMARY CARDS (TIENG VIET CO DAU) ============
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(240, 244, 247),
                Padding = new Padding(10, 5, 10, 5)
            };

            Panel card1 = CreateSummaryCard("📚 TỔNG MƯỢN", "0", Color.FromArgb(52, 152, 219), new Point(10, 5));
            lblTongMuon = card1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card2 = CreateSummaryCard("📖 TỔNG TRẢ", "0", Color.FromArgb(46, 204, 113), new Point(220, 5));
            lblTongTra = card2.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card3 = CreateSummaryCard("📕 ĐANG MƯỢN", "0", Color.FromArgb(230, 126, 34), new Point(430, 5));
            lblDangMuon = card3.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card4 = CreateSummaryCard("👥 ĐỘC GIẢ", "0", Color.FromArgb(155, 89, 182), new Point(640, 5));
            lblDocGia = card4.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card5 = CreateSummaryCard("📄 BÁO CÁO", "0", Color.FromArgb(231, 76, 60), new Point(850, 5));
            lblTongBaoCao = card5.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            pnlSummary.Controls.AddRange(new Control[] { card1, card2, card3, card4, card5 });
            this.Controls.Add(pnlSummary);

            // ============ FILTER PANEL ============
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10, 10, 10, 10)
            };

            Label lblTuNgay = new Label { Text = "Từ ngày:", Location = new Point(10, 18), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            dtpTuNgay = new DateTimePicker
            {
                Location = new Point(70, 14),
                Size = new Size(130, 25),
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(DateTime.Now.Year, 1, 1)
            };

            Label lblDenNgay = new Label { Text = "Đến ngày:", Location = new Point(220, 18), AutoSize = true, Font = new Font("Segoe UI", 9F) };
            dtpDenNgay = new DateTimePicker
            {
                Location = new Point(290, 14),
                Size = new Size(130, 25),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            btnXemBaoCao = new Button
            {
                Text = "📈 Xem",
                Location = new Point(440, 10),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(142, 68, 173),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemBaoCao.FlatAppearance.BorderSize = 0;
            btnXemBaoCao.Click += BtnXemBaoCao_Click;

            btnMoThuMuc = new Button
            {
                Text = "📂 Thư mục",
                Location = new Point(530, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnMoThuMuc.FlatAppearance.BorderSize = 0;
            btnMoThuMuc.Click += BtnMoThuMuc_Click;

            btnLamMoi = new Button
            {
                Text = "🔄",
                Location = new Point(640, 10),
                Size = new Size(45, 35),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => LoadAllData();

            pnlFilters.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnXemBaoCao, btnMoThuMuc, btnLamMoi });
            this.Controls.Add(pnlFilters);

            // ============ HEADER ============
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(142, 68, 173)
            };

            Label lblTitle = new Label
            {
                Text = "📊 QUẢN LÝ BÁO CÁO - ADMIN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblTitle);

            Label lblRole = new Label
            {
                Text = "(Chỉ xem báo cáo từ Thủ thư)",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(220, 220, 220),
                AutoSize = true,
                Location = new Point(420, 22)
            };
            pnlHeader.Controls.Add(lblRole);

            this.Controls.Add(pnlHeader);

            this.Load += FormQuanLyBaoCao_Load;

            this.ResumeLayout(false);
        }

        private Panel CreateSummaryCard(string title, string value, Color color, Point location)
        {
            Panel card = new Panel
            {
                Size = new Size(200, 85),
                Location = location,
                BackColor = Color.White
            };

            Panel colorStrip = new Panel
            {
                Size = new Size(5, 85),
                Location = new Point(0, 0),
                BackColor = color
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(127, 140, 141),
                Location = new Point(12, 8),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Name = "lblValue",
                Text = value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(12, 35),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { colorStrip, lblTitle, lblValue });
            return card;
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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 35;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250);
            dgv.RowTemplate.Height = 30;
            return dgv;
        }

        private void FormQuanLyBaoCao_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            LoadAllData();
        }

        private void BtnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                // Summary cards
                int tongMuon = db.PHIEUMUONs.Count(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay);
                int tongTra = db.PHIEUTRAs.Count(pt => pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay);
                // Cap nhat cac trang thai tieng Viet
                int dangMuon = db.PHIEUMUONs.Count(pm => pm.TRANGTHAI == "Dang muon" || pm.TRANGTHAI == "Da duyet" || pm.TRANGTHAI == "Đang mượn" || pm.TRANGTHAI == "Đã duyệt");
                int docGia = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                                              .Select(pm => pm.MASV).Distinct().Count();

                if (lblTongMuon != null) lblTongMuon.Text = tongMuon.ToString();
                if (lblTongTra != null) lblTongTra.Text = tongTra.ToString();
                if (lblDangMuon != null) lblDangMuon.Text = dangMuon.ToString();
                if (lblDocGia != null) lblDocGia.Text = docGia.ToString();

                // Load bieu do
                LoadBarChart(tuNgay, denNgay);
                LoadPieChart(tuNgay, denNgay);

                // Load danh sach bao cao
                LoadDanhSachBaoCao();

                // Load chi tiet
                LoadChiTiet(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Text = "📊 BIỂU ĐỒ CỘT: SỐ LƯỢNG MƯỢN SÁCH THEO NGÀY",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlBarChart.Controls.Add(lblChartTitle);

            Label lblSubTitle = new Label
            {
                Text = string.Format("Thời gian: {0} - {1}", tuNgay.ToString("dd/MM/yyyy"), denNgay.AddDays(-1).ToString("dd/MM/yyyy")),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(20, 45),
                AutoSize = true
            };
            pnlBarChart.Controls.Add(lblSubTitle);

            if (data.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "⚠ Không có dữ liệu mượn sách trong khoảng thời gian này.\nHãy chọn khoảng thời gian khác hoặc kiểm tra dữ liệu.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(231, 76, 60),
                    Location = new Point(20, 90),
                    AutoSize = true
                };
                pnlBarChart.Controls.Add(lblNoData);
                return;
            }

            int maxValue = data.Max(x => x.SoLuong);
            if (maxValue == 0) maxValue = 1;

            int yPos = 80;
            int barHeight = 30;
            int maxBarWidth = 500;

            foreach (var item in data)
            {
                string ngay = item.Ngay.HasValue ? item.Ngay.Value.ToString("dd/MM/yyyy") : "";
                int barWidth = (int)(item.SoLuong * maxBarWidth / maxValue);
                if (barWidth < 40) barWidth = 40;

                // Label ngay
                Label lblNgay = new Label
                {
                    Text = ngay,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(20, yPos + 5),
                    Size = new Size(90, 20)
                };
                pnlBarChart.Controls.Add(lblNgay);

                // Bar
                Panel bar = new Panel
                {
                    BackColor = Color.FromArgb(52, 152, 219),
                    Location = new Point(120, yPos),
                    Size = new Size(barWidth, barHeight - 5)
                };
                pnlBarChart.Controls.Add(bar);

                // Value inside bar
                Label lblValue = new Label
                {
                    Text = item.SoLuong.ToString() + " phiếu",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 73, 94),
                    Location = new Point(130 + barWidth, yPos + 5),
                    AutoSize = true
                };
                pnlBarChart.Controls.Add(lblValue);

                yPos += barHeight + 8;
            }

            // Tong ket
            Panel pnlTotal = new Panel
            {
                BackColor = Color.FromArgb(142, 68, 173),
                Location = new Point(20, yPos + 15),
                Size = new Size(400, 40)
            };
            Label lblTotal = new Label
            {
                Text = string.Format("  TỔNG CỘNG: {0} phiếu mượn trong {1} ngày", data.Sum(x => x.SoLuong), data.Count),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(5, 10),
                AutoSize = true
            };
            pnlTotal.Controls.Add(lblTotal);
            pnlBarChart.Controls.Add(pnlTotal);
        }

        // =================================================================
        // HÀM VẼ BIỂU ĐỒ TRÒN MỚI (DÙNG GRAPHICS THAY VÌ PANEL CỘT)
        // =================================================================
        private void LoadPieChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlPieChart.Controls.Clear();

            // Lay du lieu
            var data = (from ct in db.CHITIETPHIEUMUONs
                        join pm in db.PHIEUMUONs on ct.MAPM equals pm.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        group ct by s.THELOAI into g
                        select new { TheLoai = g.Key ?? "Khác", SoLuong = g.Count() })
                        .OrderByDescending(x => x.SoLuong)
                        .Take(10)
                        .ToList();

            // Title
            Label lblChartTitle = new Label
            {
                Text = "🥧 BIỂU ĐỒ TRÒN: TỶ LỆ THỂ LOẠI SÁCH ĐƯỢC MƯỢN",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlPieChart.Controls.Add(lblChartTitle);

            Label lblSubTitle = new Label
            {
                Text = string.Format("Thời gian: {0} - {1}", tuNgay.ToString("dd/MM/yyyy"), denNgay.AddDays(-1).ToString("dd/MM/yyyy")),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(20, 45),
                AutoSize = true
            };
            pnlPieChart.Controls.Add(lblSubTitle);

            if (data.Count == 0)
            {
                Label lblNoData = new Label
                {
                    Text = "⚠ Không có dữ liệu thể loại sách trong khoảng thời gian này.\nHãy chọn khoảng thời gian khác hoặc kiểm tra dữ liệu.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.FromArgb(231, 76, 60),
                    Location = new Point(20, 90),
                    AutoSize = true
                };
                pnlPieChart.Controls.Add(lblNoData);
                return;
            }

            int total = data.Sum(x => x.SoLuong);
            if (total == 0) total = 1;

            // Tao PictureBox de ve bieu do tron
            PictureBox pbPie = new PictureBox
            {
                Location = new Point(20, 80),
                Size = new Size(900, 500), // Kich thuoc vung ve
                BackColor = Color.White
            };

            // Su kien Paint de ve truc tiep
            pbPie.Paint += (s, ev) =>
            {
                Graphics g = ev.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(50, 20, 300, 300); // Vi tri hinh tron
                float startAngle = 0;

                int legendX = 400; // Vi tri bat dau cua chu thich
                int legendY = 30;

                int i = 0;
                foreach (var item in data)
                {
                    float sweepAngle = (float)(item.SoLuong * 360.0 / total);
                    Color c = chartColors[i % chartColors.Length];

                    // 1. Ve mieng banh
                    using (SolidBrush brush = new SolidBrush(c))
                    {
                        g.FillPie(brush, rect, startAngle, sweepAngle);
                        // Ve vien trang giua cac mieng
                        g.DrawPie(Pens.White, rect, startAngle, sweepAngle);
                    }

                    // 2. Ve chu thich (Legend)
                    using (SolidBrush brush = new SolidBrush(c))
                    {
                        // O vuong mau
                        g.FillRectangle(brush, legendX, legendY, 20, 20);
                    }

                    double percentage = item.SoLuong * 100.0 / total;
                    string text = string.Format("{0} ({1} - {2:F1}%)", item.TheLoai, item.SoLuong, percentage);

                    g.DrawString(text, new Font("Segoe UI", 11), Brushes.Black, legendX + 30, legendY);

                    startAngle += sweepAngle;
                    legendY += 35; // Xuong dong cho item tiep theo
                    i++;
                }

                // Ve tong cong
                g.DrawString($"TỔNG CỘNG: {total} cuốn", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.DarkSlateGray, 400, legendY + 10);
            };

            pnlPieChart.Controls.Add(pbPie);
        }

        private void LoadDanhSachBaoCao()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("STT", typeof(int));
                dt.Columns.Add("Tên File", typeof(string));
                dt.Columns.Add("Ngày Gửi", typeof(string));
                dt.Columns.Add("Kích Thước", typeof(string));
                dt.Columns.Add("Loại", typeof(string));
                dt.Columns.Add("DuongDan", typeof(string));

                int stt = 1;
                if (Directory.Exists(reportFolder))
                {
                    var pdfFiles = Directory.GetFiles(reportFolder, "*.pdf").Select(f => new FileInfo(f));
                    var txtFiles = Directory.GetFiles(reportFolder, "*.txt").Select(f => new FileInfo(f));
                    var allFiles = pdfFiles.Concat(txtFiles).OrderByDescending(f => f.CreationTime).ToList();

                    foreach (var file in allFiles)
                    {
                        string kichThuoc = string.Format("{0:F1} KB", file.Length / 1024.0);
                        string loaiFile = file.Extension.ToUpper().Replace(".", "");
                        dt.Rows.Add(stt++, file.Name, file.CreationTime.ToString("dd/MM/yyyy HH:mm"), kichThuoc, loaiFile, file.FullName);
                    }
                }

                dgvBaoCao.DataSource = dt;

                if (dgvBaoCao.Columns.Contains("DuongDan"))
                {
                    dgvBaoCao.Columns["DuongDan"].Visible = false;
                }

                if (lblTongBaoCao != null) lblTongBaoCao.Text = (stt - 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        }).Take(100).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Phiếu", typeof(int));
            dt.Columns.Add("Độc Giả", typeof(string));
            dt.Columns.Add("Tên Sách", typeof(string));
            dt.Columns.Add("Thể Loại", typeof(string));
            dt.Columns.Add("Ngày Mượn", typeof(string));
            dt.Columns.Add("Hạn Trả", typeof(string));
            dt.Columns.Add("Trạng Thái", typeof(string));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaPhieu, item.DocGia, item.TenSach, item.TheLoai,
                    item.NgayMuon.ToString("dd/MM/yyyy"),
                    item.HanTra.ToString("dd/MM/yyyy"),
                    item.TrangThai);
            }

            dgvChiTiet.DataSource = dt;
        }

        private void DgvBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string filePath = dgvBaoCao.Rows[e.RowIndex].Cells["DuongDan"].Value?.ToString();
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    try
                    {
                        Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnMoThuMuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(reportFolder))
                {
                    Process.Start("explorer.exe", reportFolder);
                }
                else
                {
                    MessageBox.Show("Thư mục báo cáo chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở thư mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvBaoCao_CellDoubleClick(sender, e);
        }

        private void LoadDanhSachFile()
        {
            LoadDanhSachBaoCao();
        }
    }
}