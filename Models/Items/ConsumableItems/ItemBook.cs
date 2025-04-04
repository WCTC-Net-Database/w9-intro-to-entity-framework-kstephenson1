using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.ConsumableItems;

public class ItemBook : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemBook";
    public override int MaxUses { get; set ; } = 10;
    public ItemBook()
    {
        string oldId = "book";
        Name = StringHelper.ToItemNameFormat(oldId);
        Description = "Use to read book.";
        UsesLeft = MaxUses;
    }

    public ItemBook(string id, string name) : base(id, name)
    {
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        Console.WriteLine($"You read the book. Isn't there a battle going on right now!?");
    }

    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
