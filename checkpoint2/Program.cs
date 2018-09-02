using System;
using System.Linq;
using System.Collections.Generic;

namespace checkpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checkerspoint 2. WHITE = X BLACK = O. WHITE GOES FIRST!");
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
                aBoard.PlaceCheckers();
                aBoard.DrawBoard();
                aBoard.MoveChecker();
            }
            aBoard.WhoWon();         
        }
        public Game(){}
    }
    public class Board
    {
        public String[,] grid = new String[8,8];
        public bool hasWon = false;
        public string playerColor = "white";
        public List<Checker> checkers {get;set;}
        public int whiteScore {get;set;}
        public int blackScore {get;set;}
        public Board()
        {
            this.checkers = new List<Checker>();
        }
        //this is where we will need to build some methods to CreateBoard(board constructor), DrawBoard, GenerateBoard, SelectChecker, CheckValidMove(checkerposition[],tox,toy)RETURNBOOL, MoveChecker, RemoveChecker, and CheckForWin(take in color, did white win true false)
        public void DrawBoard()
        {
            
            Console.WriteLine("   0 1 2 3 4 5 6 7 ");  
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(i + ":");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == null) // if spot on grid doesnt have a checker, a space is written so the spacing doesnt get all fucked up
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + grid[i,j]);
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
            int fromX = 0;
            int fromY = 0;
            int toX = 0;
            int toY = 0;
            string input = "";

            PlayerMove();

            void PlayerMove(){
                GetPlayerInputFrom();
                // CheckPlayerInputFrom();
                // GetPlayerInputTo();
                // CheckPlayerMove();
                // SwitchPlayers();
            }

            void GetPlayerInputFrom(){
                //GETTING PLAYER INPUT / FROM
                Console.WriteLine("Enter Pickup Row, or type \"c\" to call it a day and tally up the final score: ");
                input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    CallItADay();
                    return;
                    
                }
                if(!Int32.TryParse(input, out fromX))
                {
                    System.Console.WriteLine("Your input is invalid. Only input numbers 0-7. Try again.");
                    return;
                }
                
                Console.WriteLine("Enter Pickup Column: ");
                input = Console.ReadLine();
                if(!Int32.TryParse(input, out fromY))
                {
                    System.Console.WriteLine("Your input is invalid. Only input numbers 0-7. Try again.");
                    return;
                }
                CheckPlayerInputFrom();
            }


            void CheckPlayerInputFrom(){
                //INPUT CHECKS / FROM
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
                GetPlayerInputTo();
            }

            void GetPlayerInputTo(){
                //GETTING PLAYER INPUT / TO
                Console.WriteLine("Enter Placement Row: ");
                input = Console.ReadLine();
                if(!Int32.TryParse(input, out toX))
                {
                    System.Console.WriteLine("Your input is invalid. Only input numbers 0-7. Try again.");
                    return;
                }
                Console.WriteLine("Enter Placement Column: ");
                input = Console.ReadLine();
                if(!Int32.TryParse(input, out toY))
                {
                    System.Console.WriteLine("Your input is invalid. Only input numbers 0-7. Try again.");
                    return;
                }
                CheckPlayerMove();
            }

            void CheckPlayerMove(){
                //MOVEMENT CHECKS / TO
                Checker checkerToMove = SelectChecker(fromX, fromY);   
                if (!validInput.Contains(toX) || !validInput.Contains(toY)) // CHECKS IF DESTINATION IS OUT OF BOUNDS
                {
                    Console.WriteLine("Your destination is out of bounds of the board");
                    return;
                }
                if ((grid[toX,toY] != null) && (SelectChecker(toX, toY).color == checkerToMove.color)) //CHECKS IF DESTINATION HAS A CHECKER OF THE SAME COLOR
                {
                    Console.WriteLine("You aren't allowed to land on another checker of your color");
                    return;
                }
                if (Math.Abs(fromY - toY) > 1 || Math.Abs(fromX - toX) > 1) //making sure coordinate only increases by 1
                {
                    Console.WriteLine("Your destination is illegal. You can only move diagonally 1 space. If you want to jump an enemy checker, choose it's location.");
                    return;
                }
                if ((fromX == toX) || (fromY == toY)) //ensures they only move diagonally
                {
                    Console.WriteLine("Your destination is illegal. You can only move diagonally.");
                    return;
                }
                //checkers can only move forward 
                if (((checkerToMove.color == "black") && (fromX <= toX)) || ((checkerToMove.color == "white") && (fromX >= toX)))
                {
                    Console.WriteLine("Sorry, you can only move forward diagonally, not back.");
                    return;
                }
                //JUMPING A PIECE!!
                if ((grid[toX,toY] != null) && (SelectChecker(toX, toY).color != checkerToMove.color)) //ensuring space is not empty, and space has enemy checker in it
                {
                    if ((grid[fromX + ((toX-fromX)*2), fromY + ((toY-fromY)*2)] == null)) // ensuring space past checker to jump is empty
                    {
                        System.Console.WriteLine("You just jumped a checker!");
                        if (checkerToMove.color == "white")
                        {
                            whiteScore++;
                        }
                        else
                        {
                            blackScore++;
                        }
                        checkers.Remove(SelectChecker(toX, toY));
                        grid[toX,toY] = null;
                        toX = fromX + ((toX-fromX)*2);
                        toY = fromY + ((toY-fromY)*2);
                    }
                    else
                    {
                        System.Console.WriteLine("Sorry, you tried to jump a checker, but there's nowhere for you to land.");
                        return;
                    }
                }
                //also let the same player go again if they take out a checker, so they can chain jumps, but they cant change checkers (not sure how to do this yet)
                checkerToMove.position[0] = toX;
                checkerToMove.position[1] = toY;
                grid[fromX,fromY] = null;
                SwitchPlayers();
            }
            

            // foreach (Checker c in checkers) // this is just a console for troubleshooting to ensure that the coordinates of the checkers are really updating
            // {
            //     Console.WriteLine(c.color + " checker at X " + c.xPos + " and Y " + c.yPos); 
            // }
        }

        public void CallItADay(){
            System.Console.WriteLine("The current score is WHITE {0}, BLACK {1}", whiteScore, blackScore);
            System.Console.WriteLine("Would you like to move again, or call it a day?");
            System.Console.WriteLine("Type \"m\" to move again, or \"c\" to call it a day. No backsies.");
            string input = Console.ReadLine();
            if (input.ToLower() == "m")
            {
                return;
            }
            else if (input.ToLower() == "c")
            {
                System.Console.WriteLine("Final Score: WHITE {0} BLACK {1}", whiteScore, blackScore);
                if (whiteScore > blackScore)
                {
                    System.Console.WriteLine("White wins!");
                    hasWon = true;
                }
                else if (whiteScore < blackScore)
                {
                    System.Console.WriteLine("Black wins!");
                    hasWon = true;
                }
                else if (whiteScore == blackScore)
                {
                    System.Console.WriteLine("It's a tie! Incredible!");
                    hasWon = true;
                }
            }
            else
            {
                System.Console.WriteLine("Your input is invalid, my dude.");
                CallItADay();
            }

        }

        public Checker SelectChecker(int row, int column) //selectchecker takes in x,y, returns checker or null, or throws exception
        {
            return checkers.Find(x => x.position.SequenceEqual(new List<int> { row, column }));
        }

        public bool CheckForWin()  
        {
            return checkers.All(x => x.color == "white") || !checkers.Exists(x => x.color == "white");
        }

        public void WhoWon(){
            foreach (Checker c in checkers)
            {
                if (whiteScore == 12)
                {
                    System.Console.WriteLine("White won! Wow! You actually played through a whole game!");
                }
                else if (blackScore == 12)
                {
                    System.Console.WriteLine("Black won! Incredible! I bet you wasted a lot of time to get here!");
                }
            }
        }

        public void SwitchPlayers()
        {
            if (playerColor == "white")
            {
                Console.WriteLine("Black Turn");
                System.Console.WriteLine("White score: {0} Black score: {1}", whiteScore, blackScore);
                playerColor = "black";
            }
            else
            {
                Console.WriteLine("White Turn");
                System.Console.WriteLine("White score: {0} Black score: {1}", whiteScore, blackScore);
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
            int openCircleId = int.Parse(" 25CE", System.Globalization.NumberStyles.HexNumber);
            string openCircle = char.ConvertFromUtf32(openCircleId);
            int closedCircleId = int.Parse(" 25C9", System.Globalization.NumberStyles.HexNumber);
            string closedCircle = char.ConvertFromUtf32(closedCircleId);
            this.xPos = xPos;
            this.yPos = yPos;
            position[0] = xPos;
            position[1] = yPos;

            if (isWhite)
            {
                color = "white";
                // symbol = openCircle;
                symbol = "X";
            }
            else
            {
                color = "black";
                // symbol = closedCircle;
                symbol = "O";
            }
        }
    }
}
