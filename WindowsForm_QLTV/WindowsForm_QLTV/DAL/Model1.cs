using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsForm_QLTV
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CHITIETPHIEUMUON> CHITIETPHIEUMUONs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual DbSet<CHITIETPHIEUTRA> CHITIETPHIEUTRAs { get; set; }
        public virtual DbSet<CHITIETTHANHLY> CHITIETTHANHLies { get; set; }
        public virtual DbSet<DANHGIASACH> DANHGIASACHes { get; set; }
        public virtual DbSet<GOPY> GOPies { get; set; }
        public virtual DbSet<HOIDAP> HOIDAPs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<PHIEUMUON> PHIEUMUONs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUTRA> PHIEUTRAs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THANHLY> THANHLies { get; set; }
        public virtual DbSet<THUKHO> THUKHOes { get; set; }
        public virtual DbSet<THUTHU> THUTHUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.GIANHAP)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CHITIETPHIEUNHAP>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(21, 2);

            modelBuilder.Entity<CHITIETTHANHLY>()
                .Property(e => e.DONGIA)
                .HasPrecision(10, 2);

            modelBuilder.Entity<CHITIETTHANHLY>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(21, 2);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.NHAXUATBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANQUYEN>()
                .HasMany(e => e.TAIKHOANs)
                .WithRequired(e => e.PHANQUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.CHITIETPHIEUMUONs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUON>()
                .HasMany(e => e.PHIEUTRAs)
                .WithRequired(e => e.PHIEUMUON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.PHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTRA>()
                .HasMany(e => e.CHITIETPHIEUTRAs)
                .WithRequired(e => e.PHIEUTRA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GIAMUON)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETPHIEUMUONs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETPHIEUNHAPs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETPHIEUTRAs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETTHANHLies)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.DANHGIASACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.DANHGIASACHes)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.GOPies)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.HOIDAPs)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINHVIEN>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.SINHVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.SINHVIENs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.THUKHOes)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.THUTHUs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THANHLY>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(12, 2);

            modelBuilder.Entity<THANHLY>()
                .HasMany(e => e.CHITIETTHANHLies)
                .WithRequired(e => e.THANHLY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUKHO>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<THUKHO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<THUKHO>()
                .HasMany(e => e.PHIEUNHAPs)
                .WithRequired(e => e.THUKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUKHO>()
                .HasMany(e => e.THANHLies)
                .WithRequired(e => e.THUKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUTHU>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<THUTHU>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<THUTHU>()
                .HasMany(e => e.PHIEUMUONs)
                .WithRequired(e => e.THUTHU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUTHU>()
                .HasMany(e => e.PHIEUTRAs)
                .WithRequired(e => e.THUTHU)
                .WillCascadeOnDelete(false);
        }
    }
}
