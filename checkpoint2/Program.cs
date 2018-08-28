using System;
using System.Linq;
using System.Collections.Generic;

namespace checkpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checkerspoint 2");
            Game myGame = new Game();
            myGame.Start();
            
        }
    }
    public class Game
    {
        //"the only thing in the Game class should be the Start method"
        public void Start()
        {
            Board aBoard = new Board();
            // Console.WriteLine(int.Parse("25CB", System.Globalization.NumberStyles.HexNumber));
            // Console.WriteLine(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber));
            aBoard.GenerateCheckers();
            while (!aBoard.hasWon)
            {
                aBoard.SwitchPlayers();
                aBoard.PlaceCheckers();
                aBoard.DrawBoard();
                aBoard.MoveChecker();
            }         
        }
        public Game(){}
    }
    public class Board
    {
        public String[,] grid = new String[8,8];
        public bool hasWon = false;
        public string playerColor = "white";
        public List<Checker> checkers {get;set;}
        public Board()
        {
            this.checkers = new List<Checker>();
        }
        //this is where we will need to build some methods to CreateBoard(board constructor), DrawBoard, GenerateBoard, SelectChecker, CheckValidMove(checkerposition[],tox,toy)RETURNBOOL, MoveChecker, RemoveChecker, and CheckForWin(take in color, did white win true false)
        public void DrawBoard()
        {
            
            Console.WriteLine("   01234567");  
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == null) // if spot on grid doesnt have a checker, a space is written so the spacing doesnt get all fucked up
                    {
                        Console.Write(" ");
                    }
                    Console.Write(grid[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void GenerateCheckers(){ // generate checkers only runs once at the beginning of the game. it creates all of the white and black checkers and gives them the correct coords
            for (int i = 0; i < 3; i++) // iterate through columns where whites should go
            {
                for (int j = 0; j < 8; j++) //iterate through rows
                {
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        checkers.Add(new Checker(true, i,j));
                    }
                }
            }
            //for black
            for (int i = 5; i < 8; i++) // iterate through columns where black should go
            {
                for (int j = 0; j < 8; j++) //iterate through rows
                {
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        checkers.Add(new Checker(false, i, j));
                        // Console.WriteLine("adding black checker to list at coordinate {0} {1}", i,j);
                    }
                }
            }

            // foreach (Checker c in checkers) //INTIAL CHECKER PLACEMENT CHECK
            // {
            //     Console.WriteLine("Checker at X " + c.xPos + " and Y " + c.yPos); 
            // }

        }
        public void PlaceCheckers() //this is what reads the checker coordinates and puts it in the grid in the right place
        {
            for (var i = 0; i < checkers.Count; i++)
            {
                int[] position = checkers[i].position;
                grid[position[0],position[1]] = checkers[i].symbol;
            }
            return;
        }
        public void MoveChecker(){

            int[] validInput = new int[] {0,1,2,3,4,5,6,7};
            Console.WriteLine("Enter Pickup Row: ");
            int fromX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Pickup Column: ");
            int fromY = Convert.ToInt32(Console.ReadLine());
            Checker checkerToMove = SelectChecker(fromX, fromY);   

            if (!validInput.Contains(fromX) || !validInput.Contains(fromY)) // CHECKS IF INPUT IS OUT OF BOUNDS
            {
                Console.WriteLine("Your selection is out of bounds of the board");
                return;
            }       
            else if (checkerToMove == null) // CHECKS IF A CHECKER IS THERE
            {
                Console.WriteLine("You chose an empty space. Please choose again.");
                return;
            }
            else if (checkerToMove.color != playerColor) //CHECKS TO SEE IF IT'S THE RIGHT PLAYER's CHECKER
            {
                 Console.WriteLine("You chose the wrong colored checker. Please choose again.");
                 return;
            }


            Console.WriteLine("Enter Placement Row: ");
            int toX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Placement Column: ");
            int toY = Convert.ToInt32(Console.ReadLine());


            //DO CHECKS HERE
            //if y or x are lower than 0, or if y or x are greater than 7 don't allow
            if (!validInput.Contains(toX) || !validInput.Contains(toY)) // CHECKS IF DESTINATION IS OUT OF BOUNDS
            {
                Console.WriteLine("Your destination is out of bounds of the board");
                return;
            }
            //destination cant have another checker of the same color
            if ((grid[toX,toY] != null) && (SelectChecker(toX, toY).color == checkerToMove.color)) //CHECKS IF DESTINATION HAS A CHECKER OF THE SAME COLOR
            {
                Console.WriteLine("You aren't allowed to land on another checker of your color");
                return;
            }
            //blacks can only move y-1 and either x-1 or x+1
            if (Math.Abs(fromY - toY) > 1 || Math.Abs(fromX - toX) > 1) //only allows user to choose 1 spot away
            {
                Console.WriteLine("Your destination is illegal. You can only move diagonally 1 space. If you want to jump an enemy checker, choose it's location.");
                return;
            }
            //whites can only move y+1 and either x-1 or x+1
            if ((grid[toX,toY] != null) && (checkerToMove.color == SelectChecker(toX,toY).color))
            {
                //remove checker you just jumped on
                //double the move for checkerToMove
            }

            // if opposite colored checker is in location where you want to jump, double the move (if its x+1 and y+1 do x+2 and y+2) 
            //also let the same player go again if they take out a checker, so they can chain jumps, but they cant change checkers (not sure how to do this yet)

            checkerToMove.position[0] = toX;
            checkerToMove.position[1] = toY;

            grid[fromX,fromY] = null;

            // foreach (Checker c in checkers) // this is just a console for troubleshooting to ensure that the coordinates of the checkers are really updating
            // {
            //     Console.WriteLine(c.color + " checker at X " + c.xPos + " and Y " + c.yPos); 
            // }
        }

        public Checker SelectChecker(int row, int column) //selectchecker takes in x,y, returns checker or null, or throws exception
        {
            return checkers.Find(x => x.position.SequenceEqual(new List<int> { row, column }));
        }

        public bool CheckForWin()  
        {
            return checkers.All(x => x.color == "white") || !checkers.Exists(x => x.color == "white");
        }

        public void SwitchPlayers()
        {
            if (playerColor == "white")
            {
                Console.WriteLine("White Turn");
                playerColor = "black";
            }
            else
            {
                Console.WriteLine("Black Turn");
                playerColor = "white";
            }
        }



    }
    public class Checker
    {
        public String symbol {get;private set;}
        public String color {get;private set;}
        public int[] position = new int[2];
        public bool isWhite {get;private set;}

        public int xPos {get;set;}
        public int yPos {get;set;}

        public Checker(bool isWhite, int xPos, int yPos)
        {

            this.color = color;
            this.symbol = symbol;
            int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            this.xPos = xPos;
            this.yPos = yPos;
            position[0] = xPos;
            position[1] = yPos;

            if (isWhite)
            {
                color = "white";
                string openCircle = char.ConvertFromUtf32(openCircleId);
                // symbol = openCircle;
                symbol = "X";
            }
            else
            {
                color = "black";
                string closedCircle = char.ConvertFromUtf32(closedCircleId);
                // symbol = closedCircle;
                symbol = "O";
            }
        }
    }

}
