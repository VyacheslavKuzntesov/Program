using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    //struct Dimensions
    //{
    //    private double Length;
    //    private double Width;

    //    public Dimensions(double length, double width)
    //    {
    //        Length = length;
    //        Width = width;
    //    }

    //    public void Print()
    //    {
    //        Console.WriteLine($"Длина {Length}, широта {Width}");
    //    }
    //}

    //[модификаторы] class имя_класса
    //{
    //    [модификатор] тип_данных имя_поля
    //    [модификатор] тип_данных имя_метода([параметры])
    //    { 

    //    }
    //}
    /*
    private - даные доступны внутри класса и во вложенных классах

    protected - данные доступны только методам внутри класса и вложенным класса или в его дочерних классах

    internal - данные доступны в методах текущей сборки (по умалчанию)

    protected internal - данные доступны только методам вложенного или производного типа класса и любым методам текущей сборки

    public - данные доступны всем методам во всех сборках

    static - использует для j,]zdktybz сатического поля (принадлежит классу, а не объекту). Является общим всех экземпляров класса

    const

    readonly - поля только для чтения. Присвоение возможно только через конструктор либо при объявлении


    */
    //class Student
    //{
    //    int _studentID;
    //    string _firstName = "Иван";
    //    string _lastName = "Иванов";
    //    string _group;

    //    public void Print()
    //    {
    //        Console.WriteLine($"Студент {_firstName} {_lastName}");
    //    }
    //}

    //class Car
    //{
    //    private string _DriverName;
    //    private int _CurrSpeed;

    //    public Car(string name, int speed)
    //    {
    //        _DriverName = name;
    //        _CurrSpeed = speed;
    //    }

    //    public void Print()
    //    {
    //        Console.WriteLine($"{_DriverName} едет со скоростью {_CurrSpeed} км/ч.");
    //    }

    //    public void SpeedUp(int delta)
    //    {
    //        _CurrSpeed += delta;
    //    }
    //}

    class Bank
    {
        private double _currBalance;
        private static double _bonus;

        public Bank(double balance)
        {
            this._currBalance = balance;
        }
        static Bank()
        {
            _bonus = 1.04;
        }

        public static void SetBonus(double newRate)
        {
            _bonus = newRate;
        }

        public static double GetBonus()
        { return _bonus; }

        public double GetPercents(double summa)
        {
            if ((_currBalance - summa) > 0)
            {
                double percent = summa * _bonus;
                _currBalance -= percent;
                return percent;
            }
            else return -1;
        }
    }

    class Car
    {
        private string _DriverName;
        private int _CurrSpeed;

        public Car(string name, int speed)
        {
            _DriverName = name;
            _CurrSpeed = 10;
        }

        public Car() : this("Без водителя", 0) { }
        public Car(string name) : this(name, 0) { }

        public void SetDriver(string driverName)
        {
            this._DriverName = driverName;
        }

        public void Print()
        {
            Console.WriteLine($"{_DriverName} едет со скоростью {_CurrSpeed} км/ч.");
        }

        public void SpeedUp(int delta)
        {
            _CurrSpeed += delta;
        }
    }

    public class ClassA
    {
        public void MethodA(ClassB obj)
        {
            obj.MethodB(this);
        }
    }
    public class ClassB
    {
        public void MethodB(ClassA obj)
        {
            Console.WriteLine("Работа с классом " + obj.GetType().Name);
        }
    }

    struct MyArray
    {
        public void Array(int[] arr)
        {
            arr = new int[10];
            Console.Write("Изначальный массив:{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(20);
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine("}");
        }

    }

    internal class Program
    {
        //private static void MyFunction(out int i, out int[] myArr)
        //{
        //    Console.WriteLine("Внутри функции MyFunction i = "+i);
        //    Console.Write("MyArr { ");
        //    foreach(int i2 in myArr)
        //        Console.Write(i2+" ");
        //    Console.WriteLine("}");

        //    i = 100;
        //    myArr = new int[] { 3, 2, 1 };

        //    Console.WriteLine("Внутри функции MyFunction после изменения i = " + i);
        //    Console.Write("MyArr после изменения { ");
        //    foreach (int i2 in myArr)
        //        Console.Write(i2 + " ");
        //    Console.WriteLine("}");
        //}

        private static void MyFunction(out int i)
        {
            i = new Random().Next(10);
        }

        private static int Proizvedenie(int min, int max)
        {
            int proiz = 1;
            for (int i = min; i <= max; i++)
                proiz *= i;
            return proiz;
        }

        private static bool Fibona4i(int num)
        {
            bool fib = false;
            for (int i = 0, j = 1, k = 0; i <= num || j <= num; k++)
            {
                if (k% 2 == 0)
                {
                    if (i >= 1 && i <= num) fib = true;
                    i += j;
                }
                else
                {
                    if (j >= 1 && j <= num) fib = true;
                    j += i;
                }
            }
            if (fib)
            {
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        fib = false;
                        break;
                    }
                }
            }
            return fib;
        }

        public static void Arr(out int[]arr)
        {
            Random rand = new Random();
            arr = new int[10];
            Console.Write("Изначальный массив:{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 21);
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine("}");
        }

        private static void Sorted(bool choice)
        {
            int[] myArray;
            Arr(out myArray);

            if (choice)
            {
                Array.Sort(myArray);
                //BoubleSort(myArray);
                Console.Write("Массив после сортировки по возрастанию:{ ");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write(", "+myArray[i]);
                }
                Console.WriteLine("}");
            }
            else
            {
                Array.Sort(myArray);
                Array.Reverse(myArray);
                //ReverseBoubleSort(myArray);
                Console.Write("Массив после сортировки по возрастанию:{ ");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write(", " + myArray[i]);
                }
                Console.WriteLine("}");
            }
        }

        private static int[] ReverseBoubleSort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        private static int[] BoubleSort(int [] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1;j<arr.Length;j++)
                {
                    if(arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        static void Main(string[] args)
        {
            /*
            //1-й способ
            string a = @"It's easy to win
            forgiveness for being wrong;
            being right is what
            gets you into real trouble.

            Bjarne Stroustrup.";
            Console.WriteLine(a);

            //2-й способ
            Console.WriteLine("It\\'s easy to win\nforgiveness for being wrong;\nbeing right is what gets you into real trouble.\nBjarne Stroustrup.");

            //3-й способ
            Console.WriteLine("It\\'s easy to win");
            Console.WriteLine("forgiveness for being wrong;");
            Console.WriteLine("being right is what");
            Console.WriteLine("gets you into real trouble.");
            Console.WriteLine();
            Console.WriteLine("Bjarne Stroustrup.");
            */

            //----------------------------------------------------------------------------

            //int num, summa = 0, max = 0, min = 0, proz = 1;

            //for (int i = 0; i < 5; i++)
            //{
            //    num = Int32.Parse(Console.ReadLine());
            //    if (i == 0) max = min = num;
            //    summa += num;
            //    if (num < min) min = num;
            //    if (num > max) max = num;
            //    proz *= num;
            //}
            //Console.WriteLine(summa);
            //Console.WriteLine(max);
            //Console.WriteLine(min);
            //Console.WriteLine(proz);

            //int a = Int32.Parse(Console.ReadLine());
            //while (a > 0)
            //{
            //    Console.Write(a % 10);
            //    a /= 10;
            //}

            //-----------------------------------------------------------------------------------

            //int min = Int32.Parse(Console.ReadLine());
            //int max = Int32.Parse(Console.ReadLine());

            //uint prev1 = 0;
            //uint prev2 = 1;
            //uint current = 0;

            //for (int i = 2; i < max; ++i)
            //{
            //    if (i == 2 && min == 0)
            //    {
            //        Console.WriteLine(0);
            //        Console.WriteLine(1);
            //    };
            //    if (i == 2 && min == 1)
            //    {
            //        Console.WriteLine(1);
            //    };
            //    current = prev1 + prev2;
            //    prev1 = prev2;
            //    if (current <= max && current >= min)
            //        Console.WriteLine(current);
            //    prev2 = current;
            //}

            //for (int j = 0, k = 1, g = 0; j <= max || k <= max; g++)
            //{
            //    if (g % 2 == 0)
            //    {
            //        if (j >= min && j <= max) Console.WriteLine(j);
            //        j += k;
            //    }
            //    else
            //    {
            //        if (k >= min && k <= max) Console.WriteLine(k);
            //        k += j;
            //    }
            //}

            //-----------------------------------------------------------------------------------
            //                             Масивы                                                
            //-----------------------------------------------------------------------------------

            //int[] arr = { 48,23,16,20,23,15 };
            //int edd = 0, even = 0, unic = 0;

            //foreach (int i in arr)
            //{
            //    if (i % 2 == 0)even++;
            //    else edd++;
            //}
            //foreach (int i in arr)
            //{
            //    if (Array.IndexOf(arr, i) == Array.LastIndexOf(arr, i))
            //        unic++;
            //}
            //Console.WriteLine(even);
            //Console.WriteLine(edd);
            //Console.WriteLine(unic);

            //int[] arr = { 48, 23, 16, 16, 15, 23, 15 };
            //int col = 0, num = 0;
            //num = Int32.Parse(Console.ReadLine());
            //foreach (int i in arr)
            //{
            //    if (i < num)
            //    {
            //        col++;
            //    }
            //}
            //Console.WriteLine(col);


            //-----------------------------------------------------------------------------------
            //                             Структуры                                               
            //-----------------------------------------------------------------------------------

            //double length = 7.34, width = 23.9;
            //Dimensions dimensions = new Dimensions(length, width);
            //dimensions.Print();

            //Student student = new Student();
            //student.Print();

            //Car car = new Car("Fast speedy", 15);
            //for (int i = 0; i < 10; i++)
            //{
            //    car.SpeedUp(3);
            //    car.Print();
            //}

            //Bank b1 = new Bank(1000000);
            //Console.WriteLine($"Текущий бонусный процент: {Bank.GetBonus()}");

            //Console.WriteLine("Ваш депозит на {0:C}, в кассе забрать: {1:C}", 1000, b1.GetPercents(10000));

            //Car car = new Car();
            //for (int i = 0; i < 10; i++)
            //{
            //    car.SpeedUp(5);
            //    car.Print();
            //}

            //ClassA a = new ClassA();
            //ClassB b = new ClassB();

            //a.MethodA(b);

            //int i = 10;
            //int[] myArr = { 1, 2, 3 };
            //Console.WriteLine("Внутри функции Main i = " + i);
            //Console.Write("MyArr { ");
            //foreach (int i2 in myArr)
            //    Console.Write(i2 + " ");
            //Console.WriteLine("}");

            //MyFunction( i, myArr);
            //Console.WriteLine("Внутри функции Main i = " + i);
            //Console.Write("MyArr { ");
            //foreach (int i2 in myArr)
            //    Console.Write(i2 + " ");
            //Console.WriteLine("}");

            //int i;
            //MyFunction(out i);
            //Console.WriteLine("i = " + i);

            //int a = Proizvedenie(5, 7);
            //Console.WriteLine(a);

            //Console.WriteLine(Fibona4i(21));

            Sorted(true);
        }



        ////struct  имя: Интерфейсы
        //{
        //    //объявление данных
        //}
    }
}
