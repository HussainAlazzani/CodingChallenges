static void Main(string[] args)
{
	int[, ] example = new int[4, 4]
	{ { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 }
	};

	RotateMe(example);
	for (int i = 0; i < example.GetLength(0); i++)
	{
		for (int j = 0; j < example.GetLength(1); j++)
		{
			System.Console.Write(example[i, j] + " ");
		}
		System.Console.WriteLine();
	}
}

static void RotateMe(int[, ] matrix)
{
	int n = matrix.GetLength(0);
	int layers = n / 2;

	// Represents the layer. Example, 4x4 matrix will have 2 layers, therefore need to loop twice.
	// 5x5 matrix will also have 2 layers because the centre element does not count.
	for (int i = 0; i < layers; i++)
	{
		int first = i;
		int last = n - 1 - i;

		// Loop between first element and last element of the layer. The layers shorten as we increment through them.
		for (int j = first; j < last; j++)
		{
			// The expression (n - 1 - j) simply means we are traversing the elements in the negative direction,
			// where as j simply traverses elements in the positive direction with the loop.

			// Save top
			int temp = matrix[first, j];
			// Move left to top
			matrix[first, j] = matrix[n - 1 - j, first];
			// Move bottom to left
			matrix[n - 1 - j, first] = matrix[last, n - 1 - j];
			// Move right to bottom
			matrix[last, n - 1 - j] = matrix[j, last];
			// Move top to right
			matrix[j, last] = temp;
		}
	}
}

/////////////////////////////////////////
// Best solution. Transpose then reverse.

static void RotateBest(int[, ] matrix)
{
	if (matrix == null || matrix.Length == 0) return;

	TransposeMartix(matrix);
	Reverse(matrix);
}

static void TransposeMartix(int[, ] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = i; j < matrix.GetLength(1); j++)
		{
			int temp = matrix[i, j];
			matrix[i, j] = matrix[j, i];
			matrix[j, i] = temp;
		}
	}
}

static void Reverse(int[, ] matrix)
{
	int n = matrix.GetLength(0);

	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < n / 2; j++)
		{
			int temp = matrix[i, j];
			matrix[i, j] = matrix[i, n - 1 - j];
			matrix[i, n - 1 - j] = temp;
		}
	}
}

/////////////////////////////



// // Save top
// System.Console.WriteLine("temp = a[" + i + ", " + j + "]");
// int temp = matrix[first, j];
// // Move left to top
// System.Console.WriteLine("a[" + i + ", " + j + "]" + " = a[" + (n - 1 - j) + ", " + i + "]");
// matrix[first, j] = matrix[n - 1 - j, first];
// // Move bottom to left
// System.Console.WriteLine("a[" + (n - 1 - j) + ", " + i + "] = a[" + last + ", " + (n - 1 - j) + "]");
// matrix[n - 1 - j, first] = matrix[last, n - 1 - j];
// // Move right to bottom
// System.Console.WriteLine("a[" + last + ", " + (n - 1 - j) + "]" + "a[" + j + ", " + last + "]");
// matrix[last, n - 1 - j] = matrix[j, last];
// // Move top to right
// System.Console.WriteLine("a[" + j + ", " + last + "] = temp");
// matrix[j, last] = temp;