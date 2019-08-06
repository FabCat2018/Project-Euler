using System;

namespace Project_Euler
{
    ///<summary>Find the sum of all factors of 3 or 5 up to 1000</summary>
    class Problem1
    {
        public static void Calculate ()
        {
            int sum = SumMultiples(3, 999) + SumMultiples(5, 999) - SumMultiples(15, 999);
            Console.WriteLine("The sum of all multiples of 3 or 5 less than 1000 is: {0}", sum);
        }

        private static int SumMultiples(int factor, int max)
        {
            int sum = 0;
            for (int i = factor; i < max+1; i++)
            {
                if (i % factor == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}