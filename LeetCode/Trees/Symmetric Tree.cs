class Program
{
	static void Main(string[] args)
	{
		TreeNode root = new TreeNode(1);
		root.left = new TreeNode(2);
		root.right = new TreeNode(2);
		root.left.left = new TreeNode(3);
		root.left.right = new TreeNode(4);
		root.right.left = new TreeNode(4);
		root.right.right = new TreeNode(3);

		root.left.left.left = new TreeNode(8);
		root.left.left.right = new TreeNode(7);

		root.left.right.left = new TreeNode(6);
		root.left.right.right = new TreeNode(5);

		root.right.left.left = new TreeNode(5);
		root.right.left.right = new TreeNode(6);

		root.right.right.left = new TreeNode(7);
		root.right.right.right = new TreeNode(8);

		Solution tree = new Solution();
		System.Console.WriteLine(tree.MaxDepth(root));
		tree.InPrint(root);
		System.Console.WriteLine();

		System.Console.WriteLine(tree.IsSymmetry(root));

	}
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	public bool IsSymmetry(TreeNode root)
	{
		if (root == null) return true;
		return IsSymmetry(root.left, root.right);
	}
	private bool IsSymmetry(TreeNode root1, TreeNode root2)
	{
		if (root1 == null && root2 == null) return true;

		// Must check for nulls otherwise it fails in some test cases.
		if (root1 != null && root2 != null &&
			root1.val == root2.val)
		{
			return IsSymmetry(root1.left, root2.right) && IsSymmetry(root1.right, root2.left);
		}
		else
		{
			return false;
		}
	}

	public int MaxDepth(TreeNode root)
	{
		if (root == null) return 0;

		int left = MaxDepth(root.left);
		int right = MaxDepth(root.right);

		return Math.Max(left, right) + 1;
	}
	public void InPrint(TreeNode root)
	{
		if (root == null) return;

		InPrint(root.left);
		System.Console.Write(root.val + " ");
		InPrint(root.right);
	}
	public void PrePrint(TreeNode root)
	{
		if (root == null) return;

		System.Console.Write(root.val + " ");
		PrePrint(root.left);
		PrePrint(root.right);
	}
	public void PostPrint(TreeNode root)
	{
		if (root == null) return;

		PostPrint(root.left);
		PostPrint(root.right);
		System.Console.Write(root.val + " ");
	}

}