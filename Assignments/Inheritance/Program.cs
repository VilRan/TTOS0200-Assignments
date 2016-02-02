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
            for (int i = 0; i < 5; i++)
            {
                Box box = new Box((i + 1) * 3, (i + 1) * 2, (i + 1));
                Console.WriteLine("Box - Width={0}m, Length={1}m, Height={2}m, Area={3}m^2, Volume={4}m^3", 
                    box.Width, box.Length, box.Height, box.Area, box.Volume);
            }
            Console.WriteLine();

            PaperSheet[] sheets = new PaperSheet[1000];
            for (int i = 0; i < 1000; i++)
            {
                sheets[i] = PaperSheet.A4;
            }
            Book book = new Book(0.005, sheets);
            Console.WriteLine("Book - Width={0}cm, Length={1}cm, Thickness={2}cm",
                book.Width*100, book.Length*100, book.Height*100);
            Console.WriteLine();

            Laptop laptop = new Laptop(0.4, 0.3, 0.03);
            laptop.TogglePower();
            DVD dvd = new DVD(100);
            laptop.DiscDrive.Insert(dvd);
            laptop.DiscDrive.Disc.Data.WriteString(0, "This is a test");
            laptop.DiscDrive.Disc.Data.WriteString(22, "This should partially overwrite the last one");
            laptop.DiscDrive.Eject();

            Laptop laptop2 = new Laptop(0.4, 0.3, 0.03);
            laptop2.TogglePower();
            laptop2.DiscDrive.Insert(dvd);
            Console.WriteLine("DVD Data - " + laptop2.DiscDrive.Disc.Data.ReadString(0, 40));

            Console.WriteLine();

        }
        public static void Assignment7()
        {
            Random random = new Random();
            int n = 100;
            I3DObject[] shapes = new I3DObject[n];
            for (int i = 0; i < n; i++)
            {
                switch(random.Next(3))
                {
                    case 0:
                        shapes[i] = new Box(random.NextDouble(), random.NextDouble(), random.NextDouble());
                        break;
                    case 1:
                        shapes[i] = new Cylinder(random.NextDouble(), random.NextDouble());
                        break;
                    case 2:
                        shapes[i] = new Sphere(random.NextDouble());
                        break;
                }
            }

            I3DObject largest = shapes.OrderByDescending(s => s.Volume).FirstOrDefault();
            Console.WriteLine("Largest shape: {0} ({1}m^3)", largest.GetType(), largest.Volume);
            Console.WriteLine("Total volume of all shapes: {0}", shapes.Sum(s => s.Volume));
        }
    }
}
