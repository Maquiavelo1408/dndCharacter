using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DAL.Model.Entities
{
    [Table("spell_class")]
    public class SpellClass
    {
        [Column("id_spell")]
        public int IdSpell { get; set; }

        [Column("id_c_class")]
        public int IdCClass { get; set; }
    }
}
