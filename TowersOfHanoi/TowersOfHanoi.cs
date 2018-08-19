using System;
using System.Collections;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Towers of Hanoi");
            Game myGame = new Game();
            myGame.Run();
        }
    }


    public class Game{
        Dictionary<string, Tower> towers = new Dictionary<string, Tower>();
                bool hasWon = false;
                string location = "";
                string destination = "";

            void GetPlayerInput()
            {
                Console.WriteLine("What stack would you like to move the block from?");
                string userInput = Console.ReadLine();
                
                if ((userInput == "a") ||(userInput == "A") || (userInput == "b") ||(userInput == "B") || (userInput == "c") ||(userInput == "C"))
                {
                    location = userInput.ToUpper();
                }
                else
                {
                    Console.WriteLine("Sorry, your input is invalid.");
                    userInput = null;
                    location = null;
                    destination = null;
                    GetPlayerInput();
                }
                Console.WriteLine("What stack would you like to move the block to?");
                userInput = Console.ReadLine();
                if ((userInput == "a") ||(userInput == "A") || (userInput == "b") ||(userInput == "B") || (userInput == "c") ||(userInput == "C"))
                {
                    destination = userInput.ToUpper();
                }
                else
                {
                    Console.WriteLine("Sorry, your input is invalid.");
                    userInput = null;
                    location = null;
                    destination = null;
                    GetPlayerInput();
                }
            }
            void MovePiece(){
                
                if (towers[location].blockStack.Count == 0) //checks if "from" input is empty
                {
                    Console.WriteLine("Sorry, that move is invalid");
                    return;
                }
                var pieceToMove = towers[location].blockStack.Peek();
                if (towers[destination].blockStack.Count == 0) //checks if destination is empty
                {
                    towers[location].blockStack.Pop();
                    towers[destination].blockStack.Push(pieceToMove);
                }
                else if (towers[destination].blockStack.Peek().weight > pieceToMove.weight) //checks to see if block in destination is bigger
                {
                    towers[location].blockStack.Pop();
                    towers[destination].blockStack.Push(pieceToMove);
                }
                else
                {
                    Console.WriteLine("Sorry, that move is invalid"); //if user tries to put a bigger block on a smaller one
                }
            }
            
            void PrintBoard(){
            foreach (string name in towers.Keys)
            {
                Console.Write(name + ": ");
                Tower tower = towers[name]; 
                Stack<Block> stackOfBlocks = tower.blockStack;
                Stack<Block> stackToPrint = new Stack<Block>();

                foreach(Block b in stackOfBlocks) // this loop dumps the stack into a new stack, so it's printed out the proper way
                {
                    stackToPrint.Push(b);
                }
                foreach (Block z in stackToPrint) // this loop prints out the stack in the proper order
                {
                    Console.Write(z.weight);  
                }
                Console.WriteLine();
                }
            }

            void CheckForWin()
            {
                if (towers["C"].blockStack.Count >= 4){
                    Console.WriteLine("You Win!");
                    hasWon = true;
                }
            }
            public void Run() // this is the game logic
            {
                while (!hasWon)
                {
                    PrintBoard();
                    GetPlayerInput();
                    MovePiece();
                    CheckForWin();
                }
            }

        public Game(){ //constructor for Game
            towers["A"] = new Tower();
            towers["B"] = new Tower();
            towers["C"] = new Tower();
             
            Block block1 = new Block(1);
            Block block2 = new Block(2);
            Block block3 = new Block(3);
            Block block4 = new Block(4);

            towers["A"].blockStack.Push(block4);
            towers["A"].blockStack.Push(block3);
            towers["A"].blockStack.Push(block2);
            towers["A"].blockStack.Push(block1);
        }
    }
    public class Tower{
        public Stack<Block> blockStack {get;set;}
        public Tower()
            {
                this.blockStack = new Stack<Block>();
            }
    }
    public class Block{
        public int weight {get; set;}
        public Block(int weight) {
            this.weight = weight;
        }
    }

}
