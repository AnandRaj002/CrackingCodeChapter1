using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeChapter1
{
    /// <summary>
    /// Write and algorithm for M*N matrix for which if any element is 0 then make it entire row and column to 0
    /// </summary>
    public class ZeroMatrix
    {
        #region Common Code

        private static readonly Random RandomIntNumbers = new Random();

        private static int[][] RandomMatrix(int rowSize, int columnSize, int min, int max)
        {
            int[][] matrix = new int[rowSize][];

            for(int i = 0; i < rowSize; i++)
            {
                matrix[i] = new int[columnSize];
                for(int j = 0; j < columnSize; j++)
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

        #endregion

        #region Solution 1

        private static void setZeroMatrix(int[][] inputMatrix)
        {
            bool[] row = new bool[inputMatrix.Length];
            bool[] column = new bool[inputMatrix[0].Length];

            for(int i = 0; i < row.Length; i++)
            {
                for(int j = 0; j < column.Length; j++)
                {
                    if(inputMatrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            for(int i = 0; i < row.Length; i++)
            {
                if (row[i])
                    nullifyRow(inputMatrix, i);
            }

            for(int j = 0; j < column.Length; j++)
            {
                if (column[j])
                    nullifyColumn(inputMatrix, j);
            }
        }

        private static void nullifyRow(int[][] inputMatrix, int rowNum)
        {
            for(int j = 0; j < inputMatrix[0].Length; j++)
            {
                inputMatrix[rowNum][j] = 0;
            }
        }

        private static void nullifyColumn(int[][] inputMatrix, int columnNum)
        {
            for (int i = 0; i < inputMatrix.Length; i++)
            {
                inputMatrix[i][columnNum] = 0;
            }
        }

        #endregion

        public static void Run()
        {
            int rowSize = 10;
            int columnSize = 15;

            int[][] inputMatrix = RandomMatrix(rowSize, columnSize, -10, 10);

            PrintMatrix(inputMatrix);

            setZeroMatrix(inputMatrix);

            Console.WriteLine();

            PrintMatrix(inputMatrix);
        }
    }
}
