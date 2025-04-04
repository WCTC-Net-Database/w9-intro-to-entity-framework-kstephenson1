using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces.UnitClasses;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Wizard : Character, IMage
{
    public override string UnitType { get; set; } = "Wizard";

    public Wizard()
    {

    }
    public Wizard(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
