using System;

namespace TheHunt.LevelGeneration
{
    public class Room
    {
        public Guid ID { get; }

        public Room()
        {
            ID = Guid.NewGuid();
        }
    }
}