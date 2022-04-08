using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_25_03
{

#if MyException
    public class MyException : ApplicationException
    {
        public DateTime TimeException { get; private set; }
        public MyException() : base("Моё исключение")
        {
            TimeException = DateTime.Now;
        }
    } 
#endif

#if ExamNameof
    class ExamNameof
    {
        public string Name { get; set; }
        public ExamNameof(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Name = name;
        }
    } 
#endif

#if Garbage
    class GarbageHelper
    {
        public void MakeGarbage()
        {
            for (int i = 0; i < 1000; i++)
            {
                Person p = new Person();
            }
        }
        class Person
        {
            string _name;
            string _surname;
            byte _age;
        }
    } 
#endif

    internal class Program
    {

#if DivideByZero
        static int DivideByZero(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException e)
            {
                throw;
            }
            return result;
        } 
#endif

#if DivideByZero2
        static int DivideByZero(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException e)
            {
                throw new Exception("Дополнительная инф-я", e);
            }
            return result;
        } 
#endif

#if StackTrace
        static void f2()
        {
            throw new Exception("Моё исключение");
        }

        static void f1()
        {
            f2();
        }

        static void f()
        {
            try
            {
                f1();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                WriteLine($"Стэк: {ex.StackTrace}");
            }
        } 
#endif

#if when
        static int DivisionNumbers(int n1, int n2)
        {
            int result = 0;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException e)
            {
                throw new Exception("Проверка фильтров исключения", e);
            }
            return result;
        } 
#endif



        static void Main(string[] args)
        {

#if MyException
            int n1, n2, res = 0;

            try
            {
                n1 = int.Parse(ReadLine());
                n2 = int.Parse(ReadLine());
                res = n1 / n2;

                if (res % 2 != 0)
                {
                    throw new MyException();
                }
                WriteLine($"результат деления: {res}");
            }
            catch (DivideByZeroException e)
            {
                WriteLine(e.Message);
                //WriteLine(e.TimeException);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            } 
#endif

#if Exception1
            int[] arr = new int[5];
            int n = 0;
            try
            {
                for (int i = -3; i <= 3; i++)
                {
                    try
                    {
                        arr[n] = 100 / i;
                        WriteLine(arr[n]);
                        n++;
                    }
                    catch (DivideByZeroException e)
                    {
                        WriteLine("Внутренний catch");
                        WriteLine(e.Message);
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine("Внешний catch");
                WriteLine(e.Message);
            } 
#endif

#if DivideByZero
            int n1, n2, res = 0;
            try
            {
                n1 = int.Parse(ReadLine());
                n2 = int.Parse(ReadLine());
                res = DivideByZero(n1, n2);
                WriteLine(res);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            } 
#endif

#if DivideByZero2
            int n1, n2, res = 0;
            try
            {
                n1 = int.Parse(ReadLine());
                n2 = int.Parse(ReadLine());
                res = DivideByZero(n1, n2);
                WriteLine(res);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                WriteLine(e.InnerException.Message);
            } 
#endif

#if StackTrace
            f(); 
#endif

#if perepolnenie
            //checked
            //unchecked
            byte a = 100;
            a = (byte)(a + 200);
            WriteLine(a);

            int b = 65536;
            short s = (short)b;
            WriteLine(s); 
#endif

#if checked_unchecked
            byte b = 255;
            try
            {
                checked
                {
                    b++;
                }
                WriteLine(b);
            }
            catch (OverflowException ex)
            {
                WriteLine(ex.Message);
            }

            try
            {
                unchecked
                {
                    b++;
                }
                WriteLine(b);
            }
            catch (OverflowException ex)
            {
                WriteLine(ex.Message);
            }

            WriteLine();
            byte a = 100;
            WriteLine(unchecked((byte)(a + 200)));
            try
            {
                WriteLine(checked((byte)(a + 200)));
            }
            catch(OverflowException ex)
            {
                WriteLine(ex.Message);
            }
#endif

#if when
            int n1, n2, res = 0;
            try
            {
                n1 = int.Parse(ReadLine());
                n2 = int.Parse(ReadLine());
                res = DivisionNumbers(n1, n2);

                WriteLine(res);
            }
            catch (Exception e) when (e.InnerException != null)
            {
                WriteLine(e.Message);
                WriteLine(e.InnerException.Message);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            } 
#endif

#if ExamNameof
            try
            {
                ExamNameof ex = new ExamNameof(null);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            } 
#endif

#if Garbage
            // 0 уровень 256 Кбайт
            // 1 уровень 2 Мбайт
            // 2 уровень 10 Мбайт

            WriteLine("Демонстрация сборщика мусора");
            WriteLine($"Максимальное поколение: {GC.MaxGeneration}");

            GarbageHelper helper = new GarbageHelper();

            WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}");

            WriteLine($"Занято памяти(байт): {GC.GetTotalMemory(false)}");

            helper.MakeGarbage();

            WriteLine($"Занято памяти(байт): {GC.GetTotalMemory(false)}");

            GC.Collect(0);

            WriteLine($"Теперь занято памяти после очистки: {GC.GetTotalMemory(false)}");

            WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}");

            GC.Collect();

            WriteLine($"Теперь занято памяти после очистки: {GC.GetTotalMemory(false)}");

            WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}"); 
#endif



        }
    }
}
