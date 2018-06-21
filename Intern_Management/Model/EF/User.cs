namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Features = new HashSet<Feature>();
            ProjectMembers = new HashSet<ProjectMember>();
        }

        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Passwords { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        public bool? Stat { get; set; }

        public int? RoleID { get; set; }

        [StringLength(200)]
        public string userdes { get; set; }

        [StringLength(50)]
        public string University { get; set; }

        [StringLength(200)]
        public string imagecover { get; set; }

        [StringLength(200)]
        public string imagelogin { get; set; }

        [StringLength(100)]
        public string userAddress { get; set; }

        [StringLength(100)]
        public string specialized { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Features { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }

        public virtual Role Role { get; set; }
    }
}
