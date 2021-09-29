// 1.4 Palindrome Permutations
// Given a string, write a function to check if it is a permuation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwords.
// A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.

// This solution assume the string contains alphabetical characters.
// Create array to count number of occurances, then loop thru string and record number of occurances, then check number of occurances in the array tree.
// Even strings must contain letters that are paired. Odd strings can only contain one odd letter (center letter) but the rest must pair. Time complexity O(n).
// Another approach is to sort letters then check for pairs. Time complexity O(n logn) because we are sorting. 

public static bool IsPalindromePermutation(string s)
{
	char[] a = new char[128];
	for (int i = 0; i < s.Length; i++)
	{
		a[s[i]]++;
	}

	int oddCount = 0;

	if (s.Length % 2 == 0)
	{
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] % 2 != 0)
			{
				return false;
			}
		}
	}
	else
	{
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] % 2 != 0)
			{
				oddCount++;
			}
			if (oddCount > 1)
			{
				return false;
			}
		}
		if (oddCount != 1)
		{
			return false;
		}
	}
	return true;
}