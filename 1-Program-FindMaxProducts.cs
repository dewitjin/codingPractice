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
         * As part of a stock clearance exercise at the store, given many piles of products, follow the rules given below to stack the products in an orderly manner.
         * 
         * There are a total of n piles in products.
         * The number of products in each pile is represented by the array numProducts.
         * Select any subarray from the array numProducts and pick up products from that subarrays such that the number of products you pick from i-th pile is less than the number of products you pick from the (i+1)-th pile for all the indices i of the subarray.
         */
        public static void Main(string[] args)
        {

            var result = FindMaxProducts(new List<int>() { 7, 4, 5, 2, 6, 5 });
            Console.WriteLine(result); //should return 12

            result = FindMaxProducts(new List<int>() { 2, 5, 6, 7 });
            Console.WriteLine(result); //should return 20

            result = FindMaxProducts(new List<int>() { 2, 9, 4, 7, 5, 2 });
            Console.WriteLine(result); //should return 16

        }

        /*
         * Complete the 'findMaxProducts' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts INTEGER_ARRAY products as parameter.
         * By Dewi Tjin March 2022
     */

        public static long FindMaxProducts(List<int> products)
        {
            int sum = 0;
            int previousAddOn = 0;
            int difference = 0;

            for (int i = 0; i < products.Count; i++)
            {
                if (i < products.Count - 2)
                {
                    difference = products[i] - products[i + 1]; //only get difference if there is two inputs to compute
                }

                if (difference > 0)
                {
                    //here current item is greater than next item
                    if (difference > previousAddOn)
                    {
                        //check to see if the next item is smaller because we can only add the smaller amount minus 1
                        if (difference > products[i + 1])
                        {
                            sum += products[i + 1] - 1;
                            previousAddOn = products[i + 1] - 1;

                        }
                        else
                        {
                            sum += difference;
                            previousAddOn = difference;
                        }

                    }
                    else
                    {
                        if (products[i] > previousAddOn)
                        {
                            sum += products[i];
                            previousAddOn = products[i];
                        }
                    }
                }
                else
                {
                    //here current item is less than next item
                    if (products[i] > previousAddOn)
                    {
                        sum += products[i];
                        previousAddOn = products[i];
                    }
                    else
                    {
                        //if the current value is less than the previousAddOn value then the subarray breaks
                        return sum;

                    }
                }

            }

            return sum;

        }

    }

}







