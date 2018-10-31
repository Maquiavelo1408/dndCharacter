using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("character_spell")]
    public class CharacterSpell
    {
        [Column("id_character")]
        public int IdCharacter { get; set; }

        [Column("id_spell")]
        public int IdSpell { get; set; }

        [InverseProperty("CharacterSpells"), ForeignKey("IdCharacter")]
        public virtual Character Character { get; set; }

        [InverseProperty("CharacterSpells"), ForeignKey("IdSpell")]
        public virtual Spell Spell { get; set; }
    }
}
