using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces.InventoryBehaviors;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Models.Rooms;

namespace w9_assignment_ksteph.Models.Interfaces;

public interface IUnit : ITargetable, IAttack, IHaveInventory, IUseItems
{
    // Interface tha allows units to exist.
    MoveCommand MoveCommand { set; get; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    Room? CurrentRoom { get; set; }
    public Stat Stat { get; set; }

    void Move();
    string GetHealthBar();
}
