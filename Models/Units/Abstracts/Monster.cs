using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.Models.Units.Abstracts;

public class Monster : Unit
{
    // The Monster class is, for the most part, an abstract(ish) class that might contain some computer intelligence functions one day.
    public Monster() { }

    public Monster(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
