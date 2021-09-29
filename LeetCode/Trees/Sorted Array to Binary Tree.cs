public class Program
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	static void Main()
	{
		int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		TreeNode root = null;
		Solution tree = new Solution();
		
		root = tree.SortedArrayToBST(a);
		System.Console.WriteLine(tree.MaxDepth(root));
		tree.OrderTraverse(root);
		System.Console.WriteLine();

	}

	public class Solution
	{
		public TreeNode SortedArrayToBST(int[] nums)
		{
			return Divide(null, nums, 0, nums.Length - 1);
		}
		public TreeNode Divide(TreeNode root, int[] a, int first, int last)
		{
			if (first > last)
			{
				return root;
			}
			else
			{
				int mid = first + (last - first) / 2;
				root = Add(root, a[mid]);

				root.left = Divide(root.left, a, first, mid - 1);
				root.right = Divide(root.right, a, mid + 1, last);
			}
			return root;
		}
		public TreeNode Add(TreeNode root, int val)
		{
			if (root == null)
			{
				root = new TreeNode(val);
			}
			else if (val < root.val)
			{
				root.left = Add(root.left, val);
			}
			else
			{
				root.right = Add(root.right, val);
			}
			return root;
		}

		// NOT recursive but iterative.
		public void OrderTraverse(TreeNode root)
		{
			if (root == null) return;

			Queue<TreeNode> q = new Queue<TreeNode>();
			q.Enqueue(root);

			while (q.Any())
			{
				int size = q.Count;
				for (int i = 0; i < size; i++)
				{
					TreeNode current = q.Dequeue();
					System.Console.Write(current.val + " ");

					if (current.left != null)
					{
						q.Enqueue(current.left);
					}
					if (current.right != null)
					{
						q.Enqueue(current.right);
					}
				}
				System.Console.WriteLine();
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

	}
}