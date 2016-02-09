using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Recap
{
    class Program
    {
        const int MinAssignments = 1;
        const int MaxAssignments = 1;

        static void Main(string[] args)
        {
            Assignment1();
            while (true)
            {
                Console.Write("Enter assignment number (" + MinAssignments + "-" + MaxAssignments + ") or enter something else to exit > ");
                int assignment;
                if (!int.TryParse(Console.ReadLine(), out assignment)
                    || assignment < MinAssignments || assignment > MaxAssignments)
                    break;

                Type type = typeof(Program);
                MethodInfo info = type.GetMethod("Assignment" + assignment, BindingFlags.Static | BindingFlags.Public);
                info.Invoke(null, null);
                Console.WriteLine();
            }
        }

        public static void Assignment1()
        {
            Die die = new Die();

            Console.WriteLine("How many times do you want to throw a die : ");
            int times = int.Parse(Console.ReadLine());
            die.Throw(times);

            Console.WriteLine("Die has now been thrown {0} times", die.TotalTimes);
            Console.WriteLine("- average is " + Math.Round(die.Average, 4));
            for (int i = 1; i <= 6; i++)
                Console.WriteLine("- " + i + " count is " + die.GetTimes(i));
            Console.WriteLine();
        }
    }
}
