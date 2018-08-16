using System;
using System.Collections.Generic;

namespace CarInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Polymorphism practice!");
            Vehicle myVehicle = new Vehicle();
            Sedan mySedan = new Sedan();
            Vehicle aPrius = new Sedan();
            Truck myTruck = new Truck();

            List<Vehicle> listOfVehicles = new List<Vehicle>();
            listOfVehicles.Add(myVehicle);
            listOfVehicles.Add(mySedan);
            listOfVehicles.Add(aPrius);
            listOfVehicles.Add(myTruck);

            Console.WriteLine("mySedan honks like " + mySedan.honk());
            Console.WriteLine("aPrius honks like " + aPrius.honk());
            Console.WriteLine("myTruck honks like " + myTruck.honk());

        }
    }

    public class Vehicle
    {
        public virtual String honk(){
            return "honk honk";
        }
    }
    public class Sedan : Vehicle
    {
        public override String honk(){
            return "beep beep";
        }
    }
    public class Truck : Vehicle
    {
        public override String honk(){
            return "B I G G H O N C C";
        }
    }

}
