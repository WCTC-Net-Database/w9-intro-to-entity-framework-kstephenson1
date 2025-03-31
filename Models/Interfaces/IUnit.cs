using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces.InventoryBehaviors;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

namespace w9_assignment_ksteph.Models.Interfaces;

public interface IUnit : ITargetable, IAttack, IHaveInventory, IUseItems
{
    // Interface tha allows units to exist.
    MoveCommand MoveCommand { set; get; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    IRoom? CurrentRoom { get; set; }
    Position Position { get; set; }
    public Stats Stats { get; set; }

    void Move();
    string GetHealthBar();
}
