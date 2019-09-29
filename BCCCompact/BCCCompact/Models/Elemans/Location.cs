﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCCCompact.Models
{
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Location(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}