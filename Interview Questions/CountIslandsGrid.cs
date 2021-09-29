using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        // static void Main(string[] args)
        // {
        //     // 1
        //     char[][] grid = {
        //         new char[] { '1', '1', '1', '1', '0' },
        //         new char[] { '1', '1', '0', '1', '0' },
        //         new char[] { '1', '1', '0', '0', '0' },
        //         new char[] { '0', '0', '0', '0', '0' }
        //     };
        //     // 3
        //     char[][] grid2 = {
        //         new char[] { '1', '1', '0', '0', '0' },
        //         new char[] { '1', '1', '0', '0', '0' },
        //         new char[] { '0', '0', '1', '0', '0' },
        //         new char[] { '0', '0', '0', '1', '1' }
        //     };
        //     // 3
        //     char[][] grid3 = {
        //         new char[] { '1' }
        //     };
        //      Program p = new Program();
        //     System.Console.WriteLine(NumIslands(p.grid2));

        // int[][] grid = {
        //     new int[] { 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //     new int[] { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
        //     new int[] { 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
        // };
        // // 6
        // int[][] grid2 = {
        //     new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
        //     new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        //     new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
        //     new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
        //     new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
        // };
        // int[][] grid3 = {
        //     new int[] { 1 }
        // };

        // System.Console.WriteLine(p.MaxAreaOfIsland(grid3));
        // }

        // Private property to act as global variable to keep the count of each pixel of the island.
        //private int Count { get; set; }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    maxArea = Math.Max(maxArea, GetMaxAreaOfIsland(grid, i, j));
                }

            }

            return maxArea;
        }

        private int GetMaxAreaOfIsland(int[][] grid, int r, int c)
        {
            if (grid.Length == 0)
            {
                return 0;
            }
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[r].Length)
            {
                return 0;
            }
            // If grid element is zero, do not count.
            if (grid[r][c] == 0)
            {
                return 0;
            }

            // Mark as visited. BETTER TO CREATE A DIFFERENT GRID TO AVOID CHANGING THIS ONE. E.G. visited[r][c]
            grid[r][c] = 0;
            int visited = 1;

            // top
            int top = GetMaxAreaOfIsland(grid, r - 1, c);
            // bottom
            int bottom = GetMaxAreaOfIsland(grid, r + 1, c);
            // left
            int left = GetMaxAreaOfIsland(grid, r, c - 1);
            // right
            int right = GetMaxAreaOfIsland(grid, r, c + 1);

            return visited + top + bottom + left + right;

        }
        public int NumIslands(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    count += CountIslands(grid, i, j);
                }
            }

            return count;
        }
        private int CountIslands(char[][] grid, int r, int c)
        {
            if (grid.Length == 0)
            {
                return 0;
            }
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[r].Length)
            {
                return 0;
            }
            // If grid element is zero, do not count.
            if (grid[r][c] == '0')
            {
                return 0;
            }
            // If grid element already visited, escape without counting.
            if (grid[r][c] == '*')
            {
                return 0;
            }

            // Mark as visited.
            grid[r][c] = '*';
            // top
            CountIslands(grid, r - 1, c);
            // bottom
            CountIslands(grid, r + 1, c);
            // left
            CountIslands(grid, r, c - 1);
            // right
            CountIslands(grid, r, c + 1);

            return 1;
        }
    }
}