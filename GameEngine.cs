using w9_assignment_ksteph.Data;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Services;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph;

public class GameEngine
{
    private GameContext _db;
    private SeedHandler _seedHandler;
    private DungeonFactory _dungeonFactory;
    private UserInterface _userInterface;

    public GameEngine(GameContext db, SeedHandler seedHandler, UserInterface userInterface, DungeonFactory dungeonFactory)
    {
        _db = db;
        _seedHandler = seedHandler;
        _dungeonFactory = dungeonFactory;
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
    {
        
        
    }

    public void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        //_unitManager.ImportUnits(); //Imports the caracters from the csv or json file.
        _seedHandler.SeedFromJson();
    }

    public void Run()
    {
        // Shows the main menu.  Allows you to add/edit characters before the game is started.
        _userInterface.MainMenu.Display("[[Exit]]");

        //Dungeon dungeon = _dungeonFactory.CreateDungeon("intro");
        //dungeon.EnterDungeon();

        //_combatHandler.StartCombat();
    }

    public void End()
    {
        // Exports the character list back to the chosen file format and ends the program.
        _userInterface.ExitMenu.Show();
    }
}
