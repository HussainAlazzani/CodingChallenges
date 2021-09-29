// 2.6 Palindrome.
// Implement a function to check if a linked list is a palindrome.

// Here I copy link list onto a stack and then iterate again through the list and compare with the stack. time complexity O(2n) because looping twice.
// The other solution is optimised version of this.
public bool IsPalindrome()
{
	if (head == null) return false;

	Stack<int> s = new Stack<int>();
	Node current = head;

	while (current != null)
	{
		s.Push(current.Data);
		current = current.Next;
	}

	current = head;
	while (current != null)
	{
		if (current.Data != s.Pop())
		{
			return false;
		}
		current = current.Next;
	}
	return true;
}

// This approach is optimized for efficiency. Instead of looping through the whole list twice, we simply loop half way, then compare the first half with second half.
// This is done by having a fast and slow pointer, and making use of the stack. The fast pointer helps us mark the centre of the list.
public bool IsPalindrome()
{
	if (head == null) return false;
	Node fast = head;
	Node slow = head;

	Stack<int> s = new Stack<int>();

	while (fast != null && fast.Next != null)
	{
		s.Push(slow.Data);
		slow = slow.Next;
		fast = fast.Next.Next;
	}

	// If list has odd number of nodes. then skip the middle node.
	// If odd then the fast pointer will be null because the previously we set it to fast.Next.Next before exiting the while loop.
	if (fast != null)
	{
		slow = slow.Next;
	}

	while (slow != null)
	{
		if (slow.Data != s.Pop())
		{
			return false;
		}
		slow = slow.Next;
	}
	return true;
}