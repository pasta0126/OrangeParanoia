using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Api.Endpoints
{
    public static class AnswerEndpoints
    {
        public static void MapAnswerEndpoints(this WebApplication app)
        {
            var answerGroup = app.MapGroup("/answer").WithTags("Answers");

            answerGroup.MapGet("/magic8ball", (IAnswerService answerService) =>
                answerService.GetMagic8BallAnswer());

            answerGroup.MapGet("/yesno", (IAnswerService answerService) =>
                answerService.GetYesNoAnswer());

            answerGroup.MapGet("/truefalse", (IAnswerService answerService) =>
                answerService.GetTrueFalseAnswer());
        }
    }
}
