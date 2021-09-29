public class Program
{
	static void Main()
	{
		int n = 5;
		Solution sln = new Solution();
		System.Console.WriteLine(sln.FirstBadVersion(n));
	}

	public class Solution
	{
		// Simple iterative approach.
		public int FirstBadVersion(int n)
		{
			int first = 0;
			int last = n;
			while (first < last)
			{
				int mid = first + (last - first)/2;
				if (IsBadVersion(mid) == false)
				{
					first = mid + 1;
				}
				else
				{
					last = mid;
				}
			}
			return first;
		}

		// Recursive approach
		public int FirstBadVersion(int n)
		{
			return FirstBadVersion(1, n);
		}
		private int FirstBadVersion(int first, int last)
		{
			if (first >= last) return first;

			int mid = first + (last - first) / 2;

			if (IsBadVersion(mid))
			{
				return FirstBadVersion(first, mid);
			}
			else
			{
				return FirstBadVersion(mid + 1, last);
			}
		}

		public bool IsBadVersion(int version)
		{
			if (version >= 3) return true;
			else return false;
		}
	}
}