using System;

namespace TheHunt.LevelGeneration
{
    public class GridLevel : ILevel
    {
        private int _width;
        private int _length;
    
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

            _width = width;
            _length = length;
        }

        public IRoom[] GetRooms()
        {
            return new IRoom[] { };
        }

        public IRoomConnection[][] GetConnections()
        {
            return new IRoomConnection[][] { };
        }
    }
}