using System;
using System.Linq;

namespace Linq
{
    class Program
    {

        public static Student[] MakeSomeStudents(int numStudents){
            Student[] theStudents = new Student[numStudents];
            for (int i = 0; i < numStudents; i++)
            {
                Student newStudent = new Student(""+i, "firstname_" + i, "lastname_"+i);
              
                Random rnd = new Random();
                double randomDouble = rnd.NextDouble();
                Console.WriteLine("randomDouble for "+i+ " is " + randomDouble);
                int multby100k = (int)(randomDouble * 100000); // casting to drop off decimals
                Console.WriteLine("multby100k for "+i+ " is " + multby100k);
                double balance = multby100k / 100.0;
                newStudent.balance = balance;
                theStudents[i] = newStudent;
            }
            return theStudents;
        }
        public static void Main(string[] args)
        {
            Student[] myStudents = MakeSomeStudents(100);
            foreach (Student s in myStudents  )
            {
                Console.WriteLine(s.id + " is {0} {1} and their balance is {2}", s.firstName, s.lastName, s.balance);
                
                
            }

            var resultSet = 
                from stu in myStudents
                where (stu.firstName.EndsWith("3")) && (stu.lastName.EndsWith("3")) && (stu.balance > 100) // fix their balances
                select stu.firstName;

            // var resultSet1 = myStudents.Where().orderby().select.   you can do it this way too

            foreach (String name in resultSet )
            {
                Console.WriteLine("The student from the query " + name);
            }

        }
    }

    public class Student {
        public String firstName {get;set;}
        public String lastName;
        public double balance{get;set;}
        public String id;

        public Student(String id, String firstName, String lastName){
            this.balance = balance;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
    
}
