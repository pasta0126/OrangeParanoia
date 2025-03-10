namespace OrangeParanoia.Services.Interfaces
{
    public interface ICardService
    {
        List<string> GetTarotCards(int count);
        List<string> GetPokerCards(int count);
        List<string> GetSpanishCards(int count);
        List<string> GetUnoCards(int count);
    }
}
