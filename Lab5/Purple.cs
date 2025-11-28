using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[m];
            for(int i = 0; i < m; i++)
            {
                int counter = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j,i] < 0) counter++;
                }
                answer[i] = counter;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for(int i = 0;i < n; i++)
            {
                Console.WriteLine();
                int indMin = 0;
                for(int j = 0; j < m; j++)
                {
                    if (matrix[i, indMin] > matrix[i, j]) indMin = j;
                }
                for(int j = indMin; j > 0; j--)
                {
                    (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0),matrix.GetLength(1) + 1];

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == 0) return null;
            for (int i = 0; i < n; i++)
            {
                int indMax = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, indMax] < matrix[i, j]) indMax = j;
                }
                for(int j = 0; j <= indMax; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, indMax + 1] = matrix[i, indMax];
                for(int j = indMax + 1; j < m; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int indMax = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, indMax] < matrix[i, j]) indMax = j;
                }
                int mid = 0, c = 0;
                for (int j = indMax + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0) { mid += matrix[i, j]; c++; }
                }
                if (c == 0)
                {
                    //Console.WriteLine(); 
                    continue;
                }
                //for (int j = 0; j < m; j++) Console.Write($"{matrix[i, j]} ");
                //Console.WriteLine();
                mid = mid / c;
                for (int j = 0; j < indMax; j++)
                {
                    if (matrix[i, j] < 0) matrix[i, j] = mid;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] maxEl = new int[n];
            for (int i = 0; i < n; i++)
            {
                int indMax = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, indMax] < matrix[i, j]) indMax = j;
                }
                maxEl[i] = matrix[i, indMax];
            }

            if (k >= m) return;
            for(int i = 0; i < n; i++)
            {
                matrix[i,k] = maxEl[n - i - 1];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] maxEl = new int[m];
            for (int i = 0; i < m; i++)
            {
                int indMax = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[indMax, i] < matrix[j, i]) indMax = j;
                }
                maxEl[i] = indMax;
            }
            if (array.Length != m) return;
            for (int i = 0; i < m; i++)
            {
                matrix[maxEl[i], i] = (array[i] > matrix[maxEl[i], i] ? array[i] : matrix[maxEl[i], i]);
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[][] sPair = new int[matrix.GetLength(0)][];
            for(int i = 0; i < n; i++)
            {
                int t = matrix[i,0];
                for(int j = 0;j < m; j++)
                {
                    t = (t > matrix[i, j] ? matrix[i, j] : t);
                }
                int[] temp = new int[2];
                temp[0] = t;
                temp[1] = i;
                sPair[i] = temp;
            }
            // code here
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    if (sPair[i][0] > sPair[j][0])
                    {
                        (sPair[i], sPair[j]) = (sPair[j], sPair[i]);
                    }
                }
            }
            int[,] temp2 = new int[n,m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    temp2[i, j] = matrix[sPair[i][1], j];
                }
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = temp2[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n != m) return null;
            answer = new int[n * 2 - 1];
            // before main
            int s = 0;
            for (int i = n - 1; i > 0; i--)
            {
                s = 0;
                for(int k = 0; i + k < n && k < n; k++)
                {
                    s += matrix[i + k, k];
                }
                answer[n - 1 - i] = s;
            }
            // main
            s = 0;
            for(int i = 0; i < n; i++)
            {
                s += matrix[i, i];
            }
            answer[n - 1] = s;
            //after main
            for (int i = 1; i < n; i++)
            {
                s = 0;
                for (int k = 0; i + k < n && k < n; k++)
                {
                    s += matrix[k, k + i];
                }
                answer[n + i - 1] = s;
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n != m) return;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(k);
            // code here
            int mAbsI = 0, mAbsJ = 0;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (Math.Abs(matrix[i,j]) > Math.Abs(matrix[mAbsI, mAbsJ]))
                    {
                        mAbsI = i;
                        mAbsJ = j;
                    }
                }
            }
            Console.WriteLine($"{mAbsI, 3} {mAbsJ, 3}\n");
            if(mAbsI < k) // ...i....k...
            {
                for(int i = mAbsI; i < k; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = mAbsI; i > k; i--)
                {
                    for (int j = 0; j < m; j++)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            if (mAbsJ < k) // ...i....k...
            {
                for (int j = mAbsI; j < k; j++)
                {
                    for (int i = 0; i < m; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int j = mAbsI; j > k; j--)
                {
                    for (int i = 0; i < m; i++)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i,j], 3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------");
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;
            int n1 = A.GetLength(0), m1 = A.GetLength(1);
            int n2 = B.GetLength(0), m2 = B.GetLength(1);
            if (m1 != n2) return null;
            // code here
            answer = new int[n1, m2];
            for(int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    answer[i, j] = 0;
                    for(int k = 0; k < m1; k++)
                    {
                        answer[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1); 
            int[][] answer = new int[n][];

            // code here
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for(int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) c++;
                int[] ans = new int[c];
                c = 0;
                for(int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) ans[c++] = matrix[i,j];
                answer[i] = ans;
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int c = 0;
            for(int i = 0; i < array.Length; i++)
            {
                c += array[i].Length;
            }
            int[] mass = new int[c];
            if (c == (int)Math.Sqrt(c) * (int)Math.Sqrt(c)) c = (int)Math.Sqrt(c);
            else c = (int)Math.Sqrt(c) + 1;

            answer = new int [c,c];
            int t = 0;
            // to row
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    mass[t++] = array[i][j];
                }
            }
            t = 0;
            for (int i = 0; i < c && t < mass.Length; i++)
            {
                for(int j = 0; j < c && t < mass.Length; j++)
                {
                    answer[i,j] = mass[t++];
                }
            }
            // end

            return answer;
        }
    }
}
