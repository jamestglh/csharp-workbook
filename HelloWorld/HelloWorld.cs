using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string ccn = "";
            int exp = 0;
            int cvv = 0;
            
            Console.WriteLine("Please enter your full name as written on your credit card: ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your full credit card number, with no spaces or dashes: ");
            ccn = Console.ReadLine();
            Console.WriteLine("Please enter the expiration date of your card as a 6 digit number with no spaces: ");
            exp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the 3-digit CVV number on the back of your card: ");
            cvv = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Hello! My name is {0} and my credit card number is {1}. The expiration date is {2} and the CVV number is {3}.", name, ccn, exp, cvv);
        }
    }
}
