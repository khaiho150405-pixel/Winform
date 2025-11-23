namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUMUON")]
    public partial class CHITIETPHIEUMUON
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPM { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int SOLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HANTRA { get; set; }

        public int? SOLANGIAHAN { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
