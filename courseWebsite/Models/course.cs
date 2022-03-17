namespace courseWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("course")]
    public partial class course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public course()
        {
            course_lessons = new HashSet<course_lessons>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public DateTime? create_date { get; set; }

        public string description { get; set; }

        [Display(Name="Category")]
        public int category_id { get; set; }
        [Display(Name = "Trainer")]
        public int trainer_id { get; set; }

        public string img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<course_lessons> course_lessons { get; set; }

        public virtual traineee_course traineee_course { get; set; }
    }
}
