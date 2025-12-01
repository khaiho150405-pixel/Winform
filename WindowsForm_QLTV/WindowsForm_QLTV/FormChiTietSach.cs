using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace WindowsForm_QLTV
{
    public class FormChiTietSach : Form
    {
        private int _maSach;
        private PictureBox pbHinhAnh;
        private Label lblTenSach;
        private Label lblTheLoai;
        private Label lblTacGia;
        private Label lblNXB;
        private Label lblGiaTien;
        private Label lblSoLuong;
        private Label lblTrangThai;
        private Button btnDong;

        // Biến cần thiết cho Designer (bắt buộc)
        private System.ComponentModel.IContainer components = null;

        public FormChiTietSach(int maSach)
        {
            _maSach = maSach;

            // 1. Gọi hàm chuẩn của Designer (để không bị báo lỗi)
            InitializeComponent();

            // 2. Gọi hàm tạo giao diện riêng của bạn
            TaoGiaoDienThuCong();

            LoadData();
        }

        // --- Hàm này chỉ chứa các cài đặt cơ bản để Designer không bị lỗi ---
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new Size(600, 450);
            this.Text = "Chi tiết sách";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        // --- Di chuyển toàn bộ logic tạo nút/nhãn vào đây ---
        private void TaoGiaoDienThuCong()
        {
            // 1. Ảnh bìa bên trái
            pbHinhAnh = new PictureBox();
            pbHinhAnh.Location = new Point(20, 20);
            pbHinhAnh.Size = new Size(200, 300);
            pbHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            pbHinhAnh.BackColor = Color.WhiteSmoke;
            this.Controls.Add(pbHinhAnh);

            // 2. Các thông tin bên phải
            int labelX = 240;
            int startY = 20;
            int gap = 35;

            lblTenSach = new Label();
            lblTenSach.Location = new Point(labelX, startY);
            lblTenSach.Size = new Size(330, 60);
            lblTenSach.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTenSach.ForeColor = Color.FromArgb(44, 62, 80);
            this.Controls.Add(lblTenSach);

            // Gọi hàm CreateLabel ở đây thì OK, không bị lỗi Designer
            lblTheLoai = CreateLabel(labelX, startY + 70);
            this.Controls.Add(lblTheLoai);

            lblTacGia = CreateLabel(labelX, startY + 70 + gap);
            this.Controls.Add(lblTacGia);

            lblNXB = CreateLabel(labelX, startY + 70 + gap * 2);
            this.Controls.Add(lblNXB);

            lblGiaTien = CreateLabel(labelX, startY + 70 + gap * 3);
            lblGiaTien.ForeColor = Color.Red;
            lblGiaTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.Controls.Add(lblGiaTien);

            lblSoLuong = CreateLabel(labelX, startY + 70 + gap * 4);
            this.Controls.Add(lblSoLuong);

            lblTrangThai = CreateLabel(labelX, startY + 70 + gap * 5);
            lblTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.Controls.Add(lblTrangThai);

            // 3. Nút Đóng
            btnDong = new Button();
            btnDong.Text = "Đóng";
            btnDong.Size = new Size(100, 40);
            btnDong.Location = new Point(460, 360);
            btnDong.BackColor = Color.FromArgb(52, 152, 219);
            btnDong.ForeColor = Color.White;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Click += (s, e) => this.Close();
            this.Controls.Add(btnDong);
        }

        private Label CreateLabel(int x, int y)
        {
            return new Label
            {
                Location = new Point(x, y),
                Size = new Size(320, 30),
                Font = new Font("Segoe UI", 11F),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        // --- Giữ nguyên hàm LoadData và LoadImageFromLocalFolder của bạn ---
        private void LoadData()
        {
            try
            {
                using (var db = new Model1())
                {
                    var sach = db.SACHes.Find(_maSach);
                    if (sach != null)
                    {
                        this.Text = "Chi tiết: " + sach.TENSACH;
                        lblTenSach.Text = sach.TENSACH;
                        lblTheLoai.Text = $"Thể loại: {sach.THELOAI}";

                        string tenTacGia = (sach.TACGIA != null) ? sach.TACGIA.TENTG : "Đang cập nhật";
                        lblTacGia.Text = $"Tác giả: {tenTacGia}";

                        string tenNXB = (sach.NHAXUATBAN != null) ? sach.NHAXUATBAN.TENNXB : "Đang cập nhật";
                        lblNXB.Text = $"Nhà xuất bản: {tenNXB}";

                        lblGiaTien.Text = $"Giá trị sách: {sach.GIAMUON:N0} VNĐ";
                        lblSoLuong.Text = $"Số lượng tồn: {sach.SOLUONGTON}";

                        if (sach.SOLUONGTON > 0)
                        {
                            lblTrangThai.Text = "Trạng thái: Sẵn sàng cho mượn";
                            lblTrangThai.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblTrangThai.Text = "Trạng thái: Hết hàng";
                            lblTrangThai.ForeColor = Color.Red;
                        }

                        LoadImageFromLocalFolder(pbHinhAnh, sach.HINHANH);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadImageFromLocalFolder(PictureBox pb, string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName)) { pb.Image = null; return; }
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string path1 = Path.Combine(projectRoot, "images", imageFileName);
                string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", imageFileName);
                string fullPath = File.Exists(path1) ? path1 : (File.Exists(path2) ? path2 : null);

                if (fullPath != null)
                {
                    using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);
                            ms.Position = 0;
                            pb.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            catch { pb.Image = null; }
        }

        // Bổ sung hàm Dispose để giải phóng tài nguyên đúng chuẩn Designer
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}