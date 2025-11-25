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
        private string _selectedTenSach = string.Empty;
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
            if (_maSV <= 0)
            {
                MessageBox.Show("Lỗi hệ thống: Mã Sinh Viên không hợp lệ (MaSV = 0). Vui lòng đăng nhập lại.", "Lỗi Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
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

            var colMaSach = CreateTextColumn("MaSach", "Mã Sách", 60);
            colMaSach.Visible = false;
            dgvActiveLoans.Columns.Add(colMaSach);

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
                    var trangThaiHopLe = new[] { "Đang mượn", "Quá hạn", "Thiếu", "Quá hạn và Thiếu" };

                    var rawLoans = (from ctpm in db.CHITIETPHIEUMUONs
                                    join pm in db.PHIEUMUONs on ctpm.MAPM equals pm.MAPM
                                    join sach in db.SACHes on ctpm.MASACH equals sach.MASACH
                                    where pm.MASV == _maSV && trangThaiHopLe.Contains(pm.TRANGTHAI)
                                    select new
                                    {
                                        MaPM = ctpm.MAPM,
                                        MaSach = ctpm.MASACH,
                                        SoLuongMuon = ctpm.SOLUONG,
                                        TenSach = sach.TENSACH,
                                        HanTra = ctpm.HANTRA,
                                        SoLanGiaHan = ctpm.SOLANGIAHAN,
                                        TrangThai = pm.TRANGTHAI
                                    }).ToList();

                    if (rawLoans.Count == 0)
                    {
                        dgvActiveLoans.DataSource = null;
                        return;
                    }

                    var listMaPM = rawLoans.Select(x => x.MaPM).Distinct().ToList();

                    var rawReturns = (from ctpt in db.CHITIETPHIEUTRAs
                                      join pt in db.PHIEUTRAs on ctpt.MAPT equals pt.MAPT
                                      where listMaPM.Contains(pt.MAPM)
                                      select new
                                      {
                                          MaPM = pt.MAPM,
                                          MaSach = ctpt.MASACH,
                                          SoLuongTra = ctpt.SOLUONGTRA
                                      }).ToList();

                    var resultList = new List<ActiveLoanItem>();

                    foreach (var item in rawLoans)
                    {
                        int daTra = rawReturns
                                    .Where(r => r.MaPM == item.MaPM && r.MaSach == item.MaSach)
                                    .Sum(r => r.SoLuongTra.GetValueOrDefault(0));

                        int conNo = item.SoLuongMuon - daTra;

                        if (conNo > 0)
                        {
                            resultList.Add(new ActiveLoanItem
                            {
                                MaPhieuMuon = item.MaPM,
                                MaSach = item.MaSach,
                                TenSach = item.TenSach,
                                SoLuongConNo = conNo,
                                HanTra = item.HanTra.GetValueOrDefault(DateTime.MaxValue),
                                SoLanGiaHan = item.SoLanGiaHan.GetValueOrDefault(0),
                                TrangThai = item.TrangThai
                            });
                        }
                    }

                    dgvActiveLoans.DataSource = resultList.OrderBy(i => i.HanTra).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvActiveLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvActiveLoans.Rows.Count)
            {
                var row = dgvActiveLoans.Rows[e.RowIndex];
                var selectedItem = row.DataBoundItem as ActiveLoanItem;

                if (selectedItem != null)
                {
                    _selectedMaPM = selectedItem.MaPhieuMuon;
                    _selectedMaSach = selectedItem.MaSach;
                    _soLuongConNo = selectedItem.SoLuongConNo;
                    _soLanGiaHan = selectedItem.SoLanGiaHan;
                    _hanTraCu = selectedItem.HanTra;
                    _selectedTenSach = selectedItem.TenSach;

                    lblSelectedBook.Text = $"Sách chọn: {_selectedTenSach} (PM #{_selectedMaPM}, Nợ: {_soLuongConNo})";
                    numQuantity.Maximum = _soLuongConNo;
                    numQuantity.Value = 1;

                    bool conLuot = _soLanGiaHan < MaxGiaHan;
                    bool chuaQuaHan = _hanTraCu >= DateTime.Today;

                    btnGiaHan.Enabled = conLuot && chuaQuaHan;
                    if (!conLuot) btnGiaHan.Text = "HẾT LƯỢT GIA HẠN";
                    else if (!chuaQuaHan) btnGiaHan.Text = "QUÁ HẠN (Không thể gia hạn)";
                    else btnGiaHan.Text = $"GIA HẠN (Đã GH {_soLanGiaHan}/{MaxGiaHan})";
                }
            }
        }

        private void BtnGiaHan_Click(object sender, EventArgs e)
        {
            if (_selectedMaSach == -1)
            {
                MessageBox.Show("Vui lòng chọn sách cần gia hạn.", "Thông báo");
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var ctpm = db.CHITIETPHIEUMUONs
                        .FirstOrDefault(ct => ct.MAPM == _selectedMaPM && ct.MASACH == _selectedMaSach);

                    if (ctpm != null)
                    {
                        DateTime newDeadline = ctpm.HANTRA.GetValueOrDefault(DateTime.Today).AddDays(14);
                        ctpm.HANTRA = newDeadline;
                        ctpm.SOLANGIAHAN = ctpm.SOLANGIAHAN.GetValueOrDefault(0) + 1;

                        db.Entry(ctpm).State = EntityState.Modified;
                        db.SaveChanges();

                        MessageBox.Show($"Gia hạn thành công! Hạn trả mới: {newDeadline:dd/MM/yyyy}", "Thành công");
                        LoadActiveLoans();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi gia hạn: " + ex.Message); }
        }

        // --- SỬA ĐỔI CHÍNH Ở ĐÂY: THỰC HIỆN TRẢ SÁCH NGAY LẬP TỨC ---
        private void BtnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (_selectedMaSach == -1)
            {
                MessageBox.Show("Vui lòng chọn sách cần trả.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongTra = (int)numQuantity.Value;

            if (MessageBox.Show($"Xác nhận trả {soLuongTra} cuốn '{_selectedTenSach}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (var db = new Model1())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // --- BƯỚC 1: TẠO PHIẾU TRẢ ---
                        PHIEUTRA pt = new PHIEUTRA
                        {
                            MAPM = _selectedMaPM,
                            MATT = 1,
                            NGAYLAPPHIEUTRA = DateTime.Now,
                            TONGTIENPHAT = 0
                        };
                        db.PHIEUTRAs.Add(pt);
                        db.SaveChanges();

                        // --- BƯỚC 2: CHI TIẾT TRẢ ---
                        CHITIETPHIEUTRA ctpt = new CHITIETPHIEUTRA
                        {
                            MAPT = pt.MAPT,
                            MASACH = _selectedMaSach,
                            SOLUONGTRA = soLuongTra,
                            NGAYTRA = DateTime.Now
                        };
                        db.CHITIETPHIEUTRAs.Add(ctpt);

                        // --- BƯỚC 3: (ĐÃ XÓA) KHÔNG CẬP NHẬT KHO BẰNG CODE NỮA ---
                        // Lý do: Trigger TG_CAPNHATSLTONCUASACH_CTPT trong SQL Server sẽ tự động làm việc này
                        // khi lệnh db.SaveChanges() ở dưới được thực thi.

                        // --- BƯỚC 4: CẬP NHẬT TRẠNG THÁI PHIẾU MƯỢN ---
                        var phieuMuon = db.PHIEUMUONs.Find(_selectedMaPM);

                        // Tính toán số liệu để xem đã trả hết chưa
                        int tongMuon = db.CHITIETPHIEUMUONs
                                         .Where(ct => ct.MAPM == _selectedMaPM)
                                         .Sum(ct => ct.SOLUONG);

                        // Lấy tổng trả cũ trong DB
                        int tongDaTraCu = db.CHITIETPHIEUTRAs
                                            .Where(ct => ct.PHIEUTRA.MAPM == _selectedMaPM)
                                            .Sum(ct => (int?)ct.SOLUONGTRA) ?? 0;

                        // Tổng thực tế = Cũ + Mới đang trả
                        int tongTraTotal = tongDaTraCu + soLuongTra;

                        if (phieuMuon != null)
                        {
                            if (tongTraTotal >= tongMuon)
                            {
                                phieuMuon.TRANGTHAI = "Đã trả";
                            }
                            else
                            {
                                phieuMuon.TRANGTHAI = "Đang mượn";
                            }
                            db.Entry(phieuMuon).State = EntityState.Modified;
                        }

                        // --- BƯỚC 5: LƯU VÀ KÍCH HOẠT TRIGGER ---
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show($"Trả sách thành công!\n(Số lượng kho sẽ được Trigger tự động cập nhật).", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

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