using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem : Check if input string has any permutation which are palindrome
    /// Igone space and case insensative
    /// </summary>
    class StringPemutationPalindrome
    {
        #region Solution 1
        private static bool IsStringPermutationPalindome(string inputString)
        {
            var frequencyTable = buildFrequencyTable(inputString);
            bool checkFrequency = false;

            foreach(var value in frequencyTable)
            {
                if(value % 2 == 1)
                {
                    if (checkFrequency)
                        return false;
                    checkFrequency = true;
                }
            }
            return true;
        }

        private static int[] buildFrequencyTable(string input)
        {
            int[] outCome = new int['z' - 'a' + 1];
            string lowerInput = input.ToLower();

            for(int i = 0; i < input.Length; i++)
            {
                var x = getCharNumber(lowerInput[i]);
                if (x != -1)
                    outCome[x]++;
            }

            return outCome;
        }

        private static int getCharNumber(char c)
        {
            int zVal = 'z';
            int aVal = 'a';

            int val = c;

            if (val > aVal && val < zVal)
                return val - aVal;

            return -1;
        }

        #endregion

        #region Solution 2

        private static bool IsStringPermutationPalindromeCounter(string inputString)
        {
            int[] outCome = new int['z' - 'a' + 1];
            string lowerInput = inputString.ToLower();
            int counter = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                var x = getCharNumber(lowerInput[i]);
                if (x != -1)
                {
                    outCome[x]++;

                    if (outCome[x] % 2 == 1)
                        counter++;
                    else
                        counter--;
                }                    
            }

            return counter <= 1;           
        }

        #endregion

        public static void Run()
        {
            string inputString = "Tact Coa";
            //string inputString = "Rats live on no evil star";
            //string inputString = "sadgefd";
            //string inputString = "aaaa";

            if (IsStringPermutationPalindromeCounter(inputString))
                Console.WriteLine($"{inputString} has permitutation which palindrome");
            else
                Console.WriteLine($"{inputString} don't have permitutation which palindrome");
        }
    }
}
