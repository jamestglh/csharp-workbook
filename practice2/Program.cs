using System;
using System.Linq;
using System.IO;

namespace practice2
{
    class Program
    {
        public static void Main(string[] args)
        {

            string file = @"C:\Users\t-g-l\csharp-workbook\practice2\words.txt";
            int lineCount = File.ReadLines(file).Count();
            string userGuess = "";
            int userGuessInt = 0;
            int wordToGuessInt = 0;
            bool guessedRight = false;
            string wordToGuess = "";
            int numGuesses = 0;




            PlayGame();

            void PlayGame(){
                GenerateWordToGuess();
                while (!guessedRight)
                {
                                
                    // Console.WriteLine(wordToGuess + " " + wordToGuessInt);   // uncomment this line if you want the answer
                    GetUserGuess();
                    numGuesses++;
                    GetUserGuessInt();
                    CheckForWin();
                    BeforeOrAfter();

                }
            }

            void PlayAgain(){
                System.Console.WriteLine("Do you want to play again? (Y/N)");
                string input = Console.ReadLine();

                if (input.ToUpper() == "Y")
                {
                    guessedRight = false;
                    PlayGame();

                }
                else
                {
                    Environment.Exit(0);
                }
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
                    System.Console.WriteLine("You won! It only took you {0} tries!", numGuesses);
                    guessedRight = true;
                    numGuesses = 0;
                    userGuessInt = 0;
                    wordToGuessInt = 0;
                    userGuess = null;
                    PlayAgain();
                }
            }

            void BeforeOrAfter()
            {
                if ((userGuessInt < 1) || (userGuessInt > 58110))
                {
                    // System.Console.WriteLine("userGuessInt is "+userGuessInt +" and wordToGuess int is " +wordToGuessInt);
                    System.Console.WriteLine("Your guess isn't in my dictionary, so I can't tell you if it's before or after my secret word.");
                }
                else if (userGuessInt > wordToGuessInt)
                {
                    // System.Console.WriteLine("userGuessInt is "+userGuessInt +" and wordToGuess int is " +wordToGuessInt);
                    System.Console.WriteLine("You guessed wrong. Your guess is after my guess");
                }
                else if (userGuessInt < wordToGuessInt)
                {
                    // System.Console.WriteLine("userGuessInt is "+userGuessInt +" and wordToGuess int is " +wordToGuessInt);
                    System.Console.WriteLine("You guessed wrong. Your guess is before my guess");
                }
                
        }
    }
}}
