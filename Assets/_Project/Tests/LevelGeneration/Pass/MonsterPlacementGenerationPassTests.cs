using System.Linq;
using NUnit.Framework;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using TheHunt.LevelGeneration.Pass;
using UnityEngine;

namespace Tests.LevelGeneration.Pass
{
    [TestFixture]
    public class MonsterPlacementGenerationPassTests
    {
        [Test]
        public void ShouldPlaceMonster()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var monsterPlacementGenerationPass = new MonsterPlacementGenerationPass();
            
            monsterPlacementGenerationPass.RunPass(level);

            var hasMonster = level.GetRooms().Any(room => room.HasEntityType(typeof(MonsterEntity)));
            Assert.True(hasMonster);
        }

        [Test]
        public void ShouldNotPlaceMonsterInPlayerRoom()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var rooms = level.GetRooms();
            var monsterPlacementGenerationPass = new MonsterPlacementGenerationPass();
            var playerRoom = rooms[Random.Range(0, rooms.Length)];
            playerRoom.Entities.Add(new PlayerEntity());
            
            monsterPlacementGenerationPass.RunPass(level);
            var monsterRoom = rooms.First(room => room.HasEntityType(typeof(MonsterEntity)));

            Assert.AreNotSame(playerRoom, monsterRoom);
        }

        [Test]
        public void ShouldNotPlaceMonsterInPlayerAdjacentRoom()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var rooms = level.GetRooms();
            var monsterPlacementGenerationPass = new MonsterPlacementGenerationPass();
            var playerRoom = rooms[Random.Range(0, rooms.Length)];
            playerRoom.Entities.Add(new PlayerEntity());
            var playerAdjacentRooms = level.GetConnectedRooms(playerRoom.ID);
            
            monsterPlacementGenerationPass.RunPass(level);
            var monsterRoom = rooms.First(room => room.HasEntityType(typeof(MonsterEntity)));

            foreach (var room in playerAdjacentRooms)
            {
                Assert.AreNotSame(room, monsterRoom);
            }
        }
    }
}