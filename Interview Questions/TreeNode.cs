using System;
using System.Collections.Generic;
using System.Linq;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        // static void Main(string[] args)
        // {
        //     TreeNode root1 = null;

        //     root1 = new TreeNode(1);
        //     root1.left = new TreeNode(3);
        //     root1.right = new TreeNode(2);
        //     root1.left.left = new TreeNode(5);

        //     TreeNode root2 = null;
        //     root2 = new TreeNode(2);
        //     root2.left = new TreeNode(1);
        //     root2.right = new TreeNode(3);
        //     root2.left.right = new TreeNode(4);
        //     root2.right.right = new TreeNode(7);

        //     Print(root1);
        //     System.Console.WriteLine();
        //     Print(root2);
        //     System.Console.WriteLine();

        //     TreeNode merged = MergeTrees(root1, root2);
        //     PrintBreadth(merged);

        //     System.Console.WriteLine();
        //     TreeNode newTree = CopyTree(root1, null);
        //     Print(newTree);

        // }
        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null) return list;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            bool direction = true;
            while (q.Any())
            {
                List<int> subList = new List<int>();
                int level = q.Count;

                for (int i = 0; i < level; i++)
                {
                    root = q.Dequeue();
                    subList.Add(root.val);

                    if (root.left != null)
                        q.Enqueue(root.left);
                    if (root.right != null)
                        q.Enqueue(root.right);
                }

                direction = !direction;
                if (direction)
                {
                    subList.Reverse();
                }

                list.Add(subList);

            }
            return list;
        }
        public static bool HasPathSum(TreeNode root, int sum)
        {
            return HasPathSum(root, sum, 0);
        }
        private static bool HasPathSum(TreeNode root, int sum, int count)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                count += root.val;
                if (count == sum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            count += root.val;

            bool left = HasPathSum(root.left, sum, count);
            bool right = HasPathSum(root.right, sum, count);
            return left || right;
        }
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return ArrayToBinaryTree(nums, null, 0, nums.Length - 1);
        }
        public static TreeNode ArrayToBinaryTree(int[] nums, TreeNode root, int first, int last)
        {
            if (first > last)
            {
                return null;
            }
            int mid = first + (last - first) / 2;
            root = AddNode(root, nums[mid]);
            root.left = ArrayToBinaryTree(nums, root.left, first, mid - 1);
            root.right = ArrayToBinaryTree(nums, root.right, mid + 1, last);
            return root;
        }

        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            return MergeTrees(t1, t2, null);
        }
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2, TreeNode merged)
        {
            if (t1 == null && t2 == null) return null;
            if (t1 == null)
            {
                return merged = CopyTree(t2, merged);
            }
            if (t2 == null)
            {
                return merged = CopyTree(t1, merged);
            }
            merged = new TreeNode(t1.val + t2.val);
            merged.left = MergeTrees(t1.left, t2.left, merged.left);
            merged.right = MergeTrees(t1.right, t2.right, merged.right);
            return merged;
        }
        public static TreeNode CopyTree(TreeNode original, TreeNode copy)
        {
            if (original == null)
            {
                return null;
            }
            copy = new TreeNode(original.val);
            copy.left = CopyTree(original.left, copy.left);
            copy.right = CopyTree(original.right, copy.right);
            return copy;
        }

        public static int MinDepthQ(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            int depth = 0;
            while (q.Any())
            {
                depth++;
                // Must store the size of the queue in a variable because the queue size
                // changes as we dequeue and enqueue it inside the for loop.
                int queueSize = q.Count;
                for (int i = 0; i < queueSize; i++)
                {
                    root = q.Dequeue();
                    if (root.left == null && root.right == null)
                    {
                        return depth;
                    }
                    if (root.left != null)
                    {
                        q.Enqueue(root.left);
                    }
                    if (root.right != null)
                    {
                        q.Enqueue(root.right);
                    }
                }
            }
            return depth;
        }

        public static int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            // If no left node, visit right node WITHOUT applying minimum comparison.
            if (root.left == null)
            {
                return MinDepth(root.right) + 1;
            }
            // If no right node, visit left node WITHOUT applying minimum comparison.
            if (root.right == null)
            {
                return MinDepth(root.left) + 1;
            }
            // Visit both node and compare their lengths, selecting minimum.
            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);
            return Math.Max(left, right) + 1;
        }
        public static TreeNode AddNode(TreeNode root, int val)
        {
            if (root == null)
            {
                TreeNode newNode = new TreeNode(val);
                return newNode;
            }
            if (val < root.val)
            {
                root.left = AddNode(root.left, val);
            }
            else
            {
                root.right = AddNode(root.right, val);
            }
            return root;
        }
        public static void Print(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            System.Console.Write(root.val + " => ");
            Print(root.left);

            Print(root.right);
        }
        public static void PrintBreadth(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Any())
            {
                root = q.Dequeue();
                System.Console.Write(root.val + " => ");
                if (root.left != null)
                {
                    q.Enqueue(root.left);
                }
                if (root.right != null)
                {
                    q.Enqueue(root.right);
                }
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}