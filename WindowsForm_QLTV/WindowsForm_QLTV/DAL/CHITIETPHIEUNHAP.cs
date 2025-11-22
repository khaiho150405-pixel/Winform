namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUNHAP")]
    public partial class CHITIETPHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int? SOLUONG { get; set; }

        public decimal GIANHAP { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? THANHTIEN { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
