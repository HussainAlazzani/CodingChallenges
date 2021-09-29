// Actually I don't need to return the array because it is passed by reference. Could use the signiture:
// static void PlusOne(int[] a), instead.
static int[] PlusOne(int[] a)
{
	int addOne = 1;
	int carry = 0;
	for (int i = a.Length - 1; i >= 0; i--)
	{
		int sum = a[i] + addOne + carry;
		if (sum > 9)
		{
			a[i] = sum - 10;
			carry = 1;
			addOne = 0;
		}
		else
		{
			a[i] = sum;
			carry = 0;
			addOne = 0;
		}
	}
	return a;
}