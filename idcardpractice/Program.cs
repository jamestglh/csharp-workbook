using System;

namespace idcardpractice
{
    class Program
    {
        public static void Main(String[] args)
        {

            IdCard JamesId = new IdCard("James","Woodard", 75, "green", "brown", Convert.ToChar("m"), new DateTime(1984,5,11), "tx", true, "95793947576");

            Console.WriteLine("{0} is {1} inches tall", JamesId.firstName, JamesId.height);
            Console.WriteLine("{0} is {1} feet tall", JamesId.firstName, JamesId.heightInFeet());
        }
    }
        

            
    

    class IdCard
    {
        public String firstName {get;set;}
        public String lastName {get;set;}
        public int height {get;set;}
        public string eyeColor {get; private set;}
        public string hairColor {get;set;}
        public char gender {get;set;}
        public DateTime dob {get; private set;}
        public String state {get;private set;}
        public bool donor {get;set;}
        public String dlNumber {get;set;}

        public IdCard(String firstName, String lastName, int height, string eyeColor, string hairColor, char gender, DateTime dob, String state, bool donor, string dlNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.height = height;
            this.eyeColor = eyeColor;
            this.hairColor = hairColor;
            this.gender = gender;
            this.dob = dob;
            this.state = state;
            this.donor = donor;
            this.dlNumber = dlNumber;
        }
        public double heightInFeet()
        {
            double feet = this.height/12.0;
            return feet;
        }
    }




}
