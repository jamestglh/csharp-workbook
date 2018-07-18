using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // your code goes here
            // char[] vowels =  { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U',};

            // Console.WriteLine("Enter a sentence");
            // string sentence = Console.ReadLine();

            // string[] words = sentence.Split(' ');

            // foreach (var wordInArr in words)
            // {
            //     string word = wordInArr;
            //     Console.WriteLine(word);
                
            // }

            TranslateWords();
            PlayAgain();

            void TranslateWords() {
                Console.WriteLine("Please type in a word or sentence and press the Enter key.");
                string sentence = Console.ReadLine();
                string[] words = sentence.Split(' ');
                string[] translatedWords = new string[words.Length];
                for (int i = 0; i < words.Length; i++)
                {
                    char[] vowels =  { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'y', 'Y'};
                    string word = words[i];
                    int wordLength = word.Length;
                    int firstVowelIndex = word.IndexOfAny(vowels);
                    string firstHalf = word.Substring(0, firstVowelIndex);
                    int secondHalfLength = wordLength - firstVowelIndex;
                    string secondHalf = word.Substring(firstVowelIndex, secondHalfLength);
                    if (firstVowelIndex == 0)
                    {
                        string composite = secondHalf + firstHalf + "yay";
                        translatedWords[i] = composite;
                    }
                    else
                    {
                        string composite = secondHalf + firstHalf + "ay";
                        translatedWords[i] = composite;
                    }
                }
                string translatedSentence = String.Join(" ", translatedWords);
                Console.WriteLine(translatedSentence);
            }

            void PlayAgain() {

                string[] yes =  { Convert.ToString('y'), Convert.ToString('Y'), "yes", "Yes", "YES"};
                Console.WriteLine("Do you want to try again? [y/n]");
                for (int i = 0; i < yes.Length; i++)
                {
                    string choice = Console.ReadLine();
                    if (choice == yes[i]) 
                    {
                        TranslateWords();
                        PlayAgain();
                    }
                    else
                    {
                        Console.WriteLine("Bye!");
                        Environment.Exit(0);
                    }

                }


            }




            // TranslateWord();

            // void TranslateWord(){
            
            //     char[] vowels =  { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U',};
            //     char[] vowelsy =  { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'y', 'Y'};

            //     Console.WriteLine("Enter a word");
            //     string word = Console.ReadLine();
            //     int wordLength = word.Length;
            //     string ay = "ay";
            //     string yay = "yay";
            //     Console.WriteLine("The wordLength of the word \"" + word + "\" is " + wordLength + " characters long.");
            
            //     int firstVowelIndex = word.IndexOfAny(vowels);
            //     Console.WriteLine("The index of the first vowel in the word \"" + word + "\" is " + firstVowelIndex);

            //     string firstHalf = word.Substring(0, firstVowelIndex);
            //     Console.WriteLine("The firstHalf is " + firstHalf);

            //     int secondHalfLength = wordLength - firstVowelIndex;
            //     Console.WriteLine("The length of the second half is " + secondHalfLength);

            //     string secondHalf = word.Substring(firstVowelIndex, secondHalfLength);
            //     Console.WriteLine("The secondHalf is " + secondHalf);

            //     if (firstVowelIndex == 0)
            //     {
            //         string composite = secondHalf + firstHalf + yay;
            //         Console.WriteLine("Your pig latin translation of \"" + word + "\" is " + composite);
            //     }

            //     else
            //     {
            //         string composite = secondHalf + firstHalf + ay;
            //         Console.WriteLine("Your pig latin translation of \"" + word + "\" is \"" + composite + "\".");
            //     }
            
            // }
            
            // leave this command at the end so your program does not close automatically
            
        }
        
    }
}
