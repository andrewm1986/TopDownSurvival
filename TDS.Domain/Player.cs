﻿using System;

namespace TDS.Domain
{
    public class Player
    {
        public Guid PlayerID { get; set; }
        public string Username { get; set; }

        public Level Level { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}