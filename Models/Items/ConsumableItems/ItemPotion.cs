﻿using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.ConsumableItems;

public class ItemPotion : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemPotion";
    public override int MaxUses { get; set; } = 3;

    public ItemPotion()
    {
        string oldId = "potion";
        Name = StringHelper.ToItemNameFormat(oldId);
        Description = "Use to restore 10 hp.";
        UsesLeft = MaxUses;
    }

    public ItemPotion(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        if (Inventory.Unit!.Stat.HitPoints >= Inventory.Unit.Stat.MaxHitPoints)
        {
            Console.WriteLine($"{Inventory.Unit.Name} is already at max health.");
        }
        else
        {
            int preItemHP = Inventory.Unit.Stat.HitPoints;
            Inventory.Unit.Heal(10);
            int postItemHP = Inventory.Unit.Stat.MaxHitPoints;
            int healedHP = postItemHP - preItemHP;
            Console.WriteLine($"{Inventory.Unit.Name} used {Name} and gained {healedHP} hit points");
            UsesLeft--;

            if (UsesLeft == 0)
            {
                Inventory.RemoveItem(this);
            }
        }
    }

    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
