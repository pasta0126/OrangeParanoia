using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Cards(ICardService cardService)
    {
        public List<string> Tarot(int count, bool isSpanish = false)
        {
            return cardService.GetTarotCards(count, isSpanish);
        }

        public List<string> Poker(int count)
        {
            return cardService.GetPokerCards(count);
        }

        public List<string> Spanish(int count)
        {
            return cardService.GetSpanishCards(count);
        }

        public List<string> Uno(int count)
        {
            return cardService.GetUnoCards(count);
        }
    }
}
