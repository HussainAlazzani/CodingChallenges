// Merging two sorted linked lists.
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

static void Main(string[] args)
{
	ListNode l1 = null;
	ListNode l2 = null;
	ListNode merged = null;
	l1 = AddToStart(l1, 4);
	l1 = AddToStart(l1, 2);
	l1 = AddToStart(l1, 1);
	l2 = AddToStart(l2, 8);
	l2 = AddToStart(l2, 6);
	l2 = AddToStart(l2, 4);
	l2 = AddToStart(l2, 3);
	l2 = AddToStart(l2, 2);
	l2 = AddToStart(l2, 1);
	l2 = AddToStart(l2, 0);
	Print(l1);
	Print(l2);
	merged = Merge(l1, l2);
	Print(merged);
}
private static ListNode Merge(ListNode l1, ListNode l2)
{
	if (l1 == null && l2 == null) return null;
	if (l1 == null && l2 != null) return l2;
	if (l1 != null && l2 == null) return l1;

	ListNode head;
	if (l1.val <= l2.val)
	{
		head = l1;
		l1 = l1.next;
	}
	else
	{
		head = l2;
		l2 = l2.next;
	}

	ListNode current = head;

	while (l1 != null && l2 != null)
	{
		if (l1.val <= l2.val)
		{
			current.next = l1;
			l1 = l1.next;
		}
		else
		{
			current.next = l2;
			l2 = l2.next;
		}
		current = current.next;
	}

	if (l1 == null) current.next = l2;
	if (l2 == null) current.next = l1;

	return head;
}
private static ListNode AddToStart(ListNode head, int val)
{
	ListNode newNode = new ListNode(val);
	if (head == null) head = newNode;
	else
	{
		newNode.next = head;
		head = newNode;
	}

	return head;
}
private static void Print(ListNode head)
{
	if (head == null)
	{
		System.Console.WriteLine("No nodes");
	}
	else
	{
		while (head != null)
		{
			System.Console.Write(head.val + " => ");
			head = head.next;
		}
		System.Console.WriteLine();
	}
}