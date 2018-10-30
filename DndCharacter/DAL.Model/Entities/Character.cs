using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DAL.Model.Entities
{
    [Table("character")]
    public class Character
    {
        [Column("id_character")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("level")]
        public string Level { get; set; }

        [Column("id_c_aligment")]
        public int IdCAligment { get; set; }

        [Column("id_c_class")]
        public int IdCClass { get; set; }
    }
}
