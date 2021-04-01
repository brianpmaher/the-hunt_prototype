using System;
using System.Collections.Generic;

namespace TheHunt.LevelGeneration
{
    public interface ILevel
    {
        public Room[] GetRooms();
        public List<Room> GetConnectedRooms(Guid roomId);
    }
}