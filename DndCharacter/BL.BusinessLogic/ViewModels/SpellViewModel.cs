using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.Collections;

namespace BL.BusinessLogic.ViewModel
{
    public class SpellViewModel
    {
        public SpellViewModel()
        {
            Class = new HashSet<ClassesCollection>();
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<ClassesCollection> Class { get; set; }
        public string Description { get; set; }
    }
    public class SpellKnowViewModel {
        public SpellKnowViewModel()
        {
            SpellsLevel1 = new HashSet<SpellViewModel>();
            SpellsLevel2 = new HashSet<SpellViewModel>();
            SpellsLevel3 = new HashSet<SpellViewModel>();
            SpellsLevel4 = new HashSet<SpellViewModel>();
            SpellsLevel5 = new HashSet<SpellViewModel>();
            SpellsLevel6 = new HashSet<SpellViewModel>();
            SpellsLevel7 = new HashSet<SpellViewModel>();
            SpellsLevel8 = new HashSet<SpellViewModel>();
            SpellsLevel9 = new HashSet<SpellViewModel>();
            Cantrips = new HashSet<SpellViewModel>();
        }
        public ICollection<SpellViewModel> SpellsLevel1 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel2 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel3 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel4 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel5 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel6 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel7 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel8 { get; set; }
        public ICollection<SpellViewModel> SpellsLevel9 { get; set; }
        public ICollection<SpellViewModel> Cantrips { get; set; }

    }
}
