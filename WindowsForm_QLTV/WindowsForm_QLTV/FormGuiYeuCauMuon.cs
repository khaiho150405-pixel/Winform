using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using WindowsForm_QLTV; 

namespace WindowsForm_QLTV
{
    public partial class FormGuiYeuCauMuon : Form
    {
        private readonly int _maSV;
        private BindingList<CartItem> _cartList = new BindingList<CartItem>(); // Danh sách giỏ hàng
        private int _currentMaPM = -1; // Mã Phiếu Mượn "Chờ duyệt" hiện tại

        public FormGuiYeuCauMuon(int maSV)
        {
            InitializeComponent();
            _maSV = maSV;
            this.Load += FormGuiYeuCauMuon_Load;

            // Gán sự kiện
            btnSearchBook.Click += BtnSearchBook_Click;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
            btnGuiYeuCau.Click += BtnGuiYeuCau_Click;

            // UI
            SetupPlaceholder();
            SetupDataGridView();
        }

        private void FormGuiYeuCauMuon_Load(object sender, EventArgs e)
        {
            dgvCart.DataSource = _cartList;
            LoadBookCatalog();
            UpdateCartDisplay();

            // --- CẬP NHẬT MỚI: Thiết lập ngày hẹn trả mặc định ---
            dtpHanTra.MinDate = DateTime.Today;       // Không cho chọn ngày quá khứ
            dtpHanTra.Value = DateTime.Today.AddDays(7); // Mặc định hẹn trả sau 1 tuần
        }

        private void SetupPlaceholder()
        {
            txtSearchBook.Enter += (s, e) => { if (txtSearchBook.Text == "Nhập tên sách, tác giả...") { txtSearchBook.Text = ""; txtSearchBook.ForeColor = Color.Black; } };
            txtSearchBook.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearchBook.Text)) { txtSearchBook.Text = "Nhập tên sách, tác giả..."; txtSearchBook.ForeColor = Color.Gray; } };
        }

        private void SetupDataGridView()
        {
            // Cấu hình Danh mục Sách
            dgvBookCatalog.AutoGenerateColumns = false;
            dgvBookCatalog.Columns.Clear();
            dgvBookCatalog.Columns.Add(CreateTextColumn("MaSach", "Mã Sách", 80));
            dgvBookCatalog.Columns.Add(CreateTextColumn("TenSach", "Tên Sách", 200));
            dgvBookCatalog.Columns.Add(CreateTextColumn("TacGia", "Tác Giả", 150));
            dgvBookCatalog.Columns.Add(CreateTextColumn("SoLuongTon", "SL Tồn", 80));
            dgvBookCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookCatalog.Columns["MaSach"].Visible = false;

            // Cấu hình Giỏ hàng
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add(CreateTextColumnCart("MaSach", "Mã Sách", 80));
            dgvCart.Columns.Add(CreateTextColumnCart("TenSach", "Tên Sách", 250));
            dgvCart.Columns.Add(CreateTextColumnCart("SoLuong", "SL Mượn", 80));
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            { Name = name, HeaderText = header, DataPropertyName = name, Width = width, MinimumWidth = width };
        }

        private DataGridViewTextBoxColumn CreateTextColumnCart(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            { Name = name, HeaderText = header, DataPropertyName = name, Width = width, MinimumWidth = width };
        }

        private void LoadBookCatalog(string keyword = null)
        {
            try
            {
                using (var db = new Model1())
                {
                    var query = db.SACHes
                        .Include(s => s.TACGIA)
                        .Where(s => s.SOLUONGTON > 0);

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        string lowerKeyword = keyword.ToLower();
                        query = query.Where(s => s.TENSACH.ToLower().Contains(lowerKeyword) ||
                                                 s.TACGIA.TENTG.ToLower().Contains(lowerKeyword));
                    }

                    var bookList = query.Select(s => new BookCatalogItem
                    {
                        MaSach = s.MASACH,
                        TenSach = s.TENSACH,
                        TacGia = s.TACGIA.TENTG,
                        SoLuongTon = s.SOLUONGTON
                    }).ToList();

                    dgvBookCatalog.DataSource = bookList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục sách: " + ex.Message, "Lỗi Database");
            }
        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchBook.Text.Trim();
            if (keyword == "Nhập tên sách, tác giả...") keyword = null;
            LoadBookCatalog(keyword);
        }

        private void UpdateCartDisplay()
        {
            lblCartTitle.Text = $"GIỎ HÀNG ({_cartList.Sum(c => c.SoLuong)} cuốn)";
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvBookCatalog.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvBookCatalog.CurrentRow;
            // Ép kiểu về DTO/Model tương ứng nếu cần, ở đây giả sử binding trực tiếp
            // hoặc lấy qua Cells nếu DataSource là List anonymous/DTO
            // Cách an toàn hơn là lấy object từ DataBoundItem
            var selectedBook = row.DataBoundItem as BookCatalogItem;
            if (selectedBook == null) return;

            int maSach = selectedBook.MaSach;
            string tenSach = selectedBook.TenSach;
            int soLuongTon = selectedBook.SoLuongTon;
            int soLuongMuon = (int)numQuantity.Value;

            if (soLuongMuon <= 0 || soLuongMuon > soLuongTon)
            {
                MessageBox.Show("Số lượng mượn không hợp lệ hoặc vượt quá số lượng tồn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CartItem existingItem = _cartList.FirstOrDefault(c => c.MaSach == maSach);

            if (existingItem != null)
            {
                if (existingItem.SoLuong + soLuongMuon > soLuongTon)
                {
                    MessageBox.Show($"Tổng số lượng mượn ({existingItem.SoLuong + soLuongMuon}) vượt quá số lượng tồn ({soLuongTon}).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existingItem.SoLuong += soLuongMuon;
            }
            else
            {
                _cartList.Add(new CartItem { MaSach = maSach, TenSach = tenSach, SoLuong = soLuongMuon });
            }

            dgvCart.Refresh();
            UpdateCartDisplay();
        }

        private void BtnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách trong giỏ hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CartItem selectedItem = dgvCart.CurrentRow.DataBoundItem as CartItem;
            if (selectedItem != null)
            {
                _cartList.Remove(selectedItem);
                UpdateCartDisplay();
            }
        }

        private bool KiemTraNoPhat()
        {
            using (var db = new Model1())
            {
                var khoanPhat = db.PHIEUTRAs
                    .Where(pt => pt.PHIEUMUON.MASV == _maSV && pt.TONGTIENPHAT > 0 && pt.TRANGTHAIPHAT == "Chưa thanh toán")
                    .Select(pt => pt.TONGTIENPHAT)
                    .ToList();

                if (khoanPhat.Count > 0)
                {
                    double tongNo = (double)khoanPhat.Sum();
                    MessageBox.Show($"BẠN ĐANG CÓ KHOẢN PHẠT CHƯA THANH TOÁN!\n\n" +
                                    $"- Tổng số tiền phạt: {tongNo:N0} VNĐ\n" +
                                    $"- Lý do: Trả sách quá hạn hoặc làm hỏng sách.\n\n" +
                                    $"Vui lòng liên hệ Thủ thư để đóng phạt trước khi gửi yêu cầu mượn mới.",
                                    "Cảnh báo vi phạm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }
                return false;
            }
        }

        private void BtnGuiYeuCau_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nợ
            if (KiemTraNoPhat()) return;

            // 2. Kiểm tra giỏ hàng
            if (!_cartList.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống. Vui lòng thêm sách để gửi yêu cầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 3. KIỂM TRA NGÀY HẸN TRẢ (LOGIC MỚI) ---
            DateTime ngayMuon = DateTime.Today;
            DateTime ngayHenTra = dtpHanTra.Value.Date; // Lấy ngày chọn từ DateTimePicker

            if (ngayHenTra < ngayMuon)
            {
                MessageBox.Show("Ngày hẹn trả không được nhỏ hơn ngày hiện tại!", "Lỗi ngày tháng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime hanToiDa = ngayMuon.AddMonths(1); // Tối đa 1 tháng
            if (ngayHenTra > hanToiDa)
            {
                MessageBox.Show($"Ngày hẹn trả không được quá 1 tháng kể từ ngày mượn.\n" +
                                $"Hạn tối đa cho phép là: {hanToiDa:dd/MM/yyyy}",
                                "Quy định mượn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    // Tìm hoặc tạo Phiếu Mượn "Chờ duyệt"
                    PHIEUMUON phieuMuon = db.PHIEUMUONs
                                            .FirstOrDefault(pm => pm.MASV == _maSV && pm.TRANGTHAI == "Chờ duyệt");

                    if (phieuMuon == null)
                    {
                        phieuMuon = new PHIEUMUON
                        {
                            MASV = _maSV,
                            MATT = 1, // Mã thủ thư mặc định (hoặc xử lý sau)
                            NGAYLAPPHIEUMUON = DateTime.Today,
                            HANTRA = ngayHenTra, // <-- Lưu ngày hẹn trả người dùng chọn
                            TRANGTHAI = "Chờ duyệt",
                            SOLANGIAHAN = 0
                        };
                        db.PHIEUMUONs.Add(phieuMuon);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Nếu đã có phiếu chờ duyệt, cập nhật lại hạn trả theo yêu cầu mới nhất
                        phieuMuon.HANTRA = ngayHenTra;
                        db.Entry(phieuMuon).State = EntityState.Modified;
                    }

                    _currentMaPM = phieuMuon.MAPM;

                    // Thêm/Cập nhật sách vào Chi Tiết
                    foreach (var cartItem in _cartList)
                    {
                        CHITIETPHIEUMUON chiTiet = db.CHITIETPHIEUMUONs
                                                   .FirstOrDefault(ct => ct.MAPM == _currentMaPM && ct.MASACH == cartItem.MaSach);

                        if (chiTiet != null)
                        {
                            chiTiet.SOLUONG += cartItem.SoLuong;
                            chiTiet.HANTRA = ngayHenTra; // Cập nhật hạn trả cho sách
                            db.Entry(chiTiet).State = EntityState.Modified;
                        }
                        else
                        {
                            chiTiet = new CHITIETPHIEUMUON
                            {
                                MAPM = _currentMaPM,
                                MASACH = cartItem.MaSach,
                                SOLUONG = cartItem.SoLuong,
                                HANTRA = ngayHenTra, // Lưu hạn trả cho sách
                                SOLANGIAHAN = 0
                            };
                            db.CHITIETPHIEUMUONs.Add(chiTiet);
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show($"Gửi yêu cầu thành công!\nNgày hẹn trả: {ngayHenTra:dd/MM/yyyy}\nPhiếu #{phieuMuon.MAPM} đang chờ duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // View Models (DTOs nội bộ)
        public class BookCatalogItem
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public string TacGia { get; set; }
            public int SoLuongTon { get; set; }
        }
        public class CartItem : INotifyPropertyChanged
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            private int _soLuong;
            public int SoLuong
            {
                get { return _soLuong; }
                set
                {
                    _soLuong = value;
                    OnPropertyChanged("SoLuong");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}