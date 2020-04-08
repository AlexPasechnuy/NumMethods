﻿using System;

namespace NumMethods
{
    class NumMeth
    {
        public static double[,] InputMatrix(int rows, int collumns)
        {
            double[,] res = new double[rows,collumns];
            for(int i = 0; i < rows; i++)
            {
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < collumns; j++)
                {
                    res[i, j] = Convert.ToDouble(str[j]);
                }
            }
            return res;
        }

        private static void SetLowerNull(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(0) - 1; j > i; j--)
                {
                    double coef = matrix[j, i] / matrix[j - 1, i];
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        matrix[j, k] -= coef * matrix[j - 1, k];
                    }
                }
            }
        }

        public static void PrintArr(double[] arr)
        {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(Math.Round(arr[i], 3) + " ");
                }
        }

        public static void PrintMatr(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Math.Round(matrix[i, j], 3) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
