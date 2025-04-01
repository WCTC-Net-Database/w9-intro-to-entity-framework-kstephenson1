using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph;

public class GameEngine
{
    private GameContext _db;
    private DungeonFactory _dungeonFactory;
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(GameContext db, UnitManager unitManager, UserInterface userInterface, DungeonFactory dungeonFactory)
    {
        _db = db;
        _dungeonFactory = dungeonFactory;
        _unitManager = unitManager;
        _userInterface = userInterface;
    }

    public void StartGameEngine()
    {
        Initialization();
        Test();
        Run();
        End();
    }

    void Test()
    {                                    //
        Dungeon dungeon = new Dungeon();
        dungeon.Name = "Intro Dungeon";
        dungeon.Description = "The first dungeon in the game";
        RoomFactory factory = new();
        Room entrance = factory.CreateRoom("intro.entrance");
        Room jail = factory.CreateRoom("intro.jail");
        Room kitchen = factory.CreateRoom("intro.kitchen");
        Room hallway = factory.CreateRoom("intro.hallway");
        Room library = factory.CreateRoom("intro.entrance");
        Room dwelling = factory.CreateRoom("intro.dwelling");
        Room dwelling2 = factory.CreateRoom("intro.dwelling2");
        entrance.AddAdjacentRoom(jail, Direction.West);
        entrance.AddAdjacentRoom(kitchen, Direction.East);
        entrance.AddAdjacentRoom(hallway, Direction.North);
        hallway.AddAdjacentRoom(dwelling2, Direction.West);
        hallway.AddAdjacentRoom(library, Direction.East);
        hallway.AddAdjacentRoom(dwelling, Direction.North);

        dungeon.StartingRoom = entrance;

 

        //_db.SaveChanges();
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
