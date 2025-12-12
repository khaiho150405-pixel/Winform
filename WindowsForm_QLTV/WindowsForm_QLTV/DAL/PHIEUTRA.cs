namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTRA")]
    public partial class PHIEUTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTRA()
        {
            CHITIETPHIEUTRAs = new HashSet<CHITIETPHIEUTRA>();
        }

        [Key]
        public int MAPT { get; set; }

        public int MAPM { get; set; }

        public int MATT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYLAPPHIEUTRA { get; set; }

        public int? SONGAYQUAHAN { get; set; }

        public double? TONGTIENPHAT { get; set; }

        public string TRANGTHAIPHAT {get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUTRA> CHITIETPHIEUTRAs { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }

        public virtual THUTHU THUTHU { get; set; }
    }
}
