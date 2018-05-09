namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InternShipDb : DbContext
    {
        public InternShipDb()
            : base("name=InternShipDb")
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

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StatusCheck>()
                .Property(e => e.StatusName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Passwords)
                .IsUnicode(false);
        }
    }
}
