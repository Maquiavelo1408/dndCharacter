using System;
using System.Collections.Generic;
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

        [Column("id_feat")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("prerequisite")]
        public string Prerequisite { get; set; }

        [InverseProperty("Feat")]
        public virtual ICollection<FeatFeature> FeatFeatures { get; set; }
    }
}
