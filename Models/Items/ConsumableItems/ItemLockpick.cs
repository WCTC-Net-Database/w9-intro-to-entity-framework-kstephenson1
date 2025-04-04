using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.ConsumableItems;

public class ItemLockpick : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemLockpick";
    public override int MaxUses { get; set; } = 5;

    public ItemLockpick()
    {
        string oldId = "lockpick";
        Name = StringHelper.ToItemNameFormat(oldId);
        Description = "Use to unlock a nearby door or chest.";
        UsesLeft = MaxUses;
    }

    public ItemLockpick(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        Console.WriteLine($"{Inventory.Unit!.Name} unlocked something!");
        UsesLeft--;

        if (UsesLeft == 0)
        {
            Console.WriteLine($"The lockpick broke!");
            Inventory.RemoveItem(this);
        }
    }
    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
