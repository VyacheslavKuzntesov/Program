using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_14._03_Part2
{
    interface IWorker
    {
        //event EventHandler WorkEnded;
        bool IsWorking { get; }
        string Work();
    }

    interface IManager
    {
        List<IWorker> ListOfWorker { get; set; }

        void Organize();
        void MakeBudget();
        void Control();
    }

    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Фамилия: {LastName}; Имя: {FirstName};\nДата рождения: {BirthDate.ToLongDateString()};";
        }

    }

    abstract class Employee: Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+$"\nДолжность: {Position}; Зарплата: {Salary} руб.";
        }
    }

    class Director:Employee, IManager
    {
        public List<IWorker> ListOfWorker { get; set; }
        public void Control()
        {
            WriteLine("Контролирует процесс!");
        }
        public void MakeBudget()
        {
            WriteLine("Формирует бюджет");
        }
        public void Organize()
        {
            WriteLine("Организует работу");
        }
    }

    class Seller:Employee, IWorker
    {
        bool isWorking = true;

        public bool IsWorking { get { return isWorking; } }
        public string Work()
        {
            return "Продает товар";
        }

    }

    class Cashier:Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }
        public string Work()
        {
            return "Пробивает товар на кассе";
        }
    }

    class Storekeeper:Employee, IWorker
    {
        bool isWorking = true;
        public bool IsWorking { get { return isWorking; } }
        public string Work()
        {
            return "Грузит товар";
        }
    }

    interface Iperson
    {
        string Name { get; set; }
        string Email { get; set; }
        string LastName { get; set; }
    }

    interface IEmployee:Iperson
    {
        int Salary { get; set; }
    }

    class Person : IEmployee
    {
        public int Salary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            Director director = new Director
            {
                LastName = "Директоров",
                FirstName = "Крутой",
                BirthDate = new DateTime(1988, 10, 22),
                Position = "Директор",
                Salary = 400000
            };

            IWorker seller = new Seller
            {
                LastName = "Продавцов",
                FirstName = "Наглый",
                BirthDate = new DateTime(1985, 03, 25),
                Position = "Продавец",
                Salary = 15000
            };

            if (seller is Employee)
                WriteLine($"Заработная плата продавца: {(seller as Employee).Salary}");
            Console.WriteLine();

            director.ListOfWorker = new List<IWorker>
            {
                seller,
                new Cashier
                {
                    LastName = "Кассиров",
                    FirstName = "Кас",
                    BirthDate = new DateTime(2000, 07, 07),
                    Position = "Кассир",
                    Salary = 18000
                },
                new Storekeeper
                {
                    LastName = "Грузчиков",
                    FirstName = "Хилый",
                    BirthDate = new DateTime(1968, 11, 01),
                    Position = "Грузчик",
                    Salary = 30000
                }
            };

            WriteLine(director);
            if (director is IManager)
                director.Control();
            Console.WriteLine();
            foreach (IWorker i in director.ListOfWorker)
            {
                WriteLine(i);

                if (i.IsWorking)
                    WriteLine(i.Work());
                Console.WriteLine();
            } 
#endif

            Auditory auditory = new Auditory();

            WriteLine("Список студентов");

            foreach (Student student in auditory)
            {
                WriteLine(student);
            }
        }
    }
}
