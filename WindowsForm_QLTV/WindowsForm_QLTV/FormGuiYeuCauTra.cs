using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using WindowsForm_QLTV;

namespace WindowsForm_QLTV
{
    public partial class FormGuiYeuCauTra : Form
    {
        private readonly int _maSV;

        // Các biến lưu trữ thông tin dòng đang chọn
        private int _selectedMaPM = -1;
        private int _selectedMaSach = -1;
        private string _selectedTenSach = string.Empty;
        private DateTime _hanTraCu = DateTime.MinValue;
        private int _soLanGiaHan = 0;
        private string _trangThaiPhieu = "";

        // Quy định
        private const int MaxGiaHan = 2;

        public FormGuiYeuCauTra(int maSV)
        {
            InitializeComponent();
            _maSV = maSV;

            this.Load += FormGuiYeuCauTra_Load;

            // Đăng ký sự kiện
            dgvActiveLoans.CellClick += DgvActiveLoans_CellClick;
            btnGuiYeuCauTra.Click += BtnGuiYeuCau_Click;
            btnGiaHan.Click += BtnGiaHan_Click;

            SetupDataGridView();
        }

        private void FormGuiYeuCauTra_Load(object sender, EventArgs e)
        {
            if (_maSV <= 0)
            {
                MessageBox.Show("Lỗi: Không xác định được sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            LoadActiveLoans();
        }

        private void SetupDataGridView()
        {
            dgvActiveLoans.AutoGenerateColumns = false;
            dgvActiveLoans.Columns.Clear();

            dgvActiveLoans.Columns.Add(CreateColumn("MaPhieuMuon", "Mã Phiếu", 80));
            dgvActiveLoans.Columns.Add(CreateColumn("TenSach", "Tên Sách", 250));
            dgvActiveLoans.Columns.Add(CreateColumn("SoLuongConNo", "SL Đang Giữ", 100));
            dgvActiveLoans.Columns.Add(CreateColumn("HanTra", "Hạn Trả (Cuốn)", 120));
            dgvActiveLoans.Columns.Add(CreateColumn("SoLanGiaHan", "Lần GH", 80));
            dgvActiveLoans.Columns.Add(CreateColumn("TrangThai", "Trạng Thái Phiếu", 130));

            // Cột ẩn để xử lý
            var colMaSach = CreateColumn("MaSach", "Mã Sách", 0);
            colMaSach.Visible = false;
            dgvActiveLoans.Columns.Add(colMaSach);

            dgvActiveLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActiveLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActiveLoans.MultiSelect = false;
        }

        private DataGridViewTextBoxColumn CreateColumn(string dataName, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataName,
                HeaderText = header,
                Width = width,
                Name = dataName
            };
        }

        private void LoadActiveLoans()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Các trạng thái được phép hiển thị
                    var hienThiStatus = new[] { "Đang mượn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu", "Chờ trả", "Chờ trả quá hạn" };

                    // Join bảng để lấy thông tin chi tiết từng cuốn sách
                    var listBooks = (from ctpm in db.CHITIETPHIEUMUONs
                                     join pm in db.PHIEUMUONs on ctpm.MAPM equals pm.MAPM
                                     join sach in db.SACHes on ctpm.MASACH equals sach.MASACH
                                     where pm.MASV == _maSV && hienThiStatus.Contains(pm.TRANGTHAI)
                                     select new ActiveLoanItem
                                     {
                                         MaPhieuMuon = pm.MAPM,
                                         MaSach = ctpm.MASACH,
                                         TenSach = sach.TENSACH,
                                         SoLuongConNo = ctpm.SOLUONG,

                                         // Ưu tiên lấy hạn trả riêng của cuốn sách (nếu có), nếu không lấy hạn trả phiếu
                                         HanTra = ctpm.HANTRA.HasValue ? ctpm.HANTRA.Value : pm.HANTRA,

                                         // Lấy số lần gia hạn riêng của cuốn sách
                                         SoLanGiaHan = ctpm.SOLANGIAHAN.HasValue ? ctpm.SOLANGIAHAN.Value : 0,

                                         TrangThai = pm.TRANGTHAI
                                     }).ToList();

                    dgvActiveLoans.DataSource = listBooks.OrderBy(x => x.HanTra).ToList();

                    // --- [FIX QUAN TRỌNG] Tự động chọn dòng đầu tiên để tránh lỗi "Chưa chọn sách" ---
                    if (dgvActiveLoans.Rows.Count > 0)
                    {
                        dgvActiveLoans.Rows[0].Selected = true;
                        ProcessSelection(0); // Gọi hàm xử lý chọn ngay lập tức
                    }
                    else
                    {
                        ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi click vào bảng
        private void DgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ProcessSelection(e.RowIndex);
            }
        }

        // Hàm xử lý logic khi một dòng được chọn
        private void ProcessSelection(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvActiveLoans.Rows.Count)
            {
                var item = dgvActiveLoans.Rows[rowIndex].DataBoundItem as ActiveLoanItem;
                if (item != null)
                {
                    _selectedMaPM = item.MaPhieuMuon;
                    _selectedMaSach = item.MaSach;
                    _selectedTenSach = item.TenSach;
                    _hanTraCu = item.HanTra;
                    _soLanGiaHan = item.SoLanGiaHan;
                    _trangThaiPhieu = item.TrangThai;

                    // Hiển thị thông tin
                    lblSelectedBook.Text = $"Đang chọn: {_selectedTenSach} (Phiếu #{_selectedMaPM})";

                    // Cập nhật trạng thái các nút
                    UpdateButtonsState();
                }
            }
        }

        private void ClearSelection()
        {
            _selectedMaPM = -1;
            lblSelectedBook.Text = "Bạn chưa mượn cuốn sách nào.";
            btnGuiYeuCauTra.Enabled = false;
            btnGiaHan.Enabled = false;
        }

        private void UpdateButtonsState()
        {
            // 1. Logic nút Gia hạn (Theo từng cuốn)
            // Điều kiện: Chưa quá số lần, Chưa quá hạn, và Phiếu không ở trạng thái "Chờ trả"
            bool allowGiaHan = (_soLanGiaHan < MaxGiaHan) && (_hanTraCu >= DateTime.Today);

            if (_trangThaiPhieu == "Chờ trả") allowGiaHan = false; // Đang trả thì không gia hạn được

            btnGiaHan.Enabled = allowGiaHan;

            // Đổi text nút để người dùng hiểu tại sao không gia hạn được
            if (_trangThaiPhieu == "Chờ trả") btnGiaHan.Text = "ĐANG CHỜ TRẢ";
            else if (_hanTraCu < DateTime.Today) btnGiaHan.Text = "QUÁ HẠN (Không thể GH)";
            else if (_soLanGiaHan >= MaxGiaHan) btnGiaHan.Text = "HẾT LƯỢT GIA HẠN";
            else btnGiaHan.Text = $"GIA HẠN (Đã GH {_soLanGiaHan}/{MaxGiaHan})";


            // 2. Logic nút Trả sách (Theo phiếu)
            if (_trangThaiPhieu == "Chờ trả")
            {
                btnGuiYeuCauTra.Enabled = false;
                btnGuiYeuCauTra.Text = "ĐÃ GỬI YÊU CẦU";
                btnGuiYeuCauTra.BackColor = Color.Gray;
            }
            else
            {
                btnGuiYeuCauTra.Enabled = true;
                btnGuiYeuCauTra.Text = "GỬI YÊU CẦU TRẢ";
                btnGuiYeuCauTra.BackColor = Color.FromArgb(230, 126, 34); // Màu cam
            }
        }

        // =============================================================
        // CHỨC NĂNG 1: GỬI YÊU CẦU TRẢ (Cập nhật trạng thái PHIẾU)
        // =============================================================
        private void BtnGuiYeuCau_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (_selectedMaPM == -1)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu đã là Chờ trả hoặc Chờ trả quá hạn thì không làm gì thêm
            if (_trangThaiPhieu.Contains("Chờ trả")) return;

            // 2. Kiểm tra xem có phải sách lỗi (Quá hạn/Thiếu) không
            bool isOverdue = _trangThaiPhieu.Contains("Quá hạn") || _trangThaiPhieu.Contains("Thiếu");
            string msg;

            if (isOverdue)
            {
                msg = $"Phiếu mượn #{_selectedMaPM} đang ở trạng thái '{_trangThaiPhieu}'.\n\n" +
                      "Bạn có muốn gửi yêu cầu trả sách không?\n" +
                      "LƯU Ý: Trạng thái sẽ chuyển thành 'Chờ trả quá hạn' để thủ thư kiểm tra và tính phạt.";
            }
            else
            {
                msg = $"Bạn muốn gửi yêu cầu trả sách cho phiếu mượn #{_selectedMaPM}?\n" +
                      "Trạng thái sẽ được chuyển thành 'Chờ trả'.";
            }

            // 3. Thực hiện xử lý
            if (MessageBox.Show(msg, "Xác nhận gửi yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        var phieuMuon = db.PHIEUMUONs.Find(_selectedMaPM);
                        if (phieuMuon != null)
                        {
                            // CASE A: Nếu đang mượn bình thường -> Đổi thành "Chờ trả"
                            if (phieuMuon.TRANGTHAI == "Đang mượn")
                            {
                                phieuMuon.TRANGTHAI = "Chờ trả";
                                db.SaveChanges();
                                MessageBox.Show("Gửi yêu cầu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            // CASE B: Nếu đang Quá hạn -> Đổi thành "Chờ trả quá hạn"
                            else if (isOverdue)
                            {
                                // [QUAN TRỌNG]: Phải chạy SQL Bước 1 thì dòng này mới không lỗi
                                phieuMuon.TRANGTHAI = "Chờ trả quá hạn";
                                db.SaveChanges();

                                MessageBox.Show("Hệ thống đã ghi nhận yêu cầu trả sách QUÁ HẠN.\n" +
                                                "Trạng thái đã chuyển sang 'Chờ trả quá hạn'.\n\n" +
                                                "👉 Vui lòng mang sách đến quầy thủ thư để đóng phạt và hoàn tất.",
                                                "Đã gửi yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            // Tải lại danh sách để cập nhật giao diện
                            LoadActiveLoans();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xử lý: " + ex.Message + "\n(Hãy đảm bảo bạn đã cập nhật ràng buộc CHECK trong SQL)", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =============================================================
        // CHỨC NĂNG 2: GIA HẠN (Cập nhật bảng CHI TIẾT - Từng cuốn)
        // =============================================================
        private void BtnGiaHan_Click(object sender, EventArgs e)
        {
            if (_selectedMaSach == -1) return;

            if (MessageBox.Show($"Xác nhận gia hạn cuốn '{_selectedTenSach}' thêm 7 ngày?", "Gia hạn sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Model1())
                    {
                        // Tìm đúng cuốn sách trong phiếu mượn (Khóa chính phức hợp: MAPM + MASACH)
                        var ctpm = db.CHITIETPHIEUMUONs
                                     .FirstOrDefault(ct => ct.MAPM == _selectedMaPM && ct.MASACH == _selectedMaSach);

                        if (ctpm != null)
                        {
                            // Logic gia hạn riêng cho cuốn sách này
                            DateTime currentDeadline = ctpm.HANTRA.HasValue ? ctpm.HANTRA.Value : DateTime.Today;

                            ctpm.HANTRA = currentDeadline.AddDays(7); // Cộng thêm 7 ngày
                            ctpm.SOLANGIAHAN = (ctpm.SOLANGIAHAN ?? 0) + 1;

                            db.SaveChanges();

                            MessageBox.Show($"Gia hạn thành công! Hạn trả mới: {ctpm.HANTRA.Value:dd/MM/yyyy}", "Thành công");
                            LoadActiveLoans(); // Tải lại để cập nhật ngày trên bảng
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin chi tiết mượn.", "Lỗi");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi gia hạn: " + ex.Message);
                }
            }
        }

        // ViewModel hiển thị lên Grid
        public class ActiveLoanItem
        {
            public int MaPhieuMuon { get; set; }
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuongConNo { get; set; }
            public DateTime HanTra { get; set; }
            public int SoLanGiaHan { get; set; }
            public string TrangThai { get; set; }
        }
    }
}