using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.Invokers;
using w9_assignment_ksteph.Models.Commands.UnitCommands;

namespace w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

public interface ICastable
{
    public Stats Stats { get; set; }
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
