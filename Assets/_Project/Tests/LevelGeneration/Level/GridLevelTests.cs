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

        [Test]
        public void ShouldReturnTwoConnectedRoomsForACornerRoom()
        {
            var width = 5;
            var length = 5;

            var gridLevel = new GridLevel(width, length);
            var connectedRooms = gridLevel.GetAllAdjacentRoomsAtCoord(0, 0);

            Assert.AreEqual(2, connectedRooms.Count);
        }

        [Test]
        public void ShouldReturnThreeConnectedRoomsForANonCornerEdgeRoom()
        {
            var width = 5;
            var length = 5;

            var gridLevel = new GridLevel(width, length);
            var connectedRooms = gridLevel.GetAllAdjacentRoomsAtCoord(3, 0);

            Assert.AreEqual(3, connectedRooms.Count);
        }

        [Test]
        public void ShouldReturnFourConnectedRoomsForACentralRoom()
        {
            var width = 5;
            var length = 5;

            var gridLevel = new GridLevel(width, length);
            var connectedRooms = gridLevel.GetAllAdjacentRoomsAtCoord(2, 2);

            Assert.AreEqual(4, connectedRooms.Count);
        }
    }
}