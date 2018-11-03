using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class AbilityScoreViewModel
    {
        public int IdCharacter { get; set; }
        public string NameCharacter { get; set; }
        public int IdCAbilityScore { get; set; }
        public string ValueAbilityScore { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public int AbilityModifier { get; set; }
    }
}
