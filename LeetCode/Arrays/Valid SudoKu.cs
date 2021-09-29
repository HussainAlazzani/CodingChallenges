static void Main(string[] args)
{
	char[, ] board = new char[, ]
	{
		{'8','3','.','.','7','.','.','.','.'},
		{'6','.','.','1','9','5','.','.','.'},
		{'.','9','8','.','.','.','.','6','.'},
		{'8','.','.','.','6','.','.','.','3'},
		{'4','.','.','8','.','3','.','.','1'},
		{'7','.','.','.','2','.','.','.','6'},
		{'.','6','.','.','.','.','2','8','.'},
		{'.','.','.','4','1','9','.','.','5'},
		{'.','.','.','.','8','.','.','7','9'}
	};

	for (int i = 0; i < board.GetLength(0); i++)
	{
		for (int j = 0; j < board.GetLength(1); j++)
		{
			System.Console.Write(board[i, j] + ", ");
		}
		System.Console.WriteLine();
	}
	System.Console.WriteLine(IsValidSudoku(board));
}

static bool IsValidSudoku(char[, ] a)
{
	for (int i = 0; i < a.GetLength(0); i += 3)
	{
		for (int j = 0; j < a.GetLength(1); j += 3)
		{
			char[] cells = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j' };
			int index = 0;
			for (int r = i; r < i + 3; r++)
			{
				for (int c = j; c < j + 3; c++)
				{
					// Check that all elements within the 3x3 matrix are between 0 and 9 before proceeding to copy elements to cells array.
					if ((a[r, c] > '9' || a[r, c] < '1') && a[r, c] != '.') return false;

					if (a[r, c] != '.')
					{
						cells[index] = a[r, c];
					}
					index++;
				}
			}

			// Check that each 3x3 matrix does not contain equal numbers as per rules.
			Array.Sort(cells);
			for (int z = 0; z < cells.Length - 1; z++)
			{
				if (cells[z] == cells[z + 1]) return false;
			}
		}
	}
	return true;
}