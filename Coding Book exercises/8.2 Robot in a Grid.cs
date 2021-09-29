// 8.2 Robot in a Grid:
// Imagine a robot sitting on the upper left corner of grid with r rows
// and c columns. The robot can only move in two directions, right and down, but certain
// cells are "off limits" such that the robot cannot step on them. Design an algorithm to
// find a path for the robot from the top left to the bottom right.


class Program
{
	static void Main(string[] args)
	{
		bool[, ] grid = new bool[10, 10]
		{ { true, true, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, true, true, true }, { true, false, false, false, false, false, false, true, true, true }, { true, false, false, false, false, false, false, true, true, true }, { true, false, false, false, false, false, false, true, true, true }, { true, true, true, true, true, true, true, true, true, true }
		};

		System.Console.WriteLine(PossiblePath(grid, 9, 9));

	}

	public static bool PossiblePath(bool[, ] grid, int row, int col)
	{
		if (grid.Length == 0) return false;
		if (row < 0 || col < 0) return false;
		if (row == 0 && col == 0)
		{
			Console.Write("[" + row + ", " + col + "] ");
			return true;
		}
		if (grid[row, col] == false) return false;

		if (grid[row, col] != false)
		{
			Console.Write("[" + row + ", " + col + "] ");
			return PossiblePath(grid, row - 1, col) || PossiblePath(grid, row, col - 1);
		}
		else
		{
			return false;
		}

	}
}