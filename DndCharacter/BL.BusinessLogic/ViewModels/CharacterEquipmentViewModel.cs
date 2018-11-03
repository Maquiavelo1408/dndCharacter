using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class CharacterEquipmentViewModel
    {
        public int IdCharacter { get; set; }
        public string NameCharacter { get; set; }
        public int IdEquipment { get; set; }
        public string NameEquipment { get; set; }
        public int Quantity { get; set; }
    }
}
