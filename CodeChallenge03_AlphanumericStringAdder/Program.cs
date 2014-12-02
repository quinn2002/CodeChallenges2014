using System;
using System.Linq;

/*
 Week 3 Challenge:

 Search for all the numbers in a string, add them together, then return that final number divided by the total amount of letters in the string. 
 For example: if the string is "Hello6 9World 2, Nic8e D7ay!" the output should be 2. First if you add up all the numbers, 6 + 9 + 2 + 8 + 7 
 you get 32. Then there are 17 letters in the string. 32 / 17 = 1.882, and the final answer should be rounded to the nearest whole number, 
 so the answer is 2. You may have multi digit numbers as well as negative numbers so be sure to handle those as well.

 */
namespace CodeChallenge03_AlphanumericStringAdder
{
	class Program
	{
		static void Main(string[] args)
		{
			string userInput;
			do
			{
				Console.WriteLine("\nEnter string from which to calculate result (type 'q' to quit):");
				userInput = Console.ReadLine();
				Console.WriteLine("\nNum Char Sum: {0}", GetNumCharSum(userInput));
				Console.WriteLine("Letter Count: {0}", GetLetterCount(userInput));
				Console.WriteLine("Division result = {0}", Math.Round(DivideNumCharSumByLetterCount(userInput), MidpointRounding.AwayFromZero));
			} while (userInput != "q");
		}

		public static double DivideNumCharSumByLetterCount(string s)
		{
			var numCharSum = GetNumCharSum(s);
			var letterCount = GetLetterCount(s);
			if (letterCount <= 0)
				return 0;
			return (double)numCharSum / letterCount;
		}

		private static Int64 GetNumCharSum(string s)
		{
			Int64 sum = 0;
			for (var i = 0; i < s.Length; i++)
			{
				Int64 numInt;
				var numString = ExtractNums(s, i);

				if (Int64.TryParse(numString, out numInt))
				{
					sum += numInt;
					i += numString.Length - 1;
				}
			}

			return sum;
		}

		public static int GetLetterCount(string s)
		{
			return s.Count(Char.IsLetter);
		}

		public static string ExtractNums(string s, int index = 0)
		{
			var numString = "";
			var startIndex = index;
			for (var i = index; i < s.Length; i++)
			{
				if (i == startIndex && s[startIndex] == '-')
					numString = "-";
				else if (CharIsNumber(s[i]))
					numString += s[i];
				else
					break;
			}
			return numString;
		}

		public static bool CharIsNumber(char? c)
		{
			return c >= '0' && c <= '9';
		}
	}
}
