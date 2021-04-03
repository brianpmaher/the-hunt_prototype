using System.Linq;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using UnityEngine;

namespace TheHunt.LevelGeneration.Pass
{
    public class MonsterPlacementGenerationPass : IGenerationPass
    {
        public ILevel RunPass(ILevel level)
        {
            var rooms = level.GetRooms();
            var playerRoom = rooms.FirstOrDefault(room => room.HasEntityType(typeof(PlayerEntity)));
            var potentialMonsterRooms =
                rooms
                    .Where(room => room != playerRoom)
                    .Where(room => !level.GetConnectedRooms(room.ID).Contains(playerRoom))
                    .ToArray();

            var monsterRoom = potentialMonsterRooms[Random.Range(0, potentialMonsterRooms.Length)];
            var monsterEntity = new MonsterEntity();
            monsterRoom.Entities.Add(monsterEntity);

            return level;
        }
    }
}