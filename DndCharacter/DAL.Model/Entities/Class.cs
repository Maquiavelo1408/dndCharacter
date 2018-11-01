using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("class")]
    public class Class
    {
        public Class()
        {
            CharacterClasses = new HashSet<Character>();
        }

        [Column("id_class")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<Character> CharacterClasses { get; set; }

    }
}
