using System;
using System.Collections.Generic;

namespace Project_Euler
{
    class Problem2
    {
        ///<summary>
        ///Considering values in the Fibonacci sequence that are less than 4 million, find the sum of all even terms
        ///</summary>
        public static void Calculate ()
        {
            int[] fibonacci = GenerateFibonacci();
            int sum = SumEvenTerms(fibonacci);
            Console.WriteLine("The sum of all even terms of the Fibonacci seqence up to 4 million is: {0}", sum);
        }

        static int[] GenerateFibonacci()
        {
            List<int> memo = new List<int>();
            memo.Add(1);
            memo.Add(1);
            int i = 2;
            int limit = 0;
            while (limit <= 4000000)
            {
                memo.Add(memo[i-1] + memo[i-2]);
                limit = memo[i];
                i++;
            }
            return memo.ToArray();
        }

        static int SumEvenTerms(int[] fibonacci)
        {
            int sum = 0;
            for (int i = 0; i < fibonacci.Length; i++)
            {
                if (fibonacci[i] % 2 == 0)
                {
                    sum += fibonacci[i];
                }
            }
            return sum;
        }

        //Solution given by Mathblog, for reference.
        static void SolutionCalculate()
        {
            long [] fib = {2,0};
            int i = 0;
            long summed = 0;

            while (fib[i] < 4000000)
            {
                summed += fib[i];

                i = (i+1) % 2;
                fib[i] = 4 * fib[(i-1) % 2];
            }

            Console.WriteLine("The sum of all even terms of the Fibonacci sequence less than 4,000,000 is: {0}", summed);
        }
    }
}