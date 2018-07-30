using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "O";
        public static int turnNumber = 0;
        
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()

        {
            do
            {
                DrawBoard();
                ChangePlayer();
                GetInput();

            } while (!CheckForWin() && !CheckForTie());
            
            // leave this command at the end so your program does not close automatically
             PlayAgain();
             Console.ReadLine();
        }

        public static void GetInput()
        {
            Console.WriteLine("Turn #" + turnNumber);
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());

            if ((row == 0) || (row == 1) || (row == 2)) //check to make sure row input is valid
                    {
                        
                        Console.WriteLine("You chose " + row +".");
                    }
                    else
                    {
                        Console.WriteLine("Your row choice is invalid. Choose again.");
                        GetInput();
                    }

            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());

            if ((column == 0) || (column == 1) || (column == 2)) //check to see if column input is valid
                    {
                        
                        Console.WriteLine("You chose " + column +".");
                    }
                    else
                    {
                        Console.WriteLine("Your column choice is invalid. Choose again.");
                        GetInput();
                    }
        
            if (board[row][column] == " ") //checks to see if space is already occupied
            {
                PlaceMark(row, column);
            }
            else
            {
                Console.WriteLine("That space is already taken, please choose another space");
                GetInput();
            }
        }

        public static void PlaceMark(int row, int column)
        {
         board[row][column] = playerTurn;
         //DrawBoard();
         turnNumber ++;
        }

        public static bool CheckForWin()
        {
            bool won = false;
             if (HorizontalWin() || VerticalWin() || DiagonalWin())
             {
                 won = true;
                 Console.WriteLine("Player " + playerTurn + " Wins in " + turnNumber + " moves!");
                 turnNumber = 0;
             }

            return won;
            
        }

        public static bool CheckForTie()
        {
            bool tie = false;
            if (turnNumber >= 9 )
            
            {
                turnNumber = 0;
                tie = true;
                Console.WriteLine("It's a tie! No one wins! Sucker!");
            }

            return tie;
            
        }
        
        public static bool HorizontalWin()
        {
        // your code goes here
        if (board[0][0] == playerTurn && board[0][0] == board[0][1] && board[0][1] == board[0][2]) //check row 0
        {
            return true;
        }
        else if (board[1][0] == playerTurn && board[1][0] == board[1][1] && board[1][1] == board[1][2]) //check row 1
        {
            return true;
        }
        else if ((board[2][0] == playerTurn && board[2][0] == board[2][1] && board[2][1] == board[2][2])) //check row 2
        {
            return true;
        }
        return false;
        }

        public static bool VerticalWin()
        {
         if (board[0][0] == playerTurn && board[1][0] == board[0][0] && board[1][0] == board[2][0]) //check col 0
        {
            return true;
        }
        else if (board[0][1] == playerTurn && board[1][1] == board[0][1] && board[1][1] == board[2][1]) //check col 2
        {
            return true;
        }
        else if (board[0][2] == playerTurn && board[1][2] == board[0][2] && board[1][2] == board[2][2]) //check col 3
        {
            return true;
        }
        return false;
        }
        
        public static bool DiagonalWin()
        {
            if (board[0][0] == playerTurn && board[0][0] == board[1][1] && board[0][0] == board[2][2])
            {
                return true;
            }
            else if (board[0][2] == playerTurn && board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                return true;
            }
            else
            {
               return false; 
            }
            
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }

        public static void ChangePlayer() 
        {
            if (playerTurn == "O")
            {
                playerTurn = "X";
            }
            else
            {
                playerTurn = "O";
            }


            

    }

        public static void PlayAgain() {
                    string[] yes =  { Convert.ToString('y'), Convert.ToString('Y'), "yes", "Yes", "YES"};
                    Console.WriteLine("Do you want to try again? [y/n]");
                    for (int i = 0; i < yes.Length; i++)
                    {
                        string choice = Console.ReadLine();
                        if (choice == yes[i]) 
                        {
                            Console.Clear();
                            Main();
                        }
                        else
                        {
                            Console.WriteLine("Bye! Thanks for playing!");
                            Environment.Exit(0);



            }
}}}}
