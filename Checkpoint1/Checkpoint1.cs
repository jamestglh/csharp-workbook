using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MainMenu();

            int userChoice = 0;
            void MainMenu(){
                Console.WriteLine("Welcome to Checkpoint 1. Please select a choice:");
                Console.WriteLine("1. Divisible by 3 tool");
                Console.WriteLine("2. Addition tool");
                Console.WriteLine("3. Factorial tool");
                Console.WriteLine("4. Guess a number");
                Console.WriteLine("5. Find largest number");

                if (Int32.TryParse(Console.ReadLine(), out userChoice))
                {
                    if (userChoice == 1)
                    {
                        Problem1();
                    }
                    else if (userChoice == 2)
                    {
                        Problem2();
                    }
                    else if (userChoice == 3)
                    {
                        Problem3();
                    }
                    else if (userChoice == 4)
                    {
                        Problem4();
                    }
                    else if (userChoice == 5)
                    {
                        Problem5();
                    }
                    else  
                    {
                        Console.WriteLine("That was an invalid choice");
                        MainMenu();
                    }
                }
                else 
                {
                    Console.WriteLine("That was an invalid choice");
                    MainMenu();
                }

            }

            
            // 1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
            void Problem1(){
                int divisibleCount = 0;
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0)
                    {
                        divisibleCount++;
                        Console.WriteLine(i + " is divisible by 3. That makes " + divisibleCount + " numbers so far that are divisible by 3.");
                    }
                }
                Console.WriteLine("Counting done. There are " + divisibleCount + "numbers between 1 and 100 that are divisble by 3.");

                
            }
            

            // 2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
            void Problem2(){
                int playerChoice = 0;
                List<int> numbers = new List<int>();
                GetNumber();

                void GetNumber(){
                    Console.WriteLine("Please enter a number, or type ok if you are done entering numbers");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out playerChoice))
                    {
                        numbers.Add(playerChoice);
                        GetNumber();
                    }
                    else if (input == "ok")
                    {
                        int sum = numbers.Sum();
                        Console.WriteLine("The sum of the numbers you entered is " + sum);
                        MainMenu();
                    }
                    else 
                    {
                        Console.WriteLine("Your choice was invalid." );
                        GetNumber();
                    }
                }
            }


            // 3- Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
            void Problem3(){
                long userNumber = 0;
                long i = 0;
                
                Console.WriteLine("Enter a number: ");
                // userNumber = int.Parse(Console.ReadLine());    
                if (long.TryParse((Console.ReadLine()), out userNumber))
                {
                    long factorial = userNumber;
                    for (i = userNumber - 1; i >= 1; i--)
                    {
                            factorial = factorial * i;
                    }
                    Console.WriteLine("The factorial of " + userNumber + " is " + factorial);
                    MainMenu();
                }
                    else 
                    {
                        Console.WriteLine("Your choice was invalid." );
                        Problem3();
                    }


            }

            // 4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)
            void Problem4(){
                int chances = 4;
                int guess = 0;
                Random rnd = new Random();
                int compChoice = rnd.Next(1, 10);

                GuessingTime();

                void GuessingTime(){
                    Console.WriteLine("The computer mastermind has chosen a number between 1 and 10. Can you guess it correctly?");
                    while (chances > 0)
                    {
                        Console.WriteLine("Type a number between 1 and 10 and press Enter");
                        if (Int32.TryParse((Console.ReadLine()), out guess))
                        {
                            if ((guess > 10) || (guess < 1 ))
                            {
                                Console.WriteLine("Your selection is invalid.");
                                Problem4();
                            }
                            else if (guess == compChoice)
                            {
                                Console.WriteLine("You guessed right with " + chances + " chances left! You win!");
                                MainMenu();
                            }
                            else
                            {
                                chances--;
                                Console.WriteLine("You guessed wrong! You have " + chances + " chances left!");
                                
                            }

                        }
                        else 
                        {
                            Console.WriteLine("Your choice was invalid." );
                            Problem4();
                        }
                    }
                    Console.WriteLine("You ran out of guesses! You lose! The computer mastermind's number was " + compChoice);
                    MainMenu();
                }
   
            }
            // 5- Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
            void Problem5(){
                Console.WriteLine("Input a bunch of numbers separated by commas, then press enter");
                string input = Console.ReadLine();
                
                string[] numbers = (input).Split(",");
                int[] numbersInt = new int[numbers.Length];
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (Int32.TryParse(numbers[i], out numbersInt[i]))
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("One of your inputs was invalid, please try again");
                        Problem5();
                    }

                }
                Console.WriteLine("The largest number you entered is " + numbersInt.Max());
                MainMenu();
                

                
            }
        }
    }
}
