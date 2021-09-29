// 8.9 Parens:
// Implement an algorithm to print all valid (e.g., properly opened and closed)
// combinations of n pairs of parentheses.

// EXAMPLE
// Input: 3
// Output: ( ( () ) ) , ( () () ) , ( () ) () , () ( () ) , () () ()

// L = Left parenthesis.
// R = Right parenthesis.

// n = 1	=>	()
// n = 2	=>	(())	()()
// n = 3	=>	()(())	(()())	((()))	()()()	(())()	()(())


									""
								(		x
							/		\
						/				\
						((				()
						/\			/		\
					/		\
					(((				(()				()(
				/		\			/	\			/	\
			x			((()	(()(	()()	()((	()()
((())	(()()	(())(	()(()	()()(
((()))			(()())			(())()				()(())				()()()




// This approach is more intuitive because you increase n as you go up the stack and also left and right reflect the actual counts of No. of parens.
static void Main(string[] args)
{
	foreach (var item in GenerateParen(4))
	{
		System.Console.Write(item + "\t");
	}
}
static List<string> GenerateParen(int n)
{
	List<string> parenList = new List<string>();
	GenerateParen(n, parenList,"", 0, 0);
	return parenList;
}
static void GenerateParen(int n, List<string> parenList, string p, int left, int right)
{
	if (n <= 0 || left > n || right > left) return;

	if (left == n && right == n)
	{
		parenList.Add(p);
		return;
	}

	GenerateParen(n, parenList, p + "(", left + 1, right);
	GenerateParen(n, parenList, p + ")", left, right + 1);
}


// Decrementing as you go up the stack uses less parameters because you eliminate n.
static List<string> GenerateParen(int n)
{
	List<string> parenList = new List<string>();
	GenerateParen(parenList, "", n, n);
	return parenList;
}
static void GenerateParen(List<string> parenList, string p, int left, int right)
{
	if (left < 0 || right < left) return;

	if (left == 0 && right == 0)
	{
		parenList.Add(p);
		return;
	}

	GenerateParen(parenList, p + "(", left - 1, right);
	GenerateParen(parenList, p + ")", left, right - 1);
}








 