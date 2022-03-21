using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_21_03
{
    /*
    [модификатор_доступа] delegate тип_возврата Имя_Делегата <тип_параметров> (параметры);
     */

    public delegate T AddDelegate <T>(T x, T y);

    internal class Class2
    {
        public int AddInt(int x, int y) { return x + y; }
        public double AddDouble(double x, double y) { return x + y; }
        public static char AddChar(char x, char y) { return (char)(x + y); }
    }
}
