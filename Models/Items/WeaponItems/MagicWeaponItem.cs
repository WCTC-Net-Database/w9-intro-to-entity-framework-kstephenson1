using w9_assignment_ksteph.DataTypes;

namespace w9_assignment_ksteph.Models.Items.WeaponItems;

public class MagicWeaponItem : EquippableItem
{
    public override string ItemType { get; set; } = "MagicWeaponItem";

    // WeaponItem is a class that holds weapon item information

    public MagicWeaponItem()
    {
        
    }

    public MagicWeaponItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id, name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {
        
    }

    public override string ToString()
    {
        return $"[[{Durability}/{MaxDurability}]] {Name}";
    }

}
