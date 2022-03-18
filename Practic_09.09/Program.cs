using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Practic_09._09
{
    //class НаследуемыйКласс: БазовыйКлас, Интерфейс1, Интерфейс2, ..... { }
    //public НаследуемыйКласс:base()

    //public sealed class TuTor: Human { } !запечатанный класс
    //public class Curator : TuTor { } !ошибка

    public abstract class Human
    {
        int _id;
        string _firstName;
        string _lastName;
        DateTime _birthDate;

        public Human(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }

        public Human(string fName, string lName, DateTime date)
        {
            _firstName = fName;
            _lastName = lName;
            _birthDate = date;
        }

        public abstract void Think();

        //public virtual void Print()
        //{
        //    Console.WriteLine($"Фамилия: {_lastName}\nИмя: {_firstName}\nДата рождения: {_birthDate.ToShortDateString()}");
        //}

        public override string ToString()
        {
            return $"Фамилия: {_lastName}\nИмя: {_firstName}\nДата рождения: {_birthDate.ToShortDateString()}";
        }
    }

    abstract class Learner : Human
    {
        string _institution;

        public Learner(string fName, string lName, DateTime date, string institution) : base(fName, lName, date)
        {
            _institution = institution;
        }

        public abstract void Study();

        //public override void Print()
        //{
        //    base.Print();
        //    WriteLine($"Учебное заведение: {_institution}");
        //}

        public override string ToString()
        {
            return base.ToString()+$"\nУчебное заведение: {_institution}";
        }
    }

    class Student : Learner
    {
        string _groupName;

        public Student(string fName, string lName, DateTime date, string institution, string nameGroup) : base(fName, lName, date,institution)
        {
            _groupName = nameGroup;
        }

        public override void Think()
        {
            WriteLine("Я думаю как студент");
        }

        public override void Study()
        {
            WriteLine("Я изучаю предметы в институте");
        }

        //public override void Print()
        //{
        //    base.Print();
        //    WriteLine($"Учусь в {_groupName} группе");
        //}

        public override string ToString()
        {
            return base.ToString()+$"\nУчусь в {_groupName} группе";
        }
    }

    class SchoolChild:Learner
    {
        string _className;

        public SchoolChild(string fName, string lName, DateTime date, string institution, string className) : base(fName, lName, date, institution)
        {
            _className = className;
        }

        public override void Think()
        {
            WriteLine("Я думаю как школьник");
        }

        public override void Study()
        {
            WriteLine("Я изучаю предметы в школе");
        }

        //public override void Print()
        //{
        //    base.Print();
        //    WriteLine($"Учусь в {_className} классе");
        //}

        public override string ToString()
        {
            return base.ToString()+$"\nУчусь в {_className} классе";
        }
    }

    //public class Employee : Human
    //{
    //    double _salary;

    //    public Employee(string fName, string lName) : base(fName, lName) { }


    //    public Employee(string fName, string lName, double salary) : base(fName, lName)
    //    {
    //        _salary = salary;
    //    }

    //    public Employee(string fName, string lName, double salary, DateTime date) : base(fName, lName, date)
    //    {
    //        _salary = salary;
    //    }
    //    public override void Print()
    //    {
    //        //base.Print();
    //        Console.WriteLine($"ЗП: {_salary}");
    //    }

    //    public override void Think()
    //    {}
    //}

    //class Manager : Employee
    //{
    //    string _fieldActivity;
    //    public Manager(string fName, string lName, double salary, DateTime date, string activity) : base(fName, lName, salary, date)
    //    {
    //        _fieldActivity = activity;
    //    }

    //    public void ShowManager()
    //    {
    //        WriteLine($"Менеджер. Сфера деятельности: {_fieldActivity}");
    //    }
    //}

    //class Scientist : Employee
    //{
    //    string _scientificDirection;

    //    public Scientist(string fName, string lName, double salary, DateTime date, string ditection) : base(fName, lName, salary, date)
    //    {
    //        _scientificDirection = ditection;
    //    }

    //    public void ShowScientist()
    //    {
    //        WriteLine($"Ученый. Научное направление: {_scientificDirection}");
    //    }
    //}

    //class Specialist : Employee
    //{
    //    string _qualification;
    //    public Specialist(string fName, string lName, double salary, DateTime date, string qualification) : base(fName, lName, salary, date)
    //    {
    //        _qualification = qualification;
    //    }

    //    public void ShowSpecialist()
    //    {
    //        WriteLine($"Специалист. Квалификация: {_qualification}");
    //    }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {

            //Human employee = new Employee("Александр", "Дронов", 10000.254, new DateTime(1800, 12, 15));
            //employee.Print();

            /*
            Employee[] employees =
            {
                manager,
                new Scientist("Иван","Иванов",1954.12,new DateTime(1956,02,14),"история"),
                new Specialist("Перт","Петров",198474.02,new DateTime(1986,06,06),"грузчик")
            };
            
            foreach (Employee employee in employees)
            {
                //1 способ
                employee.Print();
                try
                {
                    ((Specialist)employee).ShowSpecialist();
                }
                catch{ }
                //2 способ
                Scientist scientist = employee as Scientist;
                if(scientist != null)
                    scientist.ShowScientist();
                //3 способ
                if (employee is Manager)
                    (employee as Manager).ShowManager();
            }
            */

            Learner[] learners =
            {
                new Student("Иван","Иванов", new DateTime(1999,8,28),"Институт","группа1"),
                new SchoolChild("Петр","Петров",new DateTime(210,3,20),"Школа","Класс1")
            };

            foreach(Learner learner in learners)
            {
                //WriteLine(learner);
                //learner.Think();
                //learner.Study();
                WriteLine($"Полное имя: {learner.GetType().FullName}");
                WriteLine($"Имя текущего элемента: {learner.GetType().Name}");
                WriteLine($"Базовый класс текущего элемента: {learner.GetType().BaseType}");
                WriteLine();
            }

            /*
             Equals - возвращает true или false (сравнивает объекты)
             finalize - принудительная очистка памяти объекта
             GetHashCode  - возвращает хэш
             GetType - возвращает тип объекта
             ReferenceEquals
             ToString
             */



        }
    }
}
