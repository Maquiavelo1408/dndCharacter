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
            FeatFeatures = new HashSet<FeatFeature>();
        }
        [Column("id_feat"), Key]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("prerequisite")]
        public string Prereqisite { get; set; }

        [InverseProperty("Feat")]
        public ICollection<FeatFeature> FeatFeatures { get; set; }

        [InverseProperty("Feat")]
        public ICollection<CharacterFeat> CharacterFeats { get; set; }
    }
}
