using System;
using System.Collections.Generic;
using System.Linq;

namespace Primtal
{
    internal static class Prime
    {
        private static bool keepGoing = true; //Bool which I use as the condition in my while loop in the Menu method.

        private static List<int> primeList = new List<int>(); //List where the prime numbers gets added.

        public static void Menu()
        {
            PrintMenu();
            var userInput = Console.ReadLine();
            var input = 0;

            try
            {
                input = Convert.ToInt32(userInput); //Exception handling in case the user inputs something wrong.
            }
            catch (OverflowException)
            {
                Console.WriteLine("The value was too large.");
                Menu();
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong type of input, requires a number.");
                Menu();
            }
            while (keepGoing)
            {
                switch (input)
                {
                    case 0:
                        keepGoing = false; //Updates the value so the while loop stops, which stops the program.
                        break;

                    case 1:
                        PrintIfPrime();
                        Menu();
                        break;

                    case 2:
                        NextPrime(primeList.LastOrDefault()); //Uses the last prime number in the primeList as the parameter.
                        Menu();                               //Which is the highest prime number because I sorted the list already.
                        break;

                    case 3:
                        PrintPrimes();
                        Menu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("There is no corresponding menu choice, try again!");
                        Menu();
                        break;
                }
            }
        }

        //Method that calculates if number is prime or not.
        private static bool IsPrime(int number)
        {
            if (number <= 1) return false; //Exception that the loop can't handle.
            if (number == 2) return true; //Exception that the loop can't handle.
            if (number % 2 == 0) return false; //If the number is evenly divided by two, it is not a prime number.
            var limit = Math.Sqrt(number); //Creating the loop's limit.

            //The loop divides the input number with all numbers starting from two to the square root of the number.
            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0) //If the number is evenly divided it is not prime.
                {
                    return false;
                }
            }

            return true; //If it is not evenly divided it is prime.
        }

        //Calculates the next prime number with greater value than the greatest in the primeList.
        private static void NextPrime(int number)
        {
            Console.Clear();
            var isPrime = false;

            while (!isPrime)
            {
                var counter = ++number; //Starts at number + 1, and increments by 1 each turn.

                if (IsPrime(counter)) //Uses the IsPrime method with the counter as the parameter.
                {
                    primeList.Add(counter); //Adds the number counter's value to the list of prime numbers.
                    isPrime = true; //Updates the isPrime variable to true to cancel the while loop.
                    Console.WriteLine("Prime number has been added."); //Inform the user that a prime number has been added to the list.
                }
            }
        }

        //Informing the user if the input number is prime or not.
        private static void PrintIfPrime()
        {
            Console.Clear();
            Console.WriteLine("Enter numbers to check if prime");
            var input = 0;

            try //Error handling in case the user input something wrong.
            {
                input = Convert.ToInt32(Console.ReadLine());

                if (IsPrime(input)) //Using the IsPrime method to calculate if prime or not.
                {
                    Console.WriteLine($"{input} is prime");

                    if (!primeList.Contains(input))
                    {
                        primeList.Add(input); //If the number is prime it gets added to the primeList.
                    }

                    primeList.Sort(); //Sorts the primeList
                }
                else
                {
                    Console.WriteLine($"{input} is not prime");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("The value was too large.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong type of input, requires a number.");
            }
        }

        //Prints the different menu choices to inform the user.
        private static void PrintMenu()
        {
            Console.WriteLine("Enter 1 to test if numbers are prime or not");
            Console.WriteLine("Enter 2 to add the next prime");
            Console.WriteLine("Enter 3 to show list of saved primes");
            Console.WriteLine("Enter 0 to exit the program");
        }

        //Prints the prime numbers stored in the primeList.
        private static void PrintPrimes()
        {
            Console.Clear();
            foreach (var item in primeList) //Iterates through all the elements in the primeList.
            {
                Console.WriteLine(item);
            }
        }
    }
}