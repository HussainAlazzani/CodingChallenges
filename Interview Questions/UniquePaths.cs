using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        // Dynamic solution
        public static int UniquePathsDynamic(int right, int down)
        {
            int[, ] t = new int[down + 1, right + 1];
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                    {
                        t[i, j] = 0;
                    }
                    else if (i == 1 || j == 1)
                    {
                        t[i, j] = 1;
                    }
                    else
                    {
                        t[i, j] = t[i - 1, j] + t[i, j - 1];
                    }
                }
            }
            return t[down, right];
        }
        // method to use memoization or normal recursion.
        public static int UniquePaths(int right, int down)
        {
            int arrayLength = Math.Max(right, down) + 1;

            int[, ] memo = new int[arrayLength, arrayLength];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            return UniquePathsMemo(memo, right, down);
        }
        // Memoization solution
        public static int UniquePathsMemo(int[, ] memo, int right, int down)
        {
            if (down < 1 || right < 1) return 0;
            if (down == 1 && right == 1) return 1;

            if (memo[right, down] > -1)
            {
                return memo[right, down];
            }

            memo[right, down] = UniquePathsMemo(memo, down - 1, right) +
                UniquePathsMemo(memo, down, right - 1);

            return memo[right, down];
        }
        // Normal recursion 
        public static int UniquePathsNaive(int right, int down)
        {
            if (down < 1 || right < 1) return 0;
            if (down == 1 && right == 1) return 1;

            int d = UniquePaths(down - 1, right);
            int r = UniquePaths(down, right - 1);

            return d + r;
        }

        // In order to create a dynamic solution I must use have some initial results. I could do that by using the 
        // first using the other methods here and then use the results to formulate the dynamic table.
        public static int UniquePathsWithObstacles(int[][] matrix)
        {
            int[, ] memo = new int[matrix.Length + 1, matrix[0].Length + 1];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }
            return UniquePathsWithObstaclesMemo(matrix, memo, matrix.Length - 1, matrix[0].Length - 1);
        }
        // Memoization solution
        public static int UniquePathsWithObstaclesMemo(int[][] matrix, int[, ] memo, int r, int c)
        {
            if (matrix.Length == 0) return 0;
            if (r < 0 || c < 0) return 0;
            if (matrix[r][c] == 1) return 0;
            if (r == 0 && c == 0) return 1;

            if (memo[r, c] > -1) return memo[r, c];

            memo[r, c] = UniquePathsWithObstaclesMemo(matrix, memo, r - 1, c) +
                UniquePathsWithObstaclesMemo(matrix, memo, r, c - 1);
            return memo[r, c];
        }
        // Naive resursive solution.
        public static int UniquePathsWithObstacles(int[][] matrix, int r, int c)
        {
            if (matrix.Length == 0) return 0;
            if (r < 0 || c < 0) return 0;
            if (matrix[r][c] == 1) return 0;
            if (r == 0 && c == 0) return 1;

            return UniquePathsWithObstacles(matrix, r - 1, c) +
                UniquePathsWithObstacles(matrix, r, c - 1);
        }
    }

}