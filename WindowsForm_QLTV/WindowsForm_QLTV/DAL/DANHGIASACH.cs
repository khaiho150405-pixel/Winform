namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIASACH")]
    public partial class DANHGIASACH
    {
        [Key]
        public int MADANHGIA { get; set; }

        public int MASACH { get; set; }

        public int MASV { get; set; }

        public int? DIEM { get; set; }

        public string NHANXET { get; set; }

        public DateTime? THOIGIAN { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
