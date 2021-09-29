// 1.2 Check permutations.
// Given two strings, check if one string is the permutation of the other.
// Time complexity O(n + 128) = O(n + c) = O(n).
// Space complexity O(1).
static bool IsPermutation(string s1, string s2)
{
	if (s1.Length != s2.Length) return false;

	int[] a = new int[128];

	for (int i = 0; i < s1.Length; i++)
	{
		a[s1[i]]++;
		a[s2[i]]++;
	}

	for (int i = 0; i < a.Length; i++)
	{
		if (a[i] % 2 != 0)
		{
			return false;
		}
	}
	return true;
}

// Convert to array of char, then sort, then 
// Time complexity O(n + n log n + n) = O(n log n)
// Space complexity O(1).
static bool IsPermutationSort(string s1, string s2)
{
	if (s1.Length != s2.Length) return false;

	char[] c1 = s1.ToCharArray();
	char[] c2 = s2.ToCharArray();

	Array.Sort(c1);
	Array.Sort(c2);

	if (c1.SequenceEqual(c2))
		return true;
	
	else
		return false;
}