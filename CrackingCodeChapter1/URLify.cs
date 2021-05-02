using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Write a method to replace all spaces in a string with %20.
    /// You may assume that string has sufficent space at the end to hold additional characters and you are given true lenght of string
    /// 2 solutions
    /// 1 with assumption values
    /// 2 without assumption general algo
    /// </summary>
    public class URLify
    {
        /// <summary>
        /// With assumption that input has sufficient space and true Lenght of string is given
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="trueLength"></param>
        /// <returns></returns>
        private static string spaceReplace(char[] inputArray, int trueLength)
        {
            int fullLength = inputArray.Length;

            for(int i = trueLength - 1; i >= 0; i--)
            {
                if(inputArray[i] == ' ')
                {
                    inputArray[fullLength - 1] = '0';
                    inputArray[fullLength - 2] = '2';
                    inputArray[fullLength - 3] = '%';
                    fullLength = fullLength - 3;
                }
                else
                {
                    inputArray[fullLength - 1] = inputArray[i];
                    fullLength--;
                }
            }

            return new string(inputArray);
        }

        /// <summary>
        /// Without assumption values algorithm
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string spaceReplaceWithoutAssumptions(string inputString)
        {
            int trueLength = inputString.Length;
            int spaceCount = countSpaces(inputString);
            int totalLength = trueLength + (spaceCount * 2);

            char[] outputArray = new char[totalLength];

            for(int i = trueLength - 1; i >= 0; i--)
            {
                if(inputString[i] == ' ')
                {
                    outputArray[totalLength - 1] = '0';
                    outputArray[totalLength - 2] = '2';
                    outputArray[totalLength - 3] = '%';
                    totalLength = totalLength - 3;
                }
                else
                {
                    outputArray[totalLength - 1] = inputString[i];
                    totalLength--;
                }
            }

            return new string(outputArray);
        }

        private static int countSpaces(string inputString)
        {
            int spaceCounter = 0;

            for(int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == ' ')
                    spaceCounter++;
            }

            return spaceCounter;
        }
        
        public static int findLastCharacterLenght(string inputString)
        {
            for(int i = inputString.Length - 1; i >= 0; i--)
            {
                if (inputString[i] != ' ')
                    return i;
            }
            return -1;
        }
        
        public static void Run()
        {
            string inputString = "Mr John Smith    ";

            int trueLength = findLastCharacterLenght(inputString) + 1;
            Console.WriteLine($"true Length is {trueLength}");
            Console.WriteLine(spaceReplace(inputString.ToCharArray(), trueLength));

            string inputStringNoSpace = "Mr John Smith";

            Console.WriteLine(spaceReplaceWithoutAssumptions(inputStringNoSpace));

            Console.WriteLine(spaceReplace(inputString.ToCharArray(), trueLength).Equals(spaceReplaceWithoutAssumptions(inputStringNoSpace)));
        }
    }
}
