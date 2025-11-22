namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETPHIEUMUONs = new HashSet<CHITIETPHIEUMUON>();
            CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            CHITIETPHIEUTRAs = new HashSet<CHITIETPHIEUTRA>();
            CHITIETTHANHLies = new HashSet<CHITIETTHANHLY>();
            DANHGIASACHes = new HashSet<DANHGIASACH>();
        }

        [Key]
        public int MASACH { get; set; }

        [Required]
        [StringLength(100)]
        public string TENSACH { get; set; }

        public int MATG { get; set; }

        public int MANXB { get; set; }

        [StringLength(255)]
        public string HINHANH { get; set; }

        [StringLength(50)]
        public string THELOAI { get; set; }

        [StringLength(255)]
        public string MOTA { get; set; }

        public decimal GIAMUON { get; set; }

        public int SOLUONGTON { get; set; }

        [Required]
        [StringLength(30)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUMUON> CHITIETPHIEUMUONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUTRA> CHITIETPHIEUTRAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHANHLY> CHITIETTHANHLies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIASACH> DANHGIASACHes { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
