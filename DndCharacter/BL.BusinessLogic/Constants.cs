using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic
{
    public class Constants
    {
        public enum Aligment
        {
            LG = 1,
            NG = 2,
            CG = 3,
            LN = 4,
            TN = 5,
            CN = 6,
            LE = 7,
            NE = 8,
            CE = 9
        }
        public enum EquipmentType
        {
            ArmorShield = 10,
            Weapons = 11,
            AdventureGear = 12,
            EquipmentPacks = 13,
            Tools = 14
        }
        public enum AbilityScore
        {
            Strength = 15,
            Dexterity = 16,
            Wisdom = 17,
            Intelligence = 18,
            Charisma = 19,
            Constitution = 20
        }
        public enum FeatType
        {
            IncreaseAbiScore = 21,
            AdvantageSkill = 22,
            IncreaseInitiative = 23,
            AdvantageSavingThrow = 24,
            IncreaseSpell = 25,
            IncreaseLanguages = 26,
            IncreaseSpeed = 27,
            ProficiencySavingThrow = 28,
            ProficiencySkill = 29,
            ProficiencyTool = 30,
            IncreaseHitPoints = 31,
            IncreaseArmorClass = 32
        }
    }
}
