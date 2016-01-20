﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Program
    {
        const int Assignments = 4;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter assignment number (1-" + Assignments + ") or enter something else to exit > ");
                int assignment;
                if (!int.TryParse(Console.ReadLine(), out assignment)
                    || assignment < 1 || assignment > Assignments)
                    break;

                Type type = typeof(Program);
                MethodInfo info = type.GetMethod("Assignment" + assignment, BindingFlags.Static | BindingFlags.Public);
                info.Invoke(null, null);
            }
        }

        public static void Assignment1()
        {
            Sauna sauna = new Sauna();

            int ticks = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            return;
                        case ConsoleKey.N:
                            sauna.TurnOn();
                            break;
                        case ConsoleKey.F:
                            sauna.TurnOff();
                            break;
                    }
                }
                else
                {
                    ticks++;
                    if (ticks % 100 == 0)
                    {
                        sauna.Update();
                        Console.WriteLine("Temperature: " + Math.Round(sauna.TemperatureCelsius, 1) + "°C");
                    }
                }
            }
        }

        public static void Assignment2()
        {

        }
        public static void Assignment3()
        {

        }
        public static void Assignment4()
        {
            Vehicle vehicle = new Vehicle() { Name = "Test", Speed = 100, Tyres = 4 };
            vehicle.PrintData();
        }
    }
}
