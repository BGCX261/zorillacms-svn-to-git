using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zorilla.Util.DataStructures
{
    public class Triplet<R,S, T>
    {
        public Triplet()
        {
        }

        public R First { get; set; }
        public S Second { get; set; }
        public T Third { get; set; }

        public Triplet(R first, S second, T third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}