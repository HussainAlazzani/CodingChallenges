// 4.4 Check Balanced:
// Implement a function to check if a binary tree is balanced. For the purposes of this
// question, a balanced tree is defined to be a tree such that the heights of the two
// subtrees of any node never differ by more than one.

public bool IsTreeBalanced()
{
	int height = IsTreeBalanced(root);
	return height < 0 ? false : true;
}
// This answers the exact question.
private static int IsTreeBalanced(BNode root)
{
	if (root == null) return 0;

	int leftHeight = IsTreeBalanced(root.Left);
	// Subtree not balanced.
	if (leftHeight == -1) return -1;

	int rightHeight = IsTreeBalanced(root.Right);
	// Subtree not balanced.
	if (rightHeight == -1) return -1;

	int heightDifference = Math.Abs(leftHeight - rightHeight);

	// Current node not balanced.
	if (heightDifference > 1)
		return -1;
	// Current node balanced.
	else
		return Math.Max(leftHeight, rightHeight) + 1;
}

// This one checks if the tree is balanced. To be balanced, only one extra left child is allowed. A right child is not allowed without a left child balancing it.
private static int IsTreeBalanced(BNode root)
{
	if (root == null) return 0;

	int leftHeight = IsTreeBalanced(root.Left);
	// Subtree not balanced.
	if (leftHeight == -1) return -1;

	int rightHeight = IsTreeBalanced(root.Right);
	// Subtree not balanced.
	if (rightHeight == -1) return -1;

	int heightDifference = leftHeight - rightHeight;

	// Current node not balanced, or has right child but no left child.
	if (heightDifference > 1 || heightDifference < 0)
		return -1;
	// Current node balanced.
	else
		return Math.Max(leftHeight, rightHeight) + 1;
}
