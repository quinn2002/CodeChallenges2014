using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using CodeChallengesBL.Interfaces;

namespace CodeChallengesBL.ConcreteClasses._2015_Q1
{
	public class CodeChallenge02_ChangeMachine : ICodeChallenge
	{
		public string OutputResult(OrderedDictionary inputValues)
		{
			string userInput = inputValues[0].ToString();
			if (IsValidCurrency(userInput))
			{
				decimal userCurrency = Convert.ToDecimal(userInput);
				return String.Format("Change for {0:C2} is: {1}", userCurrency, ComputeChange(userCurrency));
			}
			else
			{
				return ("Invalid currency decimal value.  Please try again.");
			}
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
