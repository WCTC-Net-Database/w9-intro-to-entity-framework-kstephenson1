using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.Models.Units.Abstracts;

public abstract class MonsterBase : UnitBase
{
    // The Monster class is, for the most part, an abstract(ish) class that might contain some computer intelligence functions one day.
    public MonsterBase() { }

    public MonsterBase(string name, string characterClass, int level, int hitPoints, Inventory inventory, Position position, Stats stats)
    {

    }
}
