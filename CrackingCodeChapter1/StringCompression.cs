using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem : Writer a method that created basic string compression using count of repeted characters. 
    ///           At the end methoud should return compress string or original string which is smaller in size
    /// Example : aabcccccaaa would become a2b1c5a2
    /// Assumption : all characters are only uppercase or lowercase of a to z
    /// </summary>
    public class StringCompression
    {
        private static string GetStringComp(string input)
        {
            int compressionCounter = 0;
            string compressedString = string.Empty;

            for(int i = 0; i < input.Length; i++)
            {
                compressionCounter++;

                if ( ((i+1) >= input.Length) || (input[i] != input[i+1]) )
                {
                    compressedString += "" + input[i] + compressionCounter;
                    compressionCounter = 0;
                }
            }

            return input.Length > compressedString.Length ? compressedString : input;
        }

        private static string GetStringCompWithStringBuilder(string input)
        {
            int compressionCounter = 0;
            StringBuilder compressedString = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                compressionCounter++;

                if (((i + 1) >= input.Length) || (input[i] != input[i + 1]))
                {
                    compressedString.Append(input[i]);
                    compressedString.Append(compressionCounter);
                    compressionCounter = 0;
                }
            }

            return input.Length > compressedString.ToString().Length ? compressedString.ToString() : input;
        }

        /// <summary>
        /// Check Lenght first and than do string append
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetStringCompWithImprovement(string input)
        {
            int compressionCounter = 0, compressedstringLength = 0;            

            for (int i = 0; i < input.Length; i++)
            {
                compressionCounter++;

                if (((i + 1) >= input.Length) || (input[i] != input[i + 1]))
                {
                    compressedstringLength = compressedstringLength + compressionCounter.ToString().Length + 1;
                    compressionCounter = 0;
                }
            }

            if (input.Length < compressedstringLength)
                return input;
            else
            {

                StringBuilder compressedString = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    compressionCounter++;

                    if (((i + 1) >= input.Length) || (input[i] != input[i + 1]))
                    {
                        compressedString.Append(input[i]);
                        compressedString.Append(compressionCounter);
                        compressionCounter = 0;
                    }
                }

                return input.Length > compressedString.ToString().Length ? compressedString.ToString() : input;
            }
        }

        public static void Run()
        {
            string input = "aabcccccaa"; // aa second case

            Console.WriteLine($"{input} compression => {GetStringComp(input)}");
            Console.WriteLine($"{input} compression => {GetStringCompWithStringBuilder(input)}");
            Console.WriteLine($"{input} compression => {GetStringCompWithImprovement(input)}");
        }
    }
}
