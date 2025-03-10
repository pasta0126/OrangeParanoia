using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class AnswerService(IArrayService arrayService) : IAnswerService
    {
        public string GetMagic8BallAnswer()
        {
            string[] magic8BallAnswers =
            [
                "It is certain.",
                "It is decidedly so.",
                "Without a doubt.",
                "Definitely yes.",
                "You may rely on it.",
                "As I see it, yes.",
                "Most likely.",
                "The outlook is good.",
                "Yes.",
                "Signs point to yes.",
                "Reply hazy, try again.",
                "Ask again later.",
                "Better not tell you now.",
                "Cannot predict now.",
                "Concentrate and ask again.",
                "Don't count on it.",
                "My answer is no.",
                "My sources say no.",
                "Outlook not so good.",
                "Very doubtful."
            ];

            return arrayService.GetRandomValue(magic8BallAnswers);
        }

        public string GetYesNoAnswer()
        {
            return arrayService.GetRandomValue(["Yes", "No"]);
        }

        public string GetTrueFalseAnswer()
        {
            return arrayService.GetRandomValue(["True", "False"]);
        }
    }
}
