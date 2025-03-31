using w9_assignment_ksteph.Models.Commands.Invokers;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;

namespace w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

public interface IHeal
{
    // Interface tha allows units to heal.
    CommandInvoker Invoker { set; get; }
    HealCommand HealCommand { set; get; }

    void Heal(IEntity target);
}
