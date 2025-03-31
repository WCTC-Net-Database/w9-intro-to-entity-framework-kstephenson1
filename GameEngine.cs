using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph;

public class GameEngine
{
    private DungeonFactory _dungeonFactory;
    private UnitManager _unitManager;
    private UserInterface _userInterface;

    public GameEngine(UnitManager unitManager, UserInterface userInterface, DungeonFactory dungeonFactory)
    {
        _dungeonFactory = dungeonFactory;
        _unitManager = unitManager;
        _userInterface = userInterface;
    }

    public void StartGameEngine()
    {
        Initialization();
        Run();
        Test();
        End();
    }

    void Test()
    {

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
