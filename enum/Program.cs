using System;

namespace enumpractice
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Please enter the MONTH you were born in, as a number: ");
            string dateMonth = Console.ReadLine();
            int dateMonthInt = Convert.ToInt32(dateMonth);

            Console.WriteLine("Please enter what DAY of the month you were born on, as a number: ");
            string dateDay = Console.ReadLine();
            int dateDayInt = Convert.ToInt32(dateDay);

            Console.WriteLine("Please enter ANY YEAR to see what day of the month your birthday lands on in any given year: ");
            string dateYear = Console.ReadLine();
            int dateyearInt = Convert.ToInt32(dateYear);

            DateTime dt = new DateTime(dateyearInt, dateMonthInt, dateDayInt);
            int dayOfWeekInt = (int)dt.DayOfWeek;

            Console.WriteLine("The day of the week for {0:d} is {1}.", dt, (Days)dayOfWeekInt);
        }
    }
    public enum Days 
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }



}


