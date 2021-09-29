static int[] TwoSum(int[] a, int target)
{
	int[] nums = new int[2];
	for (int i = 0; i < a.Length; i++)
	{
		if (a[i] < target)
		{
			int remainder = target - a[i];
			for (int j = i + 1; j < a.Length; j++)
			{
				if (a[j] == remainder)
				{
					nums[0] = a[i];
					nums[1] = a[j];
					return nums;
				}
			}
		}
	}
	return nums;
}