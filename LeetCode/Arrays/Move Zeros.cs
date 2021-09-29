static void MoveZeroes(int[] a)
{
	for (int i = 0, j = 0; i < a.Length; i++)
	{
		j = i;
		if (a[i] == 0)
		{
			while (j<a.Length-1 && a[j] == 0)
			{
				j++;
			}

			int temp = a[j];
			a[j] = a[i];
			a[i] = temp;
		}
	}
}