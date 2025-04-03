using System.Reflection;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class LevelUpMenu : InteractiveSelectionMenu<int>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    private readonly UnitManager _unitManager;

    public LevelUpMenu(UnitManager unitManager)
    {
        _unitManager = unitManager;
    }

    public override int Display(string prompt, string exitMessage)
    {
        int selection = default!;
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

        AddMenuItem($"-1", $"Decreases level by 1", -1);
        AddMenuItem($"+1", $"Increases level by 1", 1);

        AddMenuItem(exitMessage, $"", 0);
    }
}

