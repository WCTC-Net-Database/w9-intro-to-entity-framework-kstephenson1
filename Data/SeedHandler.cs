using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph.Data;

public class SeedHandler
{
    private GameContext _db;
    private RoomFactory _roomFactory;
    private UnitManager _unitManager;
    public SeedHandler(GameContext context, RoomFactory roomFactory, UnitManager unitManager)
    {
        _db = context;
        _roomFactory = roomFactory;
        _unitManager = unitManager;
    }
    public void SeedFromJson()
    {
        _unitManager.ImportUnits();
        if (!_db.Dungeons.Any())
        {
            Dungeon dungeon = new Dungeon();
            dungeon.Name = "Intro Dungeon";
            dungeon.Description = "The first dungeon in the game";
            Room entrance = _roomFactory.CreateRoom("intro.entrance");
            Room jail = _roomFactory.CreateRoom("intro.jail");
            Room kitchen = _roomFactory.CreateRoom("intro.kitchen");
            Room hallway = _roomFactory.CreateRoom("intro.hallway");
            Room library = _roomFactory.CreateRoom("intro.entrance");
            Room dwelling = _roomFactory.CreateRoom("intro.dwelling");
            Room dwelling2 = _roomFactory.CreateRoom("intro.dwelling2");
            entrance.AddAdjacentRoom(jail, Direction.West);
            entrance.AddAdjacentRoom(kitchen, Direction.East);
            entrance.AddAdjacentRoom(hallway, Direction.North);
            hallway.AddAdjacentRoom(dwelling2, Direction.West);
            hallway.AddAdjacentRoom(library, Direction.East);
            hallway.AddAdjacentRoom(dwelling, Direction.North);
            List<Room> rooms = new();
            rooms.AddRange<Room>(entrance, jail, kitchen, hallway, library, dwelling, dwelling2);

            dungeon.StartingRoom = entrance;

            _db.Dungeons.Add(dungeon);

            foreach (Room room in rooms)
            {
                _db.Rooms.Add(room);
            }
        }

        if (!_db.Units.Any())
        {
            foreach (Character unit in _unitManager.Characters.Units)
            {
                _db.Units.Add(unit);
                _db.Stats.Add(unit.Stat);
                _db.Inventories.Add(unit.Inventory);
                foreach (Item item in unit.Inventory.Items)
                {
                    _db.Items.Add(item);
                }
            }
            foreach (Monster unit in _unitManager.Monsters.Units)
            {
                _db.Units.Add(unit);
                _db.Stats.Add(unit.Stat);
                _db.Inventories.Add(unit.Inventory);
                foreach (Item item in unit.Inventory.Items)
                {
                    _db.Items.Add(item);
                }
            }

        }
        _db.SaveChanges();
    }
}
