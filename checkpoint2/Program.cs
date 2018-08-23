using System;
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
        //the only thing in the Game class should be the Start method
        public void Start()
        {
            Board aBoard = new Board();
            aBoard.DrawBoard();
        }
        public Game(){}
    }
    public class Board
    {
        // public String[,] grid {get;set;} //need 8 rows, 8 columns
        public String[,] grid = new String[8,8];
        public List<Checker> checkers {get;set;}
        public Board()
        {
            // this.grid = grid;
            List<Checker> checkers = new List<Checker>();
        }

        //this is where we will need to build some methods to CreateBoard(board constructor), DrawBoard, GenerateBoard, SelectChecker, CheckValidMove(checkerposition[],tox,toy)RETURNBOOL, MoveChecker, RemoveChecker, and CheckForWin(take in color, did white win true false)
        //when we instantiate a checker, we gotsta add it to the list at the same time yo
        //selectchecker takes in x,y, returns checker or null, or throws exception

        public void DrawBoard()
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 "); //what i need to do is probably do a console writeline for each row of the grid 2d array with probably 2 for loops, ie, for each row, then for each item in each row
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i,j]);
                }
                Console.WriteLine();
            }
        }


    }
    public class Checker
    {
        public String symbol {get;private set;}
        public String color {get;private set;}
        public int[] position {get;set;}

        public Checker(String color, int[] position)
        {
            this.color = color;
            this.symbol = symbol;
            this.position = position;
            int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            if (color == "white")
            {
                string openCircle = char.ConvertFromUtf32(openCircleId);
                symbol = openCircle;
            }
            else
            {
                string closedCircle = char.ConvertFromUtf32(closedCircleId);
                symbol = closedCircle;
            }
        }
    }

}
