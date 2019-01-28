using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public int IdFeat { get; set; }
        public string NameFeat { get; set; }
        public string Description { get; set; }
        public int IdCTypeFeat { get; set; }
        public string ValueTypeFeat { get; set; }
        public int AddedAmount { get; set; }
        public string AddedDescription { get; set; }
    }
}
