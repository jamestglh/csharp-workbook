using System;

namespace practice2
{
    class Program
    {
        static void Main(string[] args)
        {

            //FOR PROJECT USE DATETIME.DAYOFWEEK 
            Console.WriteLine("Hello World!");
            Console.WriteLine("Sunday is "+(int)Days.Sunday);
            Days today = Days.Wednesday;
            Days tomorrow = today + 1;
            Console.WriteLine("Today is "+today);
            Console.WriteLine("Tomorrow is "+tomorrow);
            Console.WriteLine("If today is " + today + " tomorrow is "+getNextDay(today));
        }


        public static Days getNextDay(Days day){
            return day+1;
        }
        public static bool isWeekend(Days day){
            if (day == Days.Sunday || day == Days.Saturday)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    
    public enum Days {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }


    //EXAMPLE FROM THE INNERNETTE
    // class Sample 
    // {
    //     public static void Main() 
    //     {
    // // Assume the current culture is en-US.
    // // Create a DateTime for the first of May, 2003.
    //     DateTime dt = new DateTime(2003, 5, 1);
    //     Console.WriteLine("Is Thursday the day of the week for {0:d}?: {1}", 
    //                     dt, dt.DayOfWeek == DayOfWeek.Thursday);
    //     Console.WriteLine("The day of the week for {0:d} is {1}.", dt, dt.DayOfWeek);
    //     }
}
/*
}
