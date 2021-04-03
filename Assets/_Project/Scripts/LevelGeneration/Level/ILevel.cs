using System;
using System.Collections.Generic;
using TheHunt.LevelGeneration.Level;

namespace TheHunt.LevelGeneration
{
    public interface ILevel
    {
        public Room[] GetRooms();
        public List<Room> GetConnectedRooms(Guid roomId);
        public bool IsRoomOuterRoom(Guid roomId);
    }
}