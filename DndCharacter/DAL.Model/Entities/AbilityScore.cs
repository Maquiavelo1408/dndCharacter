using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("ability_score")]
    public class AbilityScore
    {
        [Column("id_character")]
        public int IdCharacter { get; set; }

        [Column("id_c_ability_score")]
        public int IdCAbilityScore { get; set; }

        [Column("value")]
        public int Value { get; set; }

        [Column("proficient")]
        public bool Proficient { get; set; }

        [Column("ability_modifier")]
        public int AbilityModifier { get; set; }

        [InverseProperty("AbilityScores"), ForeignKey("IdCAbilityScore")]
        public virtual DataCollection AbilityScoreCollection { get; set; }

        [InverseProperty("AbilityScores"), ForeignKey("IdCharacter")]
        public virtual Character Character { get; set; }
    }
}
