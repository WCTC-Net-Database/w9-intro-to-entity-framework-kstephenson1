using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Commands.Invokers;
using w9_assignment_ksteph.Models.Commands.ItemCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.Models.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    DropItemCommand DropItemCommand { get; set; }
    TradeItemCommand TradeItemCommand { get; set; }
    Inventory Inventory { get; set; }
    void DropItem(IItem item);
    void TradeItem(IItem item, IEntity target);
}
