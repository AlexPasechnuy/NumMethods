using System;
using System.Runtime.InteropServices;

namespace NumMethods
{
    class NumMeth
    {
        public static double[,] InputMatrix(int rows, int collumns)
        {
            double[,] res = new double[rows, collumns];
            for (int i = 0; i < rows; i++)
            {
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < collumns; j++)
                {
                    res[i, j] = Convert.ToDouble(str[j]);
                }
            }
            return res;
        }

        private static double[,] SetLowerNull(double[,] matrix)
        {
            double[,] res = new double[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, res, matrix.Length);
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = res.GetLength(0) - 1; j > i; j--)
                {
                    double coef = res[j, i] / res[j - 1, i];
                    for (int k = 0; k < res.GetLength(1); k++)
                    {
                        res[j, k] -= coef * res[j - 1, k];
                    }
                }
            }
            return res;
        }

        public static double[] GaussSolve(double[,] matrix)
        {

            matrix = SetLowerNull(matrix);
            double[] res = new double[matrix.GetLength(0)];
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < matrix.GetLength(1) - 1; j++)
                {
                    sum += res[j] * matrix[i, j];
                }
                res[i] = Math.Round((matrix[i, matrix.GetLength(1) - 1] - sum) / (matrix[i, i]), 2);
            }
            return res;
        }

        public static double[] SolveSimpleIter(double[,] matrix, int eps)
        {
            double[] prevx = new double[matrix.GetLength(0)];
            double[] x = new double[matrix.GetLength(0)];
            iteration();
            void iteration()
            {
                Array.Copy(x, prevx, x.Length);
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double sum = 0;
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (j != i)
                        {
                            sum += matrix[i, j] * prevx[j];
                        }
                    }
                    x[i] = (1 / matrix[i, i]) * (matrix[i, matrix.GetLength(1) - 1] - sum);
                }
                for (int i = 0; i < x.Length; i++)
                {
                    if (Math.Round(x[i], eps) != Math.Round(prevx[i], eps))
                    {
                        iteration();
                    }
                }
                return;
            }
            return x;
        }

        public static double GaussDeter(double[,] matrix)
        {
            double[,] temp = SetLowerNull(matrix);
            double deter = 1;
            for (int i = 0; i < temp.GetLength(1); i++)
            {
                deter *= temp[i, i];
            }
            return deter;
        }

        public static double[,] GaussInverse(double[,] matrix)
        {
            double[,] res = new double[matrix.GetLength(0), matrix.GetLength(1) * 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i, j] = matrix[i, j];
                }
                res[i, i + matrix.GetLength(1)] = 1;
            }
            double[,] prev = new double[res.GetLength(0), res.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                Array.Copy(res, prev, res.Length);
                for (int j = 0; j < res.GetLength(0); j++)
                {
                    for (int k = 0; k < res.GetLength(1); k++)
                    {
                        if (j == i)
                            res[j, k] /= prev[i, i];
                        else
                            res[j, k] -= (prev[j, i] * prev[i, k]) / prev[i, i];
                    }
                }
            }
            double[,] inversed = new double[res.GetLength(0), res.GetLength(1) / 2];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1)/2; j++)
                {
                    inversed[i, j] = res[i, j + res.GetLength(1) / 2];
                }
            }
            return inversed;
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

        public static object Eval(string expr, double x)
        {
            var t = Type.GetTypeFromProgID("ScriptControl");
            dynamic scriptControl = Activator.CreateInstance(t);
            scriptControl.Language = "JavaScript";
            int xLength = x.ToString().Length;
            int pos = expr.IndexOf("x");
            while (pos != -1)
            {
                int temp = 1;
                if (expr[pos - 1] != 'e' && expr[pos - 1] != 'a')
                {
                    expr = expr.Substring(0, pos) + x.ToString() +
                        expr.Substring(pos + 1);
                    temp = xLength;
                }
                if (expr.Substring(pos + temp).IndexOf("x") == -1)
                {
                    break;
                }
                pos = expr.Substring(pos + temp).IndexOf("x") + pos + temp;
            }
            var result = scriptControl.Eval(expr);
            Marshal.ReleaseComObject(scriptControl);
            return result;
        }
    }
}
