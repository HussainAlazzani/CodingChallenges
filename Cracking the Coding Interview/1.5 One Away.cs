// 1.5 One Away
// There are three types of edits that can be performed on strings: insert, remove or replace a character.
// Given two strings, write a function to check if they are one or zero edit away.


public static bool OneWay(string a, string b)
{
	int letterDifference = a.Length - b.Length;

	if (letterDifference < -1 || letterDifference > 1) return false;

	// If deleted
	if (letterDifference == 1)
	{
		return InsertOrDelete(a, b);
	}
	// If inserted
	else if (letterDifference == -1)
	{
		return InsertOrDelete(b, a);
	}
	// if replaced or no edit.
	else if (letterDifference == 0)
	{
		int count = 0;
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] != b[i])
			{
				count++;
			}

			if (count > 1) return false;
		}
		return true;
	}
	else
	{
		return false;
	}
}

private static bool InsertOrDelete(string lString, string sString)
{
	int count = 0;
	for (int i = 0, j = 0; i < sString.Length; i++, j++)
	{
		if (sString[i] != lString[j])
		{
			count++;
			j++;
		}

		if (count > 1) return false;
	}

	return true;
}
