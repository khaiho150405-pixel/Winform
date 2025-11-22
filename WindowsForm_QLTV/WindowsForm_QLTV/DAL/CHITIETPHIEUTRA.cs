namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUTRA")]
    public partial class CHITIETPHIEUTRA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int? SOLUONGTRA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYTRA { get; set; }

        public virtual PHIEUTRA PHIEUTRA { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
