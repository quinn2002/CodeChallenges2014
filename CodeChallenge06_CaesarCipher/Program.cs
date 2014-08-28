using System;
using System.Text;
using System.Collections.Generic;

/*
Code Challenge #6
For this weeks challenge, we’ll take a look at doing some encryption and decryption.  Implement a basic encrypt and decrypt for a string using a Caesar Cipher.
 
http://en.wikipedia.org/wiki/Caesar_cipher
 
Extra credit if you can make the Caeser Cipher work on non alpha characters.  Stuff like 0-9 or #$%@#@!.
 
Please send solutions and/or questions to dan.bunker@stgutah.com and brett.child@stgutah.com this week.  Thanks and happy coding!
 
Dan
 */

namespace CodeChallenge06_CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("\n\nEnter text to encrypt using Caesar Cipher (type 'q' to quit):");
                userInput = Console.ReadLine();
                Random rnd = new Random();
                int shiftPositionMax = 26;
                int shiftPosition = rnd.Next(1, shiftPositionMax);
                var abcInfo = new AlphabetInfo("eng", 'a', 'A', 'z', 'Z', '0', '9', 26, 10);
                string encrypted = EncryptCaesarCipher(userInput, abcInfo, shiftPosition);
                string decrypted = DecryptCaesarCipher(userInput, encrypted, abcInfo, shiftPosition);
                Console.WriteLine("Shift position is: {0}", shiftPosition);
                Console.WriteLine("Encrypted: {0}", encrypted);
                Console.WriteLine("Decryption Check: {0}", decrypted);
            } while (userInput != "q");
        }

        public class AlphabetInfo
        {
            public string LangIso3 { get; private set; }
            public char FirstLetterLC { get; private set; }
            public char FirstLetterUC { get; private set; }
            public char EndLetterLC { get; private set; }
            public char EndLetterUC { get; private set; }
            public char FirstNum { get; private set; }
            public char EndNum { get; private set; }
            public int AlphabetCount { get; private set; }
            public int NumberCount { get; private set; }

            public AlphabetInfo(
                string langIso3, 
                char firstLetterLC, 
                char firstLetterUC, 
                char endLetterLC, 
                char endLetterUC, 
                char firstNum, 
                char endNum, 
                int alphabetCount, 
                int numberCount)
            {
                this.LangIso3 = langIso3;
                this.FirstLetterLC = firstLetterLC;
                this.FirstLetterUC = firstLetterUC;
                this.EndLetterLC = endLetterLC;
                this.EndLetterUC = endLetterUC;
                this.FirstNum = firstNum;
                this.EndNum = endNum;
                this.AlphabetCount = alphabetCount;
                this.NumberCount = numberCount;
            }
        }

        public static string DecryptCaesarCipher(string originalSrc, string encryptedSrc, AlphabetInfo abcInfo, int shiftPosition)
        {
            return EncryptDecryptCaesarCipher(originalSrc, encryptedSrc, abcInfo, shiftPosition);
        }

        public static string EncryptCaesarCipher(string src, AlphabetInfo abcInfo, int shiftPosition)
        {
            return EncryptDecryptCaesarCipher(src, null, abcInfo, shiftPosition);
        }
        
        // a null encryptedSrc param performs an encryption; otherwise, a decryption is performed based on the encryptedSrc
        public static string EncryptDecryptCaesarCipher(string src, string encryptedSrc, AlphabetInfo abcInfo, int shiftPosition)
        {
            bool doDecrypt = encryptedSrc != null;
            string _src = doDecrypt ? encryptedSrc : src;
            var sb = new StringBuilder(src.Length);

            // loop through each character and perform encryption/decryption
            for (int i = 0; i < src.Length; i++)
            {
                char c = _src[i];
                int _shiftPosition = shiftPosition;
                int listsize = 0;
                char? endLetterChar = null;
                char? firstLetterChar = null;

                if (Char.IsLower(c))
                {
                    _shiftPosition = shiftPosition % abcInfo.AlphabetCount;
                    listsize = abcInfo.AlphabetCount;
                    firstLetterChar = abcInfo.FirstLetterLC;
                    endLetterChar = abcInfo.EndLetterLC;
                }
                else if (Char.IsUpper(c))
                {
                    _shiftPosition = shiftPosition % abcInfo.AlphabetCount;
                    listsize = abcInfo.AlphabetCount;
                    firstLetterChar = abcInfo.FirstLetterUC;
                    endLetterChar = abcInfo.EndLetterUC;
                }
                else if (Char.IsDigit(c))
                {
                    _shiftPosition = shiftPosition % abcInfo.NumberCount;
                    listsize = abcInfo.NumberCount;
                    firstLetterChar = abcInfo.FirstNum;
                    endLetterChar = abcInfo.EndNum;
                }

                // during decryption, eliminate erroneous looping for non-alphanumeric chars
                if (doDecrypt && !Char.IsLetterOrDigit(src[i]))
                {
                    listsize = 0;
                    _shiftPosition = shiftPosition;
                }
                int newCharPosition = doDecrypt ?
                    getDecryptedCharPosition(c, listsize, _shiftPosition, firstLetterChar) :
                    getEncryptedCharPosition(c, listsize, _shiftPosition, endLetterChar);

                sb.Append(getCharAtPosition(newCharPosition));
            }
            return sb.ToString();
        }

        /***********************
          START HELPER FUNCTIONS
        ************************/

        public static int getCharPosition(char c)
        {
            return (int)c;
        }

        public static char getCharAtPosition(int position)
        {
            return (char)(position);
        }

        public static char getCharAtShiftedPosition(char c, int shiftPosition)
        {
            return getCharAtPosition(getCharPosition(c) + shiftPosition);
        }

        // force circular loop for A-Z, a-z, or 0-9 shifts
        public static int getEncryptedCharPosition(char c, int listSize, int shiftPosition, char? endOfLoopChar)
        {
            if (listSize > 0 && endOfLoopReached(c, shiftPosition, endOfLoopChar, false))
            {
                return getCharPosition(c) + ((listSize - shiftPosition) * -1);
            }
            else
            {
                return getCharPosition(c) + shiftPosition;
            }
        }

        // force circular loop for A-Z, a-z, or 0-9 shifts
        public static int getDecryptedCharPosition(char c, int listSize, int shiftPosition, char? firstOfLoopChar)
        {
            if (listSize > 0 && endOfLoopReached(c, shiftPosition * -1, firstOfLoopChar, true))
            {
                return getCharPosition(c) + (listSize - shiftPosition);
            }
            else
            {
                return getCharPosition(c) - shiftPosition;
            }
        }

        // for decryption, end of loop (endOfLoopChar) is actually the first of the loop, since the direction (shiftPosition) is reversed
        public static bool endOfLoopReached(char c, int shiftPosition, char? endOfLoopChar, bool isDecrypt)
        {
            bool endOfLoopReached;
            char shiftedChar = getCharAtShiftedPosition(c, shiftPosition);
            if (isDecrypt)
            {
                endOfLoopReached = shiftedChar < endOfLoopChar;
            }
            else
            {
                endOfLoopReached = shiftedChar > endOfLoopChar;
            }
            return endOfLoopReached;
        }
        /***********************
          END HELPER FUNCTIONS
        ************************/
    }
}
