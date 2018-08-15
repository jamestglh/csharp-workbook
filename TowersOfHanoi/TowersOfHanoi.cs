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

            
        }

    }


    public class Game{
        Dictionary<string, dynamic> towers = new Dictionary<string, dynamic>();

        public Game(){
             
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

            bool hasWon = false;
            string location = "";
            string destination = "";

            while (!hasWon)
            {
                PrintBoard();
                PlayerMove();
                CheckForWin();
            
            }

            void PrintBoard(){
                // foreach (var tower in towers)
                // {
                //     Console.Write(tower.Key + ": ");
                    
                //     foreach (Block block in towers["A"].blockStack)
                //     {
                //        Console.Write(block.weight);
                //     }
                //     Console.WriteLine();
                // }
                Console.Write("A: ");
                foreach (Block block in towers["A"].blockStack)
                    {
                       Console.Write(block.weight);
                    }
                    Console.WriteLine();
                Console.Write("B: ");
                foreach (Block block in towers["B"].blockStack)
                    {
                       Console.Write(block.weight);
                    }
                    Console.WriteLine();
                Console.Write("C: ");
                foreach (Block block in towers["C"].blockStack)
                    {
                       Console.Write(block.weight);
                    }
                    Console.WriteLine();
            }

            void CheckForWin(){
                if (towers["C"].blockStack.Count >= 4){
                    Console.WriteLine("You Win!");
                    hasWon = true;
                }
            }

            void PlayerMove(){
                // string[] acceptableLetters = new string[] {"a", "A", "b", "B", "c", "C"};
                Console.WriteLine("What stack would you like to move the block from?");
                string userInput = Console.ReadLine();
                
                    if ((userInput == "a") ||(userInput == "A") || (userInput == "b") ||(userInput == "B") || (userInput == "c") ||(userInput == "C"))
                    {
                        location = userInput.ToUpper();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your input is invalid.");
                        userInput = "";
                        location = "";
                        destination = "";
                        PlayerMove();
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
                        userInput = "";
                        location = "";
                        destination = "";
                        PlayerMove();
                    }




                var pieceToMove = towers[location].blockStack.Peek();
                if (towers[destination].blockStack.Count == 0) 
                {
                    towers[location].blockStack.Pop();
                    towers[destination].blockStack.Push(pieceToMove);
                }
                else if (towers[destination].blockStack.Peek().weight > pieceToMove.weight)
                {
                    towers[location].blockStack.Pop();
                    towers[destination].blockStack.Push(pieceToMove);
                }
                else
                {
                    Console.WriteLine("Sorry, that move is invalid");
                }
            }

            // void MovePiece(){
            //     var pieceToMove = towers[location.ToUpper()].blockStack.Pop();
            //     towers[destination.ToUpper()].blockStack.Push(pieceToMove);
            // }


        }
    }
    public class Tower{
        public Stack blockStack {get;set;}

        public Tower(){

                this.blockStack = new Stack();
            }

    }
    public class Block{
        public int weight {get; set;}
        public Block(int weight) {
            this.weight = weight;
        }
    }

}
