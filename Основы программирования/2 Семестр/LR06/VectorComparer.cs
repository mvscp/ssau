using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR06
{
    internal class VectorComparer: IComparer<IVectorable>
    {
        public int Compare(IVectorable a, IVectorable b)
        {
            return a.GetNorm().CompareTo(b.GetNorm());
        }
    }
}
