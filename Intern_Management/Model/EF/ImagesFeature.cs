namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImagesFeature")]
    public partial class ImagesFeature
    {
        public int ImagesFeatureID { get; set; }

        public int? featureID { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? addDate { get; set; }

        public bool? isCover { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
