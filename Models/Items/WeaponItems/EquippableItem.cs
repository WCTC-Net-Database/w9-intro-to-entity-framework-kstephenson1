using System.Text.Json.Serialization;
using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.WeaponItems;

public class EquippableItem : Item, IEquippableItem
{
    // Item is a class that holds item information.

    [JsonConverter(typeof(JsonStringEnumConverter<WeaponType>))]
    public WeaponType WeaponType { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter<WeaponRank>))]
    public WeaponRank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Might { get; set; }
    public int Hit { get; set; }
    public int Crit { get; set; }
    public int Range { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }

    public EquippableItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id)
    {
        MaxDurability = maxDurability; WeaponType = weaponType; Name = name;
        RequiredRank = requiredRank; Weight = weight; Crit = crit;
        Durability = maxDurability; Range = range; Hit = hit;
        ExpModifier = expModifier; Might = might;
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

    public void Equip()
    {
        bool wasEquipped = Inventory.SetEquippedItem(this);
        if (wasEquipped)
        {
            Console.WriteLine($"{Inventory.Unit!.Name} equipped {Name}");
        }
        else
        {
            Console.WriteLine($"{Inventory.Unit!.Name} already has {Name} equipped!");
        }
    }

    public void TakeDurabilityDamage(int durabilityDamage)
    {
        throw new NotImplementedException();
    }

    public void BreakItem()
    {
        throw new NotImplementedException();
    }
}
