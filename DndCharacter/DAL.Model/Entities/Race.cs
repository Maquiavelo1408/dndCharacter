using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace DAL.Model.Entities
{
    [Table("race")]
    public class Race
    {
        public Race()
        {
            CharacterRace = new HashSet<Character>();
            FeatsRace = new HashSet<Feat>();
        }

        [Column("id_race")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public string Age { get; set; }

        [Column("size")]
        public string Size { get; set; }

        [InverseProperty("Race")]
        public virtual ICollection<Character> CharacterRace { get; set; }

        [InverseProperty("Race")]
        public virtual ICollection<Feat> FeatsRace { get; set; }
    }
}
