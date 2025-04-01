using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.Rooms;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class RoomNavigationMenu : InteractiveSelectionMenu<IRoom>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public IRoom Display(IRoom room, string prompt, string exitMessage)
    {
        IRoom selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(room, exitMessage);
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

    public void Update(IRoom room, string exitMessage)
    {
        _menuItems = new();

        //foreach (AdjacentRoom adjacentRoom in room.AdjacentRooms)
        //{
        //    AddMenuItem($"{adjacentRoom.Direction.ToString()}", $"{adjacentRoom.Adjacent.Name}", adjacentRoom.Adjacent);
        //}

        AddMenuItem(exitMessage, "", null!);
    }
}

