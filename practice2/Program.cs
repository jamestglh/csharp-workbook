using System;
using System.Collections.Generic;

namespace practice2
{



    // public class Rentable{
    //     public int 
    // }
    public interface Rentable{
       double CalculateRent(double daysToRent);
    }

     public class Car : Rentable{
        
         
        public string licenseNo {get; set;}
        public double hourlyRate{get;private set;}

        public Car (string licenseNo, double rate){
            this.licenseNo = licenseNo;
            this.hourlyRate = rate;
        }

        public double CalculateRent(double daysToRent){
            double dailyRate = 24*hourlyRate;
            return dailyRate + daysToRent;
        }
    }
    

    

    public class HotelRoom : Rentable{
        public string roomNumber {get; private set;}
        public double dailyRate {get;set;}


        public HotelRoom(String roomNumber, double rate){
            this.dailyRate = rate;
            this.roomNumber = roomNumber;
        }
        public double CalculateRent(double daysToRent){
            return dailyRate * daysToRent;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Car mercedes = new Car("xxx", 140.67);
            Car lambo = new Car("xac", 1000);
            Car fiesta = new Car("vesf", 30);
            HotelRoom suite = new HotelRoom("123", 149);
            HotelRoom standard1 = new HotelRoom("456", 100);
            HotelRoom standard2 = new HotelRoom("789", 59);


            Console.WriteLine("For car {0} the 1 day amount due is {1}", mercedes.licenseNo, mercedes.CalculateRent(1));
            Console.WriteLine("For car {0} the 1 day amount due is {1}", lambo.licenseNo, lambo.CalculateRent(1));
            Console.WriteLine("For car {0} the 1 day amount due is {1}", fiesta.licenseNo, fiesta.CalculateRent(1));

            List<Rentable> rentableThings = new List<Rentable>();
            rentableThings.Add(mercedes);
            rentableThings.Add(lambo);
            rentableThings.Add(fiesta);
            rentableThings.Add(suite);
            rentableThings.Add(standard1);
            rentableThings.Add(standard2);

            foreach (Rentable thing in rentableThings)
            {
                Console.WriteLine("If you rent this {0} for 1 day the cost is {1}", thing.GetType().Name, thing.CalculateRent(1));
            }
        }

       
    }
}
