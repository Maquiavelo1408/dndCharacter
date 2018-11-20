using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class FeatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Prereqisite { get; set; }
        public int? IdRace { get; set; }
        public string NameRace { get; set; }
        public ICollection<FeatureViewModel> FeatFeatures { get; set; }
    }
}
