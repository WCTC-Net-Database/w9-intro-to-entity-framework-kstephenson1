using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.WeaponItems;

public class WeaponItem : EquippableItem
{
    // WeaponItem is a class that holds weapon item information

    public WeaponItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id, name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {
        
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

}
