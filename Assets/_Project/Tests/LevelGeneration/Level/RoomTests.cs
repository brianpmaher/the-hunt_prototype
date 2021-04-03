using NUnit.Framework;
using TheHunt.LevelGeneration.Level;
using TheHunt.LevelGeneration.Level.Entity;

namespace Tests.LevelGeneration.Level
{
    [TestFixture]
    public class RoomTests
    {
        class TestEntity : IEntity
        {
        }
        
        [Test]
        public void HasEntityTypeShouldReturnFalseWhenThereAreNoEntities()
        {
            var testEntity = new TestEntity();
            var room = new Room();
            room.Entities.Add(testEntity);

            var hasEntityType = room.HasEntityType(typeof(TestEntity));
            
            Assert.IsTrue(hasEntityType);
        }
    }
}