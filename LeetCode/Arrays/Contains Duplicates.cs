static void Main(string[] args)
{
	int[] a = { 1, 2, 3, 4, 2, 6 };
	for (int i = 0; i < a.Length; i++)
	{
		System.Console.Write(a[i] + " ");
	}
	System.Console.WriteLine();
	System.Console.WriteLine(ContainsDuplicate(a));
	System.Console.WriteLine(ContainsDuplicateSort(a));
}
// Sorting the array before checking for duplicates
static bool ContainsDuplicateSort(int[] a)
{
	Array.Sort(a);
	for (int i = 0; i < a.Length - 1; i++)
	{
		if (a[i] == a[i + 1]) return true;
	}
	return false;
}

// Brute force
static bool ContainsDuplicate(int[] a)
{
	for (int i = 0; i < a.Length - 1; i++)
	{
		for (int j = i + 1; j < a.Length; j++)
		{
			if (a[i] == a[j]) return true;
		}
	}
	return false;
}