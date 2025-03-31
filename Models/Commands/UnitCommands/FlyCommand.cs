using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class FlyCommand : ICommand
{
    // FlyCommand takes in a unit and a position, checks to see if the unit is able to fly, then flies to the position if able.

    private readonly IUnit _unit;
    public FlyCommand(IUnit unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IFlyable)
        {
            Console.WriteLine($"{_unit.Name} flies.");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot fly.");
        }
    }
}
