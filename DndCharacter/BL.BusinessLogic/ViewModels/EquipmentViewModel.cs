using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class EquipmentViewModel
    {
        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public int IdCTypeEquipment { get; set; }
        public string ValueTypeEquipment { get; set; }
        public string Cost { get; set; }
    }

    public class EquipmentByTypeViewModel
    {
        public EquipmentByTypeViewModel()
        {
            ArmorShield = new HashSet<EquipmentViewModel>();
            Weapons = new HashSet<EquipmentViewModel>();
            AdventureGear = new HashSet<EquipmentViewModel>();
            Tools = new HashSet<EquipmentViewModel>();
        }
        public ICollection<EquipmentViewModel> ArmorShield { get; set; }
        public ICollection<EquipmentViewModel> Weapons { get; set; }
        public ICollection<EquipmentViewModel> AdventureGear { get; set; }
        public ICollection<EquipmentViewModel> Tools { get; set; }
    }
}
