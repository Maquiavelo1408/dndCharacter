using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("equipment")]
    public class Equipment
    {
        public Equipment()
        {
            CharacterEquipments = new HashSet<CharacterEquipment>();
        }
        [Column("id_equipment"), Key]
        public int IdEquipment { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("id_c_type_equipment")]
        public int IdCTypeEquiment { get; set; }

        [Column("cost")]
        public string Cost { get; set; }

        [InverseProperty("Equipment")]
        public virtual ICollection<CharacterEquipment> CharacterEquipments { get; set; }

        [InverseProperty("TypesEquipment"), ForeignKey("IdCTypeEquipment")]
        public virtual DataCollection TypeEquipment { get; set; }
    }
}
