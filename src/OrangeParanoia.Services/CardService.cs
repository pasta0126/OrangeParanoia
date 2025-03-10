using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class CardService(IArrayService arrayService) : ICardService
    {
        private readonly Random _random = new();

        public List<string> GetTarotCards(int count)
        {
            if (count < 1) count = 1;

            string[] tarotMajorArcana =
                [
                    "The Fool",
                    "The Magician",
                    "The High Priestess",
                    "The Empress",
                    "The Emperor",
                    "The Hierophant",
                    "The Lovers",
                    "The Chariot",
                    "Strength",
                    "The Hermit",
                    "Wheel of Fortune",
                    "Justice",
                    "The Hanged Man",
                    "Death",
                    "Temperance",
                    "The Devil",
                    "The Tower",
                    "The Star",
                    "The Moon",
                    "The Sun",
                    "Judgement",
                    "The World"
                ];

            var result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                result.Add(arrayService.GetRandomValue(tarotMajorArcana));
            }

            return result;
        }

        public List<string> GetPokerCards(int count)
        {
            if (count < 1) count = 1;

            string[] ranks = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"];
            string[] suits = ["Clubs", "Diamonds", "Hearts", "Spades"];

            var result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var rank = arrayService.GetRandomValue(ranks);
                var suit = arrayService.GetRandomValue(suits);

                result.Add($"{rank} of {suit}");
            }

            return result;
        }

        public List<string> GetSpanishCards(int count)
        {
            if (count < 1) count = 1;

            string[] ranks = ["As", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Sota", "Caballo", "Rey"];
            string[] suits = ["Oros", "Copas", "Espadas", "Bastos"];

            var result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var rank = arrayService.GetRandomValue(ranks);
                var suit = arrayService.GetRandomValue(suits);

                result.Add($"{rank} de {suit}");
            }

            return result;
        }

        public List<string> GetUnoCards(int count)
        {
            if (count < 1) count = 1;

            var result = new List<string>();

            string[] colors = ["Red", "Blue", "Green", "Yellow"];
            string[] numberCards = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
            string[] actionCards = ["Skip", "Reverse", "Draw Two"];
            string[] wildCards = ["Wild", "Wild Draw Four"];

            for (int i = 0; i < count; i++)
            {
                // 20% chance to draw a wild card; 80% chance for a colored card.
                if (_random.NextDouble() < 0.2)
                {
                    var wild = arrayService.GetRandomValue(wildCards);

                    result.Add(wild);
                }
                else
                {
                    var color = arrayService.GetRandomValue(colors);

                    if (_random.NextDouble() < 0.7)
                    {
                        var number = arrayService.GetRandomValue(numberCards);

                        result.Add($"{color} {number}");
                    }
                    else
                    {
                        var action = arrayService.GetRandomValue(actionCards);

                        result.Add($"{color} {action}");
                    }
                }
            }

            return result;
        }
    }
}
