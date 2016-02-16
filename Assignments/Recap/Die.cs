using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class Die
    {
        public double Average {
            get
            {
                double average = 0;
                for (int i = 0; i < count.Length; i++)
                {
                    average += (i + 1) * count[i];
                }
                average /= TotalCount;
                return average;
            }
        }
        public int TotalCount { get { return count.Sum(); } }

        public void Throw(int times)
        {
            for (int i = 0; i < times; i++)
            {
                int result = random.Next(6);
                this.count[result]++;
            }
        }

        public int GetCount(int face)
        {
            if (face < 1 || face > 6)
                return 0;

            return count[face - 1];
        }

        Random random = new Random();
        int[] count = new int[6];
    }
}
