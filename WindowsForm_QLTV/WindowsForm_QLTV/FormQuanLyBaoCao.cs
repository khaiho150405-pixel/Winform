using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class FormQuanLyBaoCao : Form
    {
        // Đường dẫn phải CHÍNH XÁC như bên FormBaoCao
        string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        public FormQuanLyBaoCao()
        {
            InitializeComponent();
        }

        // Đảm bảo tên hàm này trùng với tên trong Designer
        private void FormQuanLyBaoCao_Load(object sender, EventArgs e)
        {
            LoadDanhSachFile();
        }

        private void LoadDanhSachFile()
        {
            if (!Directory.Exists(reportFolder))
            {
                // Nếu chưa có thư mục nghĩa là chưa có file nào
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("TenFile", typeof(string));
            dt.Columns.Add("NgayGui", typeof(DateTime));
            dt.Columns.Add("DuongDanFull", typeof(string));

            // Quét tất cả file PDF
            string[] files = Directory.GetFiles(reportFolder, "*.pdf");

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                dt.Rows.Add(info.Name, info.CreationTime, info.FullName);
            }

            dgvDanhSachBaoCao.DataSource = dt;

            // Format lại cột cho đẹp
            if (dgvDanhSachBaoCao.Columns["DuongDanFull"] != null)
                dgvDanhSachBaoCao.Columns["DuongDanFull"].Visible = false; // Ẩn đường dẫn

            dgvDanhSachBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Sự kiện click đúp để mở file
        private void dgvDanhSachBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string path = dgvDanhSachBaoCao.Rows[e.RowIndex].Cells["DuongDanFull"].Value.ToString();
                if (File.Exists(path))
                {
                    Process.Start(path);
                }
            }
        }
    }
}