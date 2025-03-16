using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia
{
    public class Answer(IAnswerService answerservice)
    {
        public string Magic8BallAnswer()
        {
            return answerservice.GetMagic8BallAnswer();
        }
        public string YesNo()
        {
            return answerservice.GetYesNoAnswer();
        }
        public string TrueFalse()
        {
            return answerservice.GetTrueFalseAnswer();
        }
    }
}
