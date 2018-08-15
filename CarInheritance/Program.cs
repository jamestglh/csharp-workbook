using System;

namespace CarInheritance
{
    class Program
    {


    
       


        static void Main(string[] args)
        {
            Truck aTruck = new Truck(1,4,"white",4,4,true,6);
            Truck gravedigga = new Truck(1,4,"green and black like a can of Monster",4,4,true,6);
            Motorcycle aMotorcycle = new Motorcycle(true, true, "red", 3, 2, true, 4);


            Console.WriteLine("Inheritance practice!");

            Console.WriteLine("aTruck's color is " + aTruck.color);
            Console.WriteLine("aMotorcycle's color is " + aMotorcycle.color);
            Console.WriteLine("Gravedigga's color is " + gravedigga.color);
        }
    }

    public class Vehicle{
        public string color {get;set;}
        public int numWheels {get;set;}
        public int numPassengers {get;set;}
        public bool gasPowered {get;set;}
        public int engineSize {get;set;}
        

        public Vehicle(string color, int numWheels, int numPassengers, bool gasPowered, int engineSize){
            this.color = color;
            this.numWheels = numWheels;
            this.numPassengers = numPassengers;
            this.gasPowered = gasPowered;
            this.engineSize = engineSize;
        }
    }

    public class Truck : Vehicle {
        public int cabSize {get;set;}
        public int towingCapacity {get;set;}

        public Truck(int cabSize, int towingCapacity, string color, int numWheels,  int numPassengers, bool gasPowered, int engineSize) : base(color, numWheels, numPassengers, gasPowered, engineSize){
            this.numWheels = numWheels;
            this.cabSize = cabSize;
            this.towingCapacity = towingCapacity;
        }
    }

    public class Motorcycle : Vehicle {
        public bool isCruiser {get;set;}
        public bool hasSidecar {get;set;}
        public Motorcycle(bool isCruiser, bool hasSidecar, string color, int numWheels, int numPassengers, bool gasPowered, int engineSize) : base(color, numWheels, numPassengers, gasPowered, engineSize){
            this.isCruiser = isCruiser;
            this.hasSidecar = hasSidecar;
        }
    }

    public class Van : Vehicle {
        public bool hasSlidingDoor {get;set;}
        public bool isCargoVan {get;set;}

        public Van(bool hasSlidingDoor, bool isCargoVan, string color, int numWheels,  int numPassengers, bool gasPowered, int engineSize) : base(color, numWheels, numPassengers, gasPowered, engineSize){
            this.hasSlidingDoor = hasSlidingDoor;
            this.isCargoVan = isCargoVan;
        }
    }


}
