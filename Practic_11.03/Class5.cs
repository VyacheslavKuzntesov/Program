using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_11._03
{
    abstract class Figure
    {
        public abstract void Draw();
    }

    abstract class Quandranqle : Figure { }

    class Rectangle : Quandranqle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle { Width = s.Length * 2, Height = s.Length };
        }

        public override void Draw()
        {
            for (int i = 0; i < Height; i++, WriteLine())
            {
                for (int j = 0; j < Width; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }

        public override string ToString()
        {
            return $"Rectangle: Width = {Width}," + $"Heigth = {Height}";
        }
    }

    class Square : Quandranqle
    {
        public int Length { get; set; }

        public static explicit operator Square(Rectangle r)
        {
            return new Square { Length = r.Height };
        }

        public static explicit operator int (Square s)
        {
            return s.Length;
        }

        public static implicit operator Square (int number)
        {
            return new Square { Length = number };
        }

        public override void Draw()
        {
            for (int i = 0; i < Length; i++,WriteLine())
            {
                for (int j = 0; j < Length; j++)
                {
                    Write("*");
                }
            }
            WriteLine();
        }

        public override string ToString()
        {
            return $"Square: lenght = {Length}";
        }
    }
}
