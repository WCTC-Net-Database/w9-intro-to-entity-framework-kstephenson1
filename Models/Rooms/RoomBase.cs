using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Rooms;

public abstract class RoomBase : IRoom
{
    public int RoomId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UnitBase>? Units { get; set; } = new();
    public List<AdjacentRoom> AdjacentRooms { get; set; } = new();

    protected RoomBase(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void OnRoomEnter(UnitBase unit)
    {
        Console.WriteLine($"{unit.Name} entered {Description}");
        unit.CurrentRoom.Units.Remove(unit);
        unit.CurrentRoom = this as Room;
        Units.Add(unit);
    }

    public void AddAdjacentRoom(Room room, Direction direction)
    {
        AdjacentRooms.Add(new(room, direction));
        room.AdjacentRooms.Add(new(this as Room, GetOppositeDirection(direction)));
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
