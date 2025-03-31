using w9_assignment_ksteph.Models.Commands.ItemCommands;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.InventoryBehaviors;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class CommandMenu : InteractiveSelectionMenu<ICommand>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    private readonly UnitManager _unitManager;

    public CommandMenu(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public ICommand Display(IEntity unit, string prompt, string exitMessage)
    {
        ICommand selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(unit, exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        throw new ArgumentException("Update(unit) requires a unit.");
    }

    public void Update(IEntity unit, string exitMessage)
    {
        _menuItems = new();

        AddMenuItem("Move", "Moves the unit.", new MoveCommand(null!));

        if (unit is IHaveInventory)
        {
            if (unit.Inventory.Items!.Count != 0)
                AddMenuItem("Items", "Uses an item in this unit's inventory.", new UseItemCommand(null!));
            else
                AddMenuItem("[dim]Items[/]", "[dim]Uses an item in this unit's inventory.[/]", new UseItemCommand(null!));
        }

        if (unit is IAttack)
            AddMenuItem("Attack", "Attacks a target unit.", new AttackCommand(null!, null!));

        if (unit is IHeal)
            AddMenuItem("Heal", "Heals a target unit.", new HealCommand(null!, null!));

        if (unit is IHeal || unit is ICastable)
            AddMenuItem("Cast", "Casts a spell.", new CastCommand(null!, "null"));

        AddMenuItem(exitMessage, "", null!);
    }
}

