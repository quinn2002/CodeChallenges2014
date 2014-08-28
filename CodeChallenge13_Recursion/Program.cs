using System;

/*
 Code Challenge #13
 This week’s challenge will be focused on the use of recursion.  Granted the challenge below could be done in a loop but your algorithm this week needs to make use of the concept of recursion to solve this problem.  Please send solutions to dan.bunker@stgutah.com.  Thanks
 
In mathematics, the factorial of integer 'n' is written as 'n!'. It is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

Your challenge is simple: write a function that takes an integer 'n' and returns 'n!'. You are guaranteed an integer argument. For any values outside the positive range, return 'null'.

Note: 0! is always equal to 1. Negative values should return null;

For more on Factorials : http://en.wikipedia.org/wiki/Factorial
 */

namespace CodeChallenge13_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInput;
            do
            {
                Console.WriteLine("Enter number for factorial calculation, followed by 'Enter' key.  Type 'q' to quit:");
                userInput = Console.ReadLine();
                if (IsValidFactorialNum(userInput))
                {
                    Int64? factorialRecursiveResult = FactorialRecursive(Convert.ToInt64(userInput)); // TODO - find out why values > 20 start producing weird results
                    Int64? factorialIterativeResult = FactorialIterative(Convert.ToInt64(userInput));
                    Console.WriteLine("{0}! = {1:#,###0}\n\n", userInput, factorialRecursiveResult);
                    //Console.WriteLine("Iterative: {0}! = {1:#,###0}\n\n", userInput, factorialIterativeResult);
                }
                else
                {
                    Console.WriteLine("Invalid number for factorial calculation.  Please try again.\n\n");
                }
            } while (userInput != "q");
        }

        public static Int64? FactorialRecursive(Int64 num)
        {
            if (num < 0)
            {
                return null;
            }
            if (num == 0 || num == 1)
            {
                return 1;
            }
            else
            {
                return num * FactorialRecursive(num - 1);
            }
        }

        public static Int64? FactorialIterative(Int64 num)
        {
            if (num < 0)
            {
                return null;
            }
            if (num == 0 || num == 1)
            {
                return 1;
            }
            Int64 result = num;
            {
                for (Int64 i = num - 1; i > 1; i--)
                {
                    result = result * i;
                }
            }
            return result;
        }

        public static bool IsValidFactorialNum(string num)
        {
            Int64 rval;
            return Int64.TryParse(num, out rval) && rval >= 0;
        }
    }
}
