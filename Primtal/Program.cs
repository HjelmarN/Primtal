using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Primtal
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

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

        //Method informing the user if the input number is prime or not
        public static void PrintIfPrime(int input)
        {
            if (IsPrime(input))
            {
                Console.WriteLine($"{input} is prime");

                if (!primeList.Contains(input))
                {
                    primeList.Add(input);
                }

                primeList.Sort();
            }
            else
            {
                Console.WriteLine($"{input} is not prime");
            }
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
                    isPrime = true;
                }
            }
        }
                   

        public static void PrintPrimes()
        {
            foreach (var item in primeList)
            {
                Console.WriteLine(item);
            }
        }

        public static void Menu()
        {
            var keepGoing = true;
            Console.WriteLine("Enter 1 to test if numbers are prime or not");
            Console.WriteLine("Enter 2 to add the next prime");
            Console.WriteLine("Enter 3 to show list of saved primes");
            Console.WriteLine("Enter 0 to exit the program");

            var input = Convert.ToInt32(Console.ReadLine());

            while (keepGoing)
            {
                switch (input)
                {
                    case 0:
                        keepGoing = false;
                        break;

                    case 1:
                        Console.WriteLine("Enter numbers to check if prime");
                        var intInput = Convert.ToInt32(Console.ReadLine());
                        PrintIfPrime(intInput);
                        Menu();
                        break;

                    case 2:
                        NextPrime(primeList.LastOrDefault());
                        Menu();
                        break;

                    case 3:
                        PrintPrimes();
                        Menu();
                        break;

                    default:
                        Console.WriteLine("Wrong input, try again!");
                        Menu();
                        break;
                }
            }
        }



                
                
                   
                
                
                
                    
                


                
    }
}
