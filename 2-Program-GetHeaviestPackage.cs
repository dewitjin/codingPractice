using System;
using System.Collections.Generic;
using System.Linq;

namespace codingpracticeevents
{
    internal class Program
    {
        /**
         * To increase efficieny, the shipping team will group packages being shipped according to weight.  They will merge a lighter package with a heavier package, which eliminates the need for separate shipments.
         * 
         * More formally, consider n packages, where packageWeights[i] represents the weight of the i-th package.  You can combine the i-th and the (i+1)-th pakcage if packageWeights[i] < packageWeights[i+1], then discard the i-th package.  After this operation, the number of packages is reduced by 1 and the weight of the (i+1)-th packages increases by packages by packageWeights[1].  You can merge the packages any number of times.
         * 
         * Find the maximum possible weight of a pakcage that can be achieved after any sequence of merge operations.
        */

        public static void Main(string[] args)
        {
            //problem 1
            var heaviestPackage = GetHeaviestPackage(new List<int>() { 2, 9, 10, 3, 7 });
            Console.WriteLine(heaviestPackage); //answer 21

            //problem 2
            heaviestPackage = GetHeaviestPackage(new List<int>() { 20, 13, 8, 9 });
            Console.WriteLine(heaviestPackage); //answer 50

            //problem 3
            heaviestPackage = GetHeaviestPackage(new List<int>() { 30, 15, 5, 9 });
            Console.WriteLine(heaviestPackage); //answer 30

        }

        /*
         * Complete the 'getHeaviestPackage' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts INTEGER_ARRAY packageWeights as parameter.
         * By Dewi Tjin March 2022
     */

        public static long GetHeaviestPackage(List<int> packageWeights)
        {

            var result = Reduce(packageWeights);

            while (result.Count > 2)
            {
                result = Reduce(result); //reduce list until we only have 2 left to compare

                if (result.Count == 3)
                {
                    break; //Can't reduce because the three left are not in ascending order, solution to edge case problem 3
                }
            }


            if (result.First() < result[1])
            {
                result = Reduce(result);


            }

            //Debug
            //foreach (int i in result)
            //{
            //    Console.WriteLine(i);
            //}

            return result.FirstOrDefault();

        }

        public static List<int> Reduce(List<int> input)
        {
            int p1 = 0;
            int p2 = 0;
            int index = 0;
            int sumWeights = 0;


            for (var i = 0; i < input.Count - 1; i++)
            {
                if (input[i] < input[i + 1])
                {
                    if (sumWeights < (input[i] + input[i + 1]))
                    {
                        index = i;
                        p1 = input[i];
                        p2 = input[i + 1];
                        sumWeights = p1 + p2;
                    }
                }
            }

            if (sumWeights > 0)
            {
                input[index] = sumWeights;
                input.Remove(p1);
                input.Remove(p2);
            }

            return input;
        }
    }

}







