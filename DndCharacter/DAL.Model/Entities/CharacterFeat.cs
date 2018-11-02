using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("character_feat")]
    public class CharacterFeat
    {
        [Column("id_character")]
        public int IdCharacter { get; set; }

        [Column("id_feat")]
        public int IdFeat { get; set; }

        [InverseProperty("CharacterFeats"), ForeignKey("IdCharacter")]
        public virtual Character Character { get; set; }

        [InverseProperty("CharacterFeats"), ForeignKey("IdFeat")]
        public virtual Feat Feat { get; set; }
    }
}
