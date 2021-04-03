using System.Linq;
using NUnit.Framework;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using TheHunt.LevelGeneration.Pass;
using UnityEngine;

namespace Tests.LevelGeneration.Pass
{
    [TestFixture]
    public class PitTrapPlacementGenerationPassTests
    {
        class TestEntity : IEntity
        {
        }
        
        [Test]
        public void ShouldPlacePitTrap()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var pitTrapPlacementGenerationPass = new PitTrapPlacementGenerationPass();

            pitTrapPlacementGenerationPass.RunPass(level);

            var hasPitTrap = level.GetRooms().Any(room => room.HasEntityType(typeof(PitTrapEntity)));
            Assert.True(hasPitTrap);
        }

        [Test]
        public void ShouldNotPlacePitTrapInRoomWithAnotherEntity()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var rooms = level.GetRooms();
            var entityRoom = rooms[Random.Range(0, rooms.Length)];
            entityRoom.Entities.Add(new TestEntity());
            var pitTrapPlacementGenerationPass = new PitTrapPlacementGenerationPass();

            pitTrapPlacementGenerationPass.RunPass(level);

            var pitTrapRoom = level.GetRooms().First(room => room.HasEntityType(typeof(PitTrapEntity)));
            Assert.AreNotSame(entityRoom, pitTrapRoom);
        }

        [Test]
        public void ShouldNotPlacePitTrapInRoomAdjacentToPlayerRoom()
        {
            const int width = 5;
            const int length = 5;
            var level = new GridLevel(width, length);
            var rooms = level.GetRooms();
            var playerRoom = rooms[Random.Range(0, rooms.Length)];
            playerRoom.Entities.Add(new PlayerEntity());
            var pitTrapPlacementGenerationPass = new PitTrapPlacementGenerationPass();

            pitTrapPlacementGenerationPass.RunPass(level);

            var playerAdjacentRooms = level.GetConnectedRooms(playerRoom.ID);
            var pitTrapRoom = level.GetRooms().First(room => room.HasEntityType(typeof(PitTrapEntity)));
            foreach (var playerAdjacentRoom in playerAdjacentRooms)
            {
                Assert.AreNotSame(playerAdjacentRoom, pitTrapRoom);
            }
        }
    }
}