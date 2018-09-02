using System;
using System.Linq;
using System.IO;

namespace practice2
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @"C:\Users\t-g-l\csharp-workbook\practice2\words.txt";
            int lineCount = File.ReadLines(file).Count();
            string userGuess = "";
            int userGuessInt = 0;
            int wordToGuessInt = 0;
            bool guessedRight = false;
            string wordToGuess = "";
            int numGuesses = 0;


            GenerateWordToGuess();
            Console.WriteLine(wordToGuess);   // uncomment this line if you want the answer
            // Console.WriteLine(wordToGuessInt);

            while (!guessedRight)
            {
                GetUserGuess();
                numGuesses++;
                GetUserGuessInt();
                CheckForWin();
                BeforeOrAfter();
            }



            void GenerateWordToGuess()
            {
                Random rnd = new Random();
                wordToGuessInt = rnd.Next(0, lineCount);
                wordToGuess = File.ReadLines(file).Skip(wordToGuessInt).Take(1).First();
            }

            void GetUserGuess()
            {
                Console.WriteLine("I have a word in my mind. It might be a bad word. Guess it. You have guessed {0} times so far", numGuesses);
                userGuess = Console.ReadLine();
            }

            void GetUserGuessInt()
            {
                int counter = 1;
                foreach (string line in System.IO.File.ReadLines(file))
                {
                    if (line == userGuess)
                    {
                        // System.Console.WriteLine("Found it at line {0}!", counter);
                        userGuessInt = counter;
                        // System.Console.WriteLine(userGuessInt + " is the userGuessInt for " + userGuess);
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }

            void CheckForWin()
            {
                if (userGuess == wordToGuess)
                {
                    System.Console.WriteLine("You won!");
                    guessedRight = true;
                }
            }

            void BeforeOrAfter()
            {
                int difference = userGuessInt - wordToGuessInt;
                if (difference > 0)
                {
                    System.Console.WriteLine("You guessed wrong. Your guess is after my guess");
                }
                else
                {
                    System.Console.WriteLine("You guessed wrong. Your guess is before my guess");
                }
            }
        }
    }
}
