class Program
{
	static void Main(string[] args)
	{
		TreeNode root = new TreeNode(3);
		root.left = new TreeNode(9);
		root.right = new TreeNode(20);
		root.right.left = new TreeNode(15);
		root.right.right = new TreeNode(7);
		root.right.right.left = new TreeNode(6);

		Solution tree = new Solution();
		System.Console.WriteLine(tree.MaxDepth(root));

		tree.Print(root);
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
	// This is the solution.
	public int MaxDepth(TreeNode root)
	{
		if (root == null) return 0;

		int left = MaxDepth(root.left);
		int right = MaxDepth(root.right);

		return Math.Max(left, right) + 1;
	}
	public void Print(TreeNode root)
	{
		if (root == null) return;

		Print(root.left);
		System.Console.WriteLine(root.val);
		Print(root.right);
	}
}