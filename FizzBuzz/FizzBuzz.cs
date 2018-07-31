using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            RequestSustenance();
            BuzzBeast();
            Console.ReadLine();

            void BuzzBeast(){
            int i = 0;
            while (i < number)
                {
                    i++;
                    if (i % 3 == 0 && i % 5 == 0)  
                    {
                        Console.WriteLine("FIZZBUZZ, the wild beast howls");
                        
                    }
                    else if (i % 3 == 0){
                        Console.WriteLine("FIZZ, the creature foams at the mouth");
                        
                    }
                    else if (i % 5 == 0){
                        Console.WriteLine("BUZZ, the creature emits poisonous clouds from its pores");
                        
                    }
                    else {
                        Console.WriteLine(i);
                    }
                }
            }
            void RequestSustenance()
            {
                Console.WriteLine("FEED ME AN INTEGER. I SUFFER FROM ANCIENT HUNGER.");
                number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("YES, GOOD, YOUR NUMBER IS " + number);
            }
    }
}}
