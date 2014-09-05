using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

/*
For code challenge #9, we'll tackle another commonly seen code challenge.  Palindromes. These are a sequence of characters that are the same from left to right or right to left.
 
http://en.wikipedia.org/wiki/Palindrome
 
Examples are: Dad, kayak, civic, etc.
 
Write a method or function that tests if the given set of characters or string is a palindrome or not. Return true if it is and false if it is not.
 
Extra credit.  Determine if a number in binary format is a palindrome.  
 
1 = "1"
2 = "10"
3 = "11"
4 = "100"
 
In this case if you passed in 1 your method would return true, 2 would be false, 3 would be true, etc.

As always send submissions or questions to myself (Dan) or Brett.  Thanks.
 
Dan
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge09_PalindromeCheck : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            return String.Format("Is Palindrome: {0}", Convert.ToBoolean(isPalindrome(userInput)));
        }

        public static bool isPalindrome(string input)
        {
            string str = convertNumToBase(input, 2);
            var reversedStr = new StringBuilder(str.Length);
            var charStack = new Stack<char>(str);

            for (int i = 0; i < str.Length; i++)
            {
                reversedStr.Append(charStack.Pop());
            }

            return StringsAreEqualIgnoreCaseAndNonAlphaNumeric(str, reversedStr.ToString());
        }

        public static string convertNumToBase(string num, int toBase)
        {
            int _num;
            if (Int32.TryParse(num, out _num) && (toBase == 2 || toBase == 8 || toBase == 16))
            {
                return Convert.ToString(_num, toBase);
            }
            else
            {
                return num;
            }
        }

        // strip out all non-alphanumeric chars, then do case-insensitive compare
        public static bool StringsAreEqualIgnoreCaseAndNonAlphaNumeric(string str1, string str2)
        {
            return String.Compare(stripNonAlphanumericChars(str1), stripNonAlphanumericChars(str2), true) == 0;
        }

        public static string stripNonAlphanumericChars(string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
