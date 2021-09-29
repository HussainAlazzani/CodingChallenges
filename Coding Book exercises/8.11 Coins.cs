// 8.11 Coins:
// Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents),
// and pennies (1 cent), write code to calculate the number of ways of representing n cents.

static void Main(string[] args)
{
	int[] denoms = { 25, 10, 5, 1 };
	int[] denoms2 = { 1, 5, 10, 25 };
	int[] denoms3 = { 1, 2, 5 };
	int[] denoms4 = { 5, 2, 1 };
	int cents = 123;

	Console.WriteLine(MakeChange(cents, denoms4));
	Coins(123, denoms4);
}

// Dynamic approach is correct even when the array of denoms is ascending order.
public static int MakeChange(int n, int[] denoms)
{
	return MakeChange(n, denoms, 0);
}
private static int MakeChange(int amount, int[] denoms, int index)
{
	if (index >= denoms.Length - 1) return 1;
	int denomAmount = denoms[index];
	int ways = 0;
	for (int i = 0; i * denomAmount <= amount; i++)
	{
		int amountRemaining = amount - i * denomAmount;
		ways = ways + MakeChange(amountRemaining, denoms, index + 1);
	}
	return ways;
}

// My approach using a tree but it fails when the denoms is in ascending order.
static void Coins(int n, int[] denoms)
{
	System.Console.WriteLine(Coins(n, denoms, n));
}
static int Coins(int n, int[] denoms, int prevCoin)
{
	if (n < 0) return 0;
	if (n == 0) return 1;

	int count = 0;

	for (int i = 0; i < denoms.Length; i++)
	{
		if (prevCoin >= denoms[i])
		{
			count += Coins(n - denoms[i], denoms, denoms[i]);
		}
	}

	return count;
}


// Not the question. This answers the question of returning the lest number of change to a given amount.
// Example: Amount is £123. The least change given is 25+25+25+25+10+10+1+1+1 
static void Main(string[] args)
{
	System.Console.WriteLine(Cents(123));
}

static int Cents(int n)
{
	if (n <= 0) return 0;

	if (n - 25 >= 0)
	{
		System.Console.Write(25 + " + ");
		return Cents(n - 25);
	}
	else if (n - 10 >= 0)
	{
		System.Console.Write(10 + " + ");
		return Cents(n - 10);
	}
	else if (n - 10 >= 0)
	{
		System.Console.Write(5 + " + ");
		return Cents(n - 5);
	}
	else
	{
		System.Console.Write(1 + " + ");
		return Cents(n - 1);
	}
}

// This solution stores all the solutions of the table which is actually not required. See solution below it.
static int CoinChange(int amount, int[] coins)
{
	int[, ] t = new int[coins.Length + 1, amount + 1];

	for (int i = 0; i <= coins.Length; i++)
	{
		for (int j = 0; j <= amount; j++)
		{
			if (i == 0 && j == 0)
			{
				t[i, j] = 1;
				Console.Write(t[i, j] + ", ");
			}
			else if (i == 0)
			{
				t[i, j] = 0;
			}
			else if (coins[i - 1] > j)
			{
				t[i, j] = t[i - 1, j];
				Console.Write(t[i, j] + ", ");
			}
			else
			{
				t[i, j] = t[i - 1, j] + t[i, j - coins[i - 1]];
				Console.Write(t[i, j] + ", ");
			}
		}
		System.Console.WriteLine();
	}
	return t[coins.Length, amount];
}

// This solution only stores the values of the current row. Previous row values
// are not overridden, hence remain stored.
static int CoinChange(int amount, int[] coins)
{
	int[] t = new int[amount + 1];

	t[0] = 1;
	for (int i = 0; i < coins.Length; i++)
	{
		for (int j = 0; j <= amount; j++)
		{
			if (coins[i] <= j)
			{
				t[j] = t[j] + t[j - coins[i]];
			}
			System.Console.Write(t[j] + ", ");
		}
		System.Console.WriteLine();
	}

	return t[amount];
}