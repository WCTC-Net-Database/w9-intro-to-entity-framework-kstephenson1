using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Interfaces.Rooms;

public interface IRoom
{
    string Name { get; set; }
    string Description { get; set; }
    List<Unit>? Units { get; set; }
    //List<AdjacentRoom> AdjacentRooms { get; set; }
    void OnRoomEnter(Unit unit);
    void AddAdjacentRoom(Room room, Direction direction);

}
