using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

namespace w9_assignment_ksteph.Services;

public class DungeonFactory
{
    private readonly RoomFactory _roomFactory;
    private RoomNavigationMenu _roomNavigationMenu;

    public DungeonFactory(RoomFactory roomFactory, RoomNavigationMenu roomNavigationMenu)
    {
        _roomFactory = roomFactory;
        _roomNavigationMenu = roomNavigationMenu;
    }
    public Dungeon CreateDungeon(string dungeonName)
    {
        switch (dungeonName)
        {
            case "intro":
                Dungeon dungeon = new Dungeon(_roomNavigationMenu);
                IRoom entrance = _roomFactory.CreateRoom("intro.entrance");
                IRoom jail = _roomFactory.CreateRoom("intro.jail");
                IRoom kitchen = _roomFactory.CreateRoom("intro.kitchen");
                IRoom hallway = _roomFactory.CreateRoom("intro.hallway");
                IRoom library = _roomFactory.CreateRoom("intro.entrance");
                IRoom dwelling = _roomFactory.CreateRoom("intro.dwelling");
                IRoom dwelling2 = _roomFactory.CreateRoom("intro.dwelling2");
                entrance.AddAdjacentRoom(Direction.West, jail);
                entrance.AddAdjacentRoom(Direction.East, kitchen);
                entrance.AddAdjacentRoom(Direction.North, hallway);
                hallway.AddAdjacentRoom(Direction.West, dwelling2);
                hallway.AddAdjacentRoom(Direction.East, library);
                hallway.AddAdjacentRoom(Direction.North, dwelling);

                dungeon.StartingRoom = entrance;
                return dungeon;
            default:
                throw new ArgumentOutOfRangeException($"DungeonFactory tried to create dungeon and it does not exist: {dungeonName}");
        }
    }
}
