using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Inventories;
public class Inventory
{
    // The Inventory class holds a list of items.
    [JsonIgnore]
    public IEntity? Unit;
    public List<IItem>? Items { get; set; } = new();

    public Inventory()
    {
        //SetParentsInItems();
    }
    public Inventory(List<IItem> items)
    {
        Items = items;
        //SetParentsInItems();
    }

    public bool AddItem(IItem item)
    {
        if (Items!.Count < 5)
        {
            SetParentsInItem(item);
            Items!.Add(item);
            return true;
        }
        return false;
    }

    public bool RemoveItem(IItem item)
    {
        try
        {
            Items!.Remove(item);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool IsFull()
    {
        return Items!.Count >= 5;
    }

    public bool IsEquipped(out IEquippableItem? weapon)
    {
        foreach(IItem item in Items!)
        {
            if (item is IEquippableItem)
            {
                weapon = (IEquippableItem)item;
                return true;
            }
        }
        weapon = null;
        return false;
    }

    public bool SetEquippedItem(IEquippableItem item)
    {
        IsEquipped(out IEquippableItem? weapon);
        if (weapon != null && weapon != item)
        {
            Items!.Remove(item);
            Items.Insert(0, item);
            return true;
        }
        return false;
    }
    public bool DamageEquippedItem()
    {
        if (IsEquipped(out IEquippableItem? weapon))
        {
            if (weapon is IEquippableItem)
            {
                weapon!.TakeDurabilityDamage(1);
                return true;
            }
            
            return true;
        }
        else
            return false;
    }

    public List<IConsumableItem> GetConsumableItems()
    {
        List<IConsumableItem> consumableItems = new();
        foreach (IItem item in Items!)
        {
            if (item is IConsumableItem)
            {
                consumableItems.Add((IConsumableItem)item);
            }
        }

        return consumableItems;
    }

    private void SetParentsInItem(IItem item)
    {
        item.Inventory = this;
    }

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
