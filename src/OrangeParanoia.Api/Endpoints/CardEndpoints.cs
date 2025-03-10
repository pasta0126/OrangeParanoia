using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class CardEndpoints
    {
        public static void MapCardEndpoints(this WebApplication app)
        {
            var cardGroup = app.MapGroup("/card").WithTags("Cards");

            cardGroup.MapGet("/tarot", (ICardService cardService, int count) =>
                cardService.GetTarotCards(count));

            cardGroup.MapGet("/poker", (ICardService cardService, int count) =>
                cardService.GetPokerCards(count));

            cardGroup.MapGet("/spanish", (ICardService cardService, int count) =>
                cardService.GetSpanishCards(count));
        }
    }
}
