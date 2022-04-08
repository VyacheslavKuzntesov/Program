using System;
using System.Reflection;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_1_04
{

    //class Student
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public DateTime BirthDate { get; set; }

    //    public override string ToString()
    //    {
    //        return $"LastName: {LastName}, Name: {FirstName}, " +
    //        $"Born: {BirthDate.ToLongDateString()}";
    //    }
    //}

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"LastName: {LastName}, Name: {FirstName}, " +
            $"Group: {GroupId}";
        }
    }

    class Group
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
#if Student
            const double dayOfYear = 365.25;

            List<Group> groups = new List<Group>
            {
                new Group{Id = 1, Name = "789"},
                new Group{Id = 2, Name = "456"}
            };

            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Alex", LastName = "Alexov",
                BirthDate = new DateTime(2005,3,12)},
                new Student{FirstName = "Ivan", LastName = "Ivanov",
                BirthDate = new DateTime(1998,7,22)},
                new Student{FirstName = "Elena", LastName = "Elenova",
                BirthDate = new DateTime(2010,11,30)},
                new Student{FirstName = "Petr", LastName = "Petrov",
                BirthDate = new DateTime(1996,1,10)}
            }; 
#endif

#if vozrast_starshe_20
            //var query = from s in students
            //            where (DateTime.Now - s.BirthDate).Days
            //            / dayOfYear > 20
            //            select s;

            var query = students.Where(s => (DateTime.Now - s.BirthDate).Days / dayOfYear > 20).Select(s => s); 
            WriteLine("Студенты старше 20 лет");
            foreach (var student in query)
                WriteLine(student); 
#endif

#if mladshuy_i_ego_vozrast
            WriteLine("Младший студент");
            var student = from s in students
                          where s.BirthDate == (from b in students
                                                select b.BirthDate).Max()
                          select s;

            foreach (var stu in student)
                WriteLine(stu);

            var minAge = (from s in students select s).Min(s => (DateTime.Now - s.BirthDate).Days / dayOfYear);

            WriteLine($"Возраст: {(int)minAge} лет"); 
#endif

#if zada4a_1
            string[] people = { "Иван", "Петр", "Игнат", "ибрагим", "Светлана", "Ирина" };
            //первый способ
            List<string> selectPeople = new List<string>();

            foreach (string person in people)
            {
                if (person.ToUpper().StartsWith("И"))
                    selectPeople.Add(person);
            }

            selectPeople.Sort();
            //второй способ
            var selectPeople1 = from p in people where p.ToUpper().StartsWith("И") orderby p select p;

            //foreach (var person in selectPeople1)
            //    WriteLine(person);


            //третий способ(использование методов расширения)
            var selectPeople2 = people.Where(p => p.ToUpper().StartsWith("И")).OrderBy(p => p);

            foreach (var person in selectPeople2)
                WriteLine(person); 
#endif

#if zada4a_2
            string[] people = { "Иван", "Петр", "Игнат", "ибрагим", "Светлана", "Ирина" };

            var selectPeople = from p in people where p.Length == 4 orderby p select p;

            var selectPeople2 = people.Where(p => p.Length == 4);

            foreach (var person in selectPeople2)
                WriteLine(person); 
#endif

#if zada4a_3
            int[] intArray = { 4, 7, 9, 16, 10, 2, 0, 18, 19 };

            var selectNumber = from num in intArray where num % 2 == 0 && num > 10 select num;

            var selectNumber2 = intArray.Where(num => num % 2 == 0 && num > 10);

            foreach (var person in selectNumber2)
                WriteLine(person); 
#endif

#if zada4a_4
            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Alex", LastName = "Alexov",
                BirthDate = new DateTime(2005,3,12)},
                new Student{FirstName = "Ivan", LastName = "Ivanov",
                BirthDate = new DateTime(1998,7,22)},
                new Student{FirstName = "Elena", LastName = "Elenova",
                BirthDate = new DateTime(2010,11,30)},
                new Student{FirstName = "Petr", LastName = "Petrov",
                BirthDate = new DateTime(1996,1,10)}
            };

            var sortStudent = from student in students orderby student.LastName select student;

            var sortStudent2 = students.OrderBy(student => student.LastName);

            foreach (var person in sortStudent2)
                WriteLine(person); 
#endif

#if zada4a_5
            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Alex", LastName = "Alexov",
                BirthDate = new DateTime(2005,3,12)},
                new Student{FirstName = "Ivan", LastName = "Ivanov",
                BirthDate = new DateTime(1998,7,22)},
                new Student{FirstName = "Elena", LastName = "Elenova",
                BirthDate = new DateTime(2010,11,30)},
                new Student{FirstName = "Apet", LastName = "Petrov",
                BirthDate = new DateTime(1996,1,10)}
            };

            var sortStudent = from s in students where s.FirstName.Length == 4 && s.FirstName.ToUpper().StartsWith("A") orderby s.LastName descending select s;

            var sortStudent2 = students.Where(s => s.FirstName.Length == 4 && s.FirstName.ToUpper().StartsWith("A")).OrderByDescending(s => s.LastName);

            foreach (var person in sortStudent2)
                WriteLine(person); 
#endif

            List<Group> groups = new List<Group>
            {
                new Group{Id = 1, Name = "789"},
                new Group{Id = 2, Name = "456"}
            };

            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Alex", LastName = "Alexov",
                GroupId = 1},
                new Student{FirstName = "Ivan", LastName = "Ivanov",
                GroupId = 2},
                new Student{FirstName = "Elena", LastName = "Elenova",
                GroupId = 2},
                new Student{FirstName = "Apet", LastName = "Petrov",
                GroupId = 1}
            };

            var sortStudent = from grp in groups join student in students on grp.Id equals student.GroupId select new { FirstName =  student.FirstName,LastName = student.LastName, Group =  grp.Name };

            var sortStudent2 = students.Join(groups,std => std.GroupId,grp=>grp.Id,(std,grp)=> new { FirstName = std.FirstName, LastName = std.LastName, Group = grp.Name });

            foreach (var person in sortStudent)
                WriteLine($"{person.FirstName} {person.LastName} {person.Group}");
        }
    }
}
