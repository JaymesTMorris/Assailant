using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SkillLoadout
    {
        public Skill SlotOne { get; set; }
        public Skill SlotTwo { get; set; }
        public Skill SlotThree { get; set; }

        public List<Skill> SkillList
        {
            get
            {
                return new List<Skill> { SlotOne, SlotTwo, SlotThree };
            }
        }
    }
}
