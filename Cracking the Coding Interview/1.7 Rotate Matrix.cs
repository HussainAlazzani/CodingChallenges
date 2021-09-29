using System;
using System.Text;

namespace PracticeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int [5,5]   {{ 1, 2, 3, 4, 5 },
                                            { 6, 7, 8, 9, 10 },
                                            { 11, 12, 13, 14, 15 },
                                            { 16, 17, 18, 19, 20 },
                                            { 21, 22, 23, 24, 25 } };
            RotateMatrix(matrix, 5);

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
        }

        public static void RotateMatrix(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n/2; layer++)
            {
                // Starting from the outermost layer
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int shift = i - first;

                    // Temporary variable to save top value
                    int temp = matrix[first,i];
                    // Move left value to top
                    matrix[first, i] = matrix[last - shift, first];
                    // Move bottom value to left
                    matrix[last - shift, first] = matrix[last, last - shift];
                    // Move right value to bottom
                    matrix[last, last - shift] = matrix[i, last];
                    // Move top value to right
                    matrix[i, last] = temp;
                }
            }
        }

    }
}