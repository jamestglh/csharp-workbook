using System;

namespace textGame
{
    class Program
    {
        static void Main(string[] args)
        {

            PlayGame();

            void PlayGame()
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Welcome to the cavern of secrets!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Do you take it? [y/n]: ");

                int complete = 0;
                int stick = 0;
    
                string ch1 = Console.ReadLine();

                if (ch1 == "y")
                {
                    stick = 1;
                    Console.WriteLine("You have taken the stick!");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    stick = 0;
                    Console.WriteLine("You did not take the stick");
                    System.Threading.Thread.Sleep(1000);
                } 

                Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Do you approach the object? [y/n]");

                string ch2 = Console.ReadLine();

                if (ch2 == "y")
                {
                    Console.WriteLine("You approach the object...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("The eye belongs to a giant spider!");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Do you try to fight it? [y/n]");
                    string ch3 = Console.ReadLine();

                    if (ch3 == "y")
                    {
                        if (stick == 1)
                            {
                                //WITH STICK
                                Console.WriteLine("You only have a stick to fight with!");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("                  Fighting...                   ");
                                Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                                Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"); 
                                System.Threading.Thread.Sleep(1000);

                                Random rnd = new Random();
                                int fdmg1 = rnd.Next(3, 10);  
                                int edmg1 = rnd.Next(1, 5);    

                                Console.WriteLine("you hit a " + fdmg1);
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("the spider hits a " + edmg1);
                                System.Threading.Thread.Sleep(1000);

                                if (edmg1 > fdmg1)
                                {
                                    Console.WriteLine("The spider has dealt more damage than you!");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 0;
                                    CheckStatus();
                                }
                                else if (fdmg1 < 5)
                                {
                                    Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 1;
                                    CheckStatus();
                                }
                                else
                                {
                                    Console.WriteLine("You killed the spider!");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 1;
                                    CheckStatus();
                                }
                            }
                        else
                            {
                                //WITHOUT STICK
                                Console.WriteLine("You don't have anything to fight with!");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("                  Fighting...                   ");
                                Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                                Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                System.Threading.Thread.Sleep(1000);
                                
                                Random rnd = new Random();
                                int fdmg1 = rnd.Next(1, 8);  
                                int edmg1 = rnd.Next(1, 5);  

                                Console.WriteLine("you hit a " + fdmg1);
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("the spider hits a " + edmg1);
                                System.Threading.Thread.Sleep(1000);

                                if (edmg1 > fdmg1)
                                {
                                    Console.WriteLine("The spider has dealt more damage than you!");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 0;
                                    CheckStatus();
                                }
                                else if (fdmg1 < 5)
                                {
                                    Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 1;
                                    CheckStatus();
                                }
                                else
                                {
                                    Console.WriteLine("You killed the spider!");
                                    System.Threading.Thread.Sleep(1000);
                                    complete = 1;
                                    CheckStatus();
                                }
                            }     
                    }
                    else
                    {
                    //DON'T FIGHT SPIDER
                    Console.WriteLine("You choose not to fight the spider.");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                    System.Threading.Thread.Sleep(1000);
                    complete = 0;
                    CheckStatus();
                    }
                }
                else
                {
                    //DONT MOVE TOWARDS LIGHT
                    stick = 0;
                    Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("But something won't let you....");
                    System.Threading.Thread.Sleep(1000);
                    PlayGame();
                } 

                void CheckStatus()
                        {
                            if (complete == 1)
                            {
                                Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                                string replay = Console.ReadLine();
                                if (replay == "y")
                                {
                                    PlayGame();
                                }
                                else
                                {
                                    Console.WriteLine("GAME OVER");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have died! Would you like to play again? [y/n]:  ");
                                string replay = Console.ReadLine();
                                if (replay == "y")
                                {
                                    PlayGame();
                                }
                                else
                                {
                                    Console.WriteLine("GAME OVER");
                                }
                            }
                        }
            }
        }
    }
}
