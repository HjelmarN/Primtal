using System;
using System.Collections.Generic;

namespace Primtal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPrime(18));
            NextPrime(17);

        }

        public static List<int> primeList = new List<int>();

        //Method that calculates if number is prime or not.
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false; //Exception that the loop can't handle.
            if (number == 2) return true; //Exception that the loop can't handle.

            var limit = Math.Sqrt(number); //Creating the loop's limit. 

            //The loop divides the input number with all numbers starting from two to the square root of the number.
            for(int i = 2; i <= limit; ++i)
            {
                if (number % i == 0) //If the number is evenly divided it is not prime.
                {
                    return false;
                }
            }

            return true; //If it is not evenly divided it is prime.
        }

        //Method that calculates the next prime 
        public static void NextPrime(int number)
        {
            var isPrime = false;

            while (!isPrime)
            {
                var counter = ++number;

                if (IsPrime(counter))
                {
                    primeList.Add(counter);
                    Console.WriteLine(counter);
                    isPrime = true;
                }
            }
        }
                
                
                   
                
                
                
                    
                


                
    }
}
