using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class ShootCommand : ICommand
{
    // The ShootCommand takes an attacking unit and a target, checks to see if the unit is able to shoot, then shoots at the target if available,
    // using an Encounter to calculate the damage and hit/crit chances.

    private readonly IUnit _unit;
    private readonly IUnit _target;
    private readonly Encounter _encounter;
    public ShootCommand()
    {
        
    }
    public ShootCommand(IUnit unit, IUnit target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target);
    }

    public void Execute()
    {
        if (_encounter.Unit is IShootable)
        {
            Console.WriteLine($"{_unit.Name} fires at {_target.Name}");

            if (_encounter.IsCrit())
            {
                Console.WriteLine($"{_unit.Name} critically hit {_target.Name} for {_encounter.Damage} damage!");
                _target.Damage(_encounter.Damage);
            }
            else if (_encounter.IsHit())
            {
                Console.WriteLine($"{_unit.Name} hit {_target.Name} for {_encounter.Damage} damage.");
                _target.Damage(_encounter.Damage);
            }
            else
            {
                Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
            }
        }
        else
        {
            Console.WriteLine($"{_encounter.Unit.Name} cannot use the shoot action.");
        }
    }
}
