using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.ConsumableItems;

public class ItemLockpick : Item, IConsumableItem
{
    public int MaxUses { get; set; } = 3;
    public int UsesLeft { get; set; }
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
}
