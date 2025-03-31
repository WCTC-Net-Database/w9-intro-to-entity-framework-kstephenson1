using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.UnitClasses;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Monsters;

public class EnemyCleric : MonsterBase, ICleric
{
    // An Cleric unit that is able to heal and cast spells.
    public EnemyCleric()
    {

    }

    public EnemyCleric(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stats stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    public HealCommand HealCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public CastCommand CastCommand { get; set; } = null!;

    public void Heal(IUnit target)
    {
        HealCommand = new(this, target);
        Invoker.ExecuteCommand(HealCommand);
    }
    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);

    }
}
