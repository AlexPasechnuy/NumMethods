using System;

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
            double[,] matr = {{-1, 0.22, -0.11, 0.34, -2.7 },
                {0.38, -1.0, -0.12, 0.22, 1.5 },
                {0.11, 0.23, -1, 0.51, -1.2 },
                {0.17, -0.21, 0.31, -1.0, 0.17 } };
            Console.Write("Roots of system using Gauss method are: ");
            double[] res = NumMeth.SolveGauss(matr);
            NumMeth.PrintArr(res);
            Console.WriteLine();
            Console.Write("Roots of system using simple iteration  method are: ");
            res = NumMeth.SolveSimpleIter(matr, 5);
            NumMeth.PrintArr(res);
            Console.ReadKey();
        }
    }
}
