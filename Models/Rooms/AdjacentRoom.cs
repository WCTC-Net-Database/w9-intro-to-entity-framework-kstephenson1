
using System.ComponentModel.DataAnnotations;
using w9_assignment_ksteph.DataTypes;

namespace w9_assignment_ksteph.Models.Rooms;

public class AdjacentRoom
{
    [Key]
    public Room Room { get; set; }

    [Key]
    public Direction Direction { get; set; }

    public AdjacentRoom()
    {
        
    }

    public AdjacentRoom(Room room, Direction direction)
    {
        Room = room;
        Direction = direction;
    }
}
