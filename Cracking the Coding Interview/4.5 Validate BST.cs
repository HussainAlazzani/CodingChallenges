// 4.5 Validate BST:
// Implement a function to check if a binary tree is a binary search tree.

// One approach is to make use of the inorder traverse, and store it in a list. If the list is sorted, then the tree is balanced. This approach requires a buffer ie. more space.
// More efficient approach is to set min and max and check against each node as you traverse.
public void IsBinarySearchTree()
{
	bool isBST = IsBinarySearchTree(root, int.MinValue, int.MaxValue);

	System.Console.WriteLine("Is this tree binary search tree? " + isBST);
}

private bool IsBinarySearchTree(BNode root, int min, int max)
{
	if (root == null) return true;

	else if (root.Data >= min && root.Data <= max &&
		IsBinarySearchTree(root.Left, min, root.Data) &&
		IsBinarySearchTree(root.Right, root.Data, max))
		return true;

	else
		return false;
}
