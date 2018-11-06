using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.Collections;
using BL.BusinessLogic.ViewModels;

namespace BL.BusinessLogic.ViewModel
{
    public class CharacterViewModel
    {
        public CharacterViewModel()
        {
            CharacterEquipments = new HashSet<CharacterEquipmentViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int IdCAligment { get; set; }
        public string ValueAligment { get; set; }
        public int IdClass { get; set; }
        public string PlayerName { get; set; }
        public int IdRace { get; set; }
        public int ExperiencePoints { get; set; }
        public int ProficiencyBonus { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MaxHitPoints { get; set; }
        public int CopperCoins { get; set; }
        public int SilverCoins { get; set; }
        public int ElectrumCoins { get; set; }
        public int GoldCoins { get; set; }
        public ICollection<CharacterEquipmentViewModel> CharacterEquipments { get; set; }
    }
}
