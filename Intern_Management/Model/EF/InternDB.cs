namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InternDB : DbContext
    {
        public InternDB()
            : base("name=InternDB2")
        {
        }

        public virtual DbSet<FeatureGroup> FeatureGroups { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<ImagesFeature> ImagesFeatures { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StatusCheck> StatusChecks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>()
                .Property(e => e.Descrip)
                .IsUnicode(false);

            modelBuilder.Entity<Feature>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectMembers)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusCheck>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.StatusCheck)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwords)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.imagecover)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.imagelogin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ProjectMembers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
