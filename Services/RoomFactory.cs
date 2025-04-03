﻿using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Services.DataHelpers;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph.Services;

public class RoomFactory
{
    private GameContext _db;
    public RoomFactory(GameContext context)
    {
        _db = context;
    }

    public void CreateRoomAndAddToContext()
    {
        Console.Clear();
        Console.WriteLine(
            "-------------------" +
            "    CREATE ROOM    " +
            "-------------------\n");
        string name = Input.GetString("Enter Name for new room:");
        string desc = Input.GetString($"Enter Description for room \"{name}\": ");
        Room room = new(name, desc);
        _db.Rooms.Add(room);
        _db.SaveChanges();
        Console.WriteLine($"Room \"{name}\" with description \"{desc}\" has been added to the game.");
    }
    public Room CreateRoom(string roomType)
    {
        return roomType switch
        {
            "intro.entrance" => new Room("Entrance", "the entryway to a seemingly small dungeon."),
            "intro.armory" => new Room("Armory", "a room with racks on the wall full or weapons, and manequins equipped with various types of armor."),
            "intro.kitchen" => new Room("Kitchen", "a room with a cooking pot used for cooking.  There are various vegetables and meats hanging from the ceiling."),
            "intro.hallway" => new Room("Hallway", "a mostly empty hallway that leads in four diretions."),
            "intro.jail" => new Room("Jail", "a room filled with jail cells.  One of them is locked."),
            "intro.library" => new Room("Library", "a room filled with empty bookshelves.  Goblins are not that big on reading."),
            "intro.dwelling" => new Room("Dwelling", "a small bedroom with a simple bed and a locked chest."),
            "intro.dwelling2" => new Room("Dwelling", "a small bedroom with a makeshift bed, scatted trash, and tattered clothing."),
        };
    }
}