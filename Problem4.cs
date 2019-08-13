using System;
using System.Linq;

namespace Project_Euler
{
    ///<summary>
    ///The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 * 99
    ///What is the largest palindrome that can be made from the product of two 3-digit numbers.
    ///</summary>
    class Problem4
    {
        //We know that 100*100, which is our starting point cannot give a palindrome, so we ignore it.
        public static void LargestPalindrome()
        {
            int[] info = GenerateLargestPalindrome();
            Console.WriteLine("The largest palindrome made from the product of two 3-digit numbers is {0}, made from {1} * {2}", info[0], info[1], info[2]);
        }

        static int[] GenerateLargestPalindrome()
        {
            int largestPalin = 0;
            int result = 0;
            int[] factors = new int[2];

            for (int i = 999; i > 99; i--)
            {
                for (int j = 999; j > 99; j--)
                {
                    result = i * j;
                    if (CheckPalindrome(result) && result > largestPalin)
                    {
                        largestPalin = result;
                        factors[0] = i;
                        factors[1] = j;
                    }
                }
            }
            int[] info = new int[3];
            info[0] = largestPalin;
            info[1] = factors[0];
            info[2] = factors[1];

            return info;
        }

        static bool CheckPalindrome(int value)
        {
            string valueString = value.ToString();
            string reverse = "";
            for (int i = valueString.Length-1; i >= 0; i--)
            {
                reverse += valueString[i];
            }
            return reverse.Equals(valueString);
        }

        //Solution given by Mathblog, for reference.
        static void MathblogSolution()
        {
            bool found = false;
            int firstHalf = 998, palin = 0;
            int[] factors = new int[2];

            while (!found)
            {
                firstHalf--;
                palin = MakePalindrome(firstHalf);
                for (int i = 999; i > 99; i--)
                {
                    if ((palin / i) > 999 || i*i < palin)
                    {
                        break;
                    }
                    if (palin % i == 0)
                    {
                        found = true;
                        factors[0] = palin / i;
                        factors[1] = i;
                        break;
                    }
                }
                Console.WriteLine("Found the palindrome {0}, which is made from {1}*{2}", palin, factors[0], factors[1]);
            }
        }

        static int MakePalindrome(int firstHalf)
        {
            char[] reversed = firstHalf.ToString().Reverse().ToArray();
            return Convert.ToInt32(firstHalf + new string(reversed));
        }
    }
}