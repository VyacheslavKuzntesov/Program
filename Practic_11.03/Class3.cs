using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_11._03
{
    internal class Point1
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Point1 p1, Point1 p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point1 p1, Point1 p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(Point1 p1, Point1 p2)
        {
            return Math.Sqrt(p1.X * p1.X * p1.Y * p1.Y) > Math.Sqrt(p2.X * p2.X * p2.Y * p2.Y);
        }

        public static bool operator <(Point1 p1, Point1 p2)
        {
            return Math.Sqrt(p1.X * p1.X * p1.Y * p1.Y) < Math.Sqrt(p2.X * p2.X * p2.Y * p2.Y);
        }
        public override string ToString()
        {
            return $"Point: X = {X}, Y = {Y}";
        }
    }
}
