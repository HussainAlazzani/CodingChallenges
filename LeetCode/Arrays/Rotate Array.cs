static void Main(string[] args)
{
	int[] a = { 1, 2, 3, 4, 5, 6, 7 };
	for (int i = 0; i < a.Length; i++)
	{
		System.Console.Write(a[i] + " ");
	}
	ShiftArray(a,3);
	System.Console.WriteLine();
	foreach (var item in a)
	{
		System.Console.Write(item + ", ");
	}
}
// This solution uses two temporary variables.
static void ShiftArray(int[] a, int k)
{
	int index = 0;
	int temp1 = 0, temp2 = 0;

	temp2 = a[0];

	int length = (a.Length / 2) + (a.Length % 2);

	for (int i = 0; i < length; i++)
	{
		index = (index + k) % (a.Length);
		temp1 = a[index];
		a[index] = temp2;

		index = (index + k) % (a.Length);
		temp2 = a[index];
		a[index] = temp1;
	}
}

// This solution creates another array to copy it to.
static int[] ShiftArrayCopy(int[] a, int k)
{
	int[] b = new int[a.Length];
	int index = 0;

	for (int i = 0; i < a.Length; i++)
	{
		index = (i + k) % (a.Length);
		b[index] = a[i];
	}
	return b;
}