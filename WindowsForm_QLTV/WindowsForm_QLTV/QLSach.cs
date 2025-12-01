using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace WindowsForm_QLTV
{
    public partial class FormQLSach : Form
    {
        public FormQLSach()
        {
            InitializeComponent();
            this.Load += FormQLSach_Load;

            btnQLSach.Click += DashboardButton_Click;
            btnTacGia.Click += DashboardButton_Click;
            btnNhaXuatBan.Click += DashboardButton_Click;
        }

        private void FormQLSach_Load(object sender, EventArgs e)
        {
            LoadBookCards();
        }

        // --- HÀM LOAD FORM CON (GIỮ NGUYÊN) ---
        private void LoadSubForm(Form form)
        {
            Panel pnlContent = this.Parent as Panel;
            if (pnlContent != null)
            {
                pnlContent.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(form);
                form.Show();
            }
        }

        private void LoadSubForm(Type formType)
        {
            try
            {
                Form form = (Form)Activator.CreateInstance(formType);
                LoadSubForm(form);
            }
            catch { }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn.Text == "Quản Lý Sách") LoadSubForm(typeof(EditSach));
            else if (btn.Text == "Tác Giả") LoadSubForm(typeof(FormQLTacGia));
            else if (btn.Text == "Nhà Xuất Bản") LoadSubForm(typeof(FormQLNXB));
        }

        // --- [SỬA ĐỔI 1] LƯU MÃ SÁCH KHI TẢI DỮ LIỆU ---
        private void LoadBookCards()
        {
            pnlCardContainer.Controls.Clear();
            List<BookItem> books = new List<BookItem>();

            try
            {
                using (var db = new Model1())
                {
                    var queriedBooks = db.SACHes.AsNoTracking()
                                                 .Where(s => s.TRANGTHAI == "Có sẵn")
                                                 .OrderByDescending(s => s.MASACH)
                                                 .ToList();

                    foreach (var book in queriedBooks)
                    {
                        books.Add(new BookItem
                        {
                            MaSach = book.MASACH, // <-- QUAN TRỌNG: Lưu mã sách
                            Title = book.TENSACH,
                            Subtitle = book.THELOAI,
                            HinhAnh = book.HINHANH,
                        });
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); return; }

            int x = 10, y = 10, w = 200, h = 350, padding = 20, cols = 4, idx = 0;

            foreach (var book in books)
            {
                Panel card = CreateBookCard(book, w, h);
                card.Location = new Point(x, y);
                pnlCardContainer.Controls.Add(card);

                x += w + padding;
                idx++;
                if (idx % cols == 0) { x = 10; y += h + padding; }
            }
        }

        // --- [SỬA ĐỔI 2] GÁN MÃ SÁCH VÀO NÚT BẤM ---
        private Panel CreateBookCard(BookItem book, int width, int height)
        {
            Panel pnl = new Panel { Size = new Size(width, height), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };

            PictureBox pb = new PictureBox { Size = new Size(width - 20, 200), Location = new Point(10, 10), BackColor = Color.WhiteSmoke, SizeMode = PictureBoxSizeMode.StretchImage };
            if (!string.IsNullOrEmpty(book.HinhAnh)) LoadImageFromLocalFolder(pb, book.HinhAnh);
            pnl.Controls.Add(pb);

            Label lblTitle = new Label { Text = book.Title, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, 220), Size = new Size(width - 20, 20), TextAlign = ContentAlignment.MiddleCenter };
            pnl.Controls.Add(lblTitle);

            Label lblSub = new Label { Text = "Thể loại: " + book.Subtitle, Font = new Font("Segoe UI", 9F), Location = new Point(10, 245), Size = new Size(width - 20, 20), TextAlign = ContentAlignment.MiddleCenter };
            pnl.Controls.Add(lblSub);

            Button btn = new Button
            {
                Text = "Xem chi tiết",
                BackColor = Color.FromArgb(39, 174, 96),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, height - 45),
                Size = new Size(width - 20, 35),
                Tag = book.MaSach // <-- QUAN TRỌNG: Gán ID vào Tag thay vì Title
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += BtnDetail_Click;
            pnl.Controls.Add(btn);

            return pnl;
        }

        private void LoadImageFromLocalFolder(PictureBox pb, string fileName)
        {
            try
            {
                string root = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\images"));
                string path = Path.Combine(root, fileName);
                if (File.Exists(path)) using (var ms = new MemoryStream(File.ReadAllBytes(path))) pb.Image = Image.FromStream(ms);
            }
            catch { pb.Image = null; }
        }

        // --- [SỬA ĐỔI 3] MỞ FORM CHI TIẾT THAY VÌ MESSAGEBOX ---
        private void BtnDetail_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                if (int.TryParse(btn.Tag.ToString(), out int maSach))
                {
                    // Tạo Form Chi Tiết Sách (Code form này bạn đã có ở câu trả lời trước)
                    FormChiTietSach formChiTiet = new FormChiTietSach(maSach);

                    // Cách 1: Mở dạng cửa sổ nổi (Popup) - Giống hệt Ảnh 2
                    formChiTiet.ShowDialog();

                    // Cách 2: Mở lồng vào Panel chính (nếu bạn muốn giữ phong cách Dashboard)
                    // LoadSubForm(formChiTiet);
                }
            }
        }
    }
}