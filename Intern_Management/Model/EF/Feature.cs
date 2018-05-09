namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feature
    {
        public int FeatureID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(50)]
        public string FeatureName { get; set; }

        public int? UserID { get; set; }

        public int? StatusID { get; set; }

        public virtual Project Project { get; set; }

        public virtual StatusCheck StatusCheck { get; set; }

        public virtual User User { get; set; }
    }
}
