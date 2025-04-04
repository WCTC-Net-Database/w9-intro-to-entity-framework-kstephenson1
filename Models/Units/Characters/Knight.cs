using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Knight : Character
{
    public override string UnitType { get; set; } = "Knight";

    public Knight()
    {

    }

    public Knight(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {
        
    }
}
