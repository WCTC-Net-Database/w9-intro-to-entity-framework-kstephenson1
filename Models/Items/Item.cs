using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items;

public abstract class Item : IItem
{
    // Item is a class that holds item information.
    public int ItemId { get; set; }
    [JsonIgnore]

    public abstract string ItemType { get; set; }
    public virtual Inventory Inventory { get; set; }
    public int InventoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Item() { }

    public Item(string name)
    {
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public Item(string name, string desc)
    {
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(desc);
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

}
