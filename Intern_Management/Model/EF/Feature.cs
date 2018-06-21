namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feature()
        {
            ImagesFeatures = new HashSet<ImagesFeature>();
        }

        public int FeatureID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(50)]
        public string FeatureName { get; set; }

        public int? UserID { get; set; }

        public int? StatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        [Column(TypeName = "text")]
        public string Descrip { get; set; }

        public int? featureGroupID { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        public virtual FeatureGroup FeatureGroup { get; set; }

        public virtual Project Project { get; set; }

        public virtual StatusCheck StatusCheck { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagesFeature> ImagesFeatures { get; set; }
    }
}
