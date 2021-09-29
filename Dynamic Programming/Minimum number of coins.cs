public class Program
{
	static void Main()
	{
		int[] coins = { 1, 5, 6, 9 };
		int amount = 8;

		System.Console.WriteLine(MinimumCoins(coins, amount));
		System.Console.WriteLine(MinimumCoinsDP(coins, amount));

	}
	// Dynamic approach
	private static int MinimumCoinsDP(int[] coins, int amount)
	{
		if (coins.Length == 0 || amount == 0) return 0;

		int[, ] t = new int[coins.Length + 1, amount + 1];
		int i = 0;
		int j = 0;

		for (i = 0; i < t.GetLength(0); i++)
		{
			for (j = 0; j < t.GetLength(1); j++)
			{
				if (i == 0 && j == 0)
				{
					t[i, j] = 0;
				}
				else if (i == 0)
				{
					t[i, j] = int.MaxValue;
				}
				else if (j < coins[i - 1])
				{
					t[i, j] = t[i - 1, j];
				}
				else
				{
					t[i, j] = Math.Min(t[i - 1, j], 1 + t[i, j - coins[i - 1]]);
				}
			}
		}
		return t[i - 1, j - 1];
	}
	// Recursive approach
	private static int MinimumCoins(int[] coins, int amount)
	{
		if (amount == 0) return 0;

		int[] minAmount = new int[coins.Length];
		for (int i = 0; i < minAmount.Length; i++)
		{
			if (amount < coins[i])
			{
				minAmount[i] = int.MaxValue;
			}
			else
			{
				minAmount[i] = MinimumCoins(coins, amount - coins[i]);
			}
		}
		return minAmount.Min() + 1;
	}