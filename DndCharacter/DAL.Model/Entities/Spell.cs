using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DAL.Model.Entities
{
    [Table("spell")]
    public class Spell
    {
        public Spell()
        {
            CharacterSpells = new HashSet<CharacterSpell>();
        }

        [Column("id_spell")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [InverseProperty("Spell")]
        public virtual ICollection<CharacterSpell> CharacterSpells { get; set; }
    }
}
