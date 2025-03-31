using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class UnitSelectionMenu : InteractiveSelectionMenu<IEntity>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    private readonly UnitManager _unitManager;

    public UnitSelectionMenu(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    public override IEntity Display(string prompt, string exitMessage   )
    {
        IEntity selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        _menuItems = new();

        // Adds all the characters to the unit list using green letters.
        foreach (IEntity unit in _unitManager.Characters.Units)
        {
            // Strikethrough and dim the unit info if the unit is not alive.
            if (unit.Stats.HitPoints <= 0)
            {
                AddMenuItem($"[green][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                AddMenuItem($"[green][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        // Adds all the monsters to the unit list using red letters.
        foreach (IEntity unit in _unitManager.Monsters.Units)
        {
            if (unit.Stats.HitPoints <= 0)
            {
                // Strikethrough and dim the unit info if the unit is not alive.
                AddMenuItem($"[red][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                AddMenuItem($"[red][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        AddMenuItem(exitMessage, $"", null!);
    }
}

