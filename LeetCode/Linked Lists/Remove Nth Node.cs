
// Removing nth Node with one pass
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

static void Main(string[] args)
{
	ListNode head = null;
	head = addtostart(head, 5);
	head = AddToStart(head, 4);
	head = AddToStart(head, 3);
	head = AddToStart(head, 2);
	head = AddToStart(head, 1);
	Print(head);
	head = Delete(head, 2);
	Print(head);
}
private static ListNode Delete(ListNode head, int n)
{
	ListNode first = head;
	ListNode second = head;

	for (int i = 0; i < n; i++)
	{
		first = first.next;
	}

	if (first == null)
	{
		return head.next;
	}
	else
	{
		while (first.next != null)
		{
			first = first.next;
			second = second.next;
		}

		second.next = second.next.next;
	}

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