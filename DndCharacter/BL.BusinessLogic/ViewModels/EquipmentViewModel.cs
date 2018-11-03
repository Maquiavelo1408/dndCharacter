using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class EquipmentViewModel
    {
        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public int IdCTypeEquiment { get; set; }
        public string ValueTypeEquipment { get; set; }
        public string Cost { get; set; }
    }
}
