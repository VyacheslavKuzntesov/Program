using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_23_03
{
#if ExamEventArgs
    class ExamEventArgs
    {
        public string Task { get; set; }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }



        public void Exam(object task, ExamEventArgs e)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Задача: {e.Task}");
        }
    }

    class Teacher
    {
        public EventHandler<ExamEventArgs> examEvent;
        public void Exam(ExamEventArgs task)
        {
            if (examEvent != null)
                examEvent(this, task);
        }
    }
#endif

#if ExamDelegate
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }



        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Задача: {task}");
        }
    }

    class Teacher
    {
        public event ExamDelegate examEvent;
        public void Exam(string task)
        {
            if (examEvent != null)
                examEvent(task);
        }
    } 
#endif

#if ExamDelegate1
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }



        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Задача: {task}");
        }
    }

    class Teacher
    {
        SortedList<int, ExamDelegate> _sortedList = new SortedList<int, ExamDelegate>();
        Random _rand = new Random();

        public event ExamDelegate examEvent
        {
            add
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedList.ContainsKey(key))
                    {
                        _sortedList.Add(key, value);
                        break;
                    }
                }
            }

            remove
            {
                _sortedList.RemoveAt(_sortedList.IndexOfValue(value));
            }
        }

        public void Exam(string task)
        {
            foreach (int key in _sortedList.Keys)
            {
                if (_sortedList[key] != null)
                    _sortedList[key](task);
            }
        }
    } 
#endif

#if AnonimDelegate
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }



        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Задача: {task}");
        }
    }

    class Teacher
    {
        SortedList<int, ExamDelegate> _sortedList = new SortedList<int, ExamDelegate>();
        Random _rand = new Random();

        public event ExamDelegate examEvent
        {
            add
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedList.ContainsKey(key))
                    {
                        _sortedList.Add(key, value);
                        break;
                    }
                }
            }

            remove
            {
                _sortedList.RemoveAt(_sortedList.IndexOfValue(value));
            }
        }

        public void Exam(string task)
        {
            foreach (int key in _sortedList.Keys)
            {
                if (_sortedList[key] != null)
                    _sortedList[key](task);
            }
        }
    } 
#endif

#if lyamda
    public delegate void ExamDelegate(string t);

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }



        public void Exam(string task)
        {
            WriteLine($"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Задача: {task}");
        }
    }

    class Teacher
    {
        SortedList<int, ExamDelegate> _sortedList = new SortedList<int, ExamDelegate>();
        Random _rand = new Random();

        public event ExamDelegate examEvent
        {
            add
            {
                for (int key; ;)
                {
                    key = _rand.Next();
                    if (!_sortedList.ContainsKey(key))
                    {
                        _sortedList.Add(key, value);
                        break;
                    }
                }
            }

            remove
            {
                _sortedList.RemoveAt(_sortedList.IndexOfValue(value));
            }
        }

        public void Exam(string task)
        {
            foreach (int key in _sortedList.Keys)
            {
                if (_sortedList[key] != null)
                    _sortedList[key](task);
            }
        }
    } 
#endif

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Фамилия: {LastName} Имя: {FirstName}\n " +
            $"Дата рождения: {BirthDate.ToLongDateString()}";
        }
    }


    internal class Program
    {

        class ExamCalc
        {
            public string CurrentDate => $"Текущее время {DateTime.Now.ToLongDateString()}";

            public int AddInt(int x, int y) => x + y;
            public static void AddVoid(int x, int y) =>
                WriteLine($"{x} + {y} = {x + y}");
        }

        static void Main(string[] args)
        {

#if ExamEventArgs
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999, 3, 24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997, 5, 16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998, 8, 01)
                },
            };

            Teacher teacher = new Teacher();
            foreach (Student student in auditory)
                teacher.examEvent += student.Exam;

            ExamEventArgs e = new ExamEventArgs { Task = "Решено" };
            teacher.Exam(e); 
#endif

#if ExamDelegate
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999, 3, 24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997, 5, 16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998, 8, 01)
                },
            };

            Teacher teacher = new Teacher();
            Student student = new Student();

            teacher.examEvent += student.Exam;

            teacher.Exam("Решено"); 
#endif

#if ExamDelegate1
            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999, 3, 24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997, 5, 16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998, 8, 01)
                },
            };

            Teacher teacher = new Teacher();
            foreach (Student student1 in auditory)
                teacher.examEvent += student1.Exam;

            Student student = new Student
            {
                FirstName = "Александр",
                LastName = "Александров",
                BirthDate = new DateTime(1980, 12, 12)
            };

            teacher.examEvent += student.Exam;
            teacher.Exam("Решена 1");

            WriteLine();

            teacher.examEvent -= student.Exam;
            teacher.Exam("Решена 2"); 
#endif

#if AnonimDelegate
            WriteLine("Использование события");
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.eventDouble += delegate (double a, double b)
            {
                if (b != 0)
                    return a / b;
                throw new DivideByZeroException();
            };
            double n1 = 7.4, n2 = 3.2;

            WriteLine($"{n1}/{n2} = {dispatcher.OnEventDouble(n1, n2)}");

            WriteLine("Использование локальной переменной");
            int number = 5;

            dispatcher.eventVoid += delegate (int n)
            {
                WriteLine($"{number} + {n} = {number + n}");
            };

            dispatcher.OnEventVoid();
            dispatcher.OnEventVoid(6);

            WriteLine("Использование делегата");

            AnonimDelegateVoid voidDelegate = new AnonimDelegateVoid(delegate { WriteLine("Ok!"); });

            voidDelegate += delegate { WriteLine("Bye!"); };
            voidDelegate(); 
#endif

#if lyamda
            WriteLine("Использование события");
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.eventDouble += (double a, double b) =>
            {
                if (b != 0)
                    return a / b;
                throw new DivideByZeroException();
            };
            double n1 = 7.4, n2 = 3.2;

            WriteLine($"{n1}/{n2} = {dispatcher.OnEventDouble(n1, n2)}");

            WriteLine("Использование локальной переменной");
            int number = 5;

            dispatcher.eventVoid += n =>
            {
                WriteLine($"{number} + {n} = {number + n}");
            };

            dispatcher.OnEventVoid();
            dispatcher.OnEventVoid(6);

            WriteLine("Использование делегата");

            AnonimDelegateVoid voidDelegate = new AnonimDelegateVoid(() => { WriteLine("Ok!"); });

            voidDelegate += () => { WriteLine("Bye!"); };
            voidDelegate(); 
#endif


            List<Student> auditory = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    BirthDate = new DateTime(1999, 3, 24)
                },
                new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    BirthDate = new DateTime(1997, 5, 16)
                },
                new Student
                {
                    FirstName = "Елена",
                    LastName = "Еленова",
                    BirthDate = new DateTime(1998, 8, 01)
                },
            };

            WriteLine("Студенты которые родились весной");
            List<Student> students = auditory.FindAll(s => s.BirthDate.Month >= 3 && s.BirthDate.Month <= 5);

            foreach (Student student in students)
                WriteLine(student);

            ExamCalc examCalc = new ExamCalc();
            WriteLine(examCalc.CurrentDate);
            WriteLine();
            try
            {
                Write("Введите число: ");
                int n1 = int.Parse(ReadLine());
                Write("Введите число: ");
                int n2 = int.Parse(ReadLine());

                WriteLine($"{n1} + {n2} = {examCalc.AddInt(n1, n2)}");

                ExamCalc.AddVoid(n1, n2);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            Class2 class2 = new Class2();
            class2.DividByZero();
        }
    }
}
