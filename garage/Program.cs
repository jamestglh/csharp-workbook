using System;
using System.Collections.Generic;

namespace Practice {
    class Program {

        // ignore this not part of the car "class"
        static void Main(string[] args) {
            Car myCar = new Car("blue",  "mazda", "3s");
            myCar.passengerCapacity = 5;
            myCar.engineSize = 2.3;

            Car jasonsCar = new Car("white", "volvo", "xc90");
            jasonsCar.passengerCapacity = 5;
            jasonsCar.engineSize = 3.2;

            Car robertsCar  = new Car("white", "ford", "fiesta");

            ParkingGarage p1 = new ParkingGarage(2);
            p1.name = "Yellow Submarine";

            try{
                p1.parkCar(myCar);
                Console.WriteLine("Car parked");
            } catch(Exception){
                Console.WriteLine("Could not park the car");
            }
            try{
                p1.parkCar(jasonsCar);
                Console.WriteLine("Car parked");
            } catch(Exception){
                Console.WriteLine("Could not park the car");
            }
            try{
                p1.parkCar(robertsCar);
                Console.WriteLine("Car parked");
            } catch(Exception){
                Console.WriteLine("Could not park the car");
            }
        }
    }

    class ParkingGarage {
        public String name {get; set;}
        public int capacity {get; private set;}

        // list of cars currently parked
        private List<Car> currentlyParked;

        public ParkingGarage(int initialCapacity){
            currentlyParked = new List<Car>();
            this.capacity = initialCapacity;
        }

        public bool hasFreeSpots(){
            if(this.capacity > currentlyParked.Count){
                return true;
            } else {
                return false;
            }
        }

        public void parkCar(Car carToPark){
            if(this.hasFreeSpots()){
                this.currentlyParked.Add(carToPark);
            } else {
                throw new Exception("No Capacity to park a car");
            }
        }

        public void vacate(Car carToVacate){
            bool reallyRemoved = this.currentlyParked.Remove(carToVacate);
            if(!reallyRemoved){
                throw new Exception("The car was not in the garage ...");
            }
        }

    }

    class Car {
        public String color {get; set;}
        public String make {get; private set;}
        public String model {get; private set;}
        
        // this is really the number of legally allowed passengers
        // based on number of seatbelts
        public int passengerCapacity {get;set;}
        
        public int numCylinders {get; set;}

        // enginesize is in cubic liters
        public double engineSize{get;set;} 

        /**
         initialColor: the initial color of the car
         theMake: the make of the car
         theModel: the model of thecar
         */
        public Car(String initialColor, String theMake, String theModel){
            this.color = initialColor;
            this.make = theMake;
            this.model = theModel;
        }

        public double engineSizeInCubicInches(){
            double answer = this.engineSize * 61.0237;
            return answer;
        }

    }
}
