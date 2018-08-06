using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            string player1Hand = null;
            int player1Score = 0;
            string comHand = "";
            int comScore = 0;
            int ties = 0;
            string[] rps = new string[] {"rock", "paper", "scissors"};

            while(player1Hand == null)
            {
                try
                {
                    player1Hand = PlayerTurn();
                    break;
                }
                catch(Exception)
                {
                    Console.WriteLine("Your choice is invalid. Choose again.");
                }
                finally
                {
                    Console.WriteLine("Returning. Have a wonderful day.");
                }

            }

            ComTurn();
            WinCheck();
            Scoreboard();
            PlayAgain();

            String PlayerTurn(){
                    Console.WriteLine("Please type 1 for Rock, 2 for Paper, or 3 for Scissors and press the Enter key: ");
                    String player1Choice = Console.ReadLine().Trim();
                    System.Threading.Thread.Sleep(500);

                    if (player1Choice == "alakazam")
                    {
                        player1Score++;
                        Console.WriteLine("You automatically won with the secret code mofo. Good job cheater.");
                        Scoreboard();
                        PlayAgain();
                        
                    }
                    else if ((player1Choice != "1") && (player1Choice != "2") && (player1Choice != "3"))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        player1Hand = rps[Convert.ToInt32(player1Choice) - 1];
                        Console.WriteLine("You chose " + player1Hand +".");
                        System.Threading.Thread.Sleep(500);
                    }
                    return player1Hand;
            }

            void ComTurn(){
                Random rnd = new Random();
                int roll = rnd.Next(0, 3);  
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
            void Scoreboard(){
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
                        player1Hand = null;
                        while(player1Hand == null)
                        {
                            try
                            {
                                player1Hand = PlayerTurn();
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Your choice is invalid. Choose again.");
                            }
                            finally
                            {
                                Console.WriteLine("Returning. Have a wonderful day.");
                            }

                        }
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
