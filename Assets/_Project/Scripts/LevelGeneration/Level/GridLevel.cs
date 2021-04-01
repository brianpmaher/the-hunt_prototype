using System;
using System.Collections.Generic;
using System.Linq;

namespace TheHunt.LevelGeneration.Level
{
    public class GridLevel : ILevel
    {
        private const int WidthDimension = 0;
        private const int LengthDimension = 1;
        private Room[,] _rooms;

        private int RoomsWidth => _rooms.GetLength(WidthDimension);
        private int RoomsLength => _rooms.GetLength(LengthDimension);

        public GridLevel(int width, int length)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            InitializeRooms(width, length);
        }

        public Room[] GetRooms()
        {
            var rooms = new Room[RoomsWidth * RoomsLength];
            
            for (var i = 0; i < RoomsWidth; i++)
            {
                for (var j = 0; j < RoomsLength; j++)
                {
                    rooms[i + j] = _rooms[i, j];
                }
            }

            return rooms;
        }

        public List<Room> GetConnectedRooms(Guid roomId)
        {
            for (var i = 0; i < RoomsWidth; i++)
            {
                for (var j = 0; j < RoomsLength; j++)
                {
                    var room = _rooms[i, j];
                    
                    if (room.ID != roomId) continue;
                    
                    var connectedRooms = GetAllAdjacentRoomsAtCoord(i, j);
                    return connectedRooms;
                }
            }
            
            return new List<Room>();
        }
        
        private void InitializeRooms(int width, int length)
        {
            _rooms = new Room[width, length];
            
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    _rooms[i, j] = new Room();
                }
            }
        }

        private List<Room> GetAllAdjacentRoomsAtCoord(int x, int y)
        {
            var adjacentRooms = new List<Room>();
            
            if (GetNorthRoomFromCoord(x, y, out var northRoom))
            {
                adjacentRooms.Add(northRoom);
            }

            if (GetEastRoomFromCoord(x, y, out var eastRoom))
            {
                adjacentRooms.Add(eastRoom);
            }

            if (GetSouthRoomFromCoord(x, y, out var southRoom))
            {
                adjacentRooms.Add(southRoom);
            }

            if (GetWestRoomFromCoord(x, y, out var westRoom))
            {
                adjacentRooms.Add(westRoom);
            }

            return adjacentRooms;
        }

        private bool GetNorthRoomFromCoord(int x, int y, out Room northRoom)
        {
            if (y + 1 < RoomsLength)
            {
                northRoom = _rooms[x, y + 1];
                return true;
            }

            northRoom = null;
            return false;
        }
        
        private bool GetEastRoomFromCoord(int x, int y, out Room eastRoom)
        {
            if (x + 1 < RoomsWidth)
            {
                eastRoom = _rooms[x + 1, y];
                return true;
            }

            eastRoom = null;
            return false;
        }

        private bool GetSouthRoomFromCoord(int x, int y, out Room southRoom)
        {
            if (y - 1 > 0)
            {
                southRoom = _rooms[x, y - 1];
                return true;
            }

            southRoom = null;
            return false;
        }

        private bool GetWestRoomFromCoord(int x, int y, out Room westRoom)
        {
            if (x - 1 > 0)
            {
                westRoom = _rooms[x - 1, y];
                return true;
            }

            westRoom = null;
            return false;
        }
    }
}