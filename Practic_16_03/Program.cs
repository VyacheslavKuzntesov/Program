using System;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_16_03
{
    class Student
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }

    class SortedArrayList : ArrayList
    {
        public void AddSorted(object item)
        {
            int position = BinarySearch(item);
            if (position < 0)
                position = ~position;
            Insert(position, item);
        }

        public void ModifySorted(object item, int index)
        {
            RemoveAt(index);
            int position = BinarySearch(item);
            if (position < 0)
                position = ~position;
            Insert(position, item);
        }
    }

    class Student1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }


    internal class Program
    {

        static Hashtable group = new Hashtable
        {
            { new Student1 { FirstName = "Иван",LastName = "Иванов"},
            new ArrayList {3,5,2} },
            {new Student1 {FirstName = "Петр",LastName = "Петров" },
            new ArrayList {4,4,5} }
        };

        static void RatingList()
        {
            WriteLine("Список студентов с оценками");

            foreach (Student1 student in group.Keys)
            {
                Write($"{student.FirstName} {student.LastName}: ");
                foreach (int i in (group[student] as ArrayList))
                {
                    Write(" " + i);
                }
                WriteLine();
            }
        }

        static void SetRating(string name, int mark)
        {
            WriteLine($"Студент {name} получил оценку {mark}");
            foreach (Student1 student in group.Keys)
            {
                if (student.FirstName == name)
                    (group[student] as ArrayList).Add(mark);
            }
        }

        static void Main(string[] args)
        {

#if ArrayList
            /*
               Capacity - узнать текущий размер массива или задать его
               TrimToSize - уменьшает размер до количества его значений
               Add(object) - добваление в конец
               AddRange(ICollection) - добавление коллекции
                */

            ArrayList arrayList = new ArrayList();
            ArrayList arrayList2 = new ArrayList(7);
            ArrayList arrayList3 = new ArrayList(new int[] { 1, 2, 3, 4 });

            Console.WriteLine($"Вместимость по умалчанию: {arrayList.Capacity}");

            arrayList.Add("one");
            Console.WriteLine($"Вместимость поосле добавления строки: {arrayList.Capacity}");

            arrayList.AddRange(new int[] { 1, 2, 3, 5, 6 });
            Console.WriteLine($"Вместимость поосле добавления коллекции: {arrayList.Capacity}");

            arrayList.Capacity = 10;
            Console.WriteLine($"Вместимость заявлена явно: {arrayList.Capacity}");

            Console.WriteLine($"Фактическое кол-во элементов: {arrayList.Count}");

            arrayList.TrimToSize();
            Console.WriteLine($"Вместимость уменьшена до реального кол-ва элемнтов: {arrayList.Capacity}");

            Console.WriteLine($"Элемент под индексом 3: {arrayList[3]}");

            foreach (object obj in arrayList)
                Console.WriteLine(obj.ToString());

            /*
            Insert(int,object)
            InsertRange(int,ICollection)
            RemoveAr(int) RemoveRange(int,int)
            GetRange(int, int)
            IndexOf/LastIndexOf(object)
            Sort()
             */

            Console.WriteLine();
            Console.WriteLine("Добавление");
            arrayList3.Insert(2, "hello");
            foreach (object obj in arrayList3)
                Console.WriteLine(obj.ToString());

            Console.WriteLine("Удаление");
            arrayList3.RemoveAt(3);
            foreach (object obj in arrayList3)
                Console.WriteLine(obj.ToString());

            Console.WriteLine($"Поиск индекса: {arrayList3.IndexOf("hello")}");

            ArrayList list = new ArrayList(new string[]
            {
                "Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"
            });

            ArrayList list2 = new ArrayList(list.GetRange(1, 5));

            foreach (object obj in list2)
                Console.WriteLine(obj);

            Console.WriteLine("Сортировка");
            list.Sort();

            foreach (object obj in list)
                Console.WriteLine(obj); 
#endif

#if Stack
            /*
                Push
                Pop
                Peek
                CopyTo(Array,int)
                Contains
                 */

            Stack stack = new Stack();
            Console.Write("Push(): ");
            stack.Push("one");
            stack.Push("two");
            stack.Push("three");

            foreach (var item in stack)
                Console.Write($" {item}");

            Console.WriteLine();
            Console.Write("Pop(): ");
            stack.Pop();
            foreach (var item in stack)
                Console.Write($" {item}");

            Console.WriteLine();
            Console.WriteLine($"Peek(): {stack.Peek()}");

            Console.WriteLine($"Существует ли элемент ten: {stack.Contains("ten")}");
            Console.WriteLine($"Существует ли элемент one: {stack.Contains("one")}");

            Console.Write("CopyTo: ");
            string[] arr = new string[stack.Count];
            stack.CopyTo(arr, 0);

            foreach (var item in arr)
                Console.Write($" {item}");

            Console.WriteLine();
            stack.Clear();
            Console.WriteLine($"Количество элементов после вызова Clear(): {stack.Count}"); 
#endif

#if Queue
            Queue queue = new Queue();
            /*
            Enqueue/Dequeue(object)
            Peek
             */

            Console.WriteLine("Метод Enqueue");
            for (int i = 0; i < 4; i++)
                queue.Enqueue(i);

            foreach (var item in queue)
                Console.WriteLine(item);

            Console.WriteLine($"Метод Dequeue: {queue.Dequeue()}");

            Console.WriteLine($"Существование элемента 0: {queue.Contains(0)}");
            Console.WriteLine($"Метод Peek(): {queue.Peek()}");
            Console.WriteLine($"Существование элемента 2: {queue.Contains(2)}"); 
#endif

#if Hashtable
            /*
                Add(object,object) 
                Remove(object)
                Keys,Values
                ContainsKey,ContainsValue
                 */

            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add("two", "Иван");

            foreach (object o in ht.Keys)
                Console.WriteLine($"Ключ {o}. Значение {ht[o]}");

            ht.Add("three", 5.487);

            foreach (object o in ht.Values)
                Console.WriteLine($"Значение {o}");

            ht.Remove("two");

            Console.WriteLine($"Существует ли элемент two: {ht.ContainsKey("two")}"); 
#endif


#if SortedList
            SortedList sortedList = new SortedList();
            sortedList.Add(3, 6.7);
            sortedList.Add(2, new Student { Name = "Ivan" });
            sortedList.Add(1, "one");

            foreach (object obj in sortedList.Keys)
                Console.WriteLine($"Ключ: {obj} Значение: {sortedList[obj]}");

            Console.WriteLine();
            for (int i = 0; i < sortedList.Count; i++)
                Console.WriteLine($"Ключ: {sortedList.GetKey(i)} Значение: {sortedList.GetByIndex(i)}");

            Console.WriteLine();
            foreach (object obj in sortedList.Values)
                Console.WriteLine($"Значение: {obj}");

            Console.WriteLine();
            sortedList.Remove(3);
            Console.WriteLine($"Существует ли элемент с ключом 3: {sortedList.ContainsKey(3)}"); 
#endif

#if SortedArrayList
            /*
               ICollections
               IList
               IDictionary
               IDictionaryEnumerator
                */

            SortedArrayList SortedArray = new SortedArrayList();

            WriteLine("Начальные значения");
            SortedArray.AddSorted(200);
            SortedArray.AddSorted(-7);
            SortedArray.AddSorted(0);
            SortedArray.AddSorted(-20);
            SortedArray.AddSorted(56);
            SortedArray.AddSorted(500);
            SortedArray.AddSorted(200);

            foreach (var item in SortedArray)
                Write(item + " ");

            WriteLine();

            WriteLine("Изменение значений");
            SortedArray.ModifySorted(3, 5);
            SortedArray.ModifySorted(-1, 2);
            SortedArray.ModifySorted(2, 4);
            SortedArray.ModifySorted(7, 6);

            foreach (var item in SortedArray)
                Write(item + " ");
            WriteLine(); 
#endif

#if Student1
            RatingList();
            SetRating("Петр", 1);
            RatingList(); 
#endif

        }
    }
}
