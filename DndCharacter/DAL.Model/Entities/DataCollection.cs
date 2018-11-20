using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("data_collection")]
    public class DataCollection
    {
        public DataCollection()
        {
            CharactersAligment = new HashSet<Character>();
            AbilityScores = new HashSet<AbilityScore>();
            TypesEquipment = new HashSet<Equipment>();
            FeatFeatures = new HashSet<Feature>();
            AbilitiesScoreSkill = new HashSet<Skill>();
        }
        [Column("id_data_collection")]
        public int Id { get; set; }

        [Column("id_collection")]
        public int IdCollection { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [InverseProperty("DataCollections"), ForeignKey("IdCollection")]
        public virtual Collection Collection { get; set; }

        [InverseProperty("Aligment")]
        public virtual ICollection<Character> CharactersAligment { get; set; }

        [InverseProperty("AbilityScoreCollection")]
        public virtual ICollection<AbilityScore> AbilityScores { get; set; }

        [InverseProperty("TypeEquipment")]
        public virtual ICollection<Equipment> TypesEquipment { get; set; }

        [InverseProperty("TypeFeat")]
        public virtual ICollection<Feature> FeatFeatures { get; set; }

        [InverseProperty("AbilityScoreSkill")]
        public virtual ICollection<Skill> AbilitiesScoreSkill { get; set; }
    }
}
