using System.Linq;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using UnityEngine;

namespace TheHunt.LevelGeneration.Pass
{
    public class PitTrapPlacementGenerationPass : IGenerationPass
    {
        public ILevel RunPass(ILevel level)
        {
            var rooms = level.GetRooms();
            var playerRoom = level.GetRooms().FirstOrDefault(room => room.HasEntityType(typeof(PlayerEntity)));
            var potentialPitTrapRooms = 
               rooms 
                   .Where(room => room != playerRoom)
                   .Where(room => room.Entities.Count == 0)
                   .Where(room => !level.GetConnectedRooms(room.ID).Contains(playerRoom))
                   .ToArray();

            var pitTrapRoom = potentialPitTrapRooms[Random.Range(0, potentialPitTrapRooms.Length)];
            var pitTrapEntity = new PitTrapEntity();
            pitTrapRoom.Entities.Add(pitTrapEntity);
            
            return level;
        }
    }
}