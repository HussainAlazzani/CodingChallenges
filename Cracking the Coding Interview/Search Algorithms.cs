static void MergeSort(int[] A)
{
	if (A.Length == 1) return;

	int mid = A.Length / 2;
	int[] left = new int[mid];
	int[] right = new int[A.Length - mid];

	for (int i = 0; i < left.Length; i++)
	{
		left[i] = A[i];
	}
	for (int i = 0; i < right.Length; i++)
	{
		right[i] = A[i + mid];
	}

	MergeSort(left);
	MergeSort(right);
	Merge(A, left, right);
}

static void Merge(int[] A, int[] left, int[] right)
{
	int i = 0;
	int j = 0;
	int k = 0;

	while (i < left.Length && j < right.Length)
	{
		if (left[i] < right[j])
		{
			A[k] = left[i];
			k++; i++;
		}
		else
		{
			A[k] = right[j];
			k++; j++;
		}
	}
	while (i < left.Length)
	{
		A[k] = left[i];
		i++; k++;
	}
	while (j < right.Length)
	{
		A[k] = right[j];
		j++; k++;
	}
}
