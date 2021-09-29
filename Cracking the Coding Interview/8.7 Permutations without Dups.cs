// 8.7 Permutations without Dups:
// Write a method to compute all permutations of a string of unique characters.


// Simply printing out the permutations without storing them in a list.
static void Main(string[] args)
{
	string s = "abcd";
	Perm(s, new StringBuilder(), 0, 0);
}
static void Perm(string s, string p, int index, int pos)
{
	if (index == s.Length)
	{
		System.Console.Write(p + "\t");
		return;
	}
	for (int i = 0; i <= index; i++)
	{
		Perm(s, p.Insert(i, s.Substring(index, 1)), index + 1, i);
	}
}

// Storing the permutations in a list.
static void Main(string[] args)
{
	string s = "abc";
	List<string> permList = new List<string>();
	Perm(permList, s, "", 0, 0);
	foreach (var permutation in permList)
	{
		System.Console.Write(permutation + "\t");
	}
}
static void Perm(List<string> permList, string s, string p, int index, int pos)
{
	if (index == s.Length)
	{
		permList.Add(p);
		return;
	}
	for (int i = 0; i <= index; i++)
	{
		Perm(permList, s, p.Insert(i, s.Substring(index, 1)), index + 1, i);
	}
}