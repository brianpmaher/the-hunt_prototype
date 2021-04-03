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
            var outerRooms = level.GetRooms().ToList().Where(r => level.IsRoomOuterRoom(r.ID)).ToArray();
            var room = outerRooms[Random.Range(0, outerRooms.Length)];
            room.Entities.Add(new PlayerEntity());
            return level;
        }
    }
}