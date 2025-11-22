namespace WindowsForm_QLTV
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            SINHVIENs = new HashSet<SINHVIEN>();
            THUKHOes = new HashSet<THUKHO>();
            THUTHUs = new HashSet<THUTHU>();
        }

        [Key]
        public int MATAIKHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string TENDANGNHAP { get; set; }

        [Required]
        [StringLength(255)]
        public string MATKHAU { get; set; }

        [StringLength(20)]
        public string TRANGTHAI { get; set; }

        public int MAQUYEN { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SINHVIEN> SINHVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUKHO> THUKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUTHU> THUTHUs { get; set; }
    }
}
