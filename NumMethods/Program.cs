using System;

using System.Runtime.InteropServices;

namespace NumMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter number of rows and collumns: ");
            //string[] str = Console.ReadLine().Split();
            //int rows = Convert.ToInt32(str[0]);
            //int collumns = Convert.ToInt32(str[1]);
            //double[,] matr = NumMeth.InputMatrix(rows, collumns);
            double[,] matrEq = {{-1, 0.22, -0.11, 0.34, -2.7 },
                {0.38, -1.0, -0.12, 0.22, 1.5 },
                {0.11, 0.23, -1, 0.51, -1.2 },
                {0.17, -0.21, 0.31, -1.0, 0.17 } };
            Console.Write("Roots of system using Gauss method are: ");
            double[] res = NumMeth.GaussSolve(matrEq);
            NumMeth.PrintArr(res);
            Console.WriteLine();
            Console.Write("Roots of system using simple iteration  method are: ");
            res = NumMeth.SolveSimpleIter(matrEq, 5);
            NumMeth.PrintArr(res);
            double[,] matr = {{ 0.49, 0.7, 0.62, -0.32},
                {1, 0.17, -0.35, 0.16 },
                {0.28, 0.93, 0.36, 1 },
                {-0.36, 0.86, 1, -0.64 } };
            Console.WriteLine();
            Console.WriteLine("Determinant of matrix is " + NumMeth.GaussDeter(matr));
            Console.WriteLine("Inversed matrix:");
            double[,] matrinv = {{0.54, 0.32, 1, 0.22},
            {0.66, 0.44, 0.22, 1 },
            {1, 0.42, 0.54, 0.66 },
            {0.42, 1, 0.32, 0.44 } };
            double[,] inversed = NumMeth.GaussInverse(matrinv);
            NumMeth.PrintMatr(inversed);
            Console.Write("x = 14; Math.max(x*x,Math.exp(x))/Math.sqrt(x) = ");
            Console.WriteLine(NumMeth.Eval("Math.max(x*x,Math.exp(x))/Math.sqrt(x)",14));
            Console.ReadKey();
        }
    }
}
