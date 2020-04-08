using System;

namespace NumMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows and collumns: ");
            string[] str = Console.ReadLine().Split();
            int rows = Convert.ToInt32(str[0]);
            int collumns = Convert.ToInt32(str[1]);
            double[,] matr = NumMeth.InputMatrix(rows, collumns);
            Console.Write("Roots of system using Gauss method are: ");
            double[] res = NumMeth.SolveGauss(matr);
            NumMeth.PrintArr(res);
            Console.ReadKey();
        }
    }
}
