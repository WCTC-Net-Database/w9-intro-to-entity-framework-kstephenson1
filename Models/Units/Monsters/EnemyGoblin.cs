﻿using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Monsters;

public class EnemyGoblin : Monster
{
    public override string UnitType { get; set; } = "EnemyGoblin";
    public EnemyGoblin()
    {

    }

    public EnemyGoblin(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
