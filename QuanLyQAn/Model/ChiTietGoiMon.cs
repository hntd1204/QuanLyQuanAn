namespace QuanLyQAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGoiMon")]
    public partial class ChiTietGoiMon
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string tenMonDaChon { get; set; }

        public int soLuong { get; set; }

        public decimal giaMon { get; set; }
    }
}
