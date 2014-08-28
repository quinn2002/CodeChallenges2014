using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

/*
Code Challenge #8
As developers we often use Lorem Ipsum text of a specific length as a placeholder.  The coding challenge this week will be to create a Lorem Ipsum generator.  It should generate text with a specified number of words using Lorem Ipsum text.  
 
Acceptance Criteria:
- Create a method that accepts a number and returns that many words of Lorem Ipsum text. 
- If the number is greater than the words of Lorem Ipsum it should start from the beginning again. 
Example: An input of 5 would output 'Lorem ipsum dolor sit amet'.  Feel free to handle puncuation anyway you would like.  http://en.wikipedia.org/wiki/Lorem_ipsum
 
Bonus Point:
- Modify the method to allow you to select the type of Ipsum text (your choices could include Lorem, Bacon, Riker, or whatever else you want, but there should at least be 2)
Example:  An input of 10 and 'Bacon' would output something like 'Bacon ipsum dolor sit amet ham andouille tail, beef chicken'.  You can use a small paragraph of the different texts as a base.  
 
Examples of other Ipsums: 
http://baconipsum.com/
http://www.rikeripsum.com/
 
Please send solutions and/or questions to dan.bunker@stgutah.com and brett.child@stgutah.com this week.  Thanks and happy coding!
 
Brett
 */

namespace CodeChallenge08_LoremIpsumGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Dictionary<int, LoremIpsumBase> classDictionary = LoadLoremIpsumDerivedClasses();
                GenerateLoremIpsumMenuOptions(classDictionary);

                userInput = Console.ReadLine();
                int userOptionNum;

                if (Int32.TryParse(userInput, out userOptionNum) && classDictionary.ContainsKey(userOptionNum))
                {
                    Console.WriteLine("\nEnter the number of words you would like to generate:");
                    userInput = Console.ReadLine();
                    Int16 userWordCount;
                    if (Int16.TryParse(userInput, out userWordCount) && userWordCount > 0)
                    {
                        var selectedClass = classDictionary[userOptionNum];
                        Console.WriteLine(selectedClass.GenerateText(userWordCount, selectedClass.TxtFileName));
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.  Make sure to pick a valid number of words to generate < {0}.", Int16.MaxValue);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option chosen.  Please select a number from the list below.");
                }
            } while (userInput != "q");
        }

        // get a dictionary of all classes that inherit from LoremIpsumBase (dictionary key is the ID property of the obj)
        public static Dictionary<int, LoremIpsumBase> LoadLoremIpsumDerivedClasses()
        {
            var objects = new Dictionary<int, LoremIpsumBase>();
            var typesThatInheritFromBaseClass = Assembly.GetAssembly(typeof(LoremIpsumBase)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(LoremIpsumBase)));
            foreach (Type type in typesThatInheritFromBaseClass)
            {
                LoremIpsumBase obj = Activator.CreateInstance(type) as LoremIpsumBase;
                if (!objects.ContainsKey(obj.ID))
                {
                    objects.Add(obj.ID, obj);
                }
            }
            return objects;
        }

        private static void GenerateLoremIpsumMenuOptions(Dictionary<int, LoremIpsumBase> classDictionary)
        {
            Console.WriteLine();
            foreach(var c in classDictionary)
            {
                LoremIpsumBase classInstance = c.Value;
                Console.WriteLine("Type " + classInstance.ID + " for " + classInstance.Type);
            }
            Console.WriteLine("Type 'q' to quit.");
        }
    }

    public abstract class LoremIpsumBase
    {
        //properties
        public int ID { get; private set; } //uniquely identifies the derived class--will also be the number the user types to select the class
        public string Type { get; private set; } //user-friendly string of the type of Lorem Ipsum text
        public string TxtFileName { get; private set; } //filename in project that actually contains the base text

        //methods
        public string GenerateText(int numWords, string fileName)
        {
            string directoryPath = string.Empty;
            string directoryPathFromConfig = ConfigurationManager.AppSettings["LoremIpsumDirectoryPath"];
            directoryPath = !String.IsNullOrEmpty(directoryPathFromConfig) ? directoryPathFromConfig : directoryPath;
            List<string> wordList = FileReader.GetWordsFromFile(@directoryPath + fileName);

            if (wordList.Count > 0)
            {
                var output = new List<string>();
                for (int i = 0; i < numWords; i++)
                {
                    output.Add(wordList[i % wordList.Count]);
                }
                return String.Join(" ", output.ToArray());
            }
            else
            {
                return "Error.  File is empty, does not exist, or is invalid.";
            }
        }

        //constructor
        public LoremIpsumBase(int id, string type, string txtFileName)
        {
            this.ID = id;
            this.Type = type;
            this.TxtFileName = txtFileName;
        }
    }

    public class LoremIpsum : LoremIpsumBase
    {
        public LoremIpsum()
            : base(1, "Lorum Ipsum", "LoremIpsum.txt")
        {}
    }

    public class BaconIpsum : LoremIpsumBase
    {
        public BaconIpsum()
            : base(2, "Bacon Ipsum", "BaconIpsum.txt")
        {}
    }

    public class RikerIpsum : LoremIpsumBase
    {
        public RikerIpsum()
            : base(3, "Riker Ipsum", "RikerIpsum.txt")
        {}
    }

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
                Console.WriteLine("Error reading file at:{0}", resourceLocation);
                Console.WriteLine(e.Message);
                return new List<string>();
            }
        }
    }
}
