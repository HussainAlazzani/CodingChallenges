// 1.3 URLify
// Write a method to replace all space in a string with "%20". You may assume that the string has sufficient space at the end to hold additional characters, and
// that you are given the "true" length of the string.

// Implements in two passes, first count number of spaces to figure out total length; second copy to array of char.
// Can implement in one pass by tripling the array length because worse case is string contains all spaces.
public static char[] URLify(string s)
{
	int count = 0;
	foreach (var item in s)
	{
		count++;
		if(item == ' ')
		{
			count += 2;
		}
	}

	char[] a = new char[count];

	for (int i = 0, index = 0; i < s.Length; i++, index++)
	{
		if (s[i] == ' ')
		{
			a[index] = '%';
			a[++index] = '2';
			a[++index] = '0';
		}
		else
		{
			a[index] = s[i];
		}
	}

	return a;

}