using Spectre.Console;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph.Models.UI.Character;

public class RoomUI
{
    private GameContext _db;
    // CharacterUI helps display character information in a nice little table.
    public RoomUI(GameContext context)
    {
        _db = context;
    }

    public void DisplayRooms() // Displays the rooms and their info.
    {
        var rooms = _db.Rooms.ToList();

        // Creates a display table that contains all the other tables to create a nice little display.
        Table displayTable = new Table();
        displayTable
            .AddColumn(new TableColumn("Room Name"))
            .AddColumn(new TableColumn("Room Description"));

        foreach (IRoom room in rooms)
        {
            displayTable.AddRow(room.Name, room.Description);
        }

        // Displays the table to the user.
        AnsiConsole.Write(displayTable);
    }
}
