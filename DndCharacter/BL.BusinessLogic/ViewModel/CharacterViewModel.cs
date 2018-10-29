using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.Collections;

namespace BL.BusinessLogic.ViewModel
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public ClassesCollection Class { get; set; }
        public int Level { get; set; }
        public AligmentCollection Aligment { get; set; }
        public SpellKnowViewModel SpellsKnown { get; set; }
    }
}
