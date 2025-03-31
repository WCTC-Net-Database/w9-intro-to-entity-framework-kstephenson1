using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items.ConsumableItems;

public class ItemBook : Item, IConsumableItem
{
    public int MaxUses { get; set; } = 10;
    public int UsesLeft { get; set; }
    public ItemBook()
    {
        ID = "book";
        Name = StringHelper.ToItemNameFormat(ID);
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
}
