// 1.9 String rotation
// Assume you have a method IsSubstring which checks if one word is a substring of another.
// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one
// call to IsString. (eg. "waterbottle" is a rotation of "erbottlewat").

public static bool IsStringRotation(string a, string b)
{
	if (a.Length != b.Length) return false;

	for (int i = 0; i < b.Length; i++)
	{
		if (b[i] == a[0])
		{
			if (b.Substring(i, b.Length - i).Equals(a.Substring(0, a.Length - i)) &&
				b.Substring(0, i).Equals(a.Substring(a.Length - i, i)))
			{
				return true;
			}
		}
	}

	return false;
}

public static bool IsStringRotation(string a, string b)
{
	if (a.Length != b.Length) return false;

	int firstLetterIndex = -1;
	int index = 0;
	bool flag = false;

	for (int i = 0; i < a.Length; i++)
	{
		if (flag == false && b[i] == a[0])
		{
			firstLetterIndex = i;
		}
		if (firstLetterIndex > -1)
		{
			flag = true;
			if (b[i] != a[index++])
			{
				firstLetterIndex = -1;
				index = 0;
				flag = false;
				i--;
				continue;
			}
		}
	}

	if (firstLetterIndex == -1) return false;

	for (int i = 0; i < firstLetterIndex; i++, index++)
	{
		if (a[index] != b[i]) return false;
	}

	return true;
}