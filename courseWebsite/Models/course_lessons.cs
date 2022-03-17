namespace courseWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class course_lessons
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        public int course_id { get; set; }

        public int? order_num { get; set; }

        public virtual course course { get; set; }
    }
}
