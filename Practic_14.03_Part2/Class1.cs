using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_14._03_Part2
{
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенчиский билет: {Series} {Number}";
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }

        public override string ToString()
        {
            return $"{StudentCard} {FirstName} {LastName} {BirthDate.ToLongDateString()}";
        }
    }

    class Auditory: IEnumerable
    {
        Student[] students =
        {
            new Student
            {
                FirstName = "Иван",
                LastName = "Иванов",
                BirthDate = new DateTime(1999,12,12),
                StudentCard = new StudentCard
                {
                    Number = 1,
                    Series = "AB"
                }
            },
            new Student
            {
                FirstName = "Петр",
                LastName = "Петров",
                BirthDate = new DateTime(2001,01,01),
                StudentCard = new StudentCard
                {
                    Number = 2,
                    Series = "AC"
                }
            },
            new Student
            {
                FirstName = "Сергей",
                LastName = "Сергеев",
                BirthDate = new DateTime(2005,06,05),
                StudentCard = new StudentCard
                {
                    Number = 3,
                    Series = "AD"
                }
            }
        };

        public void Sort()
        {
            Array.Sort(students);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
}
