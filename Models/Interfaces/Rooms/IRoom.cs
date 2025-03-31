using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces;

namespace w9_assignment_ksteph.Models.Interfaces.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    List<IEntity>? Units { get; set; }
    Dictionary<Direction, IRoom> AdjacentRooms { get; set; }
    void OnRoomEnter(IEntity unit);
    void AddAdjacentRoom(Direction direction, IRoom room);

}
