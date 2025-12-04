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
                    var activeStatuses = new[] { "Đang mượn", "Chờ trả", "Quá hạn", "Thiếu", "Quá hạn và Thiếu" };

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
            // 1. Kiểm tra đã chọn phiếu chưa
            if (dgvActiveLoans.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = dgvActiveLoans.CurrentRow.DataBoundItem as LoanSummaryViewModel;
            if (selectedItem == null) return;

            string trangThaiHienTai = selectedItem.TinhTrang;

            // 2. CHẶN: Nếu độc giả chưa gửi yêu cầu (Trạng thái vẫn là "Đang mượn")
            if (trangThaiHienTai.Equals("Đang mượn", StringComparison.OrdinalIgnoreCase) ||
                trangThaiHienTai.Equals("Quá hạn", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Độc giả CHƯA gửi yêu cầu trả sách cho phiếu này.\n\n" +
                                "Vui lòng yêu cầu độc giả vào phần 'Lịch sử Mượn/Trả' và bấm nút 'Gửi yêu cầu trả' trước.",
                                "Chưa có yêu cầu từ Độc giả", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 3. CHẶN: Nếu đã trả rồi (phòng trường hợp lag mạng)
            if (trangThaiHienTai.Equals("Đã trả", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Phiếu này đã hoàn tất trả sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. XỬ LÝ TRẢ: Chỉ thực hiện khi trạng thái là "Chờ trả"
            if (MessageBox.Show($"Xác nhận nhận lại sách và hoàn tất phiếu mượn #{selectedItem.MaPhieuMuon}?\nThao tác này sẽ cập nhật kho sách.",
                                "Xác nhận Trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var phieuMuon = db.PHIEUMUONs.Find(selectedItem.MaPhieuMuon);
                        if (phieuMuon != null)
                        {
                            // A. Cập nhật trạng thái Phiếu sang "Đã trả"
                            // Khi đã là "Đã trả", độc giả sẽ không thể gửi yêu cầu nữa (đã chặn bên logic Độc giả)
                            phieuMuon.TRANGTHAI = "Đã trả";

                            // B. Cộng số lượng tồn kho cho TẤT CẢ sách trong phiếu
                            var listChiTiet = db.CHITIETPHIEUMUONs.Where(ct => ct.MAPM == selectedItem.MaPhieuMuon).ToList();

                            foreach (var ct in listChiTiet)
                            {
                                var sach = db.SACHes.Find(ct.MASACH);
                                if (sach != null)
                                {
                                    sach.SOLUONGTON += ct.SOLUONG; // Trả sách về kho
                                }
                            }

                            db.SaveChanges();

                            MessageBox.Show("Đã xác nhận trả sách thành công! Kho sách đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tải lại dữ liệu để cập nhật giao diện
                            LoadAllActiveLoans();
                            dgvLoanDetails.DataSource = null;
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống khi trả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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