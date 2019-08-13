using System;
using System.Collections.Generic;

namespace Project_Euler
{
    class Problem3
    {
        ///<summary>
        ///The prime factors of 13,195 are 5, 7, 13 and 29.
        ///What is the largest prime factor of 600,851,475,143?
        ///</summary>

        //Generating the Primes:
            //We know that the highest prime factor of a number is less than or equal to its square root (if the sqrt is an integer)
            //We also know that any integer can be expressed as a product of prime factors.
            //Finally, we know that all prime numbers are odd, save for 2, hence we start from 2.

        public static void LargestPrimeFactor()
        {
            long value = 600851475143;
            long largestFactor = GeneratePrimeFactors(value);
            Console.WriteLine("The largest prime factor of 600,851,475,143 is: {0}", largestFactor);
        }

        static long GeneratePrimeFactors(long value)
        {
            long largestFactor = 0;
            int counter = 2;

            while (value > 1)
            {
                while (value % counter == 0)    //Check whether counter's value is a divisor, and modify value accordingly.
                {
                    value /= counter;
                    largestFactor = counter;
                }
                counter++;
                if ((counter*counter) > value)  //No point checking after the square root of value, hence break.
                {
                    if (value > 1)
                    {
                        largestFactor = value;  //In the case where we reach current value from squaring a prime.
                    }
                    break;
                }
            }
            return largestFactor;
        }

        //Solution given by Mathblog, for reference.
        static long AlternativeMethod(long value)
        {
            long largestFactor = 0;

            int counter = 2;
            while (counter * counter <= value)
            {
                if (value % counter == 0)
                {
                    value /= counter;
                    largestFactor = counter;
                }
                else
                    counter = (counter == 2) ? 3 : counter + 2;
            }
            if (value > largestFactor)      //I.e. the remainder is a prime
            {
                largestFactor = value;
            }
            return largestFactor;
        }
    }
}