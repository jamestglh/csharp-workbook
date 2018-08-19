using System;

namespace AnimalClassification
{   

    public class Animal {

    }

    class Vertebrate : Animal {

    }

    class Invertebrate : Animal {

    }

    class WarmBlooded : Vertebrate {

    }

    class ColdBlooded : Vertebrate {

    }

    class WithLegs : Invertebrate {

    }

    class WithoutLegs : Invertebrate {

    }

    class Mammals : WarmBlooded {
        bool livesOnLand;
        
    }
    class Birds : WarmBlooded {}
    class Fish : ColdBlooded {}
    class Reptiles : ColdBlooded {}
    class Amphibians : ColdBlooded {}
    class ThreePairsOfLegs : WithLegs {}
    class MoreThanThreePairsOfLegs : WithLegs {}
    class WormLike : WithoutLegs {}
    class NotWormLike : WithoutLegs {}



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
