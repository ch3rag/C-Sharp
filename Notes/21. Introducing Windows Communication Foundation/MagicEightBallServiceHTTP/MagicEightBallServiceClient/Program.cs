using System;
using MagicEightBallServiceClient.ServiceReference1;

namespace MagicEightBallServiceClient {
    class Program {
        static void Main(string[] args) {
            using (EightBallClient ball = new EightBallClient()) {
                Console.Write("Your question: ");
                string question = Console.ReadLine();
                string answer = ball.ObtainAnswerToQuestion(question);
                Console.WriteLine("8-Ball says: {0}", answer);
            }
            Console.ReadLine();
        }
    }
}
