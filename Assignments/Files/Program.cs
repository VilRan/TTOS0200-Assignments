using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Files
{
    class Program
    {
        const int MinAssignments = 2;
        const int MaxAssignments = 3;

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

        public static void Assignment2()
        {
            while (true)
            {
                Console.Write("Enter a number : ");

                int integer = 0;
                double real = 0;
                string input = Console.ReadLine();
                if (int.TryParse(input, out integer))
                {
                    using (StreamWriter writer = new StreamWriter("Integers.txt", true))
                    {
                        writer.WriteLine(integer);
                    }
                }
                else if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out real))
                {
                    using (StreamWriter writer = new StreamWriter("Doubles.txt", true))
                    {
                        writer.WriteLine(real);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void Assignment3()
        {
            List<TVProgram> programs = new List<TVProgram>();
            programs.Add(new TVProgram("dsfjsago", "djfsoifa", "joesafosaejf", DateTime.Parse("2016-10-3 17:00:00"), DateTime.Parse("2016-10-3 19:00:00")));
            programs.Add(new TVProgram("kfrpojsgfjer", "djfsoifa", "vjoiewjfewsvf", DateTime.Parse("2016-11-21 19:00:00"), DateTime.Parse("2016-11-21 20:00:00")));
            programs.Add(new TVProgram("kfawpoefpok", "ysigrojsged", "påkergjdsog", DateTime.Parse("2016-12-29 22:00:00"), DateTime.Parse("2016-12-29 23:00:00")));

            IFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("Programs.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                formatter.Serialize(file, programs);

            programs.Clear();
            using (FileStream file = new FileStream("Programs.txt", FileMode.Open, FileAccess.Read, FileShare.None))
                programs = (List<TVProgram>)formatter.Deserialize(file);

            foreach (TVProgram program in programs)
            {
                Console.WriteLine(program);
            }
        }
    }
}
