﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Weapon:Equipment
    {
        public WeaponType Type { get; set; }
        public Skill BasicAttack { get; set; }
    }
}