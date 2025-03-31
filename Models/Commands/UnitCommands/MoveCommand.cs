using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class MoveCommand : ICommand
{
    // The MoveCommand takes in a unit and a position, checks to see if the unit can move, then moves to that position of able.

    private readonly IUnit _unit;
    public MoveCommand(IUnit unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IUnit)
        {
            Console.WriteLine($"{_unit.Name} moves.");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot move!");
        }

    }
}
