using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment1();
            Console.ReadLine();
        }

        static void Assignment1()
        {
            Console.Write("Enter an integer > ");
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("That's not an integer!");
                return;
            }

            switch (number)
            {
                case 1:
                    Console.WriteLine("You entered a one");
                    break;
                case 2:
                    Console.WriteLine("You entered a two");
                    break;
                case 3:
                    Console.WriteLine("You entered a three");
                    break;
                default:
                    Console.WriteLine("Enter some another integer");
                    break;
            }
        }

        static void Assignment2()
        {
            Console.Write("Enter the number of points > ");
            int points;
            if (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int grade = 0;
            if (points >= 10)
                grade = 5;
            else if (points >= 8)
                grade = 4;
            else if (points >= 6)
                grade = 3;
            else if (points >= 4)
                grade = 2;
            else if (points >= 2)
                grade = 1;

            Console.WriteLine("The matching grade is " + grade);
        }

        static void Assignment3()
        {
            Console.Write("Enter first number > ");
            double value1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter second number > ");
            double value2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter third number > ");
            double value3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Sum = " + (value1 + value2 + value3));
            Console.WriteLine("Average = " + (value1 + value2 + value3) / 3);
        }

        static void Assignment4()
        {
            Console.Write("Enter an age > ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            if (age < 18)
                Console.WriteLine("underage");
            else if (age <= 65)
                Console.WriteLine("adult");
            else
                Console.Write("senior");
        }

        static void Assignment5()
        {
            Console.Write("Enter a number of seconds > ");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int hours = input / 3600;
            int minutes = input / 60 % 60;
            int seconds = input % 60;
            Console.WriteLine("... is the same as " + hours + " hours " + minutes + " minutes and " + seconds + " seconds");
        }

        static void Assignment6()
        {
            Console.Write("Enter a distance in kilometers > ");
            double distance;
            if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out distance))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            double fuel = distance / 100 * 7.02;
            double price = fuel * 1.595;
            Console.WriteLine("Fuel spent: " + fuel + " liters, price: " + price + " euros");
        }

        static void Assignment7()
        {
            Console.Write("Enter a year > ");
            int year;
            if (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
            if (isLeapYear)
                Console.WriteLine("The year is a leap year.");
            else
                Console.WriteLine("The year is not a leap year.");

        }

        static void Assignment8()
        {
            Console.Write("Enter first integer > ");
            int value1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer > ");
            int value2 = int.Parse(Console.ReadLine());
            Console.Write("Enter third integer > ");
            int value3 = int.Parse(Console.ReadLine());

            if (value1 > value2)
                if (value1 > value3)
                    Console.WriteLine("The largest integer is " + value1);
                else
                    Console.WriteLine("The largest integer is " + value3);
            else if (value2 > value3)
                Console.WriteLine("The largest integer is " + value2);
            else
                Console.WriteLine("The largest integer is " + value3);
        }

        static void Assignment9()
        {
            var values = new List<double>();
            double value;
            do
            {
                Console.Write("Enter a value > ");
                if (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                values.Add(value);
            } while (value != 0);

            Console.WriteLine("The sum of the values is " + values.Sum());
        }

        static void Assignment10()
        {
            int[] values = { 1, 2, 33, 44, 55, 68, 77, 96, 100 };
            foreach (int value in values)
            {
                if (value % 2 == 0)
                    Console.WriteLine("" + value + " is even.");
            }
        }

        static void Assignment11()
        {
            Console.Write("Enter an integer > ");

            int value;
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            for (int y = 0; y < value; y++)
            {
                for (int x = 0; x <= y; x++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        static void Assignment12()
        {
            int[] values = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter an integer > ");
                if (!int.TryParse(Console.ReadLine(), out values[i]))
                {
                    Console.WriteLine("Invalid input!");
                    i--;
                    continue;
                }
            }

            Console.Write("The integers reversed are ");
            foreach (int value in values.Reverse())
                Console.Write("" + value + ",");
        }

        static void Assignment13()
        {
            List<int> scores = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter a score > ");
                int score;
                if (!int.TryParse(Console.ReadLine(), out score))
                {
                    Console.WriteLine("Invalid input!");
                    i--;
                    continue;
                }
                scores.Add(score);
            }
            scores.Remove(scores.Min());
            scores.Remove(scores.Max());
            Console.WriteLine("Total score (minus min and max) is " + scores.Sum());
        }

        static void Assignment14()
        {
            List<int> grades = new List<int>();
            int grade = -1;
            while (true)
            {
                Console.Write("Enter a grade (0-5) > ");
                if (int.TryParse(Console.ReadLine(), out grade)
                    && grade >= 0 && grade <= 5)
                {
                    grades.Add(grade);
                }
                else break;
            }

            for (grade = 0; grade <= 5; grade++)
            {
                Console.Write("\n" + grade + ":");
                foreach (int grade2 in grades)
                    if (grade2 == grade)
                        Console.Write("*");
            }
        }

        static void Assignment15()
        {
            Console.Write("Enter an integer > ");
            int height = int.Parse(Console.ReadLine());

            int maxRadius = 0;
            if (height > 3)
                maxRadius = height - 3;
            int maxDiameter = 1 + 2 * maxRadius;

            for (int y = 0; y < height; y++)
            {
                int radius = 0;
                if (y <= height - 3)
                    radius = y;

                for (int x = 0; x < maxDiameter; x++)
                {
                    int delta = maxRadius - x;
                    if (Math.Abs(delta) <= radius)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        static void Assignment16()
        {
            int random = new Random().Next(100);
            int numGuesses = 0;
            int guess = 0;

            do
            {
                Console.Write("Guess the random integer > ");
                guess = int.Parse(Console.ReadLine());
                if (guess < random)
                    Console.WriteLine("The random integer is larger than your guess");
                else if (guess > random)
                    Console.WriteLine("The random integer is smaller than your guess");
                numGuesses++;
            } while (guess != random);

            Console.WriteLine("Congratulations, you guessed right on your " + numGuesses + " guess");
        }

        static void Assignment17()
        {
            int[] array1 = { 5, 54, 10, 20, 30, 40, 50, 105 };
            int[] array2 = { 5, 10, 15, 25, 35, 45 };
            int[] combinedArray = new int[array1.Length + array2.Length];
            int i = 0;
            foreach (int value in Enumerable.Concat(array1, array2).OrderBy(v => v))
            {
                combinedArray[i] = value;
                i++;
            }

            Console.Write("\nValues in Array 1 : ");
            foreach (int value in array1)
                Console.Write("" + value + ",");

            Console.Write("\nValues in Array 2 : ");
            foreach (int value in array2)
                Console.Write("" + value + ",");

            Console.Write("\nValues in the combined array : ");
            foreach (int value in combinedArray)
                Console.Write("" + value + ",");
        }

        static void Assignment18()
        {
            Console.Write("Enter a string > ");
            string str = Console.ReadLine();
            str = str.ToLower();
            string reversed = "";
            for (int i = str.Length - 1; i >= 0; i--)
                reversed += str[i];

            if (str == reversed)
                Console.WriteLine("The string is a palindrome");
            else
                Console.WriteLine("The string is not a palindrome");
        }

        static void Assignment19()
        {
            Console.WriteLine("Try to guess the word");

            string word = "secret";
            List<char> guessedLetters = new List<char>();

            int guessesRemaining = 5;
            do
            {
                Console.WriteLine();

                string visibleWord = "";
                foreach (char letter in word)
                    if (guessedLetters.Contains(letter))
                        visibleWord += letter;
                    else
                        visibleWord += "_";
                Console.WriteLine(visibleWord);
                Console.WriteLine();

                if (word == visibleWord)
                {
                    Console.WriteLine("You won!");
                    return;
                }

                Console.Write("Letters guessed so far: ");
                foreach (char letter in guessedLetters)
                    Console.Write("" + letter + ", ");
                Console.WriteLine();

                Console.WriteLine("Remaining guesses " + guessesRemaining);

                Console.Write("Enter a letter: ");
                char guess;
                if (!char.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You have already guessed that letter.");
                    continue;
                }
                guessedLetters.Add(guess);

                if (!word.Contains(guess))
                    guessesRemaining--;
            } while (guessesRemaining > 0);

            Console.WriteLine();
            Console.WriteLine("You lost!");
        }

        static void Assignment20()
        {
            DoAsyncStuff();
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("\tHello from the main thread! " + i + ", Thread: " + Thread.CurrentThread.ManagedThreadId);
            }
        }

        static async void DoAsyncStuff()
        {
            Console.WriteLine("Beginning async stuff... " + Thread.CurrentThread.ManagedThreadId);
            int n = 2;
            Task[] tasks = new Task[n];
            /*
            for (int i = 0; i < n; i++)
            {
                tasks[i] = new Task(() => DoTaskStuff(i));
                tasks[i].Start();
                //tasks[i].RunSynchronously();
            }
            */

            tasks[0] = new Task(() => DoTaskStuff(0));
            tasks[1] = new Task(() => DoTaskStuff(1));
            tasks[0].Start();
            tasks[1].Start();

            await Task.Run(() => DoTaskStuff(n));
            Task.WaitAll(tasks);
            Console.WriteLine("Finished async stuff. " + Thread.CurrentThread.ManagedThreadId);
        }

        static void DoTaskStuff(int taskNumber)
        {
            Console.WriteLine("Beginning task " + taskNumber + ", Thread: " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("\tHello from Task " + taskNumber + ", " + i + ", Thread: " + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Finished task " + taskNumber + ", Thread: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
