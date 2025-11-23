using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class FormGuiYeuCauTra : Form
    {
        private readonly int _maSV;
        private int _selectedMaPM = -1;
        private int _selectedMaSach = -1;
        private int _soLuongConNo = 0;
        private int _soLanGiaHan = 0;
        private DateTime _hanTraCu = DateTime.MinValue;
        private string _selectedTenSach = string.Empty; // <-- Biến này đã được khai báo ở đây
        private const int MaxGiaHan = 2;

        public FormGuiYeuCauTra(int maSV)
        {
            InitializeComponent();
            _maSV = maSV;
            this.Load += FormGuiYeuCauTra_Load;

            // Gán sự kiện
            dgvActiveLoans.CellClick += DgvActiveLoans_CellClick;
            btnGuiYeuCauTra.Click += BtnGuiYeuCau_Click;
            btnGiaHan.Click += BtnGiaHan_Click;

            SetupDataGridView();
        }

        private void FormGuiYeuCauTra_Load(object sender, EventArgs e)
        {
            LoadActiveLoans();
        }

        private void SetupDataGridView()
        {
            dgvActiveLoans.AutoGenerateColumns = false;
            dgvActiveLoans.Columns.Clear();
            dgvActiveLoans.Columns.Add(CreateTextColumn("MaPhieuMuon", "Mã PM", 60));
            dgvActiveLoans.Columns.Add(CreateTextColumn("TenSach", "Tên Sách", 200));
            dgvActiveLoans.Columns.Add(CreateTextColumn("SoLuongConNo", "SL Cần Trả", 80));
            dgvActiveLoans.Columns.Add(CreateTextColumn("HanTra", "Hạn Trả (CT)", 100));
            dgvActiveLoans.Columns.Add(CreateTextColumn("SoLanGiaHan", "Lần GH", 60));
            dgvActiveLoans.Columns.Add(CreateTextColumn("TrangThai", "Trạng Thái PM", 100));

            // Cột MaSach cần thiết cho logic, nhưng có thể ẩn
            dgvActiveLoans.Columns.Add(CreateTextColumn("MaSach", "Mã Sách", 60));
            dgvActiveLoans.Columns["MaSach"].Visible = false;

            dgvActiveLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = name,
                Width = width,
                MinimumWidth = width
            };
        }

        private void LoadActiveLoans()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Truy vấn tất cả sách đã mượn (ctpm) của sinh viên này
                    var activeLoanItems = (from ctpm in db.CHITIETPHIEUMUONs
                                           join pm in db.PHIEUMUONs on ctpm.MAPM equals pm.MAPM
                                           join sach in db.SACHes on ctpm.MASACH equals sach.MASACH
                                           where pm.MASV == _maSV && (pm.TRANGTHAI == "Đang mượn" || pm.TRANGTHAI == "Quá hạn" || pm.TRANGTHAI == "Thiếu" || pm.TRANGTHAI == "Quá hạn và Thiếu")
                                           select new
                                           {
                                               MaPM = ctpm.MAPM,
                                               MaSach = ctpm.MASACH,
                                               SoLuongMuonBanDau = ctpm.SOLUONG,
                                               TenSach = sach.TENSACH,
                                               HanTraCT = ctpm.HANTRA,
                                               SoLanGiaHan = ctpm.SOLANGIAHAN,
                                               TrangThaiPM = pm.TRANGTHAI,
                                           })
                                       .ToList();

                    // Tính toán số lượng còn nợ sau khi đã trả trước đó
                    var resultList = new List<ActiveLoanItem>();

                    foreach (var item in activeLoanItems)
                    {
                        // Tính tổng số lượng đã trả trước đó cho cuốn sách này
                        int soLuongDaTra = db.CHITIETPHIEUTRAs
                            .Where(ctpt => ctpt.MASACH == item.MaSach)
                            .Join(db.PHIEUTRAs, ctpt => ctpt.MAPT, pt => pt.MAPT, (ctpt, pt) => new { ctpt, pt })
                            .Where(j => j.pt.MAPM == item.MaPM)
                            .Sum(j => j.ctpt.SOLUONGTRA.HasValue ? j.ctpt.SOLUONGTRA.Value : 0);

                        int conNo = item.SoLuongMuonBanDau - soLuongDaTra;

                        if (conNo > 0)
                        {
                            resultList.Add(new ActiveLoanItem
                            {
                                MaPhieuMuon = item.MaPM,
                                MaSach = item.MaSach,
                                TenSach = item.TenSach, // <-- Đảm bảo TenSach được gán tại đây
                                SoLuongConNo = conNo,
                                HanTra = item.HanTraCT.HasValue ? item.HanTraCT.Value : item.HanTraCT.GetValueOrDefault(),
                                SoLanGiaHan = item.SoLanGiaHan.GetValueOrDefault(),
                                TrangThai = item.TrangThaiPM
                            });
                        }
                    }

                    dgvActiveLoans.DataSource = resultList.OrderBy(i => i.HanTra).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách đang mượn: " + ex.Message, "Lỗi Database");
            }
        }

        private void DgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvActiveLoans.Rows[e.RowIndex];

                // Lấy thông tin cần thiết từ DataBoundItem
                ActiveLoanItem selectedItem = row.DataBoundItem as ActiveLoanItem;

                if (selectedItem != null)
                {
                    _selectedMaPM = selectedItem.MaPhieuMuon;
                    _selectedMaSach = selectedItem.MaSach;
                    _soLuongConNo = selectedItem.SoLuongConNo;
                    _soLanGiaHan = selectedItem.SoLanGiaHan;
                    _hanTraCu = selectedItem.HanTra;
                    _selectedTenSach = selectedItem.TenSach; // <-- Dòng này đã đúng

                    lblSelectedBook.Text = $"Sách đã chọn: {_selectedTenSach} (PM #{_selectedMaPM}, còn nợ: {_soLuongConNo} cuốn)";
                    numQuantity.Maximum = _soLuongConNo;
                    numQuantity.Value = 1;

                    // Cập nhật trạng thái nút Gia hạn
                    btnGiaHan.Enabled = _soLanGiaHan < MaxGiaHan && _hanTraCu >= DateTime.Today;
                    btnGiaHan.Text = _soLanGiaHan < MaxGiaHan
                        ? $"GIA HẠN (Đã GH {_soLanGiaHan}/{MaxGiaHan} lần)"
                        : "HẾT LƯỢT GIA HẠN";
                }
            }
        }

        private void BtnGiaHan_Click(object sender, EventArgs e)
        {
            if (_selectedMaSach == -1 || _soLuongConNo == 0)
            {
                MessageBox.Show("Vui lòng chọn sách đang mượn để gia hạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_soLanGiaHan >= MaxGiaHan)
            {
                MessageBox.Show("Sách này đã hết lượt gia hạn tối đa (2 lần).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_hanTraCu < DateTime.Today)
            {
                MessageBox.Show("Không thể gia hạn sách đã quá hạn. Vui lòng mang sách đến quầy Thủ Thư.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    // Lấy Chi Tiết Phiếu Mượn (CTPM) để cập nhật
                    CHITIETPHIEUMUON ctpm = db.CHITIETPHIEUMUONs
                        .FirstOrDefault(ct => ct.MAPM == _selectedMaPM && ct.MASACH == _selectedMaSach);

                    if (ctpm == null)
                    {
                        MessageBox.Show("Không tìm thấy chi tiết phiếu mượn.", "Lỗi");
                        return;
                    }

                    // Cập nhật
                    DateTime hanTraMoi = ctpm.HANTRA.GetValueOrDefault(ctpm.PHIEUMUON.HANTRA).AddDays(14);
                    ctpm.HANTRA = hanTraMoi;
                    ctpm.SOLANGIAHAN = ctpm.SOLANGIAHAN.GetValueOrDefault(0) + 1;

                    db.Entry(ctpm).State = EntityState.Modified;
                    db.SaveChanges();

                    MessageBox.Show($"Đã gia hạn thành công cuốn '{_selectedTenSach}'. Hạn trả mới: {hanTraMoi.ToShortDateString()}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadActiveLoans(); // Tải lại danh sách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gia hạn sách: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (_selectedMaSach == -1)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để gửi yêu cầu trả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongTra = (int)numQuantity.Value;

            // Gửi yêu cầu trả sách là một thao tác thông báo cho Thủ Thư 
            MessageBox.Show($"Yêu cầu trả {_selectedTenSach} (SL: {soLuongTra}) trong Phiếu #{_selectedMaPM} đã được ghi nhận. Vui lòng mang sách đến quầy Thủ Thư để hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ViewModels (Đã đảm bảo có TenSach)
        public class ActiveLoanItem
        {
            public int MaPhieuMuon { get; set; }
            public int MaSach { get; set; }
            public string TenSach { get; set; } // <-- Đã khai báo
            public int SoLuongConNo { get; set; }
            public DateTime HanTra { get; set; }
            public int SoLanGiaHan { get; set; }
            public string TrangThai { get; set; }
        }
    }
}