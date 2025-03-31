using Microsoft.Extensions.DependencyInjection;
using w9_assignment_ksteph.FileIO;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Models.UI.Character;
using w9_assignment_ksteph.Models.UI.Menus;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph;

class Program
{
    static void Main()
    {
        ServiceCollection services = new ServiceCollection();

        services.AddTransient<UserInterface>();
        services.AddTransient<CharacterUtilities>();
        services.AddTransient<CharacterUI>();
        services.AddTransient<CombatHandler>();
        services.AddTransient<CommandHandler>();
        services.AddTransient<CommandMenu>();
        services.AddTransient<DungeonFactory>();
        services.AddTransient<ExitMenu>();
        services.AddSingleton<FileManager<UnitBase>>();
        services.AddTransient<InventoryMenu>();
        services.AddTransient<ItemCommandMenu>();
        services.AddTransient<MainMenu>();
        services.AddTransient<RoomFactory>();
        services.AddTransient<RoomNavigationMenu>();
        services.AddSingleton<UnitClassMenu>();
        services.AddSingleton<UnitManager>();
        services.AddTransient<UnitSelectionMenu>();

        ServiceProvider provider = services.BuildServiceProvider();

        UnitManager unitManager = provider.GetRequiredService<UnitManager>();
        UserInterface userInterface = provider.GetRequiredService<UserInterface>();
        DungeonFactory dungeonFactory = provider.GetRequiredService<DungeonFactory>();

        GameEngine engine = new GameEngine(unitManager, userInterface, dungeonFactory);
        engine.StartGameEngine();
    }
}

/*




        
 
 
 
 
 
 
 
 
 
 
 */