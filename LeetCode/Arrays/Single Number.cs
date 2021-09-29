// Find the single number by brute force.
static int FindSingleNumber(int[] a)
{
	for (int i = 0; i < a.Length - 1; i++)
	{
		int count = 0;
		for (int j = 0; j < a.Length; j++)
		{
			if (a[i] == a[j])
			{
				count++;
			}
		}
		if (count == 1) return a[i];
	}
	return -1;
}
// Find the single number by sorting the array first.
static int FindSingleNumberSort(int[] a)
{
	Array.Sort(a);
	// Check first element
	if (a[0] != a[1])
	{
		return a[0];
	}
	// Check elements in between
	for (int i = 1; i < a.Length - 1; i++)
	{
		// If current element does not equal elements before and after, it is a single number.
		if (a[i] != a[i - 1] && a[i] != a[i + 1])
		{
			return a[i];
		}
	}
	// Check last element
	if (a[a.Length - 2] != a[a.Length - 1])
	{
		return a[a.Length - 1];
	}

	return -1;
}