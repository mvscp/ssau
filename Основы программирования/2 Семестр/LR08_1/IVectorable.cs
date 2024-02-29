using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR08_1
{
    internal interface IVectorable : IComparable, ICloneable
    {
        int this[int index]
        {
            get;
            set;
        }
        int Length
        {
            get;
        }
        double GetNorm();
    }
}
