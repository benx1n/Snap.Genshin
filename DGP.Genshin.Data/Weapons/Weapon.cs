﻿using DGP.Genshin.Data.Materials.Monsters;

namespace DGP.Genshin.Data.Weapons
{
    public class Weapon : Primitive
    {
        public string Type { get; set; }
        public string ATK { get; set; }
        public string SubStat { get; set; }
        public string SubStatValue { get; set; }
        public Materials.Weapons.Weapon Ascension { get; set; }
        public Elite Elite { get; set; }
        public Monster Monster { get; set; }
    }
}
