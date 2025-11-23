using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormMuonSach : Form
    {
        private const int CurrentMaTT = 1; // Lấy từ SessionManager.CurrentMaTT

        public FormMuonSach()
        {
            InitializeComponent();

            btnXacNhan.Click += BtnXacNhanChoMuon_Click;
            btnTuChoi.Click += BtnTuChoiMuon_Click;

            dgvPendingLoans.CellClick += DgvPendingLoans_CellClick;
            dgvChiTietMuon.CellClick += DgvChiTietMuon_CellClick;

            SetupDataGridViews();
            this.Load += FormMuonSach_Load;
        }

        private void FormMuonSach_Load(object sender, EventArgs e)
        {
            LoadPendingLoans();
            ClearDetailPanel();
        }

        private void SetupDataGridViews()
        {
            // Thiết lập DGV chính: Danh sách phiếu chờ
            dgvPendingLoans.AutoGenerateColumns = false;
            dgvPendingLoans.Columns.Clear();
            dgvPendingLoans.Columns.Add(CreateColumn("MaPhieuMuon", "Mã PM", 70));
            dgvPendingLoans.Columns.Add(CreateColumn("TenDocGia", "Tên Độc Giả", 150));
            dgvPendingLoans.Columns.Add(CreateColumn("NgayLap", "Ngày Lập", 90));
            dgvPendingLoans.ReadOnly = true;
            dgvPendingLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Thiết lập DGV phụ: Chi tiết sách trong phiếu
            dgvChiTietMuon.AutoGenerateColumns = false;
            dgvChiTietMuon.Columns.Clear();
            dgvChiTietMuon.Columns.Add(CreateColumn("MaSach", "Mã Sách", 60));
            dgvChiTietMuon.Columns.Add(CreateColumn("TenSach", "Tên Sách", 180));
            dgvChiTietMuon.Columns.Add(CreateColumn("SoLuongMuon", "SL Yêu Cầu", 80));
            dgvChiTietMuon.Columns.Add(CreateColumn("SoLuongTon", "SL Tồn", 60));
            dgvChiTietMuon.ReadOnly = true;
            dgvChiTietMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private DataGridViewTextBoxColumn CreateColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width
            };
        }

        private void ClearDetailPanel()
        {
            dgvChiTietMuon.DataSource = null;
            lblRequestInfo.Text = "Chọn một phiếu mượn bên cạnh để xem chi tiết.";
            lblRequestInfo.Tag = null;
            pbBookCover.Image = null;
            txtTenSach.Text = string.Empty;
            txtSoLuongTon.Text = string.Empty;
            txtSLMuon.Text = string.Empty;
            txtGiaMuon.Text = string.Empty;
        }

        // --- Logic Tải Phiếu Chờ Duyệt ---
        private void LoadPendingLoans()
        {
            try
            {
                using (var db = new Model1())
                {
                    var pendingLoans = db.PHIEUMUONs
                                         .AsNoTracking()
                                         .Where(pm => pm.TRANGTHAI == "Chờ duyệt")
                                         .Select(pm => new PendingLoanViewModel
                                         {
                                             MaPhieuMuon = pm.MAPM,
                                             MaSV = pm.MASV,
                                             TenDocGia = pm.SINHVIEN.HOVATEN,
                                             NgayLap = pm.NGAYLAPPHIEUMUON,
                                             HanTra = pm.HANTRA
                                         })
                                         .ToList();
                    dgvPendingLoans.DataSource = pendingLoans;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phiếu chờ duyệt: {ex.Message}", "Lỗi Database");
            }
        }

        // --- Logic Hiển thị Chi tiết Phiếu khi chọn hàng ---
        private void DgvPendingLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPendingLoans.Rows[e.RowIndex].DataBoundItem as PendingLoanViewModel;
                if (row == null) return;

                // Hiển thị thông tin tổng quan phiếu
                lblRequestInfo.Text = $"Mã PM: {row.MaPhieuMuon} | Độc giả: {row.TenDocGia} | Hạn Trả: {row.HanTra.ToShortDateString()}";
                lblRequestInfo.Tag = row.MaPhieuMuon; // Lưu Mã PM

                LoadLoanDetails(row.MaPhieuMuon);
            }
        }

        private void LoadLoanDetails(int maPM)
        {
            try
            {
                using (var db = new Model1())
                {
                    var chiTiet = db.CHITIETPHIEUMUONs
                                    .AsNoTracking()
                                    .Include(ct => ct.SACH)
                                    .Where(ct => ct.MAPM == maPM)
                                    .Select(ct => new ChiTietMuonViewModel
                                    {
                                        MaSach = ct.MASACH,
                                        TenSach = ct.SACH.TENSACH,
                                        SoLuongMuon = ct.SOLUONG,
                                        SoLuongTon = ct.SACH.SOLUONGTON,
                                        HinhAnh = ct.SACH.HINHANH,
                                        GiaMuon = ct.SACH.GIAMUON
                                    })
                                    .ToList();

                    dgvChiTietMuon.DataSource = chiTiet;

                    // Nếu có chi tiết, chọn hàng đầu tiên để hiển thị ảnh
                    if (chiTiet.Any())
                    {
                        // Giả lập click vào hàng đầu tiên để load chi tiết sách
                        DgvChiTietMuon_CellClick(dgvChiTietMuon, new DataGridViewCellEventArgs(0, 0));
                    }
                    else
                    {
                        ClearDetailPanel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết phiếu: {ex.Message}", "Lỗi Database");
            }
        }

        // --- Logic Hiển thị Ảnh và Giá khi chọn sách trong chi tiết ---
        private void DgvChiTietMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvChiTietMuon.Rows[e.RowIndex].DataBoundItem != null)
            {
                var row = dgvChiTietMuon.Rows[e.RowIndex].DataBoundItem as ChiTietMuonViewModel;
                if (row == null) return;

                // Hiển thị chi tiết sách
                LoadImageFromLocalFolder(pbBookCover, row.HinhAnh);
                txtTenSach.Text = row.TenSach;
                txtSoLuongTon.Text = row.SoLuongTon.ToString();
                txtSLMuon.Text = row.SoLuongMuon.ToString();
                txtGiaMuon.Text = row.GiaMuon.ToString("N0") + " VNĐ"; // Hiển thị giá mượn (Chỉ đọc)

                // Highlight nếu sách không đủ tồn kho
                if (!row.IsAvailable)
                {
                    txtSoLuongTon.BackColor = Color.LightCoral;
                    MessageBox.Show($"CẢNH BÁO: Sách '{row.TenSach}' không đủ tồn kho ({row.SoLuongTon} < {row.SoLuongMuon}).", "Lỗi Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSoLuongTon.BackColor = SystemColors.Window;
                }
            }
        }

        // --- HÀM HỖ TRỢ TẢI ẢNH TỪ THƯ MỤC CỤC BỘ ---
        private void LoadImageFromLocalFolder(PictureBox pb, string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName))
            {
                pb.Image = null;
                return;
            }

            string fullPath = string.Empty;

            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);
                string path2 = Path.Combine(Application.StartupPath, "images", imageFileName);

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
                    pb.Image = null;
                    return;
                }

                // Load ảnh từ MemoryStream để không khóa file
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Position = 0;
                        pb.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                pb.Image = null;
            }
        }

        // --- Logic XÁC NHẬN CHO MƯỢN ---
        private void BtnXacNhanChoMuon_Click(object sender, EventArgs e)
        {
            if (lblRequestInfo.Tag == null || !int.TryParse(lblRequestInfo.Tag.ToString(), out int maPM))
            {
                MessageBox.Show("Vui lòng chọn một Phiếu Mượn để xác nhận.", "Lỗi");
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var phieuMuon = db.PHIEUMUONs.Include(pm => pm.CHITIETPHIEUMUONs).FirstOrDefault(pm => pm.MAPM == maPM);

                    if (phieuMuon == null || phieuMuon.TRANGTHAI != "Chờ duyệt") { return; }

                    // 1. Kiểm tra tồn kho và cập nhật
                    foreach (var ct in phieuMuon.CHITIETPHIEUMUONs)
                    {
                        var sach = db.SACHes.Find(ct.MASACH);
                        if (sach == null || sach.SOLUONGTON < ct.SOLUONG)
                        {
                            MessageBox.Show($"Lỗi: Sách '{sach.TENSACH}' không đủ tồn kho. Phiếu sẽ được chuyển sang trạng thái Từ chối.", "Lỗi Tồn Kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            phieuMuon.TRANGTHAI = "Từ chối";
                            db.SaveChanges();
                            LoadPendingLoans();
                            ClearDetailPanel();
                            return;
                        }
                        sach.SOLUONGTON -= ct.SOLUONG; // Giảm số lượng tồn
                    }

                    // 2. Cập nhật trạng thái và Thủ thư
                    phieuMuon.TRANGTHAI = "Đang mượn";
                    phieuMuon.MATT = CurrentMaTT;

                    db.SaveChanges();
                    MessageBox.Show($"Đã XÁC NHẬN Phiếu Mượn PM{maPM}. Trạng thái: Đang mượn.", "Thành công");
                    LoadPendingLoans();
                    ClearDetailPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xác nhận Phiếu Mượn: " + ex.Message, "Lỗi Database");
            }
        }

        // --- Logic TỪ CHỐI YÊU CẦU ---
        private void BtnTuChoiMuon_Click(object sender, EventArgs e)
        {
            if (lblRequestInfo.Tag == null || !int.TryParse(lblRequestInfo.Tag.ToString(), out int maPM))
            {
                MessageBox.Show("Vui lòng chọn một Phiếu Mượn để từ chối.", "Lỗi");
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var phieuMuon = db.PHIEUMUONs.Find(maPM);

                    if (phieuMuon == null || phieuMuon.TRANGTHAI != "Chờ duyệt") { return; }

                    phieuMuon.TRANGTHAI = "Từ chối";
                    phieuMuon.MATT = CurrentMaTT;

                    db.SaveChanges();
                    MessageBox.Show($"Đã TỪ CHỐI Phiếu Mượn PM{maPM}.", "Thành công");
                    LoadPendingLoans();
                    ClearDetailPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi từ chối Phiếu Mượn: " + ex.Message, "Lỗi Database");
            }
        }

        // ViewModel cho Chi tiết sách trong phiếu chờ duyệt
        public class ChiTietMuonViewModel
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuongMuon { get; set; }
            public int SoLuongTon { get; set; }
            public string HinhAnh { get; set; }
            public decimal GiaMuon { get; set; }
            public bool IsAvailable => SoLuongTon >= SoLuongMuon;
        }

        // ViewModel cho Phiếu Mượn chờ duyệt
        public class PendingLoanViewModel
        {
            public int MaPhieuMuon { get; set; }
            public string TenDocGia { get; set; }
            public int MaSV { get; set; }
            public DateTime NgayLap { get; set; }
            public DateTime HanTra { get; set; }
        }
    }
}