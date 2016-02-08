using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs }
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    class PlayingCard
    {
        public Suit Suit;
        public Rank Rank;

        public static IEnumerable<PlayingCard> FullDeck
        {
            get
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                        yield return new PlayingCard() { Suit = suit, Rank = rank };
            }
        }

        public override string ToString()
        {
            return "" + Rank + " of " + Suit;
        }
    }
}
