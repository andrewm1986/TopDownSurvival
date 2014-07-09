using System;

namespace TDS.Domain.Tiles
{
    public abstract class Tile
    {
        public Guid TileID { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}