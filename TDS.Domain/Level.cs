using System;
using System.Collections.Generic;
using TDS.Domain.Tiles;

namespace TDS.Domain
{
    public class Level
    {
        public Guid LevelID { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public ICollection<Tile> Tiles { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public Level()
        {
            Tiles = new HashSet<Tile>();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Level) obj);
        }

        protected bool Equals(Level other)
        {
            return LevelID.Equals(other.LevelID) && string.Equals(Name, other.Name) && Height == other.Height && Width == other.Width;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = LevelID.GetHashCode();
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Height;
                hashCode = (hashCode*397) ^ Width;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}