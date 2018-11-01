using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class AbilityScoreViewModel
    {
        public int IdCharacter { get; set; }
        public int IdCAbilityScore { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
        public int AbilityModifier { get; set; }
    }
}
