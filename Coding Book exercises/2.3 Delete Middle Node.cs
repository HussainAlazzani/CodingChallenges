// 2.3 Delete Middle Node.
// Implement an algorithm to delete a node in the middle (i.e., any node but the first
// and last node, not necessarily the exact middle) of a singly linked list,
// given only access to that node.
// EXAMPLE lnput:the node c from the linked lista->b->c->d->e->f
// Result: nothing is returned, but the new linked list looks like a->b->d->e->f


// Here I am assuing the node it lands on can also be the head node, therefore I must delete the next node.
// If I assume the I cannot land on the head node, I must therefore copy the data from the next node, and delete the next node.
public void DeleteMiddle()
{
	if (head == null || head.Next.Next == null) return;

	Node current = head;
	int count = 0;
	while (current.Next.Next != null)
	{
		if (count < 1)
		{
			current.Next = current.Next.Next;
			return;
		}
		current = current.Next;
	}
}