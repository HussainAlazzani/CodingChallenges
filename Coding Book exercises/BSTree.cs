using System;
using System.Collections.Generic;

namespace CSharpPractice
{
	internal class BNode
	{
		public int Data { get; set; }
		public BNode Left { get; set; }
		public BNode Right { get; set; }

		public BNode(int data)
		{
			Data = data;
		}
	}

	public class BSTree
	{
		private BNode root;

		public void Add(int data)
		{
			root = Add(root, data);
		}

		private BNode Add(BNode root, int data)
		{
			if (root == null)
			{
				root = new BNode(data);
			}
			else if (data < root.Data)
			{
				root.Left = Add(root.Left, data);
			}
			else
			{
				root.Right = Add(root.Right, data);
			}

			return root;
		}

		public void Print(string prefix)
		{
			switch (prefix)
			{
				case "Pre":
					PrintPreOrder(root);
					break;
				case "In":
					PrintInOrder(root);
					break;
				case "Post":
					PrintPostOrder(root);
					break;
				case "Level":
					PrintLevelOrder(root);
					break;
			}
		}

		private void PrintPreOrder(BNode root)
		{
			if (root == null) return;

			System.Console.Write("[" + root.Data + "] ");
			PrintPreOrder(root.Left);
			PrintPreOrder(root.Right);
		}

		private void PrintInOrder(BNode root)
		{
			if (root == null) return;

			PrintInOrder(root.Left);
			System.Console.Write("[" + root.Data + "] ");
			PrintInOrder(root.Right);
		}

		private void PrintPostOrder(BNode root)
		{
			if (root == null) return;

			PrintPostOrder(root.Left);
			PrintPostOrder(root.Right);
			System.Console.Write("[" + root.Data + "] ");
		}

		private void PrintLevelOrder(BNode root)
		{
			if (root == null)
			{
				Console.WriteLine("List is empty");;
			}
			else
			{
				Queue<BNode> q = new Queue<BNode>();
				q.Enqueue(root);
				while (q.Count > 0)
				{
					root = q.Dequeue();
					Console.Write("[" + root.Data + "] ");
					if (root.Left != null)
					{
						q.Enqueue(root.Left);
					}
					if (root.Right != null)
					{
						q.Enqueue(root.Right);
					}
				}
			}
		}

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

		public void MinMaxValue()
		{
			int minRecursively = MinValue(root);
			int maxRecursively = MaxValue(root);

			Console.WriteLine("Min value recursively: " + minRecursively);
			Console.WriteLine("Max value recursively: " + maxRecursively);
		}

		private int MinValue(BNode root)
		{
			// Must check if there are nodes otherwise do: if(root == null) return -1;
			if (root.Left == null) return root.Data;

			return MinValue(root.Left);
		}

		private int MaxValue(BNode root)
		{
			// Must check if there are nodes otherwise do: if(root == null) return -1;
			if (root.Right == null) return root.Data;

			return MaxValue(root.Right);
		}

		public void TreeHeight()
		{
			System.Console.WriteLine("Tree height is: " + TreeHeight(root));
		}

		private int TreeHeight(BNode root)
		{
			if (root == null) return -1;

			return Math.Max(TreeHeight(root.Left), TreeHeight(root.Right)) + 1;
		}

		public void CountNodes()
		{
			System.Console.WriteLine(CountNodes(root));
		}

		private int CountNodes(BNode root)
		{
			if (root == null) return 0;

			return CountNodes(root.Left) + CountNodes(root.Right) + 1;
		}

		public void Delete(int data)
		{
			root = Delete(root, data);
		}

		private BNode Delete(BNode root, int data)
		{
			if (root == null) return null;
			else if (root.Data > data)
			{
				root.Left = Delete(root.Left, data);
			}
			else if (root.Data < data)
			{
				// Setting to the right node because we want to move to the right node.
				root.Right = Delete(root.Right, data);
			}
			else
			{
				if (root.Left == null && root.Right == null)
				{
					root = null;
				}
				else if (root.Right == null)
				{
					root = root.Left;
				}
				else if (root.Left == null)
				{
					root = root.Left;
				}
				else
				{
					// Get minimum value of the right subtree, then set it to the node we want to delete.
					// Delete from the right subtree of the current node
					// And return the right child node.
					root.Data = MinValue(root.Right);
					root.Right = Delete(root.Right, root.Data);
				}
			}
			return root;
		}

		public void BuildHeapTree()
		{
			root = new BNode(100);
			root.Left = new BNode(80);
			root.Left.Left = new BNode(60);
			root.Left.Left.Left = new BNode(40);
			root.Left.Left.Right = new BNode(50);
			root.Left.Right = new BNode(70);
			root.Left.Right.Left = new BNode(30);
			root.Left.Right.Right = new BNode(55);
			root.Right = new BNode(90);
			root.Right.Left = new BNode(75);
			root.Right.Right = new BNode(85);
			root.Right.Right.Left = new BNode(60);
			root.Right.Right.Left.Right = new BNode(40);
			root.Right.Right.Left.Left = new BNode(50);
			root.Right.Right.Right = new BNode(65);
			root.Right.Right.Right.Left = new BNode(55);
			root.Right.Right.Right.Right = new BNode(60);
		}

		public void IsHeapTree()
		{
			System.Console.WriteLine("Is Heap tree? " + IsHeapTree(root));
		}

		private bool IsHeapTree(BNode root)
		{
			if (root == null) return true;
			if (root.Left == null && root.Right == null) return true;
			if (root.Left == null || root.Right == null) return false;
			if (root.Data >= root.Left.Data && root.Data >= root.Right.Data && IsHeapTree(root.Left) && IsHeapTree(root.Right)) return true;
			return false;
		}

	}

}

////////////////////////// Main()
// BSTree bSTree = new BSTree();
// bSTree.BuildHeapTree();
// bSTree.Print("Level");
// System.Console.WriteLine();
// bSTree.IsHeapTree();

// BSTree bSTree = new BSTree();

// bSTree.Add(50);
// bSTree.Add(30);
// bSTree.Add(70);
// bSTree.Add(20);
// bSTree.Add(80);
// bSTree.Add(100);
// bSTree.Add(20);
// bSTree.Add(10);
// bSTree.Add(120);
// bSTree.Add(10);
// bSTree.Add(40);
// bSTree.Add(75);
// bSTree.Add(60);
// bSTree.Add(35);
// bSTree.Print("Level");
// System.Console.WriteLine();

// bSTree.IsBinarySearchTree();
// bSTree.MinMaxValue();
// bSTree.TreeHeight();
// bSTree.CountNodes();
// bSTree.Delete(70);
// bSTree.Print("Level");
