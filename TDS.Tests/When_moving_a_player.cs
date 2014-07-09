using System;
using NUnit.Framework;
using TDS.Domain;
using TDS.Logic;

namespace TDS.Tests
{
    [TestFixture]
    public class When_moving_a_player
    {
        [TestCase(Direction.North, 1, 0)]
        [TestCase(Direction.NorthEast, 2, 0)]
        [TestCase(Direction.East, 2, 1)]
        [TestCase(Direction.SouthEast, 2, 2)]
        [TestCase(Direction.South, 1, 2)]
        [TestCase(Direction.SouthWest, 0, 2)]
        [TestCase(Direction.West, 0, 1)]
        [TestCase(Direction.NorthWest, 0, 0)]
        public void They_actually_move(Direction direction, int newX, int newY)
        {
            // Arrange
            Player player = CreatePlayer();

            // Act
            MovePlayer(player, direction);

            // Assert
            Assert.That(player.X, Is.EqualTo(newX));
            Assert.That(player.Y, Is.EqualTo(newY));
        }

        [TestCase(Direction.North, 0, 0, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.NorthEast, 99, 0, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.East, 99, 0, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.SouthEast, 99, 99, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.South, 99, 99, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.SouthWest, 0, 99, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.West, 0, 0, ExpectedException = typeof(PlayerCantBeMovedException))]
        [TestCase(Direction.NorthWest, 0, 0, ExpectedException = typeof(PlayerCantBeMovedException))]
        public void They_cant_go_outside_the_boundaries(Direction direction, int startX, int startY)
        {
            // Arrange
            Player player = CreatePlayer(startX, startY);

            // Act
            MovePlayer(player, direction);

            // Assert
            Assert.Fail("We shouldn't get here, exception should be thrown");
        }

        private static void MovePlayer(Player player, Direction direction)
        {
            var playerMover = new PlayerMover();
            playerMover.MovePlayer(player, direction);
        }

        private static Player CreatePlayer(int startX = 1, int startY = 1)
        {
            var player = new Player
            {
                PlayerID = Guid.NewGuid(),
                Username = "TestUser",
                X = startX,
                Y = startY,
                Level = new Level
                {
                    LevelID = Guid.NewGuid(),
                    Name = "Overworld",
                    Height = 99,
                    Width = 99
                }
            };

            return player;
        }
    }
}