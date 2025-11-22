namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHLY")]
    public partial class THANHLY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THANHLY()
        {
            CHITIETTHANHLies = new HashSet<CHITIETTHANHLY>();
        }

        [Key]
        public int MATL { get; set; }

        public int MATK { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYLAP { get; set; }

        public decimal? TONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHANHLY> CHITIETTHANHLies { get; set; }

        public virtual THUKHO THUKHO { get; set; }
    }
}
