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
            const int width = 4;
            const int length = 6;
            
            var gridLevel = new GridLevel(width, length);
            var rooms = gridLevel.GetRooms();
            
            Assert.AreEqual(width * length, rooms.Length);
        }

        [Test]
        public void ShouldReturnTwoConnectedRoomsForACornerRoom()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            
            var connectedRooms = gridLevel.GetConnectedRooms(0, 0);

            Assert.AreEqual(2, connectedRooms.Count);
        }

        [Test]
        public void ShouldReturnThreeConnectedRoomsForANonCornerEdgeRoom()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            
            var connectedRooms = gridLevel.GetConnectedRooms(3, 0);

            Assert.AreEqual(3, connectedRooms.Count);
        }

        [Test]
        public void ShouldReturnFourConnectedRoomsForACentralRoom()
        {
            const int width = 5;
            const int length = 5;
            var gridLevel = new GridLevel(width, length);
            
            var connectedRooms = gridLevel.GetConnectedRooms(2, 2);

            Assert.AreEqual(4, connectedRooms.Count);
        }

        [Test]
        public void ShouldReturnTheRoomsCoordinateWhenCallingGetRoomCoordinate()
        {
            const int width = 5;
            const int length = 10;
            var gridLevel = new GridLevel(width, length);
            var room = gridLevel.GetRoom(3, 6);
            
            var coordinate = gridLevel.GetRoomCoordinate(room.ID);
            
            Assert.AreEqual(new int[] {3, 6}, coordinate);
        }

        [Test]
        public void ShouldReturnTheRoomAtTheGivenCoordinate()
        {
            const int width = 3;
            const int length = 3;
            var gridLevel = new GridLevel(width, length);
            var rooms = gridLevel.GetRooms();
            var lastRoom = rooms[rooms.Length - 1];

            var room = gridLevel.GetRoom(2, 2);
            
            Assert.AreEqual(lastRoom, room);
        }
    }
}