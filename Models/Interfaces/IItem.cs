using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.Models.Interfaces;

public interface IItem
{
    // Interface tha allows items to exist.
    public string Name { get; set; }
    public string Description { get; set; }
    Inventory Inventory { get; set; }
}
