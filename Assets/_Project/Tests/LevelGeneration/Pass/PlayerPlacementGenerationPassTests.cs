using System.Linq;
using NUnit.Framework;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;
using TheHunt.LevelGeneration.Pass;

namespace Tests.LevelGeneration.Pass
{
    [TestFixture]
    public class PlayerPlacementGenerationPassTests
    {
        [Test]
        public void ShouldPlaceThePlayerOnAnEdge()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            var generationPass = new PlayerPlacementGenerationPass();

            generationPass.RunPass(gridLevel);
            var rooms = gridLevel.GetRooms();
            Room playerRoom = null;

            foreach (var room in rooms)
            {
                if (room.Entities.Any(entity => entity.GetType() == typeof(PlayerEntity)))
                {
                    playerRoom = room;
                    break;
                }
            }
            
            Assert.NotNull(playerRoom);
            
            var isOuterRoom = gridLevel.IsRoomOuterRoom(playerRoom.ID);
            
            Assert.True(isOuterRoom);
        }
    }
}