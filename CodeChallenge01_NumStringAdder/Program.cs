using System;
using System.Text.RegularExpressions;

/*
Code Challenge Problem #1
To kick off the STG code challenge we are going to start with an easier String parsing problem.
 
Create a method or function that takes all of the numbers out of an alphanumerical String and return the numbers found summed together.  Extra points for not using String.toInt(strValue) (or whatever method your language uses) language functionality but convert the number to an int manually.
 
So for the following string "dywi23jssi88sjdhj1" your method would return 22 as an int type. For any questions send them to dan.bunker@stgutah.com.  Happy coding!
 
Dan
 */

namespace CodeChallenge01_NumStringAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("Enter string from which to extract/add numbers (type 'q' to quit):");
                userInput = Console.ReadLine();
                string userInputNums = ExtractNums(userInput);
                Console.WriteLine("Sum = {0}\n\n", SumNumChars(userInputNums));
            } while (userInput != "q");
        }

        public static string ExtractNums(string input)
        {
            return Regex.Replace(input, @"[^0-9-]+", "");
        }

        public static int SumNumChars(string numString)
        {
            int sum = 0;
            for (int i = 0; i < numString.Length; i++)
            {
                int numInt;
                string numChar = numString[i].ToString();
                if (numChar == "-" && i + 1 < numString.Length)
                {
                    numChar += numString[i + 1]; // account for negative numbers
                    i++;
                }
                if (Int32.TryParse(numChar, out numInt))
                {
                    sum += numInt;
                }

            }
            return sum;
        }
    }
}
