using System;
using System.Collections.Generic;
using System.IO;

namespace MVCCodeChallenges.UtilityClasses
{
    public static class FileReader
    {
        public static List<string> GetWordsFromFile(string resourceLocation)
        {
            try
            {
                string[] allWords = File.ReadAllText(@resourceLocation).Split(' ');
                var wordList = new List<string>(allWords);
                var sanitizedWordList = new List<string>();

                // only keep words and punctuation (if it's part of the word)
                for (int i = 0; i < wordList.Count; i++)
                {
                    string word = wordList[i];
                    if (word.Trim().Length > 0 && !Char.IsPunctuation(word[0]))
                    {
                        sanitizedWordList.Add(word);
                    }
                }
                return sanitizedWordList;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error reading file at:{0}", resourceLocation);
                //Console.WriteLine(e.Message);
                return new List<string>();
            }
        }
    }
}