namespace courseWebsite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class coursedbcontect : DbContext
    {
        public coursedbcontect()
            : base("name=coursedbcontect")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<course_lessons> course_lessons { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<traineee> traineees { get; set; }
        public virtual DbSet<traineee_course> traineee_course { get; set; }
        public virtual DbSet<trainer> trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .HasMany(e => e.category1)
                .WithOptional(e => e.category2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<course>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<course>()
                .HasMany(e => e.course_lessons)
                .WithRequired(e => e.course)
                .HasForeignKey(e => e.course_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<course>()
                .HasOptional(e => e.traineee_course)
                .WithRequired(e => e.course);

            modelBuilder.Entity<traineee>()
                .HasMany(e => e.traineee_course)
                .WithRequired(e => e.traineee)
                .HasForeignKey(e => e.trainee_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<trainer>()
                .Property(e => e.email)
                .IsFixedLength();
        }
    }
}
