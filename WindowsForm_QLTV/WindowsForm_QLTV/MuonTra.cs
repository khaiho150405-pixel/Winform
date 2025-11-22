using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace WindowsForm_QLTV
{
    public partial class MuonTra : Form
    {
        // Constructor và Event Handlers
        public MuonTra()
        {
            InitializeComponent();
            this.Load += FormTraSachCoNut_Load;

            // Gán lại sự kiện
            btnTimKiem.Click += BtnTimKiem_Click;
            dgvSachDangMuon.CellContentClick += DgvSachDangMuon_CellContentClick;

            // Cải tiến UI: Thêm sự kiện Enter/Leave cho TextBox (Placeholder)
            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;

            SetupDataGridView();
        }

        private void FormTraSachCoNut_Load(object sender, EventArgs e)
        {
            // Thiết lập Placeholder mặc định khi Load
            txtTimKiem.Text = "Nhập tên sách cần tìm...";
            txtTimKiem.ForeColor = Color.Gray;

            LoadDataSachDangMuon();
        }

        // Cải tiến UI/UX: Placeholder cho TextBox
        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên sách cần tìm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên sách cần tìm...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void SetupDataGridView()
        {
            dgvSachDangMuon.AutoGenerateColumns = false;
            dgvSachDangMuon.Columns.Clear();

            // 1. Cột dữ liệu
            dgvSachDangMuon.Columns.Add(CreateTextColumn("MaPhieuMuon", "Mã PM", 80));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("TenDocGia", "Độc Giả", 150));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("TenSach", "Tên Sách", 250));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("SoLuong", "SL", 50));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("NgayMuon", "Ngày Mượn", 100));
            dgvSachDangMuon.Columns.Add(CreateTextColumn("HenTra", "Hẹn Trả", 100));

            // 2. Cột Nút "Trả Sách"
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "Thao tác";
            btnCol.Text = "Trả Sách";
            btnCol.Name = "btnTraSach";
            btnCol.UseColumnTextForButtonValue = true;
            btnCol.Width = 100;
            dgvSachDangMuon.Columns.Add(btnCol);

            // Cải tiến UI: Styling cho DataGridView
            dgvSachDangMuon.AllowUserToAddRows = false;
            dgvSachDangMuon.ReadOnly = true;
            dgvSachDangMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSachDangMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSachDangMuon.AllowUserToResizeRows = false;
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

        // ******************************************************
        // LOGIC TẢI DỮ LIỆU SỬ DỤNG ENTITY FRAMEWORK
        // ******************************************************
        private void LoadDataSachDangMuon(string searchKeyword = null)
        {
            try
            {
                using (var db = new Model1()) // SỬ DỤNG ENTITY FRAMEWORK
                {
                    // Truy vấn phức hợp:
                    // 1. Lấy Chi tiết Phiếu Mượn đang ở trạng thái 'Đang mượn'
                    var query = db.CHITIETPHIEUMUONs
                                  .AsNoTracking()
                                  .Where(ctpm => ctpm.PHIEUMUON.TRANGTHAI == "Đang mượn")
                                  // Map vào ViewModel
                                  .Select(ctpm => new MuonTraItem
                                  {
                                      MaPhieuMuon = ctpm.MAPM,
                                      MaSach = ctpm.MASACH,
                                      TenDocGia = ctpm.PHIEUMUON.SINHVIEN.HOVATEN,
                                      TenSach = ctpm.SACH.TENSACH,
                                      NgayMuon = ctpm.PHIEUMUON.NGAYLAPPHIEUMUON,
                                      HenTra = ctpm.PHIEUMUON.HANTRA,
                                      SoLuong = (int)ctpm.SOLUONG
                                  });

                    // 2. Áp dụng bộ lọc Tên Sách
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        query = query.Where(item => item.TenSach.Contains(searchKeyword));
                    }

                    var resultList = query.ToList();

                    dgvSachDangMuon.DataSource = resultList;

                    // Cải tiến UI: Đánh dấu các sách quá hạn
                    HighlightOverdueBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI TẢI DỮ LIỆU: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvSachDangMuon.DataSource = null;
            }
        }

        // Cải tiến UI: Đánh dấu dòng quá hạn
        private void HighlightOverdueBooks()
        {
            foreach (DataGridViewRow row in dgvSachDangMuon.Rows)
            {
                // Lấy giá trị cột Hẹn Trả (HenTra)
                if (row.Cells["HenTra"].Value != null && DateTime.TryParse(row.Cells["HenTra"].Value.ToString(), out DateTime henTra))
                {
                    if (henTra < DateTime.Today)
                    {
                        // Tô màu cảnh báo (Đỏ nhạt)
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        row.Cells["HenTra"].ToolTipText = "Đã quá hạn trả!";
                    }
                }
            }
        }

        // --- Event Handlers ---

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            // Xử lý placeholder
            if (keyword == "Nhập tên sách cần tìm...")
            {
                keyword = null;
            }

            LoadDataSachDangMuon(keyword);
        }

        private void DgvSachDangMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra có phải là cột nút "Trả Sách" được click không
            if (dgvSachDangMuon.Columns[e.ColumnIndex].Name == "btnTraSach" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSachDangMuon.Rows[e.RowIndex];

                // Lấy MaPhieuMuon và MaSach
                int maPhieuMuon = (int)row.Cells["MaPhieuMuon"].Value;
                int maSach = (int)row.Cells["MaSach"].Value;
                string tenSach = row.Cells["TenSach"].Value.ToString();

                int maThuThu = 1; // GIẢ ĐỊNH MA THỦ THƯ ĐANG ĐĂNG NHẬP LÀ 1

                if (MessageBox.Show($"Xác nhận TRẢ SÁCH '{tenSach}' (Mã PM: {maPhieuMuon})?", "Xác Nhận Trả", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ProcessBookReturn(maPhieuMuon, maSach, maThuThu))
                    {
                        MessageBox.Show($"Đã xử lý yêu cầu trả sách cho PM: {maPhieuMuon}. Vui lòng kiểm tra lại.", "Hoàn thành");
                        LoadDataSachDangMuon(); // Tải lại dữ liệu sau khi xử lý
                    }
                }
            }
        }

        /// <summary>
        /// Logic xử lý ghi nhận trả sách và cập nhật trạng thái phiếu mượn/sách.
        /// </summary>
        private bool ProcessBookReturn(int maPhieuMuon, int maSach, int maThuThu)
        {
            try
            {
                using (var db = new Model1())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        // 1. Cập nhật PHIEUMUON (Đánh dấu phiếu là 'Đã trả')
                        var phieuMuon = db.PHIEUMUONs.Find(maPhieuMuon);
                        if (phieuMuon == null) return false;

                        phieuMuon.TRANGTHAI = "Đã trả"; // Đánh dấu phiếu mượn đã hoàn thành
                        db.Entry(phieuMuon).State = EntityState.Modified;

                        // 2. Tạo PHIEUTRA
                        var phieuTra = db.PHIEUTRAs.FirstOrDefault(pt => pt.MAPM == maPhieuMuon);
                        if (phieuTra == null)
                        {
                            phieuTra = new PHIEUTRA
                            {
                                MAPM = maPhieuMuon,
                                MATT = maThuThu,
                                NGAYLAPPHIEUTRA = DateTime.Today,
                                SONGAYQUAHAN = (phieuMuon.HANTRA < DateTime.Today) ? (DateTime.Today - phieuMuon.HANTRA).Days : 0,
                                TONGTIENPHAT = 0 // Giữ 0 để tính toán sau (nếu cần)
                            };
                            db.PHIEUTRAs.Add(phieuTra);
                            db.SaveChanges(); // Lưu để lấy MAPT
                        }

                        // 3. Tạo CHITIETPHIEUTRA (Giả định trả đủ 1 cuốn sách)
                        var chiTietTra = new CHITIETPHIEUTRA
                        {
                            MAPT = phieuTra.MAPT,
                            MASACH = maSach,
                            SOLUONGTRA = 1,
                            NGAYTRA = DateTime.Today
                        };
                        db.CHITIETPHIEUTRAs.Add(chiTietTra);

                        // 4. Cập nhật Số lượng tồn của SÁCH
                        var sach = db.SACHes.Find(maSach);
                        if (sach != null)
                        {
                            sach.SOLUONGTON += 1;
                            sach.TRANGTHAI = "Có sẵn";
                            db.Entry(sach).State = EntityState.Modified;
                        }

                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI XỬ LÝ TRẢ SÁCH: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public class MuonTraItem
        {
            // Các trường DataPropertyName trong SetupDataGridView phải khớp với các tên này
            public int MaPhieuMuon { get; set; }
            public int MaSach { get; set; }
            public string TenDocGia { get; set; }
            public string TenSach { get; set; }
            public DateTime NgayMuon { get; set; }
            public DateTime HenTra { get; set; }
            public int SoLuong { get; set; }
        }
    }
}