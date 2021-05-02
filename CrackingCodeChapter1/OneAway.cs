using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem : For giver two string write a function that check if both are one/zero edit away (Edit can be insert/remove/replace)
    /// Examples:
    ///     pale, pal -> true
    ///     pales, pale -> true
    ///     pale, bale -> true
    ///     pale, bake -> false
    /// </summary>
    public class OneAway
    {
        #region Solution 1

        private static bool CheckEditReplace(string inputOne, string inputTwo)
        {
            bool founOneDiff = false;

            for(int i = 0; i < inputOne.Length; i++)
            {
                if(inputOne[i] != inputTwo[i])
                {
                    if (founOneDiff) return false;
                    founOneDiff = true;
                }
            }
            return true;
        }

        private static bool CheckEditInsertRemove(string inputOne, string inputTwo)
        {
            int index1 = 0, index2 = 0;
            while(index1 < inputOne.Length && index2 < inputTwo.Length)
            {
                if(inputOne[index1] != inputTwo[index2])
                {
                    if (index1 != index2)
                        return false;
                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        private static bool IsOneAway(string inputOne, string inputTwo)
        {
            if (inputOne.Length == inputTwo.Length)
                return CheckEditReplace(inputOne, inputTwo);
            else if (inputOne.Length + 1 == inputTwo.Length)
                return CheckEditInsertRemove(inputOne, inputTwo);
            else if (inputOne.Length - 1 == inputTwo.Length)
                return CheckEditInsertRemove(inputTwo, inputOne);
            return false;
        }

        #endregion

        #region Solution 2

        private static bool IsOneAwayWithOneMethod(string inputOne, string inputTwo)
        {
            /* Length checks. */
            if (Math.Abs(inputOne.Length - inputTwo.Length) > 1)
            {
                return false;
            }

            /* Get shorter and longer string.*/
            String s1 = inputOne.Length < inputTwo.Length ? inputOne : inputTwo;
            String s2 = inputOne.Length < inputTwo.Length ? inputTwo : inputOne;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;
            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    /* Ensure that this is the first difference found.*/
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (s1.Length == s2.Length)
                    { // On replace, move shorter pointer
                        index1++;
                    }
                }
                else
                {
                    index1++; // If matching, move shorter pointer
                }
                index2++; // Always move pointer for longer string
            }
            return true;
        }

        #endregion

        public static void Run()
        {
            string[][] wordPairs = { new string[] { "pale", "ple" }, new string[] { "pales", "pale" }, new string[] { "pale", "bale" }, new string[] { "pale", "bae" }, new string[] { "pale", "bake" } };

            foreach(var wordPair in wordPairs)
            {
                Console.WriteLine($"{wordPair[0]}, {wordPair[1]} -> {IsOneAway(wordPair[0], wordPair[1])}");
                Console.WriteLine($"{wordPair[0]}, {wordPair[1]} -> {IsOneAwayWithOneMethod(wordPair[0], wordPair[1])}");
                Console.WriteLine();
            }
        }
    }
}
