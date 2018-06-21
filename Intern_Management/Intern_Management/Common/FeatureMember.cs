using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intern_Management.Common
{
    public class FeatureMember
    {
        public int FeatureID { get; set; }
       public string FeatureName { get; set; }
       public string FeatureOwer { get; set; }
       public string FeatureStatus { get; set; }
       public int FeatureDuration { get; set; }
    }
}