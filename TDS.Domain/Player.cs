using System;

namespace TDS.Domain
{
    public class Player
    {
        public Guid PlayerID { get; set; }
        public string Username { get; set; }

        public Location Location { get; set; }
    }
}