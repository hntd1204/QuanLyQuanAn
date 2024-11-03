namespace QuanLyQAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string tenDangNhap { get; set; }

        [StringLength(100)]
        public string tenHienThi { get; set; }

        [Required]
        [StringLength(255)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string chucVu { get; set; }
    }
}
