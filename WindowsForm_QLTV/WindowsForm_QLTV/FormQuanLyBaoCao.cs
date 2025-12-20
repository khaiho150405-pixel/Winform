using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Entity Framework 6
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D; // Thư viện đồ họa
using System.IO;
using System.Linq;
using System.Text; // Thêm thư viện xử lý văn bản
using System.Windows.Forms;
using WindowsForm_QLTV; // Namespace chứa Model Entity

namespace WindowsForm_QLTV
{
    public partial class FormQuanLyBaoCao : Form
    {
        private Model1 db = new Model1();
        private string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        // --- CONTROLS TÙY CHỈNH ---
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Panel pnlSummary;
        private TabControl tabControl;

        // Tab 1: Cột (Xu hướng)
        private Panel pnlBarChart;
        // Tab 2: Tròn (Thể loại)
        private Panel pnlPieChart;
        // Tab 3: Thanh Ngang (Top Độc Giả)
        private Panel pnlTopDocGia;
        // Tab 4: Vành Khuyên (Tình trạng trả)
        private Panel pnlDoughnut;

        private DataGridView dgvBaoCao;
        private DataGridView dgvChiTiet;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;

        // Các nút chức năng
        private Button btnXemBaoCao;
        private Button btnXuatExcel; // Nút mới
        private Button btnMoThuMuc;
        private Button btnLamMoi;

        // Label Summary Cards
        private Label lblTongMuon;
        private Label lblTongTra;
        private Label lblDangMuon;
        private Label lblDocGia;
        private Label lblTongBaoCao;

        // Bảng màu sắc cho biểu đồ
        private Color[] chartColors = {
            Color.FromArgb(52, 152, 219),  // Xanh dương
            Color.FromArgb(46, 204, 113),  // Xanh lá
            Color.FromArgb(155, 89, 182),  // Tím
            Color.FromArgb(230, 126, 34),  // Cam
            Color.FromArgb(231, 76, 60),   // Đỏ
            Color.FromArgb(241, 196, 15),  // Vàng
            Color.FromArgb(26, 188, 156),  // Xanh ngọc
            Color.FromArgb(52, 73, 94)     // Xanh đậm
        };

        public FormQuanLyBaoCao()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.SuspendLayout();

            this.Text = "QUẢN LÝ BÁO CÁO - ADMIN (FULL CHARTS)";
            this.Size = new Size(1350, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // ============ TAB CONTROL ============
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F),
                ItemSize = new Size(160, 30)
            };

            // Tab 1: Biểu đồ cột
            TabPage tabBarChart = new TabPage("📊 Xu hướng mượn");
            tabBarChart.BackColor = Color.White;
            pnlBarChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabBarChart.Controls.Add(pnlBarChart);

            // Tab 2: Biểu đồ tròn
            TabPage tabPieChart = new TabPage("🥧 Tỷ lệ Thể loại");
            tabPieChart.BackColor = Color.White;
            pnlPieChart = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabPieChart.Controls.Add(pnlPieChart);

            // Tab 3: Biểu đồ thanh ngang
            TabPage tabTopUser = new TabPage("🏆 Top Độc Giả");
            tabTopUser.BackColor = Color.White;
            pnlTopDocGia = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabTopUser.Controls.Add(pnlTopDocGia);

            // Tab 4: Biểu đồ vành khuyên
            TabPage tabStatus = new TabPage("🍩 Trả sách (Đúng/Trễ)");
            tabStatus.BackColor = Color.White;
            pnlDoughnut = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Color.White };
            tabStatus.Controls.Add(pnlDoughnut);

            // Tab 5: Danh sách file báo cáo
            TabPage tabBaoCao = new TabPage("📂 File Báo cáo");
            tabBaoCao.BackColor = Color.White;
            dgvBaoCao = CreateStyledDataGridView();
            dgvBaoCao.CellDoubleClick += DgvBaoCao_CellDoubleClick;
            tabBaoCao.Controls.Add(dgvBaoCao);

            // Tab 6: Chi tiết dữ liệu
            TabPage tabChiTiet = new TabPage("📋 Chi tiết Data");
            tabChiTiet.BackColor = Color.White;
            dgvChiTiet = CreateStyledDataGridView();
            tabChiTiet.Controls.Add(dgvChiTiet);

            tabControl.TabPages.AddRange(new TabPage[] { tabBarChart, tabPieChart, tabTopUser, tabStatus, tabBaoCao, tabChiTiet });
            this.Controls.Add(tabControl);

            // ============ SUMMARY CARDS ============
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(240, 244, 247),
                Padding = new Padding(10, 5, 10, 5)
            };

            int cardW = 200; int gap = 15; int startX = 20;

            Panel card1 = CreateSummaryCard("📚 TỔNG MƯỢN", "0", Color.FromArgb(52, 152, 219), new Point(startX, 5));
            lblTongMuon = card1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card2 = CreateSummaryCard("📖 TỔNG TRẢ", "0", Color.FromArgb(46, 204, 113), new Point(startX + cardW + gap, 5));
            lblTongTra = card2.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card3 = CreateSummaryCard("📕 ĐANG MƯỢN", "0", Color.FromArgb(230, 126, 34), new Point(startX + (cardW + gap) * 2, 5));
            lblDangMuon = card3.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card4 = CreateSummaryCard("👥 ĐỘC GIẢ", "0", Color.FromArgb(155, 89, 182), new Point(startX + (cardW + gap) * 3, 5));
            lblDocGia = card4.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            Panel card5 = CreateSummaryCard("📄 BÁO CÁO", "0", Color.FromArgb(231, 76, 60), new Point(startX + (cardW + gap) * 4, 5));
            lblTongBaoCao = card5.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblValue");

            pnlSummary.Controls.AddRange(new Control[] { card1, card2, card3, card4, card5 });
            this.Controls.Add(pnlSummary);

            // ============ FILTER PANEL ============
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
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

            // Nút Xem
            btnXemBaoCao = new Button
            {
                Text = "📈 Phân tích",
                Location = new Point(440, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(142, 68, 173),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXemBaoCao.FlatAppearance.BorderSize = 0;
            btnXemBaoCao.Click += BtnXemBaoCao_Click;

            // Nút Xuất Excel (MỚI)
            btnXuatExcel = new Button
            {
                Text = "📗 Xuất Excel",
                Location = new Point(550, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, // Màu xanh lá Excel
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.Click += BtnXuatExcel_Click;

            // Nút Thư mục
            btnMoThuMuc = new Button
            {
                Text = "📂 Thư mục",
                Location = new Point(660, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnMoThuMuc.FlatAppearance.BorderSize = 0;
            btnMoThuMuc.Click += BtnMoThuMuc_Click;

            // Nút Làm mới
            btnLamMoi = new Button
            {
                Text = "🔄",
                Location = new Point(770, 10),
                Size = new Size(45, 35),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.Click += (s, e) => LoadAllData();

            pnlFilters.Controls.AddRange(new Control[] { lblTuNgay, dtpTuNgay, lblDenNgay, dtpDenNgay, btnXemBaoCao, btnXuatExcel, btnMoThuMuc, btnLamMoi });
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
                Text = "📊 HỆ THỐNG QUẢN TRỊ BÁO CÁO THƯ VIỆN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            this.Load += FormQuanLyBaoCao_Load;
            this.ResumeLayout(false);
        }

        // --- CÁC HÀM HỖ TRỢ GIAO DIỆN ---
        private Panel CreateSummaryCard(string title, string value, Color color, Point location)
        {
            Panel card = new Panel { Size = new Size(200, 85), Location = location, BackColor = Color.White };
            Panel colorStrip = new Panel { Size = new Size(5, 85), Location = new Point(0, 0), BackColor = color };
            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 8F), ForeColor = Color.FromArgb(127, 140, 141), Location = new Point(12, 8), AutoSize = true };
            Label lblValue = new Label { Name = "lblValue", Text = value, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = color, Location = new Point(12, 35), AutoSize = true };
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
            return dgv;
        }

        // --- LOAD DATA & EVENTS ---
        private void FormQuanLyBaoCao_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(reportFolder)) Directory.CreateDirectory(reportFolder);
            LoadAllData();
        }

        private void BtnXemBaoCao_Click(object sender, EventArgs e) { LoadAllData(); }

        private void LoadAllData()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                // 1. Thẻ Summary
                int tongMuon = db.PHIEUMUONs.Count(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay);
                int tongTra = db.PHIEUTRAs.Count(pt => pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay);
                var dangMuonList = new List<string> { "Dang muon", "Da duyet", "Đang mượn", "Đã duyệt" };
                int dangMuon = db.PHIEUMUONs.Count(pm => dangMuonList.Contains(pm.TRANGTHAI));
                int docGia = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay).Select(pm => pm.MASV).Distinct().Count();

                if (lblTongMuon != null) lblTongMuon.Text = tongMuon.ToString();
                if (lblTongTra != null) lblTongTra.Text = tongTra.ToString();
                if (lblDangMuon != null) lblDangMuon.Text = dangMuon.ToString();
                if (lblDocGia != null) lblDocGia.Text = docGia.ToString();

                // 2. Vẽ biểu đồ
                LoadBarChart(tuNgay, denNgay);
                LoadPieChart(tuNgay, denNgay);
                LoadTopReadersChart(tuNgay, denNgay);
                LoadOverdueChart(tuNgay, denNgay);

                // 3. Load danh sách
                LoadDanhSachBaoCao();
                LoadChiTiet(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =================================================================
        // CHỨC NĂNG XUẤT EXCEL (MỚI)
        // =================================================================
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            // Xuất dữ liệu từ DataGridView Chi Tiết
            ExportToExcel(dgvChiTiet);
        }

        private void ExportToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls"; // Lưu dạng .xls (text-based) để tương thích tốt nhất
            sfd.FileName = "BaoCao_ThuVien_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Sử dụng Encoding.Unicode để hỗ trợ Tiếng Việt tuyệt đối trong Excel
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                    {
                        // 1. Viết tiêu đề cột
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sw.Write(dgv.Columns[i].HeaderText);
                            if (i < dgv.Columns.Count - 1) sw.Write("\t"); // Dùng Tab làm phân cách
                        }
                        sw.WriteLine();

                        // 2. Viết dữ liệu dòng
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    // Xóa các ký tự xuống dòng để tránh vỡ format
                                    string val = row.Cells[i].Value.ToString().Replace("\n", " ").Replace("\r", " ").Replace("\t", "    ");
                                    sw.Write(val);
                                }
                                if (i < dgv.Columns.Count - 1) sw.Write("\t");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(sfd.FileName); // Mở file ngay lập tức
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =================================================================
        // CÁC BIỂU ĐỒ (Charts)
        // =================================================================
        private void LoadBarChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlBarChart.Controls.Clear();
            var data = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                .GroupBy(pm => DbFunctions.TruncateTime(pm.NGAYLAPPHIEUMUON))
                .Select(g => new { Ngay = g.Key, SoLuong = g.Count() }).OrderBy(x => x.Ngay).ToList();

            Label lblTitle = new Label { Text = "📊 XU HƯỚNG MƯỢN SÁCH THEO NGÀY", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), Location = new Point(20, 15), AutoSize = true };
            pnlBarChart.Controls.Add(lblTitle);
            if (data.Count == 0) return;

            int maxValue = data.Max(x => x.SoLuong); if (maxValue == 0) maxValue = 1;
            int yPos = 60; int barH = 30; int maxW = 600;

            foreach (var item in data)
            {
                string ngay = item.Ngay.HasValue ? item.Ngay.Value.ToString("dd/MM") : "";
                int w = (int)(item.SoLuong * maxW / maxValue); if (w < 20) w = 20;
                Label lblN = new Label { Text = ngay, Location = new Point(20, yPos + 5), Size = new Size(50, 20) };
                Panel bar = new Panel { BackColor = Color.FromArgb(52, 152, 219), Location = new Point(80, yPos), Size = new Size(w, barH) };
                Label lblV = new Label { Text = item.SoLuong.ToString(), Location = new Point(80 + w + 5, yPos + 5), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
                pnlBarChart.Controls.AddRange(new Control[] { lblN, bar, lblV });
                yPos += 40;
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
                        select new { TheLoai = g.Key ?? "Khác", SoLuong = g.Count() }).OrderByDescending(x => x.SoLuong).Take(10).ToList();

            Label lblTitle = new Label { Text = "🥧 TỶ LỆ CÁC THỂ LOẠI SÁCH", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), Location = new Point(20, 15), AutoSize = true };
            pnlPieChart.Controls.Add(lblTitle);
            if (data.Count == 0) return;
            int total = data.Sum(x => x.SoLuong); if (total == 0) total = 1;

            PictureBox pb = new PictureBox { Location = new Point(20, 60), Size = new Size(800, 400), BackColor = Color.White };
            pb.Paint += (s, ev) => {
                Graphics g = ev.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(50, 20, 300, 300);
                float start = 0; int legX = 400; int legY = 20; int i = 0;
                foreach (var item in data)
                {
                    float sweep = (float)(item.SoLuong * 360.0 / total);
                    Color c = chartColors[i % chartColors.Length];
                    using (Brush b = new SolidBrush(c)) { g.FillPie(b, rect, start, sweep); g.FillRectangle(b, legX, legY, 15, 15); }
                    g.DrawString($"{item.TheLoai} ({item.SoLuong})", new Font("Segoe UI", 10), Brushes.Black, legX + 25, legY);
                    start += sweep; legY += 25; i++;
                }
            };
            pnlPieChart.Controls.Add(pb);
        }

        private void LoadTopReadersChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlTopDocGia.Controls.Clear();
            var data = db.PHIEUMUONs.Where(pm => pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay)
                .GroupBy(pm => pm.MASV).Select(g => new { MaSV = g.Key, SoLuong = g.Count() }).OrderByDescending(x => x.SoLuong).Take(5).ToList();
            var svIds = data.Select(x => x.MaSV).ToList();
            var svInfos = db.SINHVIENs.Where(sv => svIds.Contains(sv.MASV)).ToList();
            var finalData = data.Select(d => new { Ten = svInfos.FirstOrDefault(s => s.MASV == d.MaSV)?.HOVATEN ?? d.MaSV.ToString(), d.SoLuong }).ToList();

            Label lblTitle = new Label { Text = "🏆 TOP 5 ĐỘC GIẢ TÍCH CỰC NHẤT", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), Location = new Point(20, 15), AutoSize = true };
            pnlTopDocGia.Controls.Add(lblTitle);
            if (finalData.Count == 0) return;

            PictureBox pb = new PictureBox { Location = new Point(20, 60), Size = new Size(800, 400), BackColor = Color.White };
            pb.Paint += (s, ev) => {
                Graphics g = ev.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                int y = 20; int maxVal = finalData.Max(x => x.SoLuong); if (maxVal == 0) maxVal = 1; int maxBarW = 400;
                for (int i = 0; i < finalData.Count; i++)
                {
                    var item = finalData[i]; int barW = (int)(item.SoLuong * maxBarW / maxVal);
                    Color c = chartColors[i % chartColors.Length];
                    g.DrawString($"#{i + 1} {item.Ten}", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.DimGray, 10, y);
                    Rectangle r = new Rectangle(250, y, barW, 30);
                    using (Brush b = new LinearGradientBrush(r, c, ControlPaint.Light(c), 0f)) { g.FillRectangle(b, r); }
                    g.DrawString($"{item.SoLuong} lần", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, 250 + barW + 10, y + 5);
                    y += 50;
                }
            };
            pnlTopDocGia.Controls.Add(pb);
        }

        private void LoadOverdueChart(DateTime tuNgay, DateTime denNgay)
        {
            pnlDoughnut.Controls.Clear();
            var dataTra = (from pt in db.PHIEUTRAs
                           join pm in db.PHIEUMUONs on pt.MAPM equals pm.MAPM
                           where pt.NGAYLAPPHIEUTRA >= tuNgay && pt.NGAYLAPPHIEUTRA < denNgay
                           select new { NgayTra = pt.NGAYLAPPHIEUTRA, HanTra = pm.HANTRA }).ToList();
            int dungHan = dataTra.Count(x => x.NgayTra <= x.HanTra); int treHan = dataTra.Count(x => x.NgayTra > x.HanTra); int total = dungHan + treHan;

            Label lblTitle = new Label { Text = "🍩 TỶ LỆ TRẢ SÁCH (ĐÚNG HẠN vs TRỄ HẠN)", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(52, 73, 94), Location = new Point(20, 15), AutoSize = true };
            pnlDoughnut.Controls.Add(lblTitle);
            if (total == 0) { Label lblNull = new Label { Text = "Chưa có dữ liệu trả sách.", Location = new Point(20, 60), AutoSize = true, ForeColor = Color.Red }; pnlDoughnut.Controls.Add(lblNull); return; }

            PictureBox pb = new PictureBox { Location = new Point(20, 60), Size = new Size(800, 450), BackColor = Color.White };
            pb.Paint += (s, ev) => {
                Graphics g = ev.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; Rectangle rect = new Rectangle(50, 20, 300, 300);
                float start = 0; float sweepDung = (float)(dungHan * 360.0 / total); float sweepTre = (float)(treHan * 360.0 / total);
                using (Brush b = new SolidBrush(Color.FromArgb(46, 204, 113))) { g.FillPie(b, rect, start, sweepDung); g.FillRectangle(b, 400, 50, 20, 20); g.DrawString($"Đúng hạn: {dungHan} ({dungHan * 100.0 / total:F1}%)", new Font("Segoe UI", 11), Brushes.Black, 430, 50); }
                start += sweepDung;
                using (Brush b = new SolidBrush(Color.FromArgb(231, 76, 60))) { g.FillPie(b, rect, start, sweepTre); g.FillRectangle(b, 400, 90, 20, 20); g.DrawString($"Trễ hạn: {treHan} ({treHan * 100.0 / total:F1}%)", new Font("Segoe UI", 11), Brushes.Black, 430, 90); }
                using (Brush b = new SolidBrush(Color.White)) { g.FillEllipse(b, 125, 95, 150, 150); }
                string totalStr = total.ToString(); SizeF size = g.MeasureString(totalStr, new Font("Segoe UI", 20, FontStyle.Bold));
                g.DrawString(totalStr, new Font("Segoe UI", 20, FontStyle.Bold), Brushes.DimGray, 200 - (size.Width / 2), 150); g.DrawString("Phiếu trả", new Font("Segoe UI", 10), Brushes.Gray, 200 - 30, 185);
            };
            pnlDoughnut.Controls.Add(pb);
        }

        private void LoadDanhSachBaoCao()
        {
            try
            {
                DataTable dt = new DataTable(); dt.Columns.Add("STT", typeof(int)); dt.Columns.Add("Tên File"); dt.Columns.Add("Ngày Gửi"); dt.Columns.Add("Kích Thước"); dt.Columns.Add("Loại"); dt.Columns.Add("DuongDan");
                int stt = 1; if (Directory.Exists(reportFolder))
                {
                    var allFiles = Directory.GetFiles(reportFolder, "*.*").Select(f => new FileInfo(f)).OrderByDescending(f => f.CreationTime).ToList();
                    foreach (var file in allFiles) { if (file.Extension.ToLower() != ".pdf" && file.Extension.ToLower() != ".txt") continue; dt.Rows.Add(stt++, file.Name, file.CreationTime.ToString("dd/MM/yyyy HH:mm"), $"{file.Length / 1024.0:F1} KB", file.Extension.Replace(".", "").ToUpper(), file.FullName); }
                }
                dgvBaoCao.DataSource = dt; if (dgvBaoCao.Columns.Contains("DuongDan")) dgvBaoCao.Columns["DuongDan"].Visible = false; if (lblTongBaoCao != null) lblTongBaoCao.Text = (stt - 1).ToString();
            }
            catch { }
        }

        private void LoadChiTiet(DateTime tuNgay, DateTime denNgay)
        {
            var data = (from pm in db.PHIEUMUONs
                        join ct in db.CHITIETPHIEUMUONs on pm.MAPM equals ct.MAPM
                        join s in db.SACHes on ct.MASACH equals s.MASACH
                        join sv in db.SINHVIENs on pm.MASV equals sv.MASV
                        where pm.NGAYLAPPHIEUMUON >= tuNgay && pm.NGAYLAPPHIEUMUON < denNgay
                        orderby pm.NGAYLAPPHIEUMUON descending
                        select new { pm.MAPM, sv.HOVATEN, s.TENSACH, s.THELOAI, pm.NGAYLAPPHIEUMUON, pm.HANTRA, pm.TRANGTHAI }).Take(100).ToList();
            DataTable dt = new DataTable(); dt.Columns.Add("Mã", typeof(int)); dt.Columns.Add("Độc Giả"); dt.Columns.Add("Sách"); dt.Columns.Add("Thể Loại"); dt.Columns.Add("Ngày Mượn"); dt.Columns.Add("Hạn Trả"); dt.Columns.Add("Trạng Thái");
            foreach (var item in data) { dt.Rows.Add(item.MAPM, item.HOVATEN, item.TENSACH, item.THELOAI, item.NGAYLAPPHIEUMUON.ToString("dd/MM/yyyy"), item.HANTRA.ToString("dd/MM/yyyy"), item.TRANGTHAI); }
            dgvChiTiet.DataSource = dt;
        }

        private void DgvBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) { string path = dgvBaoCao.Rows[e.RowIndex].Cells["DuongDan"].Value?.ToString(); if (File.Exists(path)) Process.Start(path); } }
        private void dgvDanhSachBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { DgvBaoCao_CellDoubleClick(sender, e); }
        private void BtnMoThuMuc_Click(object sender, EventArgs e) { if (Directory.Exists(reportFolder)) Process.Start("explorer.exe", reportFolder); }
    }
}