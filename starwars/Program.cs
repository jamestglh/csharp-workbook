using System;
using System.Collections.Generic;

namespace starwars
{
    class Program
    {

        static void Main(string[] args)
        {
            Person luke = new Person("Luke", "Skywalker", "Rebel");
            Person leia = new Person("Leia", "Organa", "Rebel");
            Person han = new Person("Han", "Solo", "Rebel");
            Person chewie = new Person("Chew", "Bacca", "Rebel");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Person palpatine = new Person("Emperor", "Palpatine", "Imperial");
            Ship milleniumFalcon = new Ship("Millenium Falcon", "Rebel", 3);
            Ship starDestroyer = new Ship("Star Destroyer", "Imperial", 10);
            Station rebelBase = new Station("Rebel Base", "Rebel");
            Station deathStar = new Station("Death Star", "Imperial");

            //putting haters in ships
            try
            {
                milleniumFalcon.EnterShip(luke);
                Console.WriteLine("Luke has entered the ship");            
            }
            catch(Exception)
            {
                Console.WriteLine("Luke couldn't enter the ship");
            }
            try
            {
                milleniumFalcon.EnterShip(leia);
                Console.WriteLine("Leia has entered the ship");            
            }
            catch(Exception)
            {
                Console.WriteLine("Leia couldn't enter the ship");
            }
            try
            {
                milleniumFalcon.EnterShip(han);
                Console.WriteLine("Han has entered the ship");            
            }
            catch(Exception)
            {
                Console.WriteLine("Han couldn't enter the ship");
            }
            try
            {
                milleniumFalcon.EnterShip(chewie);
                Console.WriteLine("Chewie has entered the ship");
                            
            }
            catch(Exception)
            {
                Console.WriteLine("Chewie couldn't fit. You racist against Wookiees or something?");
                // lists passengers of millenium falcon
                foreach (Person p in milleniumFalcon.passengers)
                {
                    Console.WriteLine(p.firstName);
                }
                
            } 

            //docking a ship at a station
            try
            {
                rebelBase.DockAtStation(milleniumFalcon);
                Console.WriteLine("Ship docking at Rebel Station");            
            }
            catch(Exception)
            {
                Console.WriteLine("The ship couldn't dock.");
            } 

            try
            {
                deathStar.DockAtStation(starDestroyer);
                Console.WriteLine("Ship docking at the Death Star");            
            }
            catch(Exception)
            {
                Console.WriteLine("The ship couldn't dock.");
            } 
            try
            {
                rebelBase.EmbarkOnVoyage(milleniumFalcon);
                Console.WriteLine("The Millenium Falcon has embarked on its voyage");          
            }
            catch(Exception)
            {
                Console.WriteLine("The ship couldn't embark.");
            } 


            

        }

        public class Ship
        {
            //attributes of the ship class
            public List<Person> passengers;
            public string type {get;set;}
            public string alliance {get;set;}
            public int capacity {get;set;}
            
            //constructor for Ship
            public Ship(string type, string alliance, int capacity){
            passengers = new List<Person>();
            this.capacity = capacity;
        }
            public bool hasFreeSeats()
            {
                if(this.capacity > passengers.Count){
                    return true;
                } else {
                    return false;
                }
            }
            public void EnterShip(Person personToEnter)
            {
                if (this.hasFreeSeats())
                {
                    this.passengers.Add(personToEnter);
                }
                else
                {
                    throw new Exception("Sorry pal, all full.");
                }
            }

            public void ExitShip(Person personToExit)
            {
                bool reallyExited = this.passengers.Remove(personToExit);
                if(!reallyExited)
                {
                    throw new Exception("This person was not on the ship");
                }
            }
        }
        
        public class Person
        {
            public String firstName {get;set;}
            public String lastName {get;set;}
            public String alliance {get;set;}

            //this is the constructor
            public Person(String firstName, String lastName, String alliance)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.alliance = alliance;
            }
        }


        public class Station
        {
            public string stationName {get;set;}
            public string stationAlliance {get;set;}
            public List<Ship> dockedShips; 
        
            //constructor for Station
            public Station(string stationName, string stationAlliance)
            {
                this.stationName = stationName;
                this.stationAlliance = stationAlliance;
                dockedShips = new List<Ship>();

            }

            public void DockAtStation(Ship shipToDock)
            {
                this.dockedShips.Add(shipToDock);  
            }
            public void EmbarkOnVoyage(Ship shipToEmbark){
            bool reallyRemoved = this.dockedShips.Remove(shipToEmbark);
            if(!reallyRemoved)
            {
                throw new Exception("The ship could not be found at the station");
            }
        }
        }
    }
}
