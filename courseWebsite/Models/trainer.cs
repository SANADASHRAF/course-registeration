namespace courseWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainer")]
    public partial class trainer
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        public string description { get; set; }

        public string website { get; set; }

        public DateTime? creation_date { get; set; }

        [Required]
        public string password { get; set; }
    }
}
