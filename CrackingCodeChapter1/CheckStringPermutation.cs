using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem statement : Given two input string check if one string is permutation of another means both string have same characters but in different order
    /// Example : apple & plpea are permutation strings but apple and paddle are not permutation string.
    /// 2 solution 
    /// 1 Brute force : sort string and compare strings time complexity O(N + N Log N)
    /// 2 Optimized solution : Store character in array 
    /// </summary>
    public class CheckStringPermutation
    {
        private static bool CheckPermutationSort(string string1, string string2)
        {
            if (string1.Length != string2.Length) return false;

            var stringOneArray = string1.ToCharArray();
            Array.Sort(stringOneArray);

            var stringTwoArray = string2.ToCharArray();
            Array.Sort(stringTwoArray);

            return stringOneArray.ToString().Equals(stringTwoArray.ToString());
        }

        private static bool CheckPermutaionWithArrayStore(string stringOne, string stringTwo)
        {
            if (stringOne.Length != stringTwo.Length) return false;

            int[] letters = new int[128]; // Assumption is Asscii and char array can also work

            //Can use Dictionary<char,int> if wanted to track char also
            // In First For look check if char is there than increase int value by 1 for dictionary else add 1 to int value
            // In Second For look check if char is there than decrease int value by 1 

            for (int i = 0; i < stringOne.Length; i++)
            {
                int index = stringOne[i];
                letters[index]++;
            }

            for(int j = 0; j< stringTwo.Length; j++)
            {
                int index = stringTwo[j];
                letters[index]--;
                if (letters[index] < 0) return false;
            }
            return true;
        }        

        public static void Run()
        {
            string[][] wordPairs = { new string[] { "apple", "papel" }, new string[] { "carrot", "tarroc" }, new string[] { "hellow", "llloh" } };

            foreach(var wordPair in wordPairs)
            {
                Console.WriteLine($"{wordPair[0]} is permutation with {wordPair[1]} : {CheckPermutationSort(wordPair[0], wordPair[1])}");                
                Console.WriteLine($"{wordPair[0]} is permutation with {wordPair[1]} : {CheckPermutaionWithArrayStore(wordPair[0], wordPair[1])}");
                Console.WriteLine();
            }            
        }

    }
}
