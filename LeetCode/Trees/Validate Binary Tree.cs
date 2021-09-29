class Program
{
	static void Main(string[] args)
	{
		// Edge case: 2147483647
		TreeNode root = new TreeNode(2147483647);
		// TreeNode root = new TreeNode(50);
		// root.left = new TreeNode(20);
		// root.right = new TreeNode(80);
		// root.left.left = new TreeNode(10);
		// root.left.right = new TreeNode(30);
		// root.right.left = new TreeNode(60);
		// root.right.right = new TreeNode(100);
		//root.right.right.left = new TreeNode(6);

		Solution tree = new Solution();
		System.Console.WriteLine(tree.MaxDepth(root));
		tree.Print(root);
		System.Console.WriteLine(tree.IsValidBST(root));
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
	public bool IsValidBST(TreeNode root)
	{
		// Using double to get past the stupic edge case input of [2147483647].
		return IsValidBST(root, double.MinValue, double.MaxValue);
	}
	private bool IsValidBST(TreeNode root, double min, double max)
	{
		if (root == null) return true;

		if (root.val < max && root.val > min)
		{
			return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
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
	public void Print(TreeNode root)
	{
		if (root == null) return;

		Print(root.left);
		System.Console.WriteLine(root.val);
		Print(root.right);
	}

}