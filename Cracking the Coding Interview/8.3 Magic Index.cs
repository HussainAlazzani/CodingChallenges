// 8.3 Magic Index:
// A magic index in an array A [ 0 ••• n -1] is defined to be an index such that A[i] = i.
// Given a sorted array of distinct integers, write a method to find a magic index,
// if one exists, in array A.

// FOLLOW UP
// What if the values are not distinct?

// Simple but optimised.
public static void FindMagicIndex(int[] a)
{
	for (int i = 0; i < a.Length; i++)
	{
		if (a[i] == i)
		{
			while (a[i] == i)
			{
				Console.Write(i + ", ");
				i++;
			}
			return;
		}

	}
}

// Assuming all elements are distinct
public static void MagicIndex(int[] a)
{
	int magicIndex = FindMagicIndex(a, 0, a.Length - 1);
	while(magicIndex<a.Length - 1)
	{
		while (a[magicIndex] == magicIndex)
		{
			Console.Write(magicIndex + ", ");
			magicIndex++;
		}
		magicIndex++;
	}
}

private static int FindMagicIndex(int[] a, int first, int last)
{
	if (first >= last) return first + 1;

	int mid = ((last - first) / 2) - 1;
	if (a[mid] > mid)
	{
		return FindMagicIndex(a, mid + 1, last);
	}
	else
	{
		return FindMagicIndex(a, first, mid);
	}
}