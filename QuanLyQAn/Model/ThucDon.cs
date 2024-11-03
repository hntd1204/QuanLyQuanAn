namespace QuanLyQAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDon")]
    public partial class ThucDon
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string tenMon { get; set; }

        public decimal giaMon { get; set; }

        [Column(TypeName = "text")]
        public string ghiChu { get; set; }

        [StringLength(50)]
        public string loaiMonAn { get; set; }
    }
}
