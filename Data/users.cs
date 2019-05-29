namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appsrc_sebasvelez.users")]
    public partial class users
    {
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string username { get; set; }

        [StringLength(500)]
        public string passwoord { get; set; }

        [StringLength(50)]
        public string rol { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public bool? active { get; set; }
    }
}
