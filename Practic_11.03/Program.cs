using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_11._03
{
    /*
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator ++(Point a)
        {
            a.X++;
            a.Y++;
            return a;
        }

        public static Point operator --(Point a)
        {
            a.X--;
            a.Y--;
            return a;
        }
        public static Point operator -(Point a)
        {
            return new Point { X = -a.X, Y = -a.Y };
        }

        public override string ToString()
        {
            return $"Point: X = {X}, Y = {Y}";
        }
    }*/


    internal class Program
    {
        static void Main(string[] args)
        {

#if class1
            Point point1 = new Point { X = 2, Y = 3 };
            Point point2 = new Point { X = 4, Y = 5 };

            Vector vector1 = new Vector(point1, point2);
            Vector vector2 = new Vector { X = 2, Y = 3 };

            WriteLine($"Вектора\n{vector1}\n{vector2}");

            WriteLine($"Сложение векторов: {vector1 + vector2}");
            WriteLine($"Разность векторов: {vector1 - vector2}");

            int n = int.Parse(Console.ReadLine());

            WriteLine($"Умножение вектора на число {n}: {vector1 * n}"); 
#endif

#if class2
            Class1 class1 = new Class1 { X = 10, Y = 10 };
            Class1 class2 = class1;
            Class1 class3 = new Class1 { X = 10, Y = 10 };

            WriteLine($"ReferenceEquals(class1,class2) = " + $"{ReferenceEquals(class1, class2)}");
            WriteLine($"ReferenceEquals(class1,class3) = " + $"{ReferenceEquals(class1, class3)}");

            Class2 class4 = new Class2 { X = 10, Y = 10 };
            Class2 class5 = new Class2 { X = 10, Y = 10 };

            WriteLine($"ReferenceEquals(class4,class4) = " + $"{ReferenceEquals(class4, class4)}");
            WriteLine($"Equals(class1,class3) = " + $"{Equals(class1, class3)}");
            WriteLine($"Equals(class4,class5) = " + $"{Equals(class4, class5)}"); 
#endif

#if class3
            Point1 point1 = new Point1 { X = 10, Y = 10 };
            Point1 point2 = new Point1 { X = 20, Y = 20 };

            WriteLine($"Point1: {point1}");
            WriteLine($"Point2: {point2}");

            WriteLine($"point1 == point2: {point1 == point2}");
            WriteLine($"point1 != point2: {point1 != point2}");

            WriteLine($"point1 > point2: {point1 > point2}");
            WriteLine($"point1 < point2: {point1 < point2}"); 
#endif

#if class4
            Point2 point1 = new Point2 { X = 10, Y = 10 };
            if (point1)
            {
                Console.WriteLine("Точка не в начале координат");
            }
            else
            {
                Console.WriteLine("Точка в начале координат");
            }

            Point2 point2 = new Point2 { X = 0, Y = 0 };
            WriteLine($"point1: {point1}\npoint2: {point2}");

            Write("point1 && point2: ");
            if (point1 && point2)
                WriteLine("true");
            else
                WriteLine("false");

            Write("point1 || point2: ");
            if (point1 || point2)
                WriteLine("true");
            else
                Write("false"); 
#endif

            Rectangle rect = new Rectangle { Height = 10, Width = 5};

            Square square = new Square { Length = 7 };

            Rectangle rectSquare = square;

            WriteLine($"Неявное преобразование(implicit) квадрата ({square})" + $" к прямоугольнику.\n{rectSquare}");
            rectSquare.Draw();

            Square squareRect = (Square)rect;
            WriteLine($"Явное преобразование(explicit) прямоугольника ({rect})" + $" к квадрату.\n{squareRect}");
            squareRect.Draw();

            int number = 12;
            Square squareInt = number;
            WriteLine($"Неявное преобразование числа {number} к квадрату.\n" + $"{squareInt}");
            squareInt.Draw();

            number = (int)square;
            WriteLine($"Явное преобразование квадрата {square} к числу\n" + $"{number}");


        }
    }
}
