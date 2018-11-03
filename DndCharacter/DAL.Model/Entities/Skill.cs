using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("skill")]
    public class Skill
    {
        [Column("id_skill"), Key]
        public int IdSkill { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("id_c_ability_score")]
        public int IdCAbilityScore { get; set; }

        [InverseProperty("Skill")]
        public virtual ICollection<CharacterSkill> CharacterSkills { get; set; }

        [InverseProperty("AbilitiesScoreSkill"), ForeignKey("IdCAbilityScore")]
        public virtual DataCollection AbilityScoreSkill { get; set; }
    }
}
