using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Specialized;
using System.Text;

/*
Code Challenge #3
Onto the next challenge.  This week we’ll tackle the classic FizzBuzz problem.  Loop to 150 starting at 1.  If the number is divisible by 3 print out “fizz”.  If the number is divisible by 5 print out “buzz”.  If it’s divisible by 3 and 5 print out “fizzbuzz”.  (If you’ve already solved this problem before or cruise through it easily, try it with a language you aren’t familiar with)
http://en.wikipedia.org/wiki/Fizz_buzz

Extra points if you can also print out “prime” for numbers between 1 and 150 that are prime numbers
http://en.wikipedia.org/wiki/Prime_numbers.

Please send solutions and/or questions to dan.bunker@stgutah.com and brett.child@stgutah.com this week.  Thanks and happy coding!
 
Dan*/

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge03_FizzBuzz : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            Int16 maxNum = 0;
            if (Int16.TryParse(userInput, out maxNum) && maxNum > 1)
            {
                var sb = new StringBuilder();
                for (int i = 1; i <= maxNum; i++)
                {
                    string fizzbuzzString = "";
                    if (isDivisibleBy(i, 3))
                    {
                        fizzbuzzString += "fizz";
                    }
                    if (isDivisibleBy(i, 5))
                    {
                        fizzbuzzString += "buzz";
                    }
                    if (isPrimeNumber(i))
                    {
                        fizzbuzzString += "prime";
                    }
                    if (fizzbuzzString != "")
                    {
                        sb.AppendLine(i + ":" + fizzbuzzString);
                    }
                }
                return sb.ToString();
            }
            else
            {
                return String.Format("Invalid number.  Please enter a number between 2 and {0}", Int16.MaxValue);
            }
        }

        // TODO - implement this more efficient algorithm: http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes   
        public static bool isPrimeNumber(int num)
        {
            int divisorCount = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    divisorCount++;
                }
                if (divisorCount > 2)
                {
                    break;
                }
            }
            return divisorCount == 2;
        }

        public static bool isDivisibleBy(int num, int divisor)
        {
            return num % divisor == 0;
        }
    }
}
