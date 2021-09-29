public class Program
{
	static void Main()
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

		IList<IList<int>> lists = new List<IList<int>>();
		lists = tree.OrderTraverse(root);
		foreach (var items in lists)
		{
			foreach (var item in items)
			{
				System.Console.Write(item + " ");
			}
			System.Console.WriteLine();
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
		// NOT recursive but iterative.
		public IList<IList<int>> OrderTraverse(TreeNode root)
		{
			IList<IList<int>> lists = new List<IList<int>>();

			if (root == null) return lists;

			Queue<TreeNode> q = new Queue<TreeNode>();
			q.Enqueue(root);

			while (q.Any())
			{
				// Must store the size of the queue in a variable because the queue size
				// changes as we dequeue and enqueue it inside the for loop.
				int size = q.Count;
				// A list for each level.
				List<int> level = new List<int>();
				for (int i = 0; i < size; i++)
				{
					TreeNode current = q.Dequeue();
					level.Add(current.val);
					if (current.left != null)
					{
						q.Enqueue(current.left);
					}
					if (current.right != null)
					{
						q.Enqueue(current.right);
					}
				}
				lists.Add(level);
			}

			return lists;
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

	}
}