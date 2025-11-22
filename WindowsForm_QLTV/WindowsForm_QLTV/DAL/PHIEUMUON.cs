namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            CHITIETPHIEUMUONs = new HashSet<CHITIETPHIEUMUON>();
            PHIEUTRAs = new HashSet<PHIEUTRA>();
        }

        [Key]
        public int MAPM { get; set; }

        public int MASV { get; set; }

        public int MATT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYLAPPHIEUMUON { get; set; }

        [Column(TypeName = "date")]
        public DateTime HANTRA { get; set; }

        [Required]
        [StringLength(30)]
        public string TRANGTHAI { get; set; }

        public int? SOLANGIAHAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUMUON> CHITIETPHIEUMUONs { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }

        public virtual THUTHU THUTHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRA> PHIEUTRAs { get; set; }
    }
}
