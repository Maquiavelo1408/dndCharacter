using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("feat_feature")]
    public class FeatFeature
    {
        [Column("id_feat_feature"), Key]
        public int Id { get; set; }

        [Column("id_feat")]
        public int IdFeat { get; set; }

        [Column("id_c_type_feat")]
        public int IdCTypeFeat { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("add_amount")]
        public int AddAmount { get; set; }

        [InverseProperty("FeatFeatures"), ForeignKey("IdFeat")]
        public virtual Feat Feat { get; set; }
    }
}
