using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Models.Items;

public class Item : IItem
{
    // Item is a class that holds item information.
    public int ItemId { get; set; }
    [JsonIgnore]
    public Inventory Inventory { get; set; }
    public int InventoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Item() { }

    public Item(string id)
    {
        Name = StringHelper.ToItemNameFormat(id);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public Item(string id, string name)
    {
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

}
