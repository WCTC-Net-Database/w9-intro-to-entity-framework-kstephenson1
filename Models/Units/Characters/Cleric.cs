using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.UnitClasses;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Cleric : CharacterBase, ICleric
{
    // An Cleric unit that is able to heal and cast spells.
    public Cleric()
    {

    }
    public Cleric(string name, string characterClass, int level, Inventory inventory, Position position, Stats stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Position = position;
        Stats = stats;
        Inventory.Unit = this;
    }

    [Ignore]
    [JsonIgnore]
    public HealCommand HealCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public CastCommand CastCommand { get; set; } = null!;

    public void Heal(IEntity target)
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
