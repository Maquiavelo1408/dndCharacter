using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("feat")]
    public class Feat
    {
        public Feat()
        {
            FeatFeatures = new HashSet<Feature>();
            CharacterFeats = new HashSet<CharacterFeat>();
        }
        [Column("id_feat"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("prerequisite")]
        public string Prereqisite { get; set; }

        [Column("id_race")]
        public int ? IdRace { get; set; }

        [InverseProperty("Feat")]
        public virtual ICollection<Feature> FeatFeatures { get; set; }

        [InverseProperty("Feat")]
        public virtual ICollection<CharacterFeat> CharacterFeats { get; set; }
    
        [InverseProperty("FeatsRace"), ForeignKey("IdRace")]
        public virtual  Race Race { get; set; }
    }
}
