// 2.2 Return Kth to Last.
// Implement an algorithm to find the Kth to last element of a singly linked list.
public int GetKthValue(int k)
{
	if (head == null || k < 0) return -1;

	int kthValue = -1;
	Node current = head;

	Queue<int> q = new Queue<int>();

	for (int i = 0; i <= k; i++)
	{
		q.Enqueue(-1);
	}

	while (current != null)
	{
		q.Dequeue();
		q.Enqueue(current.Data);

		current = current.Next;
	}
	kthValue = q.Dequeue();

	return kthValue;
}


// Recursive implementation, I used a counter that goes through each node adding 1 on every return. Then when K == counter, I used a seperate class to store the kth value. 
public class KthValue
{
	public int Value { get; set; }
}

//// inside the link list class
public int GetKthValueRec(int k)
{
	if (k < 0)
	{
		return -1;
	}

	KthValue kth = new KthValue { Value = -1 };
	GetKthValueRec(head, 2, kth);
	return kth.Value;
}
private static int GetKthValueRec(Node node, int k, KthValue kth)
{

	if (node == null) return -1;

	int count = GetKthValueRec(node.Next, k, kth) + 1;

	if (count == k)
	{
		kth.Value = node.Data;
	}

	return count;
}
