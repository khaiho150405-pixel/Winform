namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOIDAP")]
    public partial class HOIDAP
    {
        [Key]
        public int MAHOIDAP { get; set; }

        public int MASV { get; set; }

        [Required]
        public string CAUHOI { get; set; }

        public string TRALOI { get; set; }

        public int? MATT { get; set; }

        public DateTime? THOIGIANHOI { get; set; }

        public DateTime? THOIGIANTRALOI { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }

        public virtual THUTHU THUTHU { get; set; }
    }
}
