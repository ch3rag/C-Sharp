using System;
using System.ServiceModel;

namespace MagicEightBallServiceLib
{
    public class MagicEightBallService : IEightBall
    {
        public MagicEightBallService() {
            Console.WriteLine("The 8-Ball awaits your question..");
        }



        public string ObtainAnswerToQuestion(string userQuestion) {
            string[] answers = { "Future Uncertain", "Yes", "No", "Hazy", "Ask Again Later", "Definitely" };
            Random rand = new Random();
            return answers[rand.Next(answers.Length)];
        }
    }
}
