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
            var result = MinimalHeaviestSetA(new List<int> { 3, 7, 5, 6, 2 }); //should return 7, 6

            foreach (int value in result)
            {
                Console.WriteLine(value);
            }

            result = MinimalHeaviestSetA(new List<int> { 10, 2, 3, 1 }); //should return 10

            foreach (int value in result)
            {
                Console.WriteLine(value);
            }
        }

        /*
      * Complete the 'minimalHeaviestSetA' function below.
      *
      * The function is expected to return an INTEGER_ARRAY.
      * The function accepts INTEGER_ARRAY arr as parameter.
      * By Dewi Tjin March 2022
      */

        public static List<int> MinimalHeaviestSetA(List<int> arr)
        {

            DescendingOrder descendingOrder = new DescendingOrder();
            arr.Sort(descendingOrder);
            int sumA = 0;
            int total = arr.Sum();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                sumA += arr[i];
                int sumB = total - sumA;

                result.Add(arr[i]);

                if (sumA > sumB)
                {
                    return result;
                }
            }
            return arr;
        }


        public class DescendingOrder : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == 0 || y == 0)
                {
                    return 0;
                }

                // CompareTo() method
                return y.CompareTo(x);

            }
        }
    }
}






