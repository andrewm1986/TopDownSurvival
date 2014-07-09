using System;
using TDS.Domain;

namespace TDS.Logic
{
    public class PlayerMover : IService
    {
        public void MovePlayer(Player player, Direction direction)
        {
            var previousX = player.X;
            var previousY = player.Y;

            switch (direction)
            {
                case Direction.North:
                    player.Y--;
                    break;
                case Direction.NorthEast:
                    player.Y--;
                    player.X++;
                    break;
                case Direction.East:
                    player.X++;
                    break;
                case Direction.SouthEast:
                    player.Y++;
                    player.X++;
                    break;
                case Direction.South:
                    player.Y++;
                    break;
                case Direction.SouthWest:
                    player.Y++;
                    player.X--;
                    break;
                case Direction.West:
                    player.X--;
                    break;
                case Direction.NorthWest:
                    player.Y--;
                    player.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            if (player.X < 0 || player.Y < 0 || player.X >= player.Level.Width || player.Y >= player.Level.Height)
            {
                player.X = previousX;
                player.Y = previousY;

                throw new PlayerCantBeMovedException();
            }
        }
    }
}