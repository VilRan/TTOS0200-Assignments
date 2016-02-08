using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{
    class Program
    {
        const int MinAssignments = 4;
        const int MaxAssignments = 4;

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

        public static void Assignment4()
        {
            Universe universe = new Universe(new Random());

            Console.WriteLine("The generated universe has...");
            Console.WriteLine("    " + universe.Galaxies.Count + " galaxies,");
            Console.WriteLine("    " + universe.Systems.Count() + " systems,");
            Console.WriteLine("    " + universe.Planets.Count() + " planets,");
            Console.WriteLine("    " + universe.Moons.Count() + " moons,");
            Console.WriteLine("    " + universe.CelestialBodies.Count() + " celestial bodies in total.");
            Console.WriteLine();

            CelestialBody planet = universe.Planets.First();
            Console.WriteLine("The first planet of the first system of the first galaxy:");
            Console.WriteLine("    Mass: {0:N} Earths", planet.Mass / Universe.EarthMass);
            Console.WriteLine("    Orbit: {0:N} AU", planet.SemimajorAxis / Universe.AstronomicalUnit);
            Console.WriteLine("    Moons: {0:D}", planet.Satellites.Count);
        }
    }
}
