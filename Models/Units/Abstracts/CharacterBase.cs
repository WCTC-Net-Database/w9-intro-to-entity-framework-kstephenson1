namespace w9_assignment_ksteph.Models.Units.Abstracts;
// The character class stores information for each character.
public abstract class CharacterBase : UnitBase
{

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{Stats.HitPoints},{Inventory}";
    }
}
