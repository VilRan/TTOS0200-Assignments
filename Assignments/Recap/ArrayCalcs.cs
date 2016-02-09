using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    public static class ArrayCalcs
    {
        public static double Sum(params double[] array)
        {
            double sum = 0;
            foreach (double value in array)
                sum += value;
            return sum;
        }

        public static double Average(params double[] array)
        {
            double average = 0;
            foreach (double value in array)
                average += value;
            average /= array.Length;
            return average;
        }

        public static double Min(params double[] array)
        {
            double min = double.MaxValue;
            foreach (double value in array)
                if (value < min)
                    min = value;
            return min;
        }

        public static double Max(params double[] array)
        {
            double max = double.MinValue;
            foreach (double value in array)
                if (value > max)
                    max = value;
            return max;
        }
    }
}
