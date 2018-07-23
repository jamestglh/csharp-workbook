using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            string player1Hand = "";
            int player1Score = 0;
            string comHand = "";
            int comScore = 0;
            int ties = 0;
            string[] rps = new string[] {"rock", "paper", "scissors"};

            PlayerTurn();
            ComTurn();
            WinCheck();
            Scoreboard();
            PlayAgain();

            void PlayerTurn(){
                    Console.WriteLine("Please type 1 for Rock, 2 for Paper, or 3 for Scissors and press the Enter key: ");
                    // int player1Choice = Convert.ToInt32(Console.ReadLine()) - 1;
                    string player1Choice = Console.ReadLine();
                    System.Threading.Thread.Sleep(500);
                    if ((player1Choice == "1") || (player1Choice == "2") || (player1Choice == "3"))
                    {
                        player1Hand = rps[Convert.ToInt32(player1Choice) - 1];
                        Console.WriteLine("You chose " + player1Hand +".");
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {
                        Console.WriteLine("Your choice is invalid. Choose again.");
                        System.Threading.Thread.Sleep(500);
                        PlayerTurn();
                    }
            }

            void ComTurn(){
                Random rnd = new Random();
                int roll = rnd.Next(0, 2);  
                comHand = rps[roll];
                Console.WriteLine("The Computer Mastermind chose " + comHand + ".");
                System.Threading.Thread.Sleep(500);
            }

            void WinCheck(){

                if (player1Hand == comHand){
                    Console.WriteLine("That's a tie!");
                    ties ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "rock" && comHand == "paper"){
                    Console.WriteLine("Paper beats rock! You lose!");
                    comScore ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "rock" && comHand == "scissors"){
                    Console.WriteLine("Rock beats scissors! You win!");
                    player1Score ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "scissors" && comHand == "paper"){
                    Console.WriteLine("Scissors beats paper! You win!");
                    player1Score ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "scissors" && comHand == "rock"){
                    Console.WriteLine("Rock beats scissors! You lose!");
                    comScore ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "paper" && comHand == "rock"){
                    Console.WriteLine("Paper beats rock! You win!");
                    player1Score ++;
                    System.Threading.Thread.Sleep(500);
                }
                else if (player1Hand == "paper" && comHand == "scissors"){
                    Console.WriteLine("Scissors beats paper! You lose!");
                    comScore ++;
                    System.Threading.Thread.Sleep(500);
                }
            }

            // void WinCheckSmall(){
            //     if (player1Hand == comHand){
            //     Console.WriteLine("That's a tie!");
            //     ties ++;
            //     }
            //     else if (player1Hand == "rock" && comHand == "paper") || (player1Hand == "scissors" && comHand == "rock") {
            //     Console.WriteLine("Paper beats rock! You lose!");
            //     comScore ++;
            //     }
            // }

            void Scoreboard(){
                // Console.WriteLine("CURRENT SCORE: \n PLAYER 1: " + player1Score + "\nCOMPUTER MASTERMIND SCORE: " + comScore);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("            CURRENT SCORE:          ");
                Console.WriteLine("   PLAYER 1: " + player1Score);
                Console.WriteLine("   COMPUTER MASTERMIND: " + comScore);
                Console.WriteLine("   TIES: " + ties);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); 
                System.Threading.Thread.Sleep(500);
            }

            void PlayAgain() {
                string[] yes =  { Convert.ToString('y'), Convert.ToString('Y'), "yes", "Yes", "YES"};
                Console.WriteLine("Do you want to try again? [y/n]");
                for (int i = 0; i < yes.Length; i++)
                {
                    string choice = Console.ReadLine();
                    if (choice == yes[i]) 
                    {
                        Console.Clear();
                        PlayerTurn();
                        ComTurn();
                        WinCheck();
                        Scoreboard();
                        PlayAgain();
                    }
                    else
                    {
                        Console.WriteLine("Bye! Thanks for playing!");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
