﻿using System;
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
            CharacterFeats = new HashSet<CharacterFeatViewModel>();
            CharacterSkills = new HashSet<CharacterSkillViewModel>();
            CharacterSpells = new HashSet<CharacterSpellViewModel>();
            SpellsKnown = new SpellKnowViewModel();
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
        public int CurrentHitPoints { get; set; }
        public int CopperCoins { get; set; }
        public int SilverCoins { get; set; }
        public int ElectrumCoins { get; set; }
        public int GoldCoins { get; set; }
        public ICollection<CharacterEquipmentViewModel> CharacterEquipments { get; set; }
        public ICollection<CharacterFeatViewModel> CharacterFeats { get; set; }
        public ICollection<CharacterSkillViewModel> CharacterSkills { get; set; }
        public ICollection<CharacterSpellViewModel> CharacterSpells { get; set; }
        public SpellKnowViewModel SpellsKnown { get; set; }
        public SpellsCharacterInfoViewModel SpellsCharacterInfo { get; set; }
    }
    
    public class SpellsCharacterInfoViewModel
    {
        public SpellKnowViewModel SpellKnow { get; set; }
        public int CantripsKnown { get; set; }
        public int Level1Known { get; set; }
        public int Level2Known { get; set; }
        public int Level3Known { get; set; }
        public int Level4Known { get; set; }
        public int Level5Known { get; set; }
        public int Level6Known { get; set; }
        public int Level7Known { get; set; }
        public int Level8Known { get; set; }
        public int Level9Known { get; set; }
        public int TotalSpellKnown { get; set; }

    }

}
