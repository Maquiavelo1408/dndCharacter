using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("character_skill")]
    public class CharacterSkill
    {
        [Column("id_character")]
        public int IdCharacter { get; set; }

        [Column("id_skill")]
        public int IdSkill { get; set; }

        [Column("value")]
        public int Value { get; set; }

        [Column("proficient")]
        public bool Proficient { get; set; }

        [InverseProperty("CharacterSkills"), ForeignKey("IdSkill")]
        public virtual Skill Skill { get; set; }

        [InverseProperty("CharacterSkills"), ForeignKey("IdCharacter")]
        public virtual Character Character { get; set; }
    }
}
