namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GOPY")]
    public partial class GOPY
    {
        [Key]
        public int MAGOPY { get; set; }

        public int MASV { get; set; }

        [Required]
        public string NOIDUNG { get; set; }

        [StringLength(50)]
        public string LOAIGOPY { get; set; }

        public DateTime? THOIGIANGUI { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
