// 8.1 Triple Step:
// A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3 steps
// at a time. Implement a method to count how many possible ways the child can run up the stairs.

public static int NumberOfPossibleSteps(int n)
{
	if (n <= 0) return 0;
	if (n == 1 || n == 2) return n;

	return NumberOfPossibleSteps(n - 3) + NumberOfPossibleSteps(n - 2) + NumberOfPossibleSteps(n - 1);
}

public static int NumberOfPossibleStepsMemo(int n, int[] memo)
{
	if (n <= 0) return 0;
	if (n == 1 || n == 2) return n;

	if (memo[n] != 0)
	{
		return memo[n];
	}
	else
	{
		memo[n] = NumberOfPossibleStepsMemo(n - 3, memo) + NumberOfPossibleStepsMemo(n - 2, memo) + NumberOfPossibleStepsMemo(n - 1, memo);
		return memo[n];
	}
}
