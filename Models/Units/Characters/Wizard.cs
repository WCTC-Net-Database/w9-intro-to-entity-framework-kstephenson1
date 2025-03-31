using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces.UnitClasses;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Characters;

public class Wizard : CharacterBase, IMage
{
    // A Mage unit that is able to cast spells.
    public Wizard()
    {

    }
    public Wizard(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stats stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    public CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
