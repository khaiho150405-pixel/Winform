using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace WindowsForm_QLTV
{
    public partial class FormTraSach : Form
    {
        private int _currentMaSV = -1; // Mã SV của phiếu mượn đang được chọn
        private const int CurrentMaTT = 1;

        public FormTraSach()
        {
            InitializeComponent();

            // Đã loại bỏ nút tìm kiếm, chỉ giữ lại xử lý cho DataGridView
            dgvActiveLoans.CellClick += DgvActiveLoans_CellClick;
            btnXacNhanTra.Click += BtnXacNhanTra_Click;
            btnHuy.Click += BtnHuy_Click;

            SetupDataGridViews();
            this.Load += FormTraSach_Load;
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            // Tải tất cả phiếu mượn đang hoạt động của tất cả độc giả ngay khi form mở
            ClearForm();
            LoadAllActiveLoans();
        }

        private void SetupDataGridViews()
        {
            // Thiết lập dgvActiveLoans
            dgvActiveLoans.AutoGenerateColumns = false;
            dgvActiveLoans.Columns.Clear();
            dgvActiveLoans.Columns.Add(CreateColumn("MaPhieuMuon", "Mã PM", 80));
            dgvActiveLoans.Columns.Add(CreateColumn("TenDocGia", "Tên Độc Giả", 180));
            dgvActiveLoans.Columns.Add(CreateColumn("NgayMuon", "Ngày Mượn", 120));
            dgvActiveLoans.Columns.Add(CreateColumn("HenTra", "Hẹn Trả", 120));
            dgvActiveLoans.Columns.Add(CreateColumn("TinhTrang", "Trạng Thái", 100));
            dgvActiveLoans.ReadOnly = true;

            // Thiết lập dgvLoanDetails
            dgvLoanDetails.AutoGenerateColumns = false;
            dgvLoanDetails.Columns.Clear();
            dgvLoanDetails.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvLoanDetails.Columns.Add(CreateColumn("TenSach", "Tên Sách", 200));
            dgvLoanDetails.Columns.Add(CreateColumn("SoLuongMuonBanDau", "SL Mượn", 80));
            dgvLoanDetails.Columns.Add(CreateColumn("SoLuongDaTra", "SL Đã Trả", 80));
            dgvLoanDetails.Columns.Add(CreateColumn("SoLuongConNo", "SL Còn Nợ", 80));
            dgvLoanDetails.ReadOnly = true;
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
            // Cập nhật text fields
            txtTenDocGia.Text = "Chưa có phiếu mượn nào được chọn.";
            txtSLTra.Text = "1";
            _currentMaSV = -1;

            // Đặt lại DataGridViews
            dgvActiveLoans.DataSource = null;
            dgvLoanDetails.DataSource = null;
            dgvLoanDetails.Tag = null;

            // Cập nhật trạng thái
            lblDocGiaStatus.Text = "Tổng quan yêu cầu trả sách";
            lblDocGiaStatus.ForeColor = Color.Black;
        }

        // Tải tất cả phiếu mượn đang hoạt động của tất cả độc giả
        private void LoadAllActiveLoans()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Các trạng thái hoạt động theo DB Script (ThuVienDB.sql)
                    var activeStatuses = new[] { "Đang mượn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu", "Chờ duyệt" };

                    var activeLoans = db.PHIEUMUONs
                                             .AsNoTracking()
                                             .Include(pm => pm.SINHVIEN) // Bắt buộc phải Include để lấy tên độc giả
                                             .Where(pm => activeStatuses.Contains(pm.TRANGTHAI))
                                             .OrderByDescending(pm => pm.NGAYLAPPHIEUMUON)
                                             .Select(pm => new LoanSummaryViewModel
                                             {
                                                 MaPhieuMuon = pm.MAPM,
                                                 MaSV = pm.MASV, // THÊM MÃ SV
                                                 TenDocGia = pm.SINHVIEN.HOVATEN,
                                                 NgayMuon = pm.NGAYLAPPHIEUMUON,
                                                 HenTra = pm.HANTRA,
                                                 TinhTrang = pm.TRANGTHAI
                                             })
                                             .ToList();

                    dgvActiveLoans.DataSource = activeLoans;

                    // Cập nhật tiêu đề và trạng thái
                    lblActiveLoansTitle.Text = $"DANH SÁCH {activeLoans.Count} PHIẾU MƯỢN ĐANG HOẠT ĐỘNG TRÊN HỆ THỐNG";
                    lblDocGiaStatus.Text = $"Đã tải {activeLoans.Count} phiếu. Vui lòng chọn phiếu để xử lý.";

                    // Đảm bảo cột MaSV được thêm (ẩn) nếu chưa có
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phiếu mượn toàn hệ thống: {ex.Message}", "Lỗi Database");
            }
        }

        private void DgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvActiveLoans.Rows[e.RowIndex].DataBoundItem != null)
            {
                DataGridViewRow selectedRow = dgvActiveLoans.Rows[e.RowIndex];

                // Lấy Mã PM và Mã SV từ hàng được chọn
                if (int.TryParse(selectedRow.Cells["MaPhieuMuon"].Value.ToString(), out int maPM))
                {
                    int maSV = (int)selectedRow.Cells["MaSV"].Value;

                    // Cập nhật trạng thái độc giả đang được xử lý
                    _currentMaSV = maSV;
                    string tenDocGia = selectedRow.Cells["TenDocGia"].Value.ToString();
                    string tinhTrang = selectedRow.Cells["TinhTrang"].Value.ToString();

                    txtTenDocGia.Text = $"MSV: {maSV} - {tenDocGia} (Phiếu #{maPM})";
                    lblDocGiaStatus.Text = $"Đang xử lý: {tinhTrang} của {tenDocGia}";
                    lblDocGiaStatus.ForeColor = Color.Blue;

                    LoadLoanDetails(maPM);
                }
                else
                {
                    MessageBox.Show("Không thể lấy Mã Phiếu Mượn. Vui lòng kiểm tra dữ liệu.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLoanDetails(int maPM)
        {
            try
            {
                using (var db = new Model1())
                {
                    // Lấy chi tiết phiếu mượn
                    var chiTietMuon = db.CHITIETPHIEUMUONs
                                         .AsNoTracking()
                                         .Include(ct => ct.SACH)
                                         .Where(ct => ct.MAPM == maPM)
                                         .ToList();

                    // Lấy tổng số lượng sách đã trả cho Phiếu Mượn này
                    var chiTietTraDaThanhToan = (from ctt in db.CHITIETPHIEUTRAs
                                                 join pt in db.PHIEUTRAs on ctt.MAPT equals pt.MAPT
                                                 where pt.MAPM == maPM
                                                 select ctt)
                                                 .AsNoTracking()
                                                 .ToList();

                    var result = chiTietMuon.Select(ct =>
                    {
                        // Tính toán số lượng đã trả từ kết quả join
                        int daTraTruoc = chiTietTraDaThanhToan
                                             .Where(ctt => ctt.MASACH == ct.MASACH)
                                             .Sum(ctt => ctt.SOLUONGTRA.HasValue ? ctt.SOLUONGTRA.Value : 0);

                        int conNo = ct.SOLUONG - daTraTruoc;

                        return new BookDebtViewModel
                        {
                            MaSach = ct.MASACH,
                            TenSach = ct.SACH.TENSACH,
                            SoLuongMuonBanDau = ct.SOLUONG,
                            SoLuongDaTra = daTraTruoc,
                            SoLuongConNo = conNo
                        };
                    })
                    .Where(vm => vm.SoLuongConNo > 0) // Chỉ hiển thị sách còn nợ
                    .ToList();

                    dgvLoanDetails.DataSource = result;
                    dgvLoanDetails.Tag = maPM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết phiếu mượn: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXacNhanTra_Click(object sender, EventArgs e)
        {
            if (dgvLoanDetails.CurrentRow == null || dgvLoanDetails.Tag == null || _currentMaSV == -1)
            {
                MessageBox.Show("Vui lòng đảm bảo đã chọn Phiếu Mượn và Sách cần trả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPM = (int)dgvLoanDetails.Tag;

            if (!int.TryParse(dgvLoanDetails.CurrentRow.Cells["MaSach"].Value.ToString(), out int maSach)) return;
            if (!int.TryParse(dgvLoanDetails.CurrentRow.Cells["SoLuongConNo"].Value.ToString(), out int soLuongConNo)) return;

            if (!int.TryParse(txtSLTra.Text, out int soLuongTra) || soLuongTra <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng trả hợp lệ (> 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuongTra > soLuongConNo)
            {
                MessageBox.Show($"Số lượng trả vượt quá số lượng còn nợ ({soLuongConNo} cuốn).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    // 1. Tạo Phiếu Trả (PHIEUTRA)
                    PHIEUTRA phieuTra = new PHIEUTRA
                    {
                        MAPM = maPM,
                        MATT = CurrentMaTT,
                        NGAYLAPPHIEUTRA = DateTime.Now.Date,
                        TONGTIENPHAT = 0
                    };
                    db.PHIEUTRAs.Add(phieuTra);
                    db.SaveChanges();

                    // 2. Tạo Chi Tiết Phiếu Trả (CHITIETPHIEUTRA)
                    CHITIETPHIEUTRA chiTietTra = new CHITIETPHIEUTRA
                    {
                        MASACH = maSach,
                        SOLUONGTRA = soLuongTra,
                        MAPT = phieuTra.MAPT,
                        NGAYTRA = DateTime.Now.Date
                    };
                    db.CHITIETPHIEUTRAs.Add(chiTietTra);

                    // 3. Cập nhật trạng thái PHIEUMUON (Đồng bộ với Trigger)
                    var phieuMuon = db.PHIEUMUONs.Find(maPM);
                    int tongMuon = db.CHITIETPHIEUMUONs.Where(ct => ct.MAPM == maPM).Sum(ct => ct.SOLUONG);

                    // Tính tổng số lượng trả MỚI (bao gồm cả lần trả này)
                    int tongTraMoi = (from ctt in db.CHITIETPHIEUTRAs
                                      join pt in db.PHIEUTRAs on ctt.MAPT equals pt.MAPT
                                      where pt.MAPM == maPM
                                      select ctt.SOLUONGTRA)
                                       .Sum(x => x.HasValue ? x.Value : 0);

                    if (tongTraMoi >= tongMuon)
                    {
                        phieuMuon.TRANGTHAI = "Đã trả";
                    }

                    db.SaveChanges();
                    MessageBox.Show($"Xác nhận trả {soLuongTra} cuốn sách (Mã: {maSach}) thành công! (Phiếu Trả #{phieuTra.MAPT})", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu (ĐÃ SỬA LỖI GÕ NHẦM HÀM)
                    LoadLoanDetails(maPM); // Cập nhật chi tiết phiếu mượn đang chọn
                    LoadAllActiveLoans(); // Cập nhật danh sách toàn hệ thống
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý trả sách: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            LoadAllActiveLoans(); // Tải lại toàn bộ danh sách để bắt đầu quy trình mới
            MessageBox.Show("Đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ViewModels
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

        // Class giả định SessionManager giữ nguyên
        public static class SessionManager
        {
            public static int CurrentMaSV { get; set; } = 1;
            public static int CurrentMaTT { get; set; } = 1;
        }
    }
}