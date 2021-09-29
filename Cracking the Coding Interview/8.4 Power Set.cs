// 8.4 Power Set:
// Write a method to return all subsets of a set.

// 									{}
//									/\
// 							{} 				{a}
//							/\				/\
// 				{} 					{b} 			{a} 				{b,a}
//				/\ 					/\				/\					/\
// 			{}		{c}			{b}		{b,c}	{a}		{a,c}		{a,b}	{a,b,c}

static void Main(string[] args)
{
	char[] a = new char[] {'a', 'b', 'c'};
	PowerSet(a, new List<char>(), 0);
}

static void PowerSet(char[] arr, List<char> subset, int index)
{
	if (arr.Length == 0) return;
	if (index > arr.Length) return;
	if (index == arr.Length)
	{
		Console.Write("{");
		foreach (var item in subset)
		{
			Console.Write(item + " ");
		}
		Console.WriteLine("}");
		return;
	}

	PowerSet(arr, subset, index + 1);
	subset.Add(arr[index]);
	PowerSet(arr, subset, index + 1);
	subset.Clear();

}