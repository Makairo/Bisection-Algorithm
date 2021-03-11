using System;
using System.Collections.Generic;
using System.Text;

namespace EX_9A_Bisection_Algorithm
{
    class GuessNumber
    {
        private static Random rand = new Random();
        private static int numTimes = 0;
        public static void HumanPlays()
        {
            int number = rand.Next(0,1001);
            int guess = 0;

            Console.WriteLine($"I'm thinking of a number between 0 and 1000, can you guess what it is?");
            guess = Int32.Parse(Console.ReadLine());

            while (guess != number)
            {
                Console.WriteLine($"{guess} is {( guess > number ? "higher" : "lower" ) } than my number.");
                Console.WriteLine("Guess again: ");
                guess = Int32.Parse(Console.ReadLine());
                numTimes++;
            }

            Console.WriteLine($"You got it! My number was {number}. It took you {numTimes} guesses.");
            numTimes = 0;
        }
        public static void ComputerPlays()
        {
            string LH = "";
            bool correct = false;
            int guess = 0;
            int min = 0;
            int max = 100;

            Console.WriteLine($"Think of a number between 0 and 100. I'll guess what it is! Press any key to start.");
            Console.ReadKey(true);

            while (correct == false)
            {
                guess = rand.Next(min, max + 1);
                Console.WriteLine($"Is your number {guess}? If not, am I too high or low? (Enter Y / H / L)");
                while(LH != "H" && LH != "L" && LH != "Y")
                {
                    LH = Console.ReadLine();
                    LH = LH.ToUpper();
                }
                
                if(LH == "Y")
                {
                    correct = true;
                }
                if (LH == "H")
                {
                    max = guess - 1;
                }
                if (LH == "L")
                {
                    min = guess + 1;
                }
                LH = "";
                numTimes++;
            }

            Console.WriteLine($"I got it! Your number was {guess}. It took me {numTimes} guesses.");
            numTimes = 0;
        }
    }
}
