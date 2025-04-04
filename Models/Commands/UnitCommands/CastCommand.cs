using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

namespace w9_assignment_ksteph.Models.Commands.UnitCommands;

public class CastCommand : ICommand
{
    // The CastCommand takes in a casting unit and a spell name.  If the unit is a caster, it will cast the spell.

    private readonly IUnit _unit;
    private readonly string _spellName;
    public CastCommand()
    {
        
    }
    public CastCommand(IUnit unit, string spellName)
    {
        _unit = unit;
        _spellName = spellName;
    }
    public void Execute()
    {
        if (_unit is ICastable)
        {
            Console.WriteLine($"{_unit.Name} casts {_spellName}");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} is not a spellcaster!");
        }
    }
}
