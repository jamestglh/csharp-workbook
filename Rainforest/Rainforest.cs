using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's build a bootleg Amazon!");

            Company rainforest = new Company("Rainforest");
            Warehouse sanAntonio = new Warehouse("San Antonio", 10);
            Warehouse austin = new Warehouse("Austin", 10);
            Warehouse houston = new Warehouse("Houston", 10);
            Warehouse shitCity = new Warehouse("Shit City", 10);
            Container sanAntonio_1 = new Container("SanAntonio-1", 6);
            Container sanAntonio_2 = new Container("SanAntonio-2", 6);
            Container austin_1 = new Container("Austin-1", 6);
            Container houston_1 = new Container("Houston-1", 6);
            Container shitCity_1 = new Container("ShitCity-1", 6);
            Item bananas = new Item("Bananas", 1.99m);
            Item cockfightingDVDs = new Item("Cockfighting DVDs", 19.99m);
            Item bootlegAdidas = new Item("Bootleg Adidas", 14.99m);
            Item gallonOfChamoy = new Item("Gallon of Chamoy", 9.99m);
            Item goldTeeth = new Item ("Gold Teeth", 499.99m);
            Item brickOfCocaine = new Item("Brick of Cocaine", 999.99m);
            Item cannibalCorpseCD = new Item ("Cannibal Corpse - Greatest Hits", 14.99m);

            //building the warehouses, spec 3
            rainforest.BuildWarehouse(sanAntonio);
            rainforest.BuildWarehouse(austin);
            rainforest.BuildWarehouse(houston);
            rainforest.BuildWarehouse(shitCity);
            //building the containers, spec 4
            sanAntonio.BuildContainer(sanAntonio_1);
            sanAntonio.BuildContainer(sanAntonio_2);
            austin.BuildContainer(austin_1);
            houston.BuildContainer(houston_1);
            shitCity.BuildContainer(shitCity_1);
            //adding items, spec 5
            sanAntonio_1.AddItems(bananas);
            sanAntonio_2.AddItems(cockfightingDVDs);
            sanAntonio_2.AddItems(bootlegAdidas);
            austin_1.AddItems(gallonOfChamoy);
            houston_1.AddItems(goldTeeth);
            shitCity_1.AddItems(brickOfCocaine);
            shitCity_1.AddItems(cannibalCorpseCD);
            //attempting to create the index
            Dictionary<string, string> index = new Dictionary<string, string>();
            
            //printing out the contents of each thing, spec 6
            foreach (Warehouse w in rainforest.warehouses)
            {
                Console.WriteLine(w.location);
                foreach (Container c in w.containers)
                {
                    Console.WriteLine("  " + c.id);
                    foreach (Item i in c.items)
                    {
                        index.Add(i.name, c.id); //this line creates the index, spec 7
                        Console.WriteLine("    " + i.name + " - $" + i.price);
                    }
                }
            }
            //printing out contents of index
            foreach (var item in index)
            {
                Console.WriteLine(item);
            }
        }
        public class Company {
            public String name {get;set;}
            public List<Warehouse> warehouses;
            public Company(String name){
                warehouses = new List<Warehouse>();
            }
            public void BuildWarehouse(Warehouse newWarehouse){
                this.warehouses.Add(newWarehouse); // this adds warehouse to the warehouses list
            }
        }
        public class Warehouse {
            public String location {get;set;}
            public int size {get;set;}
            public List<Container> containers;
            //constructor for Warehouse
            public Warehouse(string location, int size){
                this.location = location;
                this.size = size;
                containers = new List<Container>();
            }
            public void BuildContainer(Container newContainer){
                this.containers.Add(newContainer); // adds container to the containers list
            }
        }

        public class Container{
            public int size {get;set;}
            public String id {get;set;}
            public List<Item> items;
            public Container(String id, int size){
                this.id = id;
                this.size = size;
                items = new List<Item>();
            }
            public void AddItems(Item newItem){
                this.items.Add(newItem);
            }
        }
        public class Item {
            public String name {get;set;}
            public decimal price {get;set;}
            public Item(string name, decimal price){
                this.name = name;
                this.price = price;
            }
        }
    }
}
