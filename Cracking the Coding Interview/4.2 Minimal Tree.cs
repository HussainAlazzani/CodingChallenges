// 4.2 Minimal Tree:
// Given a sorted (increasing order) array with unique integer elements,
// write an algorithm to create a binary search tree with minimal height.

public static BTNode CreateMinimalBST(int[] a)
{
	BTNode root = CreateMinimalBST(a, 0, a.Length-1);
	return root;
}
private static BTNode CreateMinimalBST(int[] a, int start, int last)
{
	if(start<last) return null;
	
	int midIndex = (last - start)/2;
	
	BTNode newNode = new BTNode{Data = a[midIndex]};
	
	newNode.Left = CreateMinimalBST(a, start, midIndex-1);
	newNode.Right = CreateMinimalBST(a, midIndex+1, last);
	
	return newNode;
}