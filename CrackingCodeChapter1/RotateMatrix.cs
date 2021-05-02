using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Problem : Implement method to Rotate N*N matrix to 90 degree
    /// </summary>
    public class RotateMatrix
    {
        private static readonly Random RandomIntNumbers = new Random();

        private static void Rotate(int[][] inputMatrix, int matrixSize)
        {
            for(int layer = 0; layer < matrixSize/2; layer++)
            {
                int first = layer;
                int last = matrixSize - 1 - layer;

                for(int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = inputMatrix[first][i];

                    // left -> top
                    inputMatrix[first][i] = inputMatrix[last - offset][first];

                    // bottom -> left
                    inputMatrix[last - offset][first] = inputMatrix[last][last - offset];

                    // right -> bottom
                    inputMatrix[last][last - offset] = inputMatrix[i][last];

                    // top -> right
                    inputMatrix[i][last] = top;
                }
            }
        }

        private static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = RandomIntNumbers.Next(max + 1 - min) + min;
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 10 && matrix[i][j] > -10)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] < 100 && matrix[i][j] > -100)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] >= 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }


        public static void Run()
        {
            int size = 3;
            int[][] inputMatrix = RandomMatrix(size, size, 0, 9);
            PrintMatrix(inputMatrix);
            Rotate(inputMatrix, size);
            Console.WriteLine();
            PrintMatrix(inputMatrix);
        }
    }
}
