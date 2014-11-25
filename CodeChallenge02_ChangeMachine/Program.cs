using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Week 2:

The challenge for this week is as follows:

Write a change machine that, given a U.S. currency value, determines the FEWEST number of bills and coins to return for change, listing out the exact change.
 Assume $1, $5, $10, $20, $50, $100 bills and penny, nickel, dime, quarter coins for the denominations.
  
 Here are some examples:
 5.27 -> 1 $5 bill, 1 quarter, 2 pennies
 10 -> 1 $10 bill
 30 -> 1 $20 bill, 1 $10 bill
 */

// Author: Quinn Heiner
namespace CodeChallenge02_ChangeMachine
{
	class Program
	{
		static void Main(string[] args)
		{
			string userInput;
			do
			{
				Console.WriteLine("\n\nEnter the exact change to compute (no $ signs), e.g. 5.26. Type 'q' to quit.");
				userInput = Console.ReadLine();
				if (IsValidCurrency(userInput))
				{
					decimal userCurrency = Convert.ToDecimal(userInput);
					Console.WriteLine("Change for {0:C2} is: {1}", userCurrency, ComputeChange(userCurrency));
				}
				else
				{
					Console.WriteLine("Invalid currency decimal value.  Please try again.");
				}
			} while (userInput != "q");
		}

		public static bool IsValidCurrency(string userInput)
		{
			decimal userDecimal;
			return Decimal.TryParse(userInput, out userDecimal) && userDecimal > 0.0m;
		}

		public static string ComputeChange(decimal amount)
		{
			var sb = new StringBuilder();
			amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
			Dictionary<string, decimal> denominationLookup = GetDenominationLookupValues();
			do
			{
				var maxCurrency = denominationLookup.First(kvp => kvp.Value <= amount);
				amount = amount - maxCurrency.Value;
				sb.Append("\n" + maxCurrency.Key);
			}
			while (amount > 0.00m);
			return AggregateChangeData(sb.ToString(), '\n');
		}

		public static Dictionary<string, decimal> GetDenominationLookupValues()
		{
			return new Dictionary<string, decimal>()
			{
				// these must be listed in descending value for algorithm to work properly
				{"$100 bill", 100.00m},
				{"$50 bill", 50.00m},
				{"$20 bill", 20.00m},
				{"$10 bill", 10.00m},
				{"$5 bill", 5.00m},
				{"$1 bill", 1.00m},
				{"quarter", 0.25m},
				{"dime", 0.10m},
				{"nickel", 0.05m},
				{"penny", 0.01m}
			};
		}

		public static string AggregateChangeData(string changeData, char delimiter)
		{
			var sb = new StringBuilder();
			sb.AppendLine();
			var changeList = new List<string>(changeData.Split(delimiter).Where(x => x.Trim().Length > 0));
			var distinctChangeList = new List<string>(changeList.Distinct());
			foreach (string change in distinctChangeList)
			{
				int changeCount = changeList.Count(x => x == change);
				string changeWord = changeCount == 1 ? change : PluralizeLcWord(change);
				sb.AppendLine(changeCount + " " + changeWord);
			}
			return sb.ToString();
		}

		public static string PluralizeLcWord(string word)
		{
			if (word.EndsWith("y"))
			{
				return word.Remove(word.LastIndexOf('y')) + "ies";
			}
			if (word.EndsWith("s"))
			{
				return word.Remove(word.LastIndexOf('s')) + "es";
			}
			return word + "s";
		}
	}
}
