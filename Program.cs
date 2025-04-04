using Microsoft.Extensions.DependencyInjection;
using w9_assignment_ksteph.FileIO;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Models.UI.Character;
using w9_assignment_ksteph.Models.UI.Menus;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;
using W9_assignment_template;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph;

class Program
{
    static void Main()
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);
        

        ServiceProvider provider = serviceCollection.BuildServiceProvider();

        GameContext db = provider.GetRequiredService<GameContext>();
        UnitManager unitManager = provider.GetRequiredService<UnitManager>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        DungeonFactory dungeonFactory = provider.GetRequiredService<DungeonFactory>();
        RoomFactory roomFactory = provider.GetRequiredService<RoomFactory>();

        GameEngine engine = new GameEngine(db, unitManager, userInterface, dungeonFactory, roomFactory);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */