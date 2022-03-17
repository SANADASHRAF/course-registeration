namespace courseWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("traineee")]
    public partial class traineee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public traineee()
        {
            traineee_course = new HashSet<traineee_course>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string password { get; set; }

        [NotMapped]
        [Compare("password")]
        [Required(ErrorMessage = "*")]
        public string Confirm_Password { get; set; }

        public int? is_active { get; set; }

        public DateTime? creation_date { get; set; }

       
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "invalied email")]
        public string email { get; set; }

        public string img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<traineee_course> traineee_course { get; set; }
    }
}
