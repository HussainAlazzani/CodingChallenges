// 2.4 Partition.
// Write code to partition a linked list around a value x, such that all nodes less than x
// come before all nodes greater than or equal to x. If x is contained within the list,
// the values of x only need to be after the elements less than x (see below).
// The partition element x can appear anywhere in the "right partition";
// it does not need to appear between the left and right partitions.
// EXAMPLE
// Input: 3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5]
// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8

public void Partition(int val)
{
	if (head == null) return;

	Node headPartition1 = null;
	Node headPartition2 = null;

	Node current = head;
	while (current.Next != null)
	{
		if (current.Data < val)
		{
			headPartition1 = AddToTail(headPartition1, current.Data);
		}
		else
		{
			headPartition2 = AddToTail(headPartition2, current.Data);
		}

		current = current.Next;
	}
	if (current.Data < val)
	{
		headPartition1 = AddToTail(headPartition1, current.Data);
	}
	else
	{
		headPartition2 = AddToTail(headPartition2, current.Data);
	}

	Print(headPartition1);
	Print(headPartition2);

	Node currentPartition = headPartition1;
	while (currentPartition.Next!= null)
	{
		currentPartition = currentPartition.Next;
	}
	currentPartition.Next = headPartition2;
	Print(headPartition1);
}

private static void Print(Node head)
{
	if (head == null)
	{
		Console.WriteLine("No nodes");
		return;
	}

	Node current = head; // Pointing to the start of the list

	while (current != null)
	{
		Console.Write("[" + current.Data + "]->");
		current = current.Next;
	}
	Console.WriteLine(" Null");
}

private static Node AddToTail(Node head, int data)
{
	Node newNode = new Node(data);

	if (head == null)
	{
		head = newNode;
	}
	else
	{
		Node current = head;
		while (current.Next != null)
		{
			current = current.Next;
		}
		current.Next = newNode;
	}
	return head;
}
