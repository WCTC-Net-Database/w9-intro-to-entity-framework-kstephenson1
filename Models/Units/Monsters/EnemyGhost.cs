using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Units.Monsters;

public class EnemyGhost : MonsterBase, IFlyable
{
    // A Ghost unit that is able fly.
    public EnemyGhost()
    {

    }

    public EnemyGhost(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stats stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    public FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly()
    {
        FlyCommand = new(this);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move() => Fly();

}
