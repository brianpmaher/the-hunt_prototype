using System;
using System.Collections.Generic;

namespace TheHunt.LevelGeneration.Level
{
    public interface ILevel
    {
        public Room[] GetRooms();
        public List<Room> GetConnectedRooms(Guid roomId);
        public bool IsRoomOuterRoom(Guid roomId);
    }
}