using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    public class StringRotation
    {
        private static bool IsSubString(string bigString, string smallString)
        {
            return bigString.IndexOf(smallString) >= 0;
        }

        private static bool IsStringRotation(string s1, string s2)
        {
            if((s1.Length != s2.Length) || s1.Length == 0)
            {
                return false;
            }

            var combineString = s1 + s1;

            if (IsSubString(combineString, s2))
                return true;
            return false;
        }

        public static void Run()
        {
            string[][] wordPairs =
            {
                new string[] { "apple", "pleap" },
                new string[] { "waterbottle", "erbottlewat" },
                new string[] { "camera", "macera" }
            };

            foreach(var wordPair in wordPairs)
            {
                Console.WriteLine($"{wordPair[0]}, {wordPair[1]} => IsRotation {IsStringRotation(wordPair[0], wordPair[1])}");
            }
        }
    }
}
