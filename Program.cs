using Microsoft.Extensions.DependencyInjection;
using w9_assignment_ksteph.Data;
using w9_assignment_ksteph.Models.UI;
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
        SeedHandler seedHandler = provider.GetRequiredService<SeedHandler>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        DungeonFactory dungeonFactory = provider.GetRequiredService<DungeonFactory>();

        GameEngine engine = new GameEngine(db, seedHandler, userInterface, dungeonFactory);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */