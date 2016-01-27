using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        const int MinAssignments = 5;
        const int MaxAssignments = 7;

        static void Main(string[] args)
        {
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
        
        public static void Assignment5()
        {
            Radio radio = new Radio();
            radio.TurnOn();
            Console.WriteLine(radio.Status);
            radio.Frequency = 30000.0;
            radio.Volume = 11;
            Console.WriteLine(radio.Status);
            radio.Frequency = 15000.0;
            radio.Volume = 4;
            Console.WriteLine(radio.Status);
            radio.Frequency = 1000.0;
            radio.Volume = -5;
            Console.WriteLine(radio.Status);
        }
        public static void Assignment6()
        {

        }
        public static void Assignment7()
        {

        }
    }
}
