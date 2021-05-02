using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem statement : Check if input string have all unique characters
    /// Special condition : Find solution without using any extra data structure
    /// 3 solutions
    /// 1 brute forse : O(N^2) time complexcity O(1) space complexity
    /// 2 using boolean array : O(1) time complexity  O(1) space complexity
    /// 3 using bit vetor : O(1) time complexity O(1) space complexity // no data structure so practically less space use
    /// </summary>
    public class IsUnqueCharacterProblem
    {
        /// <summary>
        /// Brute Force method
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>boolean</returns>
        public bool IsUniqueChar(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Using Boolean Array
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>boolean</returns>
        public bool IsUniqueCharBookSolution1(string input)
        {
            if (input.Length > 128) // max standard Ascii Character can also use 256 if wanted to cover extended ascii characters https://www.ascii-code.com/
            {
                return false;
            }

            bool[] char_set = new bool[128];
            for (int i = 0; i < input.Length; i++)
            {
                int val = input[i];
                if (char_set[val]) return false;
                char_set[val] = true;
            }
            return true;
        }

        /// <summary>
        /// Using Bit Vector
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>boolean</returns>
        // Using bitvector - https://www.youtube.com/watch?v=0AcuCP4ikrM     
        public bool IsUniqueCharBookSolution2(string input)
        {
            if (input.Length > 128) // max standard Ascii Character can also use 256 if wanted to cover extended ascii characters https://www.ascii-code.com/
            {
                return false;
            }

            int checker = 0; // checker represent 1 bit for each character example a = 00000001, b = 00000010, ab = 00000011 etc..
            for (int i = 0; i < input.Length; i++)
            {
                // left shift 1 by order in which character came example for a (1 << 0) for b (1 << 1) for c (1 << 2) etc
                // than check if there is duplicate with logical and operator with checker as checker represent what charcter alread came
                // if logical and is > 0  meand already charcter is there so return false. 
                // if logical and is 0 than do logical | with checker and add bit to checker
                int val = input[i] - 'a';
                if ((checker & (1 << val)) > 0) return false;

                checker |= (1 << val); // logical or checker = checker | character bit shift
            }
            return true;
        }
    }
}
