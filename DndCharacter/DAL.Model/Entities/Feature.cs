using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("feature")]
    public class Feature
    {
        [Column("id_feat_feature"), Key]
        public int Id { get; set; }

        [Column("id_feat")]
        public int IdFeat { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("id_c_type_feat")]
        public int IdCTypeFeat { get; set; }

        [Column("added_amount")]
        public int AddedAmount { get; set; }

        [Column("added_description")]
        public string AddedDescription { get; set; }

        [InverseProperty("FeatFeatures"), ForeignKey("IdFeat")]
        public virtual Feat Feat { get; set; }

        [InverseProperty("FeatFeatures"), ForeignKey("IdCTypeFeat")]
        public virtual DataCollection TypeFeat { get; set; }
    }
}
