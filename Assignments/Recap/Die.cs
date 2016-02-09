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
                for (int i = 0; i < times.Length; i++)
                {
                    average += (i + 1) * times[i];
                }
                average /= TotalTimes;
                return average;
            }
        }
        public int TotalTimes { get { return times.Sum(); } }

        public void Throw(int times)
        {
            for (int i = 0; i < times; i++)
            {
                int result = random.Next(6);
                this.times[result]++;
            }
        }

        public int GetTimes(int face)
        {
            if (face < 1 || face > 6)
                return 0;

            return times[face - 1];
        }

        Random random = new Random();
        int[] times = new int[6];
    }
}
