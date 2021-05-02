using System;

namespace CrackingCodeChapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string[] words = { "abcde", "hello", "apple", "kite", "padle", "asdfsadf sfsdfsdfs sadfsdfds sdfsdfs dfsadfs sadfsfsoiwetrwt wertfwrwqe 2342 sdfsd2!!" };
            IsUnqueCharacterProblem u1 = new IsUnqueCharacterProblem();

            foreach(var word in words)
            {
                //Console.WriteLine($"{word} is unique : {u1.IsUniqueCharBookSolution2(word)}");
            }

            //Console.WriteLine();

            //CheckStringPermutation.Run();

            //Console.WriteLine();

            //URLify.Run();

            //Console.WriteLine();

            //StringPemutationPalindrome.Run();

            //Console.WriteLine();

            //OneAway.Run();

            //Console.WriteLine();

            //StringCompression.Run();

            //Console.WriteLine();

            //RotateMatrix.Run();

            //Console.WriteLine();

            //ZeroMatrix.Run();

            Console.WriteLine();

            StringRotation.Run();
        }        
    }
}
