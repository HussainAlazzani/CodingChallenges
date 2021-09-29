class Program
{
	static void Main(string[] args)
	{
		int[] nums = { 1, 2, 3, 4, 5 };
		
		Solution obj = new Solution(nums);
		int[] param_2 = obj.Shuffle();
		int[] param_1 = obj.Reset();
		param_2 = obj.Shuffle();
	}
}
public class Solution
{
	private int[] nums;
	private int[] numsOriginal;

	public Solution(int[] nums)
	{
		this.nums = nums;
		numsOriginal = new int[nums.Length];
		for (int i = 0; i < nums.Length; i++)
		{
			numsOriginal[i] = nums[i];
		}
	}

	/** Resets the array to its original configuration and return it. */
	public int[] Reset()
	{
		return numsOriginal;
	}

	/** Returns a random shuffling of the array. */
	public int[] Shuffle()
	{
		Random r = new Random();

		for (int i = 0; i < nums.Length; i++)
		{
			int randomIndex = r.Next(nums.Length - 1);
			int temp = nums[i];
			nums[i] = nums[randomIndex];
			nums[randomIndex] = temp;
		}
		return nums;
	}
}