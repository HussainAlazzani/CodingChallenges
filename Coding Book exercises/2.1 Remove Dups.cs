// 2.1 Remove Dups
// Write code to remove duplicates from an unsorted linked list.
// Follow up: How would you solve the problem if a temporary buffer is not allowed?

// Without buffer, we can use two current pointers, one pointing at the node in question, while the other iterates thru all nodes checking for duplicated and deleting.

// Time complexity O(n), Space complexity O(n)
public void RemoveDuplicates()
{
	if (head == null) return;

	Node current = head;
	HashSet<int> nonDuplicates = new HashSet<int>();
	nonDuplicates.Add(current.Data);

	while (current.Next != null)
	{
		if (nonDuplicates.Contains(current.Next.Data))
		{
			current.Next = current.Next.Next;
		}
		else
		{
			nonDuplicates.Add(current.Next.Data);
			current = current.Next;
		}
	}
}

public static Node RemoveDuplicates(Node head)
{
	if (head == null) return head;

	Node current = head;
	HashSet<int> nonDuplicates = new HashSet<int>();
	nonDuplicates.Add(current.Data);

	while (current.Next != null)
	{
		if (nonDuplicates.Contains(current.Next.Data))
		{
			current.Next = current.Next.Next;
		}
		else
		{
			nonDuplicates.Add(current.Next.Data);
			current = current.Next;
		}
	}
	return head;
}