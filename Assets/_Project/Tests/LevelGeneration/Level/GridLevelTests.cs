using System;
using NUnit.Framework;
using TheHunt.LevelGeneration.Level;

namespace Tests.LevelGeneration.Level
{
    [TestFixture]
    public class GridLevelTests
    {
        [Test]
        public void ShouldThrowAnErrorIfWidthIsNegative()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new GridLevel(-1, 1));
        }
        
        [Test]
        public void ShouldThrowAnErrorIfLengthIsNegative()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new GridLevel(1, -1));
        }

        [Test]
        public void ShouldGenerateANumberOfRooms()
        {
            var width = 4;
            var length = 6;
            
            var gridLevel = new GridLevel(width, length);
            var rooms = gridLevel.GetRooms();
            
            Assert.AreEqual(width * length, rooms.Length);
        }
    }
}