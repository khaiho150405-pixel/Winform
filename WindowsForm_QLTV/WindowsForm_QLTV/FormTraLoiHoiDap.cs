using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// Lưu ý: Chỉ dùng namespace gốc của project, không thêm .DAL để tránh lỗi
using WindowsForm_QLTV;

namespace WindowsForm_QLTV
{
    public class FormTraLoiHoiDap : Form
    {
        // --- KHAI BÁO CÁC CONTROL ---
        private DataGridView dgvCauHoi;
        private GroupBox grpChiTiet;
        private Label lblNguoiHoi;
        private TextBox txtCauHoi;
        private Label lblTraLoi;
        private TextBox txtTraLoi;
        private Button btnGuiTraLoi;
        private Button btnTaiLai; // Nút làm mới danh sách

        // Biến lưu thông tin
        private int _maThuThu; // ID thủ thư đang đăng nhập
        private int _currentMaHoiDap = -1; // ID câu hỏi đang chọn

        public FormTraLoiHoiDap(int maThuThu)
        {
            _maThuThu = maThuThu;

            // 1. Dựng giao diện
            InitializeCustomComponents();

            // 2. Tải dữ liệu
            LoadDanhSachCauHoi();
        }

        // --- PHẦN 1: CODE DỰNG GIAO DIỆN (UI) ---
        private void InitializeCustomComponents()
        {
            this.Text = "Tiếp Nhận & Trả Lời Câu Hỏi - Thủ Thư";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // 1. Panel bên trái: Danh sách câu hỏi (60% chiều rộng)
            Label lblTitleList = new Label()
            {
                Text = "Danh sách câu hỏi chờ trả lời",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            btnTaiLai = new Button()
            {
                Text = "Tải lại",
                Location = new Point(480, 5),
                Size = new Size(80, 30),
                BackColor = Color.LightGray
            };
            btnTaiLai.Click += (s, e) => LoadDanhSachCauHoi();

            dgvCauHoi = new DataGridView();
            dgvCauHoi.Location = new Point(10, 45);
            dgvCauHoi.Size = new Size(550, 500);
            dgvCauHoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.MultiSelect = false;
            dgvCauHoi.BackgroundColor = Color.White;
            dgvCauHoi.AllowUserToAddRows = false;
            // Gắn sự kiện khi click vào dòng
            dgvCauHoi.CellClick += DgvCauHoi_CellClick;

            // 2. Panel bên phải: Chi tiết và trả lời (40% chiều rộng)
            grpChiTiet = new GroupBox();
            grpChiTiet.Text = "Chi tiết phản hồi";
            grpChiTiet.Location = new Point(580, 40);
            grpChiTiet.Size = new Size(390, 505);
            grpChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpChiTiet.Font = new Font("Arial", 10, FontStyle.Regular);

            lblNguoiHoi = new Label() { Text = "Sinh viên hỏi:", Location = new Point(15, 30), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };

            Label lblNoiDungHoi = new Label() { Text = "Nội dung câu hỏi:", Location = new Point(15, 60), AutoSize = true };
            txtCauHoi = new TextBox()
            {
                Location = new Point(15, 85),
                Size = new Size(360, 100),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.WhiteSmoke
            };

            lblTraLoi = new Label() { Text = "Nhập câu trả lời:", Location = new Point(15, 200), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.DarkGreen };
            txtTraLoi = new TextBox()
            {
                Location = new Point(15, 225),
                Size = new Size(360, 200),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnGuiTraLoi = new Button()
            {
                Text = "Gửi Trả Lời",
                Location = new Point(15, 440),
                Size = new Size(360, 50),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                Font = new Font("Arial", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnGuiTraLoi.Click += BtnGuiTraLoi_Click;

            // Thêm control vào GroupBox
            grpChiTiet.Controls.Add(lblNguoiHoi);
            grpChiTiet.Controls.Add(lblNoiDungHoi);
            grpChiTiet.Controls.Add(txtCauHoi);
            grpChiTiet.Controls.Add(lblTraLoi);
            grpChiTiet.Controls.Add(txtTraLoi);
            grpChiTiet.Controls.Add(btnGuiTraLoi);

            // Thêm control vào Form
            this.Controls.Add(lblTitleList);
            this.Controls.Add(btnTaiLai);
            this.Controls.Add(dgvCauHoi);
            this.Controls.Add(grpChiTiet);
        }

        // --- PHẦN 2: XỬ LÝ LOGIC (DATABASE) ---

        // Hàm tải danh sách câu hỏi "Chờ trả lời"
        private void LoadDanhSachCauHoi()
        {
            try
            {
                using (var db = new Model1())
                {
                    // Lấy các câu hỏi có trạng thái "Chờ trả lời"
                    var list = db.HOIDAPs
                        .Where(h => h.TRANGTHAI == "Chờ trả lời")
                        .OrderByDescending(h => h.THOIGIANHOI)
                        .Select(h => new
                        {
                            MaHD = h.MAHOIDAP,
                            // Truy cập vào bảng SINHVIEN thông qua navigation property (nếu có)
                            // Nếu Model1 chưa map quan hệ, có thể phải join thủ công. 
                            // Ở đây giả định Model1 đã có quan hệ (foreign key)
                            TenSV = h.SINHVIEN.HOVATEN,
                            NoiDung = h.CAUHOI,
                            NgayHoi = h.THOIGIANHOI
                        })
                        .ToList();

                    dgvCauHoi.DataSource = list;

                    // Định dạng cột
                    if (dgvCauHoi.Columns["MaHD"] != null) dgvCauHoi.Columns["MaHD"].Visible = false; // Ẩn ID
                    if (dgvCauHoi.Columns["TenSV"] != null) dgvCauHoi.Columns["TenSV"].HeaderText = "Sinh Viên";
                    if (dgvCauHoi.Columns["NoiDung"] != null) dgvCauHoi.Columns["NoiDung"].HeaderText = "Câu Hỏi";
                    if (dgvCauHoi.Columns["NgayHoi"] != null) dgvCauHoi.Columns["NgayHoi"].HeaderText = "Ngày Hỏi";
                }

                // Reset form nhập liệu
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện khi chọn một dòng trong bảng
        private void DgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCauHoi.CurrentRow != null)
            {
                // Lấy dữ liệu từ dòng được chọn
                var row = dgvCauHoi.Rows[e.RowIndex];

                _currentMaHoiDap = Convert.ToInt32(row.Cells["MaHD"].Value);
                string tenSV = row.Cells["TenSV"].Value.ToString();
                string cauHoi = row.Cells["NoiDung"].Value.ToString();

                // Hiển thị lên panel chi tiết
                lblNguoiHoi.Text = "Sinh viên hỏi: " + tenSV;
                txtCauHoi.Text = cauHoi;
                txtTraLoi.Focus(); // Đặt con trỏ chuột vào ô trả lời
            }
        }

        // Sự kiện nút Gửi Trả Lời
        private void BtnGuiTraLoi_Click(object sender, EventArgs e)
        {
            if (_currentMaHoiDap == -1)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi từ danh sách bên trái!", "Chưa chọn câu hỏi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTraLoi.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu trả lời!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    // Tìm câu hỏi trong DB theo ID
                    var hd = db.HOIDAPs.Find(_currentMaHoiDap);
                    if (hd != null)
                    {
                        // Cập nhật thông tin trả lời
                        hd.TRALOI = txtTraLoi.Text.Trim();
                        hd.MATT = _maThuThu; // Gán ID thủ thư thực hiện
                        hd.THOIGIANTRALOI = DateTime.Now;
                        hd.TRANGTHAI = "Đã trả lời";

                        db.SaveChanges(); // Lưu vào DB

                        MessageBox.Show("Đã gửi câu trả lời thành công!", "Thông báo");

                        // Tải lại danh sách để loại bỏ câu hỏi vừa trả lời
                        LoadDanhSachCauHoi();
                    }
                    else
                    {
                        MessageBox.Show("Câu hỏi không tồn tại hoặc đã bị xóa!", "Lỗi");
                        LoadDanhSachCauHoi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu câu trả lời: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            _currentMaHoiDap = -1;
            lblNguoiHoi.Text = "Sinh viên hỏi: ...";
            txtCauHoi.Clear();
            txtTraLoi.Clear();
        }
    }
}