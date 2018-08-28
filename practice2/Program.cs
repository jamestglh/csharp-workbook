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



}


