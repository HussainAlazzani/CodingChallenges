static void Main(string[] args)
{
	int[] p = {7,1,5,3,6,4};
	for (int i = 0; i < p.Length; i++)
	{
		System.Console.Write(p[i] + " ");
	}
	System.Console.WriteLine("\n" + GetMaxProfit(p));
}
// This searches through the array once, every time there is a positive, it marks the
// beginning as buy, and the peak as sell, then calculates the profit. It repeats 
// through until the end of the array. Time complexity is O(n).
static int GetMaxProfit(int[] p)
{
	int buy = 0;
	int sell = 0;
	int profit = 0;

	for (int i = 0; i < p.Length-1; i++)
	{
		if (p[i] <p[i+1])
		{
			buy = p[i];
			while (i<p.Length && p[i]<p[i+1])
			{
				i++;
			}
			sell = p[i];
		}
		profit += sell - buy;
	}
	return profit;
}