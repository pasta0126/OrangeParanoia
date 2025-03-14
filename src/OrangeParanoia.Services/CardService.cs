using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class CardService(IArrayService arrayService) : ICardService
    {
        private readonly IArrayService _arrayService = arrayService;
        private readonly Random _random = new();

        public List<string> GetTarotCards(int count, bool isSpanish = false)
        {
            if (count < 1) count = 1;

            string[] tarotMajorArcana =
            {
                "1-The Fool",
                "2-The Magician",
                "3-The High Priestess",
                "4-The Empress",
                "5-The Emperor",
                "6-The Hierophant",
                "7-The Lovers",
                "8-The Chariot",
                "9-Justice",
                "10-The Hermit",
                "11-Wheel of Fortune",
                "12-Strength",
                "13-The Hanged Man",
                "14-Death",
                "15-Temperance",
                "16-The Devil",
                "17-The Tower",
                "18-The Star",
                "19-The Moon",
                "20-The Sun",
                "21-Judgement",
                "22-The World"
            };

            if (isSpanish)
            {
                string[] tarotArcanosMayores =
                {
                    "1-El Loco",
                    "2-El Mago",
                    "3-La Sacerdotisa",
                    "4-La Emperatriz",
                    "5-El Emperador",
                    "6-El Hierofante",
                    "7-El Enamorado",
                    "8-El Carro",
                    "9-La Justicia",
                    "10-El Ermitaño",
                    "11-La Rueda de la Fortuna",
                    "12-La Fuerza",
                    "13-El Colgado",
                    "14-La Muerte",
                    "15-La Templanza",
                    "16-El Diablo",
                    "17-La Torre",
                    "18-La Estrella",
                    "19-La Luna",
                    "20-El Sol",
                    "21-El Juicio",
                    "22-El Mundo"
                };

                tarotMajorArcana = tarotArcanosMayores;
            }

            var deck = tarotMajorArcana.ToList();
            count = Math.Min(count, deck.Count);

            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(deck.Count);
                result.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return result;
        }

        public List<string> GetPokerCards(int count)
        {
            if (count < 1) count = 1;

            string[] ranks = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"];
            string[] suits = ["Clubs", "Diamonds", "Hearts", "Spades"];

            var deck = new List<string>();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            count = Math.Min(count, deck.Count);

            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(deck.Count);
                result.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return result;
        }

        public List<string> GetSpanishCards(int count)
        {
            if (count < 1) count = 1;

            string[] ranks = ["As", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Sota", "Caballo", "Rey"];
            string[] suits = ["Oros", "Copas", "Espadas", "Bastos"];

            var deck = new List<string>();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add($"{rank} de {suit}");
                }
            }

            count = Math.Min(count, deck.Count);

            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(deck.Count);
                result.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return result;
        }

        public List<string> GetUnoCards(int count)
        {
            if (count < 1) count = 1;

            string[] colors = ["Red", "Blue", "Green", "Yellow"];
            string[] numberCards = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
            string[] actionCards = ["Skip", "Reverse", "Draw Two"];
            string[] wildCards = ["Wild", "Wild Draw Four"];

            var deck = new List<string>();

            foreach (var color in colors)
            {
                deck.Add($"{color} 0");

                for (int i = 1; i < numberCards.Length; i++)
                {
                    deck.Add($"{color} {numberCards[i]}");
                }

                foreach (var action in actionCards)
                {
                    deck.Add($"{color} {action}");
                }
            }

            foreach (var wild in wildCards)
            {
                deck.Add(wild);
            }

            count = Math.Min(count, deck.Count);

            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(deck.Count);
                result.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return result;
        }
    }
}
