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
        private int _currentMaPM = -1;

        public FormTraSach()
        {
            InitializeComponent();

            // Gán sự kiện
            dgvActiveLoans.CellClick += DgvActiveLoans_CellClick;
            dgvLoanDetails.CellClick += DgvLoanDetails_CellClick;
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
            dgvActiveLoans.Columns.Add(CreateColumn("TinhTrang", "Trạng Thái", 120));
            dgvActiveLoans.ReadOnly = true;
            dgvActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cấu hình bảng Chi tiết sách (Bên dưới)
            dgvLoanDetails.AutoGenerateColumns = false;
            dgvLoanDetails.Columns.Clear();
            dgvLoanDetails.Columns.Add(CreateColumn("MaSach", "Mã Sách", 80));
            dgvLoanDetails.Columns.Add(CreateColumn("TenSach", "Tên Sách", 250));
            dgvLoanDetails.Columns.Add(CreateColumn("SoLuongConNo", "SL Đang Giữ", 100));
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
            txtSLTra.Text = "1";
            txtSLTra.Enabled = true;
            _currentMaSV = -1;
            _currentMaPM = -1;

            dgvActiveLoans.DataSource = null;
            dgvLoanDetails.DataSource = null;

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
                    var activeStatuses = new[] { "Chờ trả", "Chờ trả quá hạn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu" };

                    var activeLoans = db.PHIEUMUONs
                                        .AsNoTracking()
                                        .Include(pm => pm.SINHVIEN)
                                        .Where(pm => activeStatuses.Contains(pm.TRANGTHAI))
                                        .OrderByDescending(pm => pm.NGAYLAPPHIEUMUON)
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

                    lblActiveLoansTitle.Text = $"DANH SÁCH {activeLoans.Count} PHIẾU CẦN XỬ LÝ";

                    txtTenDocGia.Text = "Chưa có phiếu mượn nào được chọn.";
                    lblDocGiaStatus.Text = "Tổng quan yêu cầu trả sách";
                    lblDocGiaStatus.ForeColor = Color.Black;
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
                var item = dgvActiveLoans.Rows[e.RowIndex].DataBoundItem as LoanSummaryViewModel;
                if (item != null)
                {
                    _currentMaSV = item.MaSV;
                    _currentMaPM = item.MaPhieuMuon;

                    txtTenDocGia.Text = $"MSV: {item.MaSV} - {item.TenDocGia} (Phiếu #{item.MaPhieuMuon})";

                    lblDocGiaStatus.Text = $"Trạng thái phiếu: {item.TinhTrang}";
                    lblDocGiaStatus.ForeColor = item.TinhTrang == "Chờ trả" ? Color.Green : Color.Red;

                    LoadLoanDetails(item.MaPhieuMuon);
                }
            }
        }

        private void DgvLoanDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLoanDetails.Rows[e.RowIndex].DataBoundItem != null)
            {
                var item = dgvLoanDetails.Rows[e.RowIndex].DataBoundItem as BookDebtViewModel;
                if (item != null)
                {
                    txtSLTra.Text = "1";
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
                                        .Where(ct => ct.MAPM == maPM && ct.SOLUONG > 0)
                                        .Select(ct => new BookDebtViewModel
                                        {
                                            MaSach = ct.MASACH,
                                            TenSach = ct.SACH.TENSACH,
                                            SoLuongConNo = ct.SOLUONG
                                        })
                                        .ToList();

                    dgvLoanDetails.DataSource = chiTietMuon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết: {ex.Message}");
            }
        }

        private void BtnXacNhanTra_Click(object sender, EventArgs e)
        {
            if (Session.CurrentMaTT <= 0)
            {
                MessageBox.Show("Vui lòng đăng nhập bằng tài khoản Thủ thư để thực hiện chức năng này.",
                                "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentMaPM <= 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvLoanDetails.CurrentRow == null || dgvLoanDetails.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn cuốn sách cần trả trong danh sách chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBook = dgvLoanDetails.CurrentRow.DataBoundItem as BookDebtViewModel;
            if (selectedBook == null) return;

            if (!int.TryParse(txtSLTra.Text.Trim(), out int soLuongTra) || soLuongTra <= 0)
            {
                MessageBox.Show("Số lượng trả phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soLuongTra > selectedBook.SoLuongConNo)
            {
                MessageBox.Show($"Số lượng trả ({soLuongTra}) không được lớn hơn số lượng đang giữ ({selectedBook.SoLuongConNo}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận nhận lại {soLuongTra} cuốn '{selectedBook.TenSach}' cho phiếu #{_currentMaPM}?",
                                "Xác nhận Trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var phieuMuon = db.PHIEUMUONs.Find(_currentMaPM);
                    if (phieuMuon == null) return;

                    // Tính quá hạn dựa trên hạn trả phiếu (giữ nguyên logic cũ)
                    double tienPhat = 0;
                    int soNgayQuaHan = 0;
                    DateTime ngayTraThucTe = DateTime.Now;

                    if (ngayTraThucTe.Date > phieuMuon.HANTRA.Date)
                    {
                        soNgayQuaHan = (ngayTraThucTe.Date - phieuMuon.HANTRA.Date).Days;
                        tienPhat = soNgayQuaHan * 2000;
                    }

                    // Tạo phiếu trả
                    var phieuTra = new PHIEUTRA
                    {
                        MAPM = phieuMuon.MAPM,
                        MATT = Session.CurrentMaTT,
                        NGAYLAPPHIEUTRA = ngayTraThucTe,
                        SONGAYQUAHAN = soNgayQuaHan,
                        TONGTIENPHAT = tienPhat,
                        TRANGTHAIPHAT = tienPhat > 0 ? "Chưa thanh toán" : "Không có"
                    };

                    db.PHIEUTRAs.Add(phieuTra);
                    db.SaveChanges();

                    // Cập nhật chi tiết mượn (giảm số lượng còn nợ)
                    var ctpm = db.CHITIETPHIEUMUONs.FirstOrDefault(x => x.MAPM == _currentMaPM && x.MASACH == selectedBook.MaSach);
                    if (ctpm == null) return;

                    ctpm.SOLUONG -= soLuongTra;

                    // Ghi chi tiết trả
                    var ctpt = new CHITIETPHIEUTRA
                    {
                        MAPT = phieuTra.MAPT,
                        MASACH = selectedBook.MaSach,
                        SOLUONGTRA = soLuongTra,
                        NGAYTRA = ngayTraThucTe
                    };
                    db.CHITIETPHIEUTRAs.Add(ctpt);

                    // Cộng lại tồn kho
                    var sach = db.SACHes.Find(selectedBook.MaSach);
                    if (sach != null)
                    {
                        sach.SOLUONGTON += soLuongTra;
                    }

                    // Nếu tất cả sách trong phiếu đã trả hết thì cập nhật trạng thái phiếu
                    bool conNo = db.CHITIETPHIEUMUONs.Any(x => x.MAPM == _currentMaPM && x.SOLUONG > 0);
                    if (!conNo)
                    {
                        phieuMuon.TRANGTHAI = soNgayQuaHan > 0 ? "Đã trả quá hạn" : "Đã trả";
                    }
                    else
                    {
                        // Trả một phần: đưa phiếu về trạng thái "Đang mượn" để tiếp tục theo dõi
                        phieuMuon.TRANGTHAI = "Đang mượn";
                    }

                    db.SaveChanges();

                    MessageBox.Show("Đã xác nhận trả sách thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllActiveLoans();
                    LoadLoanDetails(_currentMaPM);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show("Lỗi hệ thống: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllActiveLoans();
        }

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
            public int SoLuongConNo { get; set; }
        }
    }
}