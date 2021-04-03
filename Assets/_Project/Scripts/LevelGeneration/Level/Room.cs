using System;
using System.Collections.Generic;
using TheHunt.LevelGeneration.Level.Entity;

namespace TheHunt.LevelGeneration.Level
{
    public class Room
    {
        public Guid ID { get; }
        public List<IEntity> Entities { get; }
        
        public Room()
        {
            ID = Guid.NewGuid();
            Entities = new List<IEntity>();
        }
    }
}