using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Tuple<T, E>
    {
        public T Item1;
        public E Item2;
        public Tuple(T itemOne, E itemTwo)
        {
            Item1 = itemOne;
            Item2 = itemTwo;
        }
    }
}
