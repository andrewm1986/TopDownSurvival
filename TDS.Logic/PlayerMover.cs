using System;
using TDS.Domain;

namespace TDS.Logic
{
    public class PlayerMover : IService
    {
        public void MovePlayer(Player player, Direction direction)
        {
            var previousX = player.Location.X;
            var previousY = player.Location.Y;

            switch (direction)
            {
                case Direction.North:
                    player.Location.Y--;
                    break;
                case Direction.NorthEast:
                    player.Location.Y--;
                    player.Location.X++;
                    break;
                case Direction.East:
                    player.Location.X++;
                    break;
                case Direction.SouthEast:
                    player.Location.Y++;
                    player.Location.X++;
                    break;
                case Direction.South:
                    player.Location.Y++;
                    break;
                case Direction.SouthWest:
                    player.Location.Y++;
                    player.Location.X--;
                    break;
                case Direction.West:
                    player.Location.X--;
                    break;
                case Direction.NorthWest:
                    player.Location.Y--;
                    player.Location.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            if (player.Location.X < 0 || player.Location.Y < 0 || player.Location.X >= player.Location.Level.Width || player.Location.Y >= player.Location.Level.Height)
            {
                player.Location.X = previousX;
                player.Location.Y = previousY;

                throw new PlayerCantBeMovedException();
            }
        }
    }
}