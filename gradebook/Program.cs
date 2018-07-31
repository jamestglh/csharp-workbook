﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack studentz = new Stack();
            Dictionary<string, int[]> gradez = new Dictionary<string, int[]>();
            Console.WriteLine("Dictionary and Stack Practice");

            GetStudentName();
            GetGrades();

            void GetStudentName(){
                
                Console.WriteLine("Please enter a student name, or type \"done\" when done.");     
                    string input = Console.ReadLine();
                    if (input == "done")
                    {
                        GetGrades();
                    }
                    else 
                    {
                        studentz.Push(input);
                        GetStudentName();
                    }
            }

            void GetGrades(){                
                foreach (string student in studentz)
                {
                    Console.WriteLine("Please enter the grades for " + student + ", with commas in between the grades");
                    string input = Console.ReadLine();
                    string[] gradeArray = (input).Split(",");
                    int[] gradeArrayInt = new int[gradeArray.Length];
                    for (int i = 0; i < gradeArray.Length; i++)
                    {
                        if (Int32.TryParse(gradeArray[i], out gradeArrayInt[i]))
                        {
                        }
                        else
                        {
                            Console.WriteLine("One of your inputs was invalid, please try again");
                        }
                    }
                        gradez.Add(student, gradeArrayInt);
                }
            }
        }
    }
}
