static int[] Intersection(int[] a, int[] b)
{
	Array.Sort(a);
	Array.Sort(b);

	List<int> intersect = new List<int>();

	int i = 0;
	int j = 0;
	while (i < a.Length && j < b.Length)
	{
		// Skip elements a that are smaller than elements b
		if (a[i] < b[j])
		{
			i++;
		}
		// Skip elements b that are smaller than elements a
		else if (b[j] < a[i])
		{
			j++;
		}
		// Intersection is found
		else
		{
			intersect.Add(a[i]);
			i++;
			j++;
		}
	}

	return intersect.ToArray();
}