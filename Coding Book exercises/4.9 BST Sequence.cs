// 4.9 BST Sequences:
// A binary search tree was created by traversing through an array from left to right
// and inserting each element. Given a binary search tree with distinct elements,
// print all possible arrays that could have led to this tree.

// Example.
// Input:
// 		  2
// 		 / \
// 		1   3
// Output: {2, 1, 3}, {2, 3, 1}

     4
   /   \
  2     6
 / \   / \
1   3 5   7

4, 2, 6
4, 6, 2

4, 2, 1, 3, 6, 5, 7
4, 2, 1, 3, 6, 7, 5
4, 2, 3, 1, 6, 5, 7
4, 2, 3, 1, 6, 7, 5

4, 6, 5, 7, 2, 1, 3
4, 6, 5, 7, 2, 3, 1
4, 6, 7, 5, 2, 1, 3
4, 6, 7, 5, 2, 3, 1

4, 2, 6, 1, 3, 5, 7
4, 2, 6, 1, 3, 7, 5

4, 2, 6, 3, 1, 5, 7
4, 2, 6, 3, 1, 7, 5

4, 6, 2, 1, 3, 5, 7
4, 6, 2, 3, 1, 7, 5

4, 6, 2, 3, 1
4, 6, 2, 1, 3




root
left
right

root
right
left

public void BSTSequence()
{
	List<List<int>> squences = new  List<List<int>>();
	squences = BSTSequence(BNode root);
	
	foreach(var sequence in squences)
	{
		foreach(var item in squence)
		{
			Console.Write(item + "");
		}
		Console.WriteLine();
	}
}

private static List<List<int>> BSTSequence(BNode root, List<List<int>> sequences)
{
	List<List<int>> sequences = new List<List<int>>();
	
	List<int> sequence = new List<int>();
	sequences.Add(PreOrderLeft(root, sequence));
	
	sequences.Add(PreOrderRight(root, sequence));
	
	return sequences;
}

private static List<int> sequence PreOrderLeft(BNode root, List<int> sequence)
{
	if(root == null) return;
	
	sequence.Add(root.Data);
	sequence = PreOrderLeft(root.Left, sequence);
	sequence = PreOrderLeft(root.Right, sequence);
	
	return sequence;
}

private static List<int> sequence PreOrderRight(BNode root, List<int> sequence)
{
	if(root == null) return;
	
	sequence.Add(root.Data);
	sequence = PreOrderLeft(root.Right, sequence);
	sequence = PreOrderLeft(root.Left, sequence);
	
	return sequence;
}


