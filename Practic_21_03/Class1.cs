using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_21_03
{
    internal class NameIterator
    {
        const int LIM = 10;
        int _limit;

        public NameIterator(int limit)
        {
            _limit = limit;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _limit; i++)
            {
                if (i == LIM)
                    yield break;

                yield return i;
            }
        }

        /*
        public IEnumerable имя_итератора (список_параметров)
        {
            код
            yield return возвращаемое_значение
        }
        */

        public IEnumerable<int> GetRange(int start)
        {
            for (int i = start; i < _limit; i++)
            {
                if (i == LIM)
                    yield break;
                yield return i;
            }
        }
    }
}
