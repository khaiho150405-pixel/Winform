using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel;

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
            dgvBookCatalog.Columns["MaSach"].Visible = false; // Ẩn Mã sách thô

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
            int maSach = (int)row.Cells["MaSach"].Value;
            string tenSach = row.Cells["TenSach"].Value.ToString();
            int soLuongTon = (int)row.Cells["SoLuongTon"].Value;
            int soLuongMuon = (int)numQuantity.Value;

            if (soLuongMuon <= 0 || soLuongMuon > soLuongTon)
            {
                MessageBox.Show("Số lượng mượn không hợp lệ hoặc vượt quá số lượng tồn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra và cập nhật giỏ hàng
            CartItem existingItem = _cartList.FirstOrDefault(c => c.MaSach == maSach);

            if (existingItem != null)
            {
                // Kiểm tra tổng số lượng có vượt quá tồn kho không
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

            // Refresh DataGridView và cập nhật UI
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

        private void BtnGuiYeuCau_Click(object sender, EventArgs e)
        {
            if (!_cartList.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống. Vui lòng thêm sách để gửi yêu cầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    // 1. Tìm hoặc tạo Phiếu Mượn "Chờ duyệt"
                    PHIEUMUON phieuMuon = db.PHIEUMUONs
                                            .FirstOrDefault(pm => pm.MASV == _maSV && pm.TRANGTHAI == "Chờ duyệt");

                    if (phieuMuon == null)
                    {
                        phieuMuon = new PHIEUMUON
                        {
                            MASV = _maSV,
                            MATT = 1, // Giả định Thủ Thư có MATT = 1
                            NGAYLAPPHIEUMUON = DateTime.Today,
                            HANTRA = DateTime.Today.AddDays(14), // Mặc định 14 ngày
                            TRANGTHAI = "Chờ duyệt",
                            SOLANGIAHAN = 0
                        };
                        db.PHIEUMUONs.Add(phieuMuon);
                        db.SaveChanges(); // Lưu để lấy MAPM
                    }
                    _currentMaPM = phieuMuon.MAPM;

                    // 2. Thêm hoặc cập nhật tất cả sách từ giỏ hàng vào Chi Tiết Phiếu Mượn
                    foreach (var cartItem in _cartList)
                    {
                        CHITIETPHIEUMUON chiTiet = db.CHITIETPHIEUMUONs
                                                   .FirstOrDefault(ct => ct.MAPM == _currentMaPM && ct.MASACH == cartItem.MaSach);

                        if (chiTiet != null)
                        {
                            chiTiet.SOLUONG += cartItem.SoLuong;
                            db.Entry(chiTiet).State = EntityState.Modified;
                        }
                        else
                        {
                            chiTiet = new CHITIETPHIEUMUON
                            {
                                MAPM = _currentMaPM,
                                MASACH = cartItem.MaSach,
                                SOLUONG = cartItem.SoLuong,
                                HANTRA = phieuMuon.HANTRA,
                                SOLANGIAHAN = 0
                            };
                            db.CHITIETPHIEUMUONs.Add(chiTiet);
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show($"Yêu cầu mượn {phieuMuon.CHITIETPHIEUMUONs.Count} loại sách (Tổng {phieuMuon.CHITIETPHIEUMUONs.Sum(ct => ct.SOLUONG)} cuốn) đã được gửi thành công! Phiếu #{phieuMuon.MAPM} đang chờ duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi yêu cầu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // View Models
        public class BookCatalogItem
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public string TacGia { get; set; }
            public int SoLuongTon { get; set; }
        }
        public class CartItem
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }
    }
}