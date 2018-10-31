﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("skill")]
    public class Skill
    {
        [Column("id_skill")]
        public int IdSkill { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("id_c_ability_score")]
        public int IdCAbilityScore { get; set; }

        [InverseProperty("Skill")]
        public virtual ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}