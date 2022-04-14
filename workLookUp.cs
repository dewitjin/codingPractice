using System;
using System.Collections.Generic;

/*
You are running a classroom and suspect that some of your students are passing around the answers to multiple choice questions disguised as random strings.

Your task is to write a function that, given a list of words and a string, finds and returns the word in the list that is scrambled up inside the string, if any exists. There will be at most one matching word. The letters don't need to be in order or next to each other. The letters cannot be reused.

Example:
words = ['cat', 'baby', 'dog', 'bird', 'car', 'ax']
string1 = 'tcabnihjs'
find_embedded_word(words, string1) -> cat (the letters do not have to be in order)

string2 = 'tbcanihjs'
find_embedded_word(words, string2) -> cat (the letters do not have to be together)

string3 = 'baykkjl'
find_embedded_word(words, string3) -> None / null (the letters cannot be reused)

string4 = 'bbabylkkj'
find_embedded_word(words, string4) -> baby

string5 = 'ccc'
find_embedded_word(words, string5) -> None / null

string6 = 'breadmaking'
find_embedded_word(words, string6) -> bird

Complexity analysis variables:

W = number of words in `words`
S = maximal length of each word or string
*/

namespace codingPracticeEvents
{
    internal class karat
    {
        static void Main(String[] args)
        {
            string[] words = new string[] { "cat", "baby", "dog", "bird", "car", "ax" };
            string string1 = "tcabnihjs";
            string string2 = "tbcanihjs";
            string string3 = "baykkjl";
            string string4 = "bbabylkkj";
            string string5 = "ccc";
            string string6 = "breadmaking";

            var result = find_embedded_word(words, string1);
            Console.WriteLine(result);//cat

            result = find_embedded_word(words, string2);
            Console.WriteLine(result);//cat 

            result = find_embedded_word(words, string3);
            Console.WriteLine(result); //should be null

            result = find_embedded_word(words, string4);
            Console.WriteLine(result); //baby

            result = find_embedded_word(words, string5);
            Console.WriteLine(result); //null

            result = find_embedded_word(words, string6);
            Console.WriteLine(result); //bird
        }

        public static string find_embedded_word(string[] words, string text)
        {
            string result = null;
            var isFound = false;

            //PrintDictionary(dict);//debug

            foreach (string word in words)
            {
                int foundLength = 0;
                var dict = loadDictionary(text); //load up dict again after each word
                foreach (char letter in word)
                {
                    if (dict.ContainsKey(letter))
                    {
                        dict.TryGetValue(letter, out int incrementValue);

                        if (incrementValue > 0)
                        {
                            dict[letter] = --incrementValue;
                            foundLength += 1;
                        }

                        if (foundLength == word.Length)
                        {
                            isFound = true;
                        }

                        if (isFound)
                        {
                            return word;
                        }

                    }
                    else 
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public static Dictionary<char, int> loadDictionary(string words)
        {
            Dictionary<char, int> results = new Dictionary<char, int>();

            foreach (char letter in words)
            {
                var isExists = results.TryGetValue(letter, out int incrementValue);

                if (isExists)
                {
                    results[letter] = ++incrementValue;
                }
                else
                {
                    results[letter] = 1;
                }
            }

            return results;
        }

        public static void PrintDictionary(Dictionary<char, int> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{ pair.Key} -- { pair.Value}");
            }
        }
    }
}



