static void Main(string[] args)
{
	int[] a = { 0, 0, 0, 0, 0, 0, 2, 3, 4, 4, 4, 4, 4, 5, 6, 7, 7, 8, 8, 8, 9, 12, 12, 13 };
	int length = GetLength(a);
	System.Console.WriteLine(length);
	for (int i = 0; i < length; i++)
	{
		System.Console.Write(a[i] + ", ");
	}
}
static int GetLength(int[] a)
{
	int index = 0;
	int max = a[a.Length - 1];

	for (int i = 1; i < a.Length; i++)
	{
		if(a[index] == max) return index + 1;
		if (a[index] < a[i])
		{
			a[index + 1] = a[i];
			index++;
		}
	}
	
	return index + 1;
}