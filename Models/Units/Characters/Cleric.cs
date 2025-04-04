using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.UnitClasses;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Cleric : Character, ICleric
{
    public override string UnitType { get; set; } = "Cleric";

    public Cleric()
    {

    }
    public Cleric(string name, string characterClass, int level, Inventory inventory, Stat stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Stat = stats;
        Inventory.Unit = this;
    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual HealCommand HealCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

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
