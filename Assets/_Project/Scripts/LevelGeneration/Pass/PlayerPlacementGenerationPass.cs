using System.Linq;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using UnityEngine;

namespace TheHunt.LevelGeneration.Pass
{
    public class PlayerPlacementGenerationPass : IGenerationPass
    {
        public ILevel RunPass(ILevel level)
        {
            var potentialPlayerRooms = 
                level.GetRooms()
                    .Where(r => r.Entities.Count == 0)
                    .Where(r => level.IsRoomOuterRoom(r.ID)).ToArray();
            
            var playerRoom = potentialPlayerRooms[Random.Range(0, potentialPlayerRooms.Length)];
            playerRoom.Entities.Add(new PlayerEntity());
            
            return level;
        }
    }
}