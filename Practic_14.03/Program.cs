using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_14._03
{
    internal class Program
    {

#if true
        public class Laptop
        {
            public string Vender { get; set; }
            public double Price { get; set; }

            public override string ToString()
            {
                return $"{Vender} {Price}";
            }
        }

        enum Vendors { HP, LENOVO, MACBOOK };

        public class Shop
        {
            Laptop[] laptopArr;

            public int Length
            {
                get { return laptopArr.Length; }
            }

            public Shop(int size)
            {
                laptopArr = new Laptop[size];
            }

            public Laptop this [double price]
            {
                get
                {
                    if (FindByPrice(price)>=0)
                        return this[FindByPrice(price)];
                    throw new Exception("Error");
                }
                set
                {
                    if (FindByPrice(price) >= 0)
                        this[FindByPrice(price)] = value;
                }
            }

            public Laptop this[int index]
            {
                get
                {
                    if (index >= 0 && index < laptopArr.Length) return laptopArr[index];
                    throw new IndexOutOfRangeException();
                }
                set
                {
                    laptopArr[index] = value;
                }
            }

            public int FindByPrice(double price)
            {
                for (int i = 0;i<laptopArr.Length; i++)
                {
                    if (laptopArr[i].Price == price)
                        return i;
                }
                return -1;
            }

            public Laptop this [string name]
            {
                get
                {
                    if (Enum.IsDefined(typeof(Vendors), name)) return laptopArr[(int)Enum.Parse(typeof(Vendors), name)];
                    else return new Laptop();
                }
                set
                {
                    if (Enum.IsDefined(typeof(Vendors), name)) laptopArr[(int)Enum.Parse(typeof(Vendors), name)] = value;
                }
            }
        }
#endif

#if MultArray
        public class MultArray
        {
            private int[,] array;

            public int Rows { get; private set; }
            public int Cols { get; private set; }

            public MultArray(int rows, int cols)
            {
                this.Rows = rows;
                this.Cols = cols;
                array = new int[rows, cols];
            }

            public int this[int r, int c]
            {
                get { return array[r, c]; }
                set { array[r, c] = value; }
            }
        } 
#endif

        static void Main(string[] args)
        {

#if true
            //тип_данных this[тип_аргумента]{get;set}

            Shop laptops = new Shop(3);

            laptops[0] = new Laptop { Vender = "HP", Price = 67520 };
            laptops[1] = new Laptop { Vender = "Lenovo", Price = 45000 };
            laptops[2] = new Laptop { Vender = "MacBook", Price = 243000 };

            try
            {
                for (int i = 0; i < laptops.Length; i++)
                    Console.WriteLine(laptops[i]);

                Console.WriteLine();

                Console.WriteLine($"Производитель Lenovo: {laptops["LENOVO"]}");

                Console.WriteLine($"Стоимость в 243 000: {laptops[243000.0]}");

                laptops.FindByPrice(243000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
#endif

#if MultArray
            MultArray mult = new MultArray(2, 3);

            for (int i = 0; i < mult.Rows; i++)
            {
                for (int j = 0; j < mult.Cols; j++)
                {
                    mult[i, j] = i + j;
                    Console.Write(mult[i, j] + " ");
                }
                Console.WriteLine();
            } 
#endif


        }
    }
}
