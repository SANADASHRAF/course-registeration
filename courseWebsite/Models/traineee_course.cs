namespace courseWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class traineee_course
    {
        public int trainee_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int course_id { get; set; }

        public DateTime register_date { get; set; }

        public virtual course course { get; set; }

        public virtual traineee traineee { get; set; }
    }
}
