namespace TDS.Domain
{
    public class Location
    {
        public Level Level { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Level != null ? Level.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ X;
                hashCode = (hashCode*397) ^ Y;
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Location) obj);
        }

        protected bool Equals(Location other)
        {
            return Equals(Level, other.Level) && X == other.X && Y == other.Y;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1},{2})", Level, X, Y);
        }
    }
}