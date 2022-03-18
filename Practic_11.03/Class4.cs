using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_11._03
{
    internal class Point2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator true(Point2 p)
        {
            return p.X != 0 || p.Y != 0 ? true : false;
        }
        public static bool operator false(Point2 p)
        {
            return p.X == 0 && p.Y == 0 ? true : false;
        }
        public static Point2 operator |(Point2 p1,Point2 p2)
        {
            if ((p1.X != 0 || p1.Y != 0) || (p2.X != 0 || p2.Y != 0))return p2;
            return new Point2();
        }
        public static Point2 operator &(Point2 p1, Point2 p2)
        {
            if ((p1.X != 0 && p1.Y != 0) && (p2.X != 0 && p2.Y != 0)) return p2;
            return new Point2();
        }
        public override string ToString()
        {
            return $"Point: X = {X}, Y = {Y}";
        }
    }
}
