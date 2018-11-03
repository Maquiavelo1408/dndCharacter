using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels
{
    public class CharacterSkillViewModel
    {
        public int IdCharacter { get; set; }
        public string NameCharacter { get; set; }
        public int IdSkill { get; set; }
        public string NameSkill { get; set; }
        public int Value { get; set; }
        public bool Proficient { get; set; }
    }
}
