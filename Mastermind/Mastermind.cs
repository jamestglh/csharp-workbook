using System;
using System.Collections.Generic;
using System.Threading;


namespace Mastermind 
{
    class Program 
    {
        static void Main (string[] args) {
 	        
            string[] randomLetters = new string[] {"a", "b", "c", "d", "e", "f"};
            Random rando = new Random();
            Game game = new Game (new string[] { randomLetters[rando.Next(0,6)], randomLetters[rando.Next(0,6)], randomLetters[rando.Next(0,6)], randomLetters[rando.Next(0,6)] }, 10);
            // Game game = new Game (new string[] { "a", "a", "a", "a" });
            for (int turns = game.numTries; turns > 0; turns--) {
                Console.WriteLine($"You have {turns} tries left");
                Console.WriteLine ("Choose four letters: ");
                string letters = Console.ReadLine ();
                string[] lettersArray = letters.Split("");
                Ball[] balls = new Ball[4];
                for (int i = 0; i < 4; i++) {
                    balls[i] = new Ball (letters[i].ToString());
                }
                Row row = new Row (balls);
                game.AddRow (row);
                Console.WriteLine (game.Rows);
                
                
            }
            Console.WriteLine ("Out Of Turns");
        }
    }

    class Game {
        private List<Row> rows = new List<Row> ();
        private string[] answer = new string[4];

        public int numTries {get;set;}

        public Game (string[] answer, int numTries) 
        {
            this.answer = answer;
        }

        public string Score (Row row) {
            string[] answerClone = (string[]) this.answer.Clone ();
            // red is correct letter and correct position
            // white is correct letters minus red
            // this.answer => ["a", "b", "c", "d"]
            // row.balls => [{ Letter: "c" }, { Letter: "b" }, { Letter: "d" }, { Letter: "a" }]
            int red = 0;
            for (int i = 0; i < 4; i++) 
            {
                if (answerClone[i] == row.balls[i].Letter) 
                {
                    red++;
                }
            }

            int white = 0;
            for (int i = 0; i < 4; i++) 
            {
                int foundIndex = Array.IndexOf (answerClone, row.balls[i].Letter);
                if (foundIndex > -1) {
                    white++;
                    answerClone[foundIndex] = null;
                }
            }
            //win conditions
            if ((white - red == 0) && (red == 4))
            {
                Console.WriteLine("You've won!");
                System.Environment.Exit(1);
            }


            return $" {red} - {white - red}";
            
        }

        public void AddRow (Row row) 
        {
            this.rows.Add (row);
        }

        public string Rows 
        {
            get 
            {
                foreach (var row in this.rows) 
                {
                    Console.WriteLine (row.Balls);
                    Console.WriteLine (Score (row));
                }
            return null;    
            }
        }
    }

    class Ball 
    {
        public string Letter { get; private set; }

        public Ball (string letter) 
        {
            this.Letter = letter;
        }
    }

    class Row 
    {
        public Ball[] balls = new Ball[4];

        public Row (Ball[] balls) 
        {
            this.balls = balls;
        }

        public string Balls 
        {
            get 
            {
                foreach (var ball in this.balls) 
                {
                    Console.Write (ball.Letter);
                }
                return "";
            }
        }
    }
}