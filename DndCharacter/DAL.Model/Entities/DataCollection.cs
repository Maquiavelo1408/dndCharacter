using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("data_collection")]
    public class DataCollection
    {
        [Column("id_data_collection")]
        public int Id { get; set; }

        [Column("id_collection")]
        public int IdCollection { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [InverseProperty("DataCollections"), ForeignKey("IdCollection")]
        public virtual Collection Collection { get; set; }

        [InverseProperty("Aligment")]
        public virtual ICollection<Character> CharactersAligment { get; set; }
    }
}
