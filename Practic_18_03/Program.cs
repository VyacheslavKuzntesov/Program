using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_18_03
{
    sealed class OperationTimer : IDisposable
    {
        long _startTime;
        string _text;
        int _CollectionCount;

        public OperationTimer(string text)
        {
            PrepareForOperation();
            _text = text;
            _CollectionCount = GC.CollectionCount(0);
            _startTime = Stopwatch.GetTimestamp();
        }

        public void Dispose()
        {
            WriteLine($"{_text}\t{(Stopwatch.GetTimestamp() - _startTime) / (double)Stopwatch.Frequency:0.00} секуны сборка мусора {GC.CollectionCount(0) - _CollectionCount}");
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

#if GenericClass
    class GenericClass<T>
    {
        public void M1(T obj)
        {
            WriteLine($"Параметр {obj}");
        }

        public virtual void M2(T obj)
        {
            WriteLine($"Generic {obj}");
        }
    }

    class InheritClass : GenericClass<int>
    {
        public override void M2(int obj)
        {
            WriteLine($"Inherit {obj}");
        }
    } 
#endif

#if BasicClass
    class BasicClass
    {
        protected int age;
    }

    class GenericClasss<T> : BasicClass
    {
        public void M1(int obj)
        {
            age = 46;
            WriteLine($"Basic {age}");
        }
    } 
#endif

    class A<T>
    {
        public class Inner { }
    }

    class B<T>
    {
        public class Inner<U> { }
    }

    interface ICalc<T>
    {
        T Sum(T b);
    }

    internal class Program
    {

        private static void ValueTypePerfTest()
        {
            const int COUNT = 10000000;

            using (new OperationTimer("List"))
            {
                List<int> list = new List<int> { COUNT };
                for (int n = 0; n < COUNT; n++)
                {
                    list.Add(n);
                    int x = list[n];
                }
                list = null;
            }

            using (new OperationTimer("ArrayList"))
            {
                ArrayList array = new ArrayList();
                for (int n = 0; n < COUNT; n++)
                {
                    array.Add(n);
                    int x = (int)array[n];
                }
                array = null;
            }
        }

        static T MaxElement<T>(T[] arr) where T: IComparable<T>
        {
            T max = arr[0];
            foreach (T t in arr)
            {
                if(t.CompareTo(max) > 0)
                    max = t;
            }
            return max;
        }

        class CalcInt:ICalc<CalcInt>
        {
            int _number = 0;

            public CalcInt(int n)
            {
                _number = n;
            }

            public CalcInt Sum (CalcInt b)
            {
                return new CalcInt(_number + b._number);
            }

            public override string ToString()
            {
                return _number.ToString();
            }
        }

        class MyList<T> where T : ICalc<T>
        {
            List<T> list = new List<T>();

            public void Add(T t)
            {
                list.Add(t);
            }

            public T Sum()
            {
                if (list.Count == 0)
                    return default(T);

                T result = list[0];

                for (int i = 1; i < list.Count; i++)
                    result = result.Sum(list[i]);

                return result;
            }


        }

        static void Main(string[] args)
        {

            /*
            CollectionBase          Collection <T>
            ArrayList               List <T>
            Hashtable               Dictionary <TKey , TValue>
            SortedList              SortedList <TKey , TValue>
            Stack                   Stack <T>
            Queue                   Queue <T>
                                    LinkedList <T>
             */

            //ValueTypePerfTest();

#if CollectionList
            WriteLine("Коллекция целых чисел");
            List<int> listInt = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                listInt.Add(random.Next(100));
            }

            foreach (int i in listInt)
                Write(i + " ");


            WriteLine();
            WriteLine("Коллекция строк");
            List<string> listString = new List<string>();
            listString.Add("Hello");
            listString.Add("World");
            listString.Add("!");

            foreach (string str in listString)
                Write(str + " "); 
#endif

#if Dictionary
            Dictionary<string, int> groups = new Dictionary<string, int>()
            {
                ["GR4"] = 10,
                ["GR5"] = 13,
                ["GR6"] = 45,

            };

            groups.Add("GR1", 10);
            groups.Add("GR2", 12);
            groups.Add("GR3", 5);

            groups["GR4"] = 4;
            groups["GR2"] = 50;

            WriteLine("Содержимое словаря");
            foreach (KeyValuePair<string, int> group in groups)
                WriteLine($"{group.Key} {group.Value}");

            groups.Remove("GR4");

            try
            {
                groups.Add("GR1", 19);
            }
            catch (ArgumentException e)
            {
                WriteLine(e.Message);
            }

            try
            {
                WriteLine(groups["GR8"]);
            }
            catch (KeyNotFoundException e)
            {
                WriteLine(e.Message);
            }

            int key;
            if (groups.TryGetValue("GR3", out key))
                WriteLine(key);
            else
                WriteLine("Такого ключа не существует"); 
#endif

#if Class1
            Point2D<int> p1 = new Point2D<int>();
            WriteLine($"x = {p1.X} y = {p1.Y}");
            WriteLine(typeof(Point2D<int>));

            Point2D<double> p2 = new Point2D<double>(5.7, 6.48);
            WriteLine($"x = {p2.X} y = {p2.Y}");
            WriteLine(p2); 
#endif

#if GenericClass
            InheritClass obj = new InheritClass();
            obj.M1(45);
            obj.M2(845); 
#endif

#if BasicClass
            GenericClasss<int> obj2 = new GenericClasss<int>();
            obj2.M1(49); 
#endif

#if MaxElement
            //A<int>.Inner a = new A<int>.Inner();
            //WriteLine(a);

            //A<double>.Inner a1 = new A<double>.Inner();
            //WriteLine(a1);

            //B<int>.Inner<string> b = new B<int>.Inner<string>();
            //WriteLine(b);

            /*
            where T: struct
                     class
                     new()
                     BaseClass
                     Interface

            class ИмяКласса <T> where T: ограничения

            class GenericClass <T> where T: class, IComparable, new(){}
             */

            int[] arrInt = new int[] { 48, 74, 13, 98, 0, 44 };

            WriteLine($"Максимальный элемент {MaxElement<int>(arrInt)}");

            double[] arrDouble = new double[] { 12.4, 5.7, 63.07 };

            WriteLine($"Максимальный элемент {MaxElement<double>(arrDouble)}"); 
#endif

#if Student1_Class1
            ArrayList auditory = new ArrayList
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName ="Иванов",
                    BirthDate = new DateTime(1990,2,13)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName ="Петров",
                    BirthDate = new DateTime(1995,6,25)
                },
                new Student
                {
                    FirstName = "Лена",
                    LastName ="Ленова",
                    BirthDate = new DateTime(1994,10,23)
                }
            };

            WriteLine("Список студентов");
            foreach (Student student in auditory)
                WriteLine(student);

            WriteLine("Сортировка по фамилии студентов");
            auditory.Sort();
            foreach (Student student in auditory)
                WriteLine(student);

            WriteLine("Сортировка по дате рождения студентов");
            auditory.Sort(new DateComparer());
            foreach (Student student in auditory)
                WriteLine(student);
#endif

#if Student2_Class2
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName ="Иванов",
                    BirthDate = new DateTime(1990,2,13)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName ="Петров",
                    BirthDate = new DateTime(1995,6,25)
                },
                new Student
                {
                    FirstName = "Лена",
                    LastName ="Ленова",
                    BirthDate = new DateTime(1994,10,23)
                }
            };

            WriteLine("Список студентов");
            foreach (Student student in auditory)
                WriteLine(student);

            WriteLine("Сортировка по фамилии студентов");
            auditory.Sort();
            foreach (Student student in auditory)
                WriteLine(student);

            WriteLine("Сортировка по дате рождения студентов");
            auditory.Sort(new DateComparer());
            foreach (Student student in auditory)
                WriteLine(student); 
#endif

            MyList<CalcInt> mylist = new MyList<CalcInt>();
            mylist.Add(new CalcInt(10));
            mylist.Add(new CalcInt(20));
            mylist.Add(new CalcInt(30));

            WriteLine($"Сумма элементов = {mylist.Sum()}");
        }
    }
}
