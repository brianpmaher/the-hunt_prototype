using System;
using System.Collections.Generic;

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
            
            for (var x = 0; x < RoomsWidth; x++)
            {
                for (var y = 0; y < RoomsLength; y++)
                {
                    rooms[RoomsWidth * x + y] = _rooms[x, y];
                }
            }

            return rooms;
        }
        
        public List<Room> GetConnectedRooms(int x, int y)
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

        public List<Room> GetConnectedRooms(Guid roomId)
        {
            for (var x = 0; x < RoomsWidth; x++)
            {
                for (var y = 0; y < RoomsLength; y++)
                {
                    var room = _rooms[x, y];
                    
                    if (room.ID != roomId) continue;
                    
                    var connectedRooms = GetConnectedRooms(x, y);
                    return connectedRooms;
                }
            }
            
            return new List<Room>();
        }

        public int[] GetRoomCoordinate(Guid roomId)
        {
            for (var x = 0; x < RoomsWidth; x++)
            {
                for (var y = 0; y < RoomsLength; y++)
                {
                    var room = _rooms[x, y];
                    
                    if (room.ID != roomId) continue;

                    return new[] {x, y};
                }
            }

            throw new RoomNotFoundException(roomId);
        }

        public Room GetRoom(int x, int y)
        {
            return _rooms[x, y];
        }

        public bool IsRoomOuterRoom(Guid roomId)
        {
            return GetConnectedRooms(roomId).Count < 4;
        }
        
        private void InitializeRooms(int width, int length)
        {
            _rooms = new Room[width, length];
            
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < length; y++)
                {
                    _rooms[x, y] = new Room();
                }
            }
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

    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException(Guid id) 
            : base("The room with ID " + id + " could not be found in the level.")
        {
        }
    }
}