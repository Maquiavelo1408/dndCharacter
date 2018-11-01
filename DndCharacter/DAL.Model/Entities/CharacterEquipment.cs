using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("character_equipment")]
    public class CharacterEquipment
    {
        [Column("id_character")]
        public int IdCharacter { get; set; }

        [Column("id_equipment")]
        public int IdEquipment { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [InverseProperty("CharacterEquipments"), ForeignKey("IdCharacter")]
        public virtual Character Character { get; set; }

        [InverseProperty("CharacterEquipments"), ForeignKey("IdEquipment")]
        public virtual Equipment Equipment { get; set; }
    }
}
