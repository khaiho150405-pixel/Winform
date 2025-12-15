using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForm_QLTV
{
    public partial class FormBaoCao : Form
    {
        Model1 db = new Model1();
        // Thư mục lưu chung: bin/Debug/Reports
        string reportFolder = Path.Combine(Application.StartupPath, "Reports");

        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            // Tạo thư mục nếu chưa có
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }
            this.reportViewer1.RefreshReport();
        }

        // 1. XEM BÁO CÁO (Load dữ liệu lên Viewer)
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int thang = dateTimePicker1.Value.Month;
            int nam = dateTimePicker1.Value.Year;
            LoadReportMuonSach(thang, nam);
        }

        private void LoadReportMuonSach(int thang, int nam)
        {
            try
            {
                var data = from pm in db.PHIEUMUONs
                           join ct in db.CHITIETPHIEUMUONs on pm.MAPM equals ct.MAPM
                           join s in db.SACHes on ct.MASACH equals s.MASACH
                           join sv in db.SINHVIENs on pm.MASV equals sv.MASV
                           where pm.NGAYLAPPHIEUMUON.Month == thang && pm.NGAYLAPPHIEUMUON.Year == nam
                           select new
                           {
                               MaPhieu = pm.MAPM,
                               TenSinhVien = sv.HOVATEN,
                               TenSach = s.TENSACH,
                               NgayMuon = pm.NGAYLAPPHIEUMUON,
                               HanTra = pm.HANTRA,
                               SoLuong = ct.SOLUONG
                           };

                if (data.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong tháng này.", "Thông báo");
                    reportViewer1.Clear();
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("MaPhieu", typeof(int));
                dt.Columns.Add("TenSinhVien", typeof(string));
                dt.Columns.Add("TenSach", typeof(string));
                dt.Columns.Add("NgayMuon", typeof(DateTime));
                dt.Columns.Add("HanTra", typeof(DateTime));
                dt.Columns.Add("SoLuong", typeof(int));

                foreach (var item in data)
                {
                    dt.Rows.Add(item.MaPhieu, item.TenSinhVien, item.TenSach, item.NgayMuon, item.HanTra, item.SoLuong);
                }

                reportViewer1.LocalReport.ReportPath = "RptMuonSachThang.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // 2. GỬI BÁO CÁO (Lưu ra PDF)
        private void btnGuiBaoCao_Click(object sender, EventArgs e)
        {
            if (reportViewer1.LocalReport.DataSources.Count == 0)
            {
                MessageBox.Show("Vui lòng xem báo cáo trước khi gửi!", "Cảnh báo");
                return;
            }

            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out extension,
                    out streamids, out warnings);

                // Tên file: BaoCao_ThangX_NamY_[ThờiGian].pdf
                string fileName = string.Format("BaoCao_Thang{0}_{1}_{2}.pdf",
                    dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Year,
                    DateTime.Now.ToString("ddMMyyyy_HHmmss"));

                string fullPath = Path.Combine(reportFolder, fileName);

                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

                MessageBox.Show("Đã gửi báo cáo thành công cho Admin!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi báo cáo: " + ex.Message);
            }
        }
    }
}