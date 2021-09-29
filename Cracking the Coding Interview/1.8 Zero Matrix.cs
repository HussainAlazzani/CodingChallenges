// 1.8 Zero matrix
// Write an algorithm such that if an element in an MxN matrix is 0,
// its entire row and colum are set to 0.

public static void ZeroMatrix(int[, ] matrix)
{
	int n = matrix.GetLength(0);
	int m = matrix.GetLength(1);

	Dictionary<int, int> coordinates = new Dictionary<int, int>();

	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			if (matrix[i, j] == 0)
			{
				coordinates.Add(i,j);
			}
		}
	}

	foreach (var coordinate in coordinates)
	{
		int row = coordinate.Key;
		for (int j = 0; j < m; j++)
		{
			matrix[row, j] = 0;
		}

		int col = coordinate.Value;
		for (int j = 0; j < n; j++)
		{
			matrix[j, col] = 0;
		}
	}
}

//////////////////

static void Main(string[] args)
{
	int[, ] matrix = new int[5, 6]
	{ { 0, 2, 3, 4, 5, 6 }, { 6, 7, 6, 9, 10, 11 }, { 11, 12, 13, 14, 10, 16 }, { 16, 17, 18, 19, 20, 21 }, { 21, 22, 23, 24, 0, 26 }
	};

	ZeroMatrix(matrix);
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			System.Console.Write(matrix[i, j] + " ");
		}
		System.Console.WriteLine();
	}
}