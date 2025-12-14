using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WindowsForm_QLTV;

namespace WindowsForm_QLTV
{
    public partial class FormTraSach : Form
    {
        private int _currentMaSV = -1;

        public FormTraSach()
        {
            InitializeComponent();

            // Gán sự kiện
            dgvActiveLoans.CellClick += DgvActiveLoans_CellClick;
            btnXacNhanTra.Click += BtnXacNhanTra_Click;
            btnHuy.Click += BtnHuy_Click;

            SetupDataGridViews();
            this.Load += FormTraSach_Load;
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllActiveLoans();
        }

        private void SetupDataGridViews()
        {
            // Cấu hình bảng Danh sách phiếu mượn (Bên trên)
            dgvActiveLoans.AutoGenerateColumns = false;
            dgvActiveLoans.Columns.Clear();
            dgvActiveLoans.Columns.Add(CreateColumn("MaPhieuMuon", "Mã PM", 80));
            dgvActiveLoans.Columns.Add(CreateColumn("TenDocGia", "Tên Độc Giả", 180));
            dgvActiveLoans.Columns.Add(CreateColumn("NgayMuon", "Ngày Mượn", 120));
            dgvActiveLoans.Columns.Add(CreateColumn("HenTra", "Hẹn Trả", 120));
            dgvActiveLoans.Columns.Add(CreateColumn("TinhTrang", "Trạng Thái", 120)); // Cột quan trọng
            dgvActiveLoans.ReadOnly = true;
            dgvActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cấu hình bảng Chi tiết sách (Bên dưới)
            dgvLoanDetails.AutoGenerateColumns = false;
            dgvLoanDetails.Columns.Clear();
            dgvLoanDetails.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvLoanDetails.Columns.Add(CreateColumn("TenSach", "Tên Sách", 250));
            dgvLoanDetails.Columns.Add(CreateColumn("SoLuongMuonBanDau", "SL Mượn", 100));
            dgvLoanDetails.ReadOnly = true;
            dgvLoanDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void ClearForm()
        {
            txtTenDocGia.Text = "Chưa có phiếu mượn nào được chọn.";
            txtSLTra.Text = "1"; // Mặc định, dù logic mới trả toàn bộ phiếu
            txtSLTra.Enabled = false; // Khóa lại vì trả theo phiếu
            _currentMaSV = -1;

            dgvActiveLoans.DataSource = null;
            dgvLoanDetails.DataSource = null;
            dgvLoanDetails.Tag = null;

            lblDocGiaStatus.Text = "Tổng quan yêu cầu trả sách";
            lblDocGiaStatus.ForeColor = Color.Black;
        }

        // Tải danh sách phiếu: Bao gồm cả 'Chờ trả' để thủ thư xử lý
        private void LoadAllActiveLoans()
        {
            try
            {
                using (var db = new Model1())
                {
                    // [QUAN TRỌNG] Thêm "Chờ trả" vào danh sách hiển thị
                    var activeStatuses = new[] { "Đang mượn", "Chờ trả", "Chờ trả quá hạn", "Đã trả quá hạn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu" };

                    var activeLoans = db.PHIEUMUONs
                                        .AsNoTracking()
                                        .Include(pm => pm.SINHVIEN)
                                        .Where(pm => activeStatuses.Contains(pm.TRANGTHAI))
                                        .OrderByDescending(pm => pm.NGAYLAPPHIEUMUON) // Phiếu mới nhất lên đầu
                                        .Select(pm => new LoanSummaryViewModel
                                        {
                                            MaPhieuMuon = pm.MAPM,
                                            MaSV = pm.MASV,
                                            TenDocGia = pm.SINHVIEN.HOVATEN,
                                            NgayMuon = pm.NGAYLAPPHIEUMUON,
                                            HenTra = pm.HANTRA,
                                            TinhTrang = pm.TRANGTHAI
                                        })
                                        .ToList();

                    dgvActiveLoans.DataSource = activeLoans;

                    // Thêm cột ẩn MaSV nếu chưa có
                    if (!dgvActiveLoans.Columns.Contains("MaSV"))
                    {
                        var maSVCol = new DataGridViewTextBoxColumn
                        {
                            Name = "MaSV",
                            DataPropertyName = "MaSV",
                            Visible = false
                        };
                        dgvActiveLoans.Columns.Add(maSVCol);
                    }

                    lblActiveLoansTitle.Text = $"DANH SÁCH {activeLoans.Count} PHIẾU CẦN XỬ LÝ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvActiveLoans.Rows[e.RowIndex].DataBoundItem != null)
            {
                var selectedRow = dgvActiveLoans.Rows[e.RowIndex];

                // Lấy thông tin từ dòng đã chọn (ViewModel)
                var item = selectedRow.DataBoundItem as LoanSummaryViewModel;
                if (item != null)
                {
                    _currentMaSV = item.MaSV;
                    txtTenDocGia.Text = $"MSV: {item.MaSV} - {item.TenDocGia} (Phiếu #{item.MaPhieuMuon})";

                    // Hiển thị trạng thái để thủ thư chú ý
                    lblDocGiaStatus.Text = $"Trạng thái phiếu: {item.TinhTrang}";
                    if (item.TinhTrang == "Chờ trả")
                    {
                        lblDocGiaStatus.ForeColor = Color.Green; // Màu xanh: Sẵn sàng xử lý
                        lblDocGiaStatus.Text += " (Độc giả đã yêu cầu)";
                    }
                    else
                    {
                        lblDocGiaStatus.ForeColor = Color.Red; // Màu đỏ: Chưa có yêu cầu
                    }

                    LoadLoanDetails(item.MaPhieuMuon);
                }
            }
        }

        // Tải chi tiết sách trong phiếu
        private void LoadLoanDetails(int maPM)
        {
            try
            {
                using (var db = new Model1())
                {
                    var chiTietMuon = db.CHITIETPHIEUMUONs
                                        .AsNoTracking()
                                        .Include(ct => ct.SACH)
                                        .Where(ct => ct.MAPM == maPM)
                                        .Select(ct => new BookDebtViewModel
                                        {
                                            MaSach = ct.MASACH,
                                            TenSach = ct.SACH.TENSACH,
                                            SoLuongMuonBanDau = ct.SOLUONG,
                                            // Với logic trả cả phiếu, ta chỉ cần hiển thị số lượng mượn
                                            SoLuongDaTra = 0,
                                            SoLuongConNo = ct.SOLUONG
                                        })
                                        .ToList();

                    dgvLoanDetails.DataSource = chiTietMuon;
                    dgvLoanDetails.Tag = maPM; // Lưu Mã phiếu vào Tag để dùng lúc xác nhận
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết: {ex.Message}");
            }
        }

        // =============================================================
        // LOGIC CHÍNH: XÁC NHẬN TRẢ SÁCH
        // =============================================================
        private void BtnXacNhanTra_Click(object sender, EventArgs e)
        {
            // 0. Kiểm tra đăng nhập thủ thư
            if (Session.CurrentMaTT <= 0)
            {
                MessageBox.Show("Vui lòng đăng nhập bằng tài khoản Thủ thư để thực hiện chức năng này.",
                                "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Kiểm tra đã chọn dòng chưa
            if (dgvActiveLoans.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ dòng đang chọn
            var selectedItem = dgvActiveLoans.CurrentRow.DataBoundItem as LoanSummaryViewModel;
            if (selectedItem == null) return;

            string trangThaiHienTai = selectedItem.TinhTrang;

            // 2. BỘ LỌC ĐẦU VÀO (Quan trọng)
            // - Nếu là "Đang mượn" -> Bắt độc giả gửi yêu cầu trước.
            // - Nếu là "Chờ trả", "Chờ trả quá hạn", "Quá hạn" -> CHO PHÉP xử lý.
            if (trangThaiHienTai.Equals("Đang mượn", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Độc giả CHƯA gửi yêu cầu trả sách.\nVui lòng bảo độc giả gửi yêu cầu trước (để hệ thống ghi nhận trạng thái).",
                                "Chưa có yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // - Nếu đã trả rồi (Đã trả / Đã trả quá hạn) -> Chặn.
            if (trangThaiHienTai.Contains("Đã trả"))
            {
                MessageBox.Show("Phiếu này đã hoàn tất trả sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. XÁC NHẬN VÀ XỬ LÝ
            if (MessageBox.Show($"Xác nhận nhận lại sách cho phiếu #{selectedItem.MaPhieuMuon}?",
                                "Xác nhận Trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var phieuMuon = db.PHIEUMUONs.Find(selectedItem.MaPhieuMuon);
                        if (phieuMuon != null)
                        {
                            // A. TÍNH TOÁN QUÁ HẠN & TIỀN PHẠT
                            double tienPhat = 0;
                            int soNgayQuaHan = 0;
                            DateTime ngayTraThucTe = DateTime.Now;

                            // So sánh ngày hiện tại với Hạn trả
                            if (ngayTraThucTe.Date > phieuMuon.HANTRA.Date)
                            {
                                TimeSpan span = ngayTraThucTe.Date - phieuMuon.HANTRA.Date;
                                soNgayQuaHan = span.Days;
                                // Ví dụ: Phạt 2.000đ/ngày
                                tienPhat = soNgayQuaHan * 2000;
                            }

                            // B. TẠO PHIẾU TRẢ (Lưu lịch sử trả + phạt)
                            PHIEUTRA phieuTra = new PHIEUTRA();
                            phieuTra.MAPM = phieuMuon.MAPM;
                            phieuTra.MATT = Session.CurrentMaTT; // Lấy mã thủ thư
                            phieuTra.NGAYLAPPHIEUTRA = ngayTraThucTe;
                            phieuTra.SONGAYQUAHAN = soNgayQuaHan;
                            phieuTra.TONGTIENPHAT = tienPhat;

                            // Xét trạng thái thanh toán tiền phạt
                            if (tienPhat > 0)
                            {
                                phieuTra.TRANGTHAIPHAT = "Chưa thanh toán";
                            }
                            else
                            {
                                phieuTra.TRANGTHAIPHAT = "Không có";
                            }

                            db.PHIEUTRAs.Add(phieuTra);
                            db.SaveChanges(); // Lưu để lấy MAPT (khóa chính tự tăng)

                            // C. TẠO CHI TIẾT PHIẾU TRẢ & CỘNG LẠI TỒN KHO SÁCH
                            var listChiTiet = db.CHITIETPHIEUMUONs.Where(ct => ct.MAPM == selectedItem.MaPhieuMuon).ToList();
                            foreach (var ct in listChiTiet)
                            {
                                // Tạo chi tiết phiếu trả
                                CHITIETPHIEUTRA chiTietTra = new CHITIETPHIEUTRA();
                                chiTietTra.MAPT = phieuTra.MAPT; // Lấy MAPT vừa được tạo
                                chiTietTra.MASACH = ct.MASACH;
                                chiTietTra.SOLUONGTRA = ct.SOLUONG;
                                chiTietTra.NGAYTRA = ngayTraThucTe;
                                db.CHITIETPHIEUTRAs.Add(chiTietTra);

                                // Cộng lại tồn kho
                                var sach = db.SACHes.Find(ct.MASACH);
                                if (sach != null)
                                {
                                    sach.SOLUONGTON += ct.SOLUONG;
                                }
                            }

                            // D. CẬP NHẬT TRẠNG THÁI PHIẾU MƯỢN
                            if (soNgayQuaHan > 0)
                            {
                                phieuMuon.TRANGTHAI = "Đã trả quá hạn";
                            }
                            else
                            {
                                phieuMuon.TRANGTHAI = "Đã trả";
                            }

                            // E. LƯU VÀO DATABASE
                            db.SaveChanges();

                            // Thông báo cho thủ thư biết nếu có tiền phạt
                            if (tienPhat > 0)
                            {
                                MessageBox.Show($"⚠️ SÁCH QUÁ HẠN {soNgayQuaHan} NGÀY!\n" +
                                                $"-----------------------------------\n" +
                                                $"💰 Tổng tiền phạt: {tienPhat:N0} VNĐ\n" +
                                                $"📝 Hệ thống đã ghi nợ. Yêu cầu độc giả đóng phạt.",
                                                "CẢNH BÁO QUÁ HẠN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            MessageBox.Show("Đã xác nhận trả sách thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tải lại giao diện
                            LoadAllActiveLoans();
                            dgvLoanDetails.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                    if (ex.InnerException != null)
                    {
                        errorMessage = ex.InnerException.Message;
                    }
                    MessageBox.Show("Lỗi hệ thống: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllActiveLoans();
        }

        // --- View Models ---
        public class LoanSummaryViewModel
        {
            public int MaPhieuMuon { get; set; }
            public int MaSV { get; set; }
            public string TenDocGia { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime HenTra { get; set; }
            public string TinhTrang { get; set; }
        }

        public class BookDebtViewModel
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuongMuonBanDau { get; set; }
            public int SoLuongDaTra { get; set; }
            public int SoLuongConNo { get; set; }
        }
    }
}