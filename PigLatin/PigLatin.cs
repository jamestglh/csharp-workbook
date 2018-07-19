using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
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
        }
    }
}
