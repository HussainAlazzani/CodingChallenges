public class Program
{
	static void Main()
	{
		int[] a = { 4, 5, 6, 0, 0, 0 };
		int[] b = { 1, 2, 3 };

		Solution sln = new Solution();
		sln.Merge(a, 3, b, 3);
		foreach (var item in a)
		{
			System.Console.Write(item + " ");
		}

	}

	public class Solution
	{
		// Starting from the end of nums one. That way, I don't have to use a temporary variable to swap elements.
		public void Merge(int[] nums1, int m, int[] nums2, int n)
		{
			if (nums1.Length == 0 || nums2.Length == 0)
			{
				return;
			}
			if (nums1.Length == nums2.Length)
			{
				for (int k = 0; k < nums1.Length; k++)
				{
					nums1[k] = nums2[k];
				}
				return;
			}

			int i = m - 1;
			int j = n - 1;
			int z = m + n - 1;

			while (i >= 0 && j >= 0)
			{
				if (nums1[i] < nums2[j])
				{
					nums1[z] = nums2[j];
					j--;
					z--;
				}
				else
				{
					nums1[z] = nums1[i];
					i--;
					z--;
				}
			}
			if (j != 0)
			{
				while (j >= 0)
				{
					nums1[z] = nums2[j];
					j--;
					z--;
				}
			}
			if (nums1[0] > nums2[0])
			{
				nums1[0] = nums2[0];
			}
		}
	}
}