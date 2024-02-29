using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Counter
    {
        public int minV;
        public int maxV;
        public int curV;
        public Counter()
        { }
        public Counter(int minV, int maxV, int curV)
        {
            this.minV = minV;
            this.maxV = maxV;
            this.curV = curV;
        }
        public void Inc()
        {
            if (curV < maxV)
                curV += 1;
            else 
                curV = minV;
        }
        public void Dec()
        {
            if (curV > minV)
                curV -= 1;
            else
                curV = maxV;
        }
        public int GetV()
        {
            return curV;
        }
    }
}
