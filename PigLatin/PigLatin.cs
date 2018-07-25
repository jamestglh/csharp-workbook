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
                string sentence = Console.ReadLine().ToLower();
                string[] words = sentence.Split(' ');
                string[] translatedWords = new string[words.Length];
                for (int j = 0; j < words.Length; j++)
                {
                    char[] vowels =  { 'a', 'e', 'i', 'o', 'u', 'y',};
                    string a = "a";
                    string e = "e";
                    string i = "i";
                    string o = "o";
                    string u = "u";
                    string y = "y";
                    string word = words[j];
                    int wordLength = word.Length; 

                    if (word.Contains(a) || word.Contains(e) || word.Contains(i) || word.Contains(o) || word.Contains(u) || word.Contains(y))
                    {
                        int firstVowelIndex = word.IndexOfAny(vowels);
                        string firstHalf = word.Substring(0, firstVowelIndex);
                        int secondHalfLength = wordLength - firstVowelIndex;
                        string secondHalf = word.Substring(firstVowelIndex, secondHalfLength);
                        if (firstVowelIndex == 0)
                        {
                            string composite = secondHalf + firstHalf + "yay";
                            translatedWords[j] = composite;
                        }
                        else
                        {
                            string composite = secondHalf + firstHalf + "ay";
                            translatedWords[j] = composite;
                        }
                    }
                    else
                    {
                        translatedWords[j] = word + "yay";
                    }


                    // int firstVowelIndex = word.IndexOfAny(vowels);
                    // string firstHalf = word.Substring(0, firstVowelIndex);
                    // int secondHalfLength = wordLength - firstVowelIndex;
                    // string secondHalf = word.Substring(firstVowelIndex, secondHalfLength);
                    // if (firstVowelIndex == 0)
                    // {
                    //     string composite = secondHalf + firstHalf + "yay";
                    //     translatedWords[j] = composite;
                    // }
                    // else
                    // {
                    //     string composite = secondHalf + firstHalf + "ay";
                    //     translatedWords[j] = composite;
                    // }
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
