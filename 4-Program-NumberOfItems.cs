using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace codingpracticeevents
{
    internal class Program
    {
        /**
        * This company would like to know how much inventory exists in their closed inventory compartments.  Given a string s consisting of items as "*" and closed compartments as an open and close "|", an array of starting indices startIndices and an array of ending indices endIndices, determine the number of items in closed compartments within the substring between the two indices, inclusive.
        * 
        * An item is represented as an asterisk ('*' ascii decimal 42)
        * A compartment is represented as a pair of pipes that may or may not have items between them ('|' = ascii decimal 124).
        */
        public static void Main(string[] args)
        {
            string input = "|**|*|";
            var startIndices = LoadIndice(input);
            var endIndices = LoadIndice(input);

            var result = NumbertOfItems(input, startIndices, endIndices); //should return [2,3]

            //Turn link to array for final output - output array to console

            Console.WriteLine("[{0}]", string.Join(", ", result));

            //Debug
            //foreach (int value in result)
            //{
            //    Console.WriteLine(value);
            //}
        }

        /*
          * Complete the 'NumbertOfItems' function below.
          * Note: question params List<int> startIndices and List<int> endIndices, but I didn't used them to solve question.
          * By Dewi Tjin March 2022
        */

        public static List<int> NumbertOfItems(string input, List<int> startIndices, List<int> endIndices)
        {
            List<int> result = new List<int>();
            bool isOpeningPipe = false;
            char pipe = '|';
            char star = '*';
            int starCount = 0;

            int i = 0;
            while (i < input.Length)
            {
                //Console.WriteLine(input[i++]);

                if (input[i] == pipe && isOpeningPipe == false)
                {
                    isOpeningPipe = true;
                }
                else if (input[i] == star && isOpeningPipe == true)
                {
                    ++starCount;
                }
                else if (input[i] == pipe && isOpeningPipe == true)
                {
                    result.Add(starCount); //hit because the pipe is a closing pipe
                }

                i++;//update to next char
            }
            return result;
        }

        public static List<int> LoadIndice(string input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Length;)
            {
                result.Add(++i);
            }
            
            return result;
        }
    }
}






