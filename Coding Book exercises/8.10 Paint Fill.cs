// 8.10 Paint Fill:
// Implement the "paint fill" function that one might see on many image editing programs.
// That is, given a screen (represented by a two-dimensional array of colors), a point, and a
// new color, fill in the surrounding area until the color changes from the original color.

// Passing the array that represents the paint area by reference.
static void Main(string[] args)
{
	int[,] area = new int[,]
	{
		{0, 255, 255, 50, 50},
		{0, 255, 255, 50, 50},
		{0, 255, 255, 255, 255},
		{0, 255, 255, 255, 255},
		{255, 255, 255, 255, 255},
		{255, 255, 100, 100, 255},
		{100, 100, 100, 100, 255},
		
	};

	Paint(ref area, 77, 255, 2, 3);
	for (int i = 0; i < area.GetLength(0); i++)
	{
		for (int j = 0; j < area.GetLength(1); j++)
		{
			System.Console.Write(area[i,j] + "\t");
		}
		System.Console.WriteLine();
	}
}

static void Paint(ref int[, ] area, int newColor, int oldColor, int row, int col)
{
	if (area.Length == 0) return;
	if (row < 0 || col < 0 || row > area.GetLength(0) - 1 || col > area.GetLength(1) - 1) return;
	if (area[row, col] != oldColor) return;

	if (area[row, col] == oldColor)
	{
		area[row, col] = newColor;
		
		// up
		Paint(ref area, newColor, oldColor, row - 1, col);
		// down
		Paint(ref area, newColor, oldColor, row + 1, col);
		// left
		Paint(ref area, newColor, oldColor, row, col - 1);
		// right
		Paint(ref area, newColor, oldColor, row, col + 1);
	}
}