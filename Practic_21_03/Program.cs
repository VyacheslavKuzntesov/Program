using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_21_03
{
#if Student_Auditory_1
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Фамилия: {LastName} Имя: {FirstName}\n Дата: {BirthDate.ToLongDateString()}";
        }
    }

    class Auditory
    {
        List<Student> auditory = new List<Student>
        {
            new Student
            {
                FirstName = "Иван",
                LastName = "Иванов",
                BirthDate = new DateTime(1999,3,24)
            },
            new Student
            {
                FirstName = "Петр",
                LastName = "Петров",
                BirthDate = new DateTime(1997,5,16)
            },
            new Student
            {
                FirstName = "Елена",
                LastName = "Еленова",
                BirthDate = new DateTime(1998,8,01)
            },
        };

        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < auditory.Count; i++)
                yield return auditory[i];
        }
    } 
#endif

#if Student_Auditory_1
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Фамилия: {LastName} Имя: {FirstName}\n Дата: {BirthDate.ToLongDateString()}";
        }
    } 
#endif

#if Event

    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n" + $"задача: {task}");
        }
    }

    class Teacher
    {
        public event ExamDelegate examevent;
        public void Exam(string task)
        {
            if (examevent != null)
                examevent(task);
        }
    } 
#endif

#if NO_EVENT
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n" + $"задача: {task}");
        }
    }

    class Teacher
    {
        public ExamDelegate examevent;
        public void Exam(string task)
        {
            if (examevent != null)
                examevent(task);
        }
    } 
#endif

#if Calculate
    public delegate double CalcDelegate(double x, double y);

    class Calculator
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mult(double x, double y) { return x * y; }
        public double Div(double x, double y)
        {
            if (y != 0)
                return x / y;
            throw new DivideByZeroException();
        }
    } 
#endif

    internal class Program
    {
#if Student_Auditory_1
        static void FullName(Student student)
        {
            WriteLine($"{student.FirstName} {student.LastName}");
        }

        static string FullName1(Student student)
        {
            return $"{student.FirstName} {student.LastName}";
        }

        static bool OnlySpring(Student student)
        {
            return student.BirthDate.Month >= 3 && student.BirthDate.Month <= 5;
        }

        static int SortBirthDate(Student student1, Student student2)
        {
            return student1.BirthDate.CompareTo(student2.BirthDate);
        } 
#endif

        static void Main(string[] args)
        {

#if Student_Auditory_1
            Auditory auditory = new Auditory();
            foreach (Student student in auditory)
                WriteLine(student); 
#endif

#if NameIterator_Class1
            WriteLine("Введите начальное значение:");
            int start = int.Parse(ReadLine());

            WriteLine("Введите конечное значение:");
            int end = int.Parse(ReadLine());

            NameIterator nameIterator = new NameIterator(end);

            WriteLine("Все значения");
            foreach (int i in nameIterator)
                Write($"{i} ");

            WriteLine();

            WriteLine("Хначения в заданом диапозоне");
            foreach (int i in nameIterator.GetRange(start))
                Write($"{i} "); 
#endif

            /*
            Clone()
            Combine(Delegate,Delegate)
            CreateDelegate(Type,MethodInfo)
            Delegate Remove(Delegate,Delegate)
            bool operator == (Delegate,Delegate)
            bool operator != (Delegate,Delegate)
             */

#if Calculator1
            Calculator calculator = new Calculator();
            Write("Введите выражение: ");
            string exp = ReadLine();
            char sign = ' ';

            foreach (char c in exp)
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    sign = c;
                    break;
                }

            string[] numbers = exp.Split(sign);

            CalcDelegate del = null;

            switch (sign)
            {
                case '+': del = new CalcDelegate(calculator.Add); break;
                case '-': del = new CalcDelegate(calculator.Sub); break;
                case '*': del = calculator.Mult; break;
                case '/': del = calculator.Div; break;
                default: throw new InvalidOperationException();
            }

            WriteLine($"{del(double.Parse(numbers[0]), double.Parse(numbers[1]))}"); 
#endif

#if Calculator2
            Calculator calculator = new Calculator();
            CalcDelegate calcAll = null;

            CalcDelegate calcDiv = calculator.Div;

            calcAll += calcDiv;
            calcAll += calculator.Add;
            calcAll += calculator.Sub;

            foreach (CalcDelegate i in calcAll.GetInvocationList())
            {
                try
                {
                    WriteLine($"{i(5.7, 3.2)}");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } 
#endif

#if Class2
            Class2 class2 = new Class2();
            AddDelegate<int> dellegateInt = class2.AddInt;
            WriteLine($"Сумма целых чисел: {dellegateInt(8, 6)}");

            AddDelegate<double> dellegateDouble = class2.AddDouble;
            WriteLine($"Сумма дробных чисел: {dellegateDouble(4.7, 0.8)}");

            AddDelegate<char> dellegateChar = Class2.AddChar;
            WriteLine($"Сумма символов чисел: {dellegateChar('S', 'h')}"); 
#endif

#if Student_Auditory_1
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999,3,24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997,5,16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998,8,01)
                }
            };

#if FullName
            WriteLine("Список студентов");
            auditory.ForEach(FullName);

            WriteLine();

            WriteLine("Список студентов");
            IEnumerable<string> students = auditory.Select(FullName1);
            foreach (string student in students)
                WriteLine(student); 
#endif

#if OnlySpring
            List<Student> students = auditory.FindAll(OnlySpring);

            foreach (Student student in students)
                WriteLine(student); 
#endif

#if SortBirthDate
            auditory.Sort(SortBirthDate);
            foreach (Student student in auditory)
                WriteLine(student); 
#endif



#endif

#if Event
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999,3,24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997,5,16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998,8,01)
                }
            };

            Teacher teacher = new Teacher();
            foreach (Student student in auditory)
                teacher.examevent += student.Exam;

            teacher.Exam("Решена"); 
#endif

#if NO_EVENT
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999,3,24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997,5,16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998,8,01)
                }
            };

            Teacher teacher = new Teacher();
            foreach (Student student in auditory)
                teacher.examevent += student.Exam;

            teacher.examevent.Invoke("никто не пришел");

            teacher.examevent = null;



            teacher.Exam("Решена"); 
#endif

        }
    }
}
