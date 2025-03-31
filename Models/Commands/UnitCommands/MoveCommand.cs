using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class MoveCommand : ICommand
{
    // The MoveCommand takes in a unit and a position, checks to see if the unit can move, then moves to that position of able.

    private readonly IUnit _unit;
    private Position _position;
    public MoveCommand(IUnit unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IUnit)
        {
            int x = Input.GetInt("Enter target location's x-coordinate: ");
            int z = Input.GetInt("Enter target location's z-coordinate: ");
            _position = new(x, z);

            Console.WriteLine($"{_unit.Name} moves from {_unit.Position} to {_position}");
            _unit.Position = _position;
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot move!");
        }

    }
}
