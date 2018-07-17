namespace PokerEngine
{
    public class Card
    {
        public Rank rank { get; set; }
        public Suit suit { get; set; }
    }

    public enum Rank
    {
        NULL,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }
}
