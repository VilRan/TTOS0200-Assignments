using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Collections
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
            CD cd = new CD();

            cd.Title = "Current Thoughts";
            cd.Artist = "Me";

            cd.Songs.Add(new Song() { Title = "Not Very Creative", Duration = TimeSpan.FromSeconds(174) });
            cd.Songs.Add(new Song() { Title = "Boredom Strikes", Duration = TimeSpan.FromSeconds(253) });
            cd.Songs.Add(new Song() { Title = "I want to go play XCOM", Duration = TimeSpan.FromSeconds(312) });
            cd.Songs.Add(new Song() { Title = "Legend/Ironman", Duration = TimeSpan.FromSeconds(6321) });
            cd.Songs.Add(new Song() { Title = "The Only Way to Play", Duration = TimeSpan.FromSeconds(5236) });
            cd.Songs.Add(new Song() { Title = "This Should Be Enough", Duration = TimeSpan.FromSeconds(21) });

            Console.WriteLine(cd.Information);
        }

        public static void Assignment3()
        {
            Random random = new Random();
            List<PlayingCard> cards = PlayingCard.FullDeck.OrderBy(c => random.Next()).ToList();

            foreach (PlayingCard card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
