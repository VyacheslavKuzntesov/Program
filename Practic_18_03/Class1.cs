using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_18_03
{
#if Point2D
    internal class Point2D<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }
    } 
#endif

#if Student1
    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
            }

            throw new NotImplementedException();
        }
    }

    class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Фамилия: {LastName}, Имя: {FirstName}, Дата: {BirthDate.ToLongDateString()}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();
        }
    } 
#endif
}
