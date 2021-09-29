// 4.1O Check Subtree:
// Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an
// algorithm to determine if T2 is a subtree of Tl. A tree T2 is a subtree of Tl if
// there exists a node n in Tl such that the subtree of n is identical to T2.
// That is, if you cut off the tree at node n, the two trees would be identical.


public static bool ContainsTree(BNode root1, BNode root2)
{
	if (root2 == null) return true;
	return SubTree(root1, root2);
}
public static bool SubTree(BNode root1, BNode root2)
{
	if (root1 == null) return false;

	if (root1.Data == root2.Data && MatchTree(root1, root2))
	{
		return true;
	}

	return SubTree(root1.Left, root2) || SubTree(root1.Right, root2);
}
public static bool MatchTree(BNode root1, BNode root2)
{
	if (root1 == null && root2 == null) return true;
	else if (root1 == null || root2 == null) return false;
	else if (root1.Data != root2.Data) return false;
	else
		return MatchTree(root1.Left, root2.Left) && MatchTree(root1.Right, root2.Right);
}

public static void find(BNode root1, BNode root2)
{
	if (root2 == null) return;
	if (root1 == null) return;

	if (root1.Data == root2.Data)
	{
		Console.Write("[" + root1.Data + " = " + root2.Data + "] ");

		find(root1.Left, root2.Left);
		find(root1.Right, root2.Right);

	}
	find(root1.Left, root2);
	find(root1.Right, root2);
}