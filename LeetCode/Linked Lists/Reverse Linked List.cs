// Reversing linked list both iteratively and recursively
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

static void Main(string[] args)
{
	ListNode head = null;
	head = AddToStart(head, 5);
	head = AddToStart(head, 4);
	head = AddToStart(head, 3);
	head = AddToStart(head, 2);
	head = AddToStart(head, 1);
	Print(head);
	head = ReverseRecursively(head);
	Print(head);
}
private static ListNode ReverseRecursively(ListNode head)
{
	if (head == null) return null;
	ListNode current = head;
	Stack<int> st = new Stack<int>();
	while (current != null)
	{
		st.Push(current.val);
		current = current.next;
	}
	current = head;
	while (st.Count > 0)
	{
		current.val = st.Pop();
		current = current.next;
	}
	return head;
}
private static ListNode ReverseIteratively(ListNode head)
{
	if (head == null) return null;

	ListNode prev = null;
	ListNode current = head;
	ListNode next = head.next;

	while (next != null)
	{
		current.next = prev;
		prev = current;
		current = next;
		next = next.next;
	}
	current.next = prev;
	return current;
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