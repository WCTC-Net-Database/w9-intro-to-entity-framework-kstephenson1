using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class FlyCommand : ICommand
{
    // FlyCommand takes in a unit and a position, checks to see if the unit is able to fly, then flies to the position if able.

    private readonly IEntity _unit;
    private Position _position;
    public FlyCommand(IEntity unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IFlyable)
        {
            int x = Input.GetInt("Enter target location's x-coordinate: ");
            int z = Input.GetInt("Enter target location's z-coordinate: ");
            _position = new(x, z);

            Console.WriteLine($"{_unit.Name} flies from {_unit.Position} to {_position}");
            _unit.Position = _position;
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot fly and remains on {_unit.Position}");
        }
    }
}
