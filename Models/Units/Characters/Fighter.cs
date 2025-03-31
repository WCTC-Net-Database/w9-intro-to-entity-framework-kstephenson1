using System.Text.Json.Serialization;
using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Fighter : CharacterBase
{
    public Fighter()
    {

    }
    public Fighter(string name, string characterClass, int level, Inventory inventory, Position position, Stats stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Position = position;
        Stats = stats;
        Inventory.Unit = this;
    }
}
