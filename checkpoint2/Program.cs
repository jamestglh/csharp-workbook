using System;
using System.Collections.Generic;

namespace checkpoint2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Game myGame = new Game();
            
        }
    }
    public class Game
    {
        //the only thing in the Game class should be the Start method
        public void Start()
        {
            
        }
    }
    public class Board
    {
        public String[][] Grid {get;set;}
        public List<Checker> Checkers {get;set;}

        //this is where we will need to build some methods to CreateBoard, DrawBoard, GenerateBoard, SelectChecker, RemoveChecker, and CheckForWin

        public void DrawBoard()
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 ");
            Console.WriteLine();
            Console.WriteLine("0");
            Console.WriteLine();
            Console.WriteLine("1");
            Console.WriteLine();
            Console.WriteLine("2");
            Console.WriteLine();
            Console.WriteLine("3");
            Console.WriteLine();
            Console.WriteLine("4");
            Console.WriteLine();
            Console.WriteLine("5");
            Console.WriteLine();
            Console.WriteLine("6");
            Console.WriteLine();
            Console.WriteLine("7");
        }


    }
    public class Checker
    {
        public String symbol {get;set;}
        public String color {get;set;}
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
