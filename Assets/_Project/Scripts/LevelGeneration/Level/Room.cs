using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public bool HasEntityType(Type entityType)
        {
            return Entities.Any(entity => entity.GetType() == entityType);
        }
    }
}