// 1.6 String Compression 
// Implement a method to perform basic string compression using counts of repeated characters. For example, the string aabcccccaaa would become a2b1c5a3.
// If the compressed string would not become smaller than the original string, your method should return the original string.
// You can assume the string has only uppercase and lowercase letters.

public static string Compress(string s)
{
	StringBuilder compressedString = new StringBuilder();

	for (int i = 0; i < s.Length - 1; i++)
	{
		int count = 1;
		compressedString.Append(s[i]);

		while (i < (s.Length - 1) && (s[i] == s[i + 1]))
		{
			count++;
			i++;
		}
		compressedString.Append(count);
	}

	return (compressedString.Length < s.Length) ? compressedString.ToString() : s;
	
}