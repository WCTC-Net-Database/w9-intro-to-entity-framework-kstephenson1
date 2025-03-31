using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

namespace w9_assignment_ksteph.Models.Interfaces.UnitClasses;

public interface IArcher : IShootable
{
    // An Archer unit that is able to shoot.
    public void Attack(IEntity target) => Shoot(target);
}
