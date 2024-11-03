namespace QuanLyQAn.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSBan")]
    public partial class DSBan
    {
        [Key]
        public int idBan { get; set; }

        [Required]
        [StringLength(100)]
        public string tenBan { get; set; }

        [StringLength(50)]
        public string trangThai { get; set; }
    }
}
