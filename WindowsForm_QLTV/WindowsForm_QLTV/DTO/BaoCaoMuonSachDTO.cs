using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_QLTV.DTO
{
    internal class BaoCaoMuonSachDTO
    {
        public int MaPhieu { get; set; }
        public string TenSinhVien { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }
    }
}
