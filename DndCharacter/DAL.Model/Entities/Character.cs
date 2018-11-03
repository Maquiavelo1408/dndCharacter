using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DAL.Model.Entities
{
    [Table("character")]
    public class Character
    {
        public Character()
        {
            CharacterSpells = new HashSet<CharacterSpell>();
            AbilityScores = new HashSet<AbilityScore>();
            CharacterEquipments = new HashSet<CharacterEquipment>();
            CharacterFeats = new HashSet<CharacterFeat>();
        }

        [Column("id_character")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("level")]
        public string Level { get; set; }

        [Column("id_c_aligment")]
        public int IdCAligment { get; set; }

        [Column("id_class")]
        public int IdClass { get; set; }

        [Column("player_name")]
        public string PlayerName { get; set; }

        [Column("id_race")]
        public int IdRace { get; set; }

        [Column("experience_points")]
        public int ExperiencePoints { get; set; }

        [Column("proficiency_bonus")]
        public int ProficiencyBonus { get; set; }

        [Column("armor_class")]
        public int ArmorClass { get; set; }

        [Column("initiative")]
        public int Initiative { get; set; }

        [Column("speed")]
        public int Speed { get; set; }

        [Column("max_hit_points")]
        public int MaxHitPoints { get; set; }

        [Column("copper_coins")]
        public int CopperCoins { get; set; }

        [Column("silver_coins")]
        public int SilverCoins { get; set; }

        [Column("electrum_coins")]
        public int ElectrumCoins { get; set; }

        [Column("gold_coins")]
        public int GoldCoins { get; set; }

        [InverseProperty("CharactersAligment"), ForeignKey("IdCAligment")]
        public virtual DataCollection Aligment { get; set; }

        [InverseProperty("Character")]
        public virtual ICollection<CharacterSpell> CharacterSpells { get; set; }

        [InverseProperty("CharacterClasses"), ForeignKey("IdClass")]
        public virtual Class Class { get; set; }

        [InverseProperty("Character")]
        public virtual ICollection<AbilityScore> AbilityScores { get; set; }

        [InverseProperty("Character")]
        public virtual ICollection<CharacterSkill> CharacterSkills { get; set; }

        [InverseProperty("Character")]
        public virtual ICollection<CharacterEquipment> CharacterEquipments { get; set; }

        [InverseProperty("Character")]
        public virtual ICollection<CharacterFeat> CharacterFeats { get; set; }
    }
}
