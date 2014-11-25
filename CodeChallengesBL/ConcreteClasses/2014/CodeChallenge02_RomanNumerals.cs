using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

/*
 Code Challenge #2
Onto the next challenge.  This week we’ll make it a little harder.  Write a function or method that takes a Roman Numeral String and returns the Decimal value.  Essentially, you need to write a Roman Numeral converter.  Here is an explanation of Roman numerals for anyone who’s never encountered them before.  http://www.wikihow.com/Convert-Roman-Numerals
 
Extra points if you can also include a summary of the performance cost of this algorithm.  If you aren’t aware of Big O notation you can find info on it here: http://en.wikipedia.org/wiki/Big_O_notation.  I’m mainly interested if you think the algorithm is constant, linear, quadratic, exponential, etc.  
 
Please send solutions and/or questions to dan.bunker@stgutah.com.  Thanks and happy coding!
 
Dan
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge02_RomanNumerals : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            if (AreValidRomanNumerals(userInput))
            {
                return String.Format("Value for {0} is: {1}", userInput, RomanNumeralsToDecimal(userInput));
            }
            else
            {
                return "Invalid Roman Numerals.  Please try again.";
            }
        }

        public static bool AreValidRomanNumerals(string userInput)
        {
            string validRomanNumerals = "IiVvXxLlCcDdMm";
            foreach (char c in userInput)
            {
                if (!validRomanNumerals.Contains(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public static int RomanNumeralsToDecimal(string userInput)
        {
            List<int> setSums = getRomanNumeralDecimalSets(userInput);
            int sum = 0;
            foreach (int setSum in setSums)
            {
                sum += setSum;
            }
            return sum;
        }

        public static List<int> getRomanNumeralDecimalSets(string userInput)
        {
            var decimals = getRomanNumeralDecimalLookupVals(userInput);
            var setSums = new List<int>();

            for (int i = 0; i < decimals.Count; i++)
            {
                if (i + 1 == decimals.Count || decimals[i] >= decimals[i + 1])
                {
                    // count how many times the num appears in a row and multiply the num by that count
                    int repeatCount = 0;
                    for (int j = i; j < decimals.Count; j++)
                    {
                        if (j + 1 < decimals.Count && decimals[j + 1] == decimals[j])
                        {
                            repeatCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    setSums.Add(decimals[i] * (repeatCount + 1));
                    i = i + (repeatCount);
                }
                else
                {
                    // subtract the value of the symbol before the num from the num
                    setSums.Add(decimals[i + 1] - decimals[i]);
                    i = i + 1;
                }
            }
            return setSums;
        }

        public static List<int> getRomanNumeralDecimalLookupVals(string userInput)
        {
            var decimalLookup = getRomanNumeralLookupTable();
            var decimals = new List<int>();
            for (int i = 0; i < userInput.Length; i++)
            {
                decimals.Add(decimalLookup[UpperCaseChar(userInput[i])]);
            }
            return decimals;
        }

        public static Dictionary<char, int> getRomanNumeralLookupTable()
        {
            var dictRomanNumeralVals = new Dictionary<char, int>();
            dictRomanNumeralVals.Add('I', 1);
            dictRomanNumeralVals.Add('V', 5);
            dictRomanNumeralVals.Add('X', 10);
            dictRomanNumeralVals.Add('L', 50);
            dictRomanNumeralVals.Add('C', 100);
            dictRomanNumeralVals.Add('D', 500);
            dictRomanNumeralVals.Add('M', 1000);
            return dictRomanNumeralVals;
        }

        public static char UpperCaseChar(char input)
        {
            return input.ToString().ToUpper()[0];
        }
    }
}
