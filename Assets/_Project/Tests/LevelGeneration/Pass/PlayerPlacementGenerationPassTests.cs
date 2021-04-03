using System.Linq;
using NUnit.Framework;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using TheHunt.LevelGeneration.Pass;
using UnityEngine;

namespace Tests.LevelGeneration.Pass
{
    [TestFixture]
    public class PlayerPlacementGenerationPassTests
    {
        private class TestEntity : IEntity
        {
        }
        
        [Test]
        public void ShouldPlaceThePlayerOnAnEdge()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            var generationPass = new PlayerPlacementGenerationPass();

            generationPass.RunPass(gridLevel);
            var rooms = gridLevel.GetRooms();
            var playerRoom = rooms.First(room => room.HasEntityType(typeof(PlayerEntity)));

            Assert.NotNull(playerRoom);
            
            var isOuterRoom = gridLevel.IsRoomOuterRoom(playerRoom.ID);
            
            Assert.IsTrue(isOuterRoom);
        }

        [Test]
        public void ShouldOnlyPlaceOnePlayerEntity()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            var generationPass = new PlayerPlacementGenerationPass();

            generationPass.RunPass(gridLevel);
            var rooms = gridLevel.GetRooms();
            var playerRooms = rooms.Where(room => room.HasEntityType(typeof(PlayerEntity)));

            Assert.AreEqual(1, playerRooms.Count());
        }

        [Test]
        public void ShouldNotPlacePlayerInRoomWithAnotherEntity()
        {
            const int width = 2;
            const int length = 2;
            var level = new GridLevel(width, length);
            var rooms = level.GetRooms();
            var entityRoom = rooms[Random.Range(0, rooms.Length)];
            entityRoom.Entities.Add(new TestEntity());
            var generationPass = new PlayerPlacementGenerationPass();

            generationPass.RunPass(level);

            var playerRoom = rooms.First(r => r.HasEntityType(typeof(PlayerEntity)));
            Assert.AreNotSame(entityRoom, playerRoom);
        }
    }
}