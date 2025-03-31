using w9_assignment_ksteph.Models.Commands.ItemCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class ItemCommandMenu : InteractiveSelectionMenu<ICommand>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public ICommand Display(IItem item, string prompt, string exitMessage)
    {
        ICommand selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(item, exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        throw new ArgumentException("Update(item) requires an item.");
    }

    public void Update(IItem item, string exitMessage)
    {
        _menuItems = new();

        AddMenuItem($"Drop Item", $"Get rid of the item forever.", new DropItemCommand(null!, null!));
        AddMenuItem($"Trade Item", $"Gives this item to someone else.", new TradeItemCommand(null!, null!, null!));

        if (item is IConsumableItem consumableItem)
        {
            AddMenuItem($"Use Item", $"{consumableItem.Description}", new UseItemCommand(null!));
        }

        if (item is IEquippableItem weaponItem)
        {
            weaponItem.Inventory.IsEquipped(out IEquippableItem? equippedItem);
            if (weaponItem == equippedItem)
            {
                AddMenuItem($"[dim]Equip Item[/]", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", null!);
            }
            else
            {
                AddMenuItem($"Equip Item", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", new EquipCommand(null!, null!));
            }
        }

        AddMenuItem(exitMessage, "", null!);
    }
}

