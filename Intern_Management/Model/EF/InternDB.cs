namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InternDB : DbContext
    {
        public InternDB()
            : base("name=InternDB")
        {
        }

        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StatusCheck> StatusChecks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Projects)
                .Map(m => m.ToTable("ProjectMember").MapLeftKey("ProjectID").MapRightKey("UserID"));

            modelBuilder.Entity<StatusCheck>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.StatusCheck)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwords)
                .IsUnicode(false);
        }
    }
}
