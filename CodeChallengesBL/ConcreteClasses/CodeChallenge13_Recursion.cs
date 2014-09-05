using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Specialized;

/*
 Code Challenge #13
 This week’s challenge will be focused on the use of recursion.  Granted the challenge below could be done in a loop but your algorithm this week needs to make use of the concept of recursion to solve this problem.  Please send solutions to dan.bunker@stgutah.com.  Thanks
 
In mathematics, the factorial of integer 'n' is written as 'n!'. It is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

Your challenge is simple: write a function that takes an integer 'n' and returns 'n!'. You are guaranteed an integer argument. For any values outside the positive range, return 'null'.

Note: 0! is always equal to 1. Negative values should return null;

For more on Factorials : http://en.wikipedia.org/wiki/Factorial
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge13_Recursion : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            if (IsValidFactorialNum(userInput))
            {
                Int64? factorialRecursiveResult = FactorialRecursive(Convert.ToInt64(userInput)); // TODO - find out why values > 20 start producing weird results
                Int64? factorialIterativeResult = FactorialIterative(Convert.ToInt64(userInput));
                return String.Format("{0}! = {1:#,###0}\n\n", userInput, factorialRecursiveResult);
                //String.Format("Iterative: {0}! = {1:#,###0}\n\n", userInput, factorialIterativeResult);
            }
            else
            {
                return String.Format("Invalid number for factorial calculation. Make sure number is between {0} and {1}. Please try again.", 0, 1000);
            }
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
            return Int64.TryParse(num, out rval) && rval >= 0 && rval <= 1000;
        }
    }
}
