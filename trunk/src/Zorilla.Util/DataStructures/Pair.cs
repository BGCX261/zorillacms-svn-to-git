﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zorilla.Util.DataStructures
{
    public class Pair<S,T>
    {
        public S First { get; set; }
        public T Second { get; set; }

        public Pair(S first, T second)
        {
            First = first;
            Second = second;
        }

        public Pair()
        {
        }
    }
}