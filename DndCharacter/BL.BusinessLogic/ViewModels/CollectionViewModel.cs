using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class CollectionViewModel
    {
        public CollectionViewModel()
        {
            DataCollections = new HashSet<DataCollectionViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DataCollectionViewModel> DataCollections { get; set; }
    }
}
