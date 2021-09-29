// 1.1 Is Unique
// Implement an algorithm to determine if a string has all unique characters.
// What if you cannot use additional data structures?
// First method relies on a data structure, namely arrays.
// Second method is simplest.
// Another simple method is to sort the string O(nlog n), then check letter with neighbouring letter O(n).

// Time complexity O(n), space complexity O(1).
public static bool IsUniqueOptimised(string s)
{
	if (s.Length > 128)
		return false;

	// By default bools are false.
	bool[] charCheck = new bool[128];

	for (int i = 0; i < s.Length; i++)
	{
		// From the second letter, check if it has occured. If occured, it will be true. 
		if (charCheck[s[i]])
			return false;
		// Set bool value to true for occuring letter.
		charCheck[s[i]] = true;
	}
	return true;
}

// Time complexity O(n^2), space complexity O(1).
public static bool IsUniqueBrute(string s)
{
	string a = s.ToLower();

	for (int i = 0; i < a.Length; i++)
	{
		for (int j = i + 1; j < s.Length; j++)
		{
			if (a[i] == a[j])
			{
				return false;
			}
		}
	}

	return true;
}
