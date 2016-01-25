using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Program
    {
        const int Assignments = 5;

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
                Console.WriteLine();
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
                        Console.WriteLine("Temperature: " + Math.Round(sauna.Celsius, 1) + "°C");
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

        public static void Assignment5()
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Course("Programming", 7, false) );
            courses.Add(new Course("Mathematics", 5, false));
            courses.Add(new Course("Physics", 3, false));
            courses.Add(new Course("Something", 5, true));

            Random random = new Random();
            int numStudents = 100;
            int idCounter = 1000;
            List<Student> students = new List<Student>(numStudents);
            for (int i = 0; i < numStudents; i++)
            {
                Student student = new Student(Person.GenerateDateOfBirth(random), Person.GenerateName(random), "" + idCounter++);
                foreach (Course course in courses)
                {
                    student.Enroll(course);
                    if (course.IsGradeless)
                        student.GiveGrade(course, random.Next(2) == 1);
                    else
                        student.GiveGrade(course, random.Next(6));
                }
                students.Add(student);
            }
            
            foreach (Student student in students.OrderBy(s => s.StudyCredits).ThenBy(s => s.WeightedAverageGrade))
            {
                Console.WriteLine("ID: {1:D}, Name: {0},  Avg Grade: {2:N}, Weighted Avg: {3:N}, Credits: {4:D}", 
                    student.Name, student.StudentID, student.AverageGrade, student.WeightedAverageGrade, student.StudyCredits);
            }
            
        }

    }
}
