using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("collection")]
    public class Collection
    {
        public Collection()
        {
            DataCollections = new HashSet<DataCollection>();
        }
        [Column("id_collection")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Collection")]
        public virtual ICollection<DataCollection> DataCollections { get; set; }
    }
}
