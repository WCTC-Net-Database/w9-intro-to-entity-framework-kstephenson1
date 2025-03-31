using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Rooms;

namespace w9_assignment_ksteph.Models.Rooms;

public abstract class RoomBase : IRoom
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IUnit>? Units { get; set; } = new();
    public Dictionary<Direction, IRoom> AdjacentRooms { get; set; } = new();

    protected RoomBase(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void OnRoomEnter(IUnit unit)
    {
        Console.WriteLine($"{unit.Name} entered {Description}");
        unit.CurrentRoom.Units.Remove(unit);
        unit.CurrentRoom = this;
        Units.Add(unit);
    }

    public void AddAdjacentRoom(Direction direction, IRoom room)
    {
        AdjacentRooms.Add(direction, room);
        room.AdjacentRooms.Add(GetOppositeDirection(direction), this);
    }

    private Direction GetOppositeDirection(Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.South,
            Direction.East => Direction.West,
            Direction.South => Direction.North,
            Direction.West => Direction.East,
            _ => throw new ArgumentOutOfRangeException($"Direction does not exist: {direction.ToString()}")
        };
    }
}
