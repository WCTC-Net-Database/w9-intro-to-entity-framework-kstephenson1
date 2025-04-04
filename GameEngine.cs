using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph;

public class GameEngine
{
    private GameContext _db;
    private DungeonFactory _dungeonFactory;
    private RoomFactory _roomFactory;
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(GameContext db, UnitManager unitManager, UserInterface userInterface, DungeonFactory dungeonFactory, RoomFactory roomFactory)
    {
        _db = db;
        _dungeonFactory = dungeonFactory;
        _roomFactory = roomFactory;
        _unitManager = unitManager;
        _userInterface = userInterface;
    }

    public void StartGameEngine()
    {
        Initialization();
        SeedDb();
        Run();
        End();
    }

    void SeedDb()
    {
        if(!_db.Dungeons.Any())
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
                _db.SaveChanges();
            }
            _db.SaveChanges();
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

            _db.SaveChanges();
        }
        
    }

    public void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        _unitManager.ImportUnits(); //Imports the caracters from the csv or json file.
    }

    public void Run()
    {
        // Shows the main menu.  Allows you to add/edit characters before the game is started.
        _userInterface.MainMenu.Display("[[Start Game]]");

        Dungeon dungeon = _dungeonFactory.CreateDungeon("intro");
        dungeon.EnterDungeon();

        //_combatHandler.StartCombat();
    }

    public void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        _unitManager.ExportUnits();
        _userInterface.ExitMenu.Show();
    }
}
