using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyQAn.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietGoiMon> ChiTietGoiMons { get; set; }
        public virtual DbSet<DSBan> DSBans { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietGoiMon>()
                .Property(e => e.tenMonDaChon)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietGoiMon>()
                .Property(e => e.giaMon)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DSBan>()
                .Property(e => e.tenBan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenHienThi)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.chucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ThucDon>()
                .Property(e => e.tenMon)
                .IsUnicode(false);

            modelBuilder.Entity<ThucDon>()
                .Property(e => e.giaMon)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ThucDon>()
                .Property(e => e.ghiChu)
                .IsUnicode(false);

            modelBuilder.Entity<ThucDon>()
                .Property(e => e.loaiMonAn)
                .IsUnicode(false);
        }
    }
}
