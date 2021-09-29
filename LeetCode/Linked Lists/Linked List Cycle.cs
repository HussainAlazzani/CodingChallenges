public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

static void Main(string[] args)
{
	ListNode l1 = null;
	l1 = AddToStart(l1, 4);
	// l1 = AddToStart(l1, 3);
	// l1 = AddToStart(l1, 2);
	// l1 = AddToStart(l1, 1);
	// l1 = AddToStart(l1, 2);
	// l1 = AddToStart(l1, 3);
	// l1 = AddToStart(l1, 4);

	Print(l1);
	l1 = Cycle(l1, 0);
	System.Console.WriteLine(HasCycle(l1));

}
// This creates a cycle.
private static ListNode Cycle(ListNode head, int pos)
{
	ListNode current = head;
	ListNode node = head;
	while (current.next != null)
	{
		System.Console.Write(current.val + " -> ");
		current = current.next;
	}
	for (int i = 0; i < pos; i++)
	{
		node = node.next;
	}
	current.next = node;
	System.Console.WriteLine(node.val);

	return head;
}
// This determines whether a cycle exists.
// Inefficient because it has to store all the addresses. Space complexity O(n)
private static bool HasCycle(ListNode head)
{
	if (head == null) return false;

	ListNode current = head;
	List<ListNode> list = new List<ListNode>();

	while (current != null)
	{
		list.Add(current);
		current = current.next;

		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == current)
			{
				return true;
			}
		}
	}

	return false;

}
// This determines whether a cycle exists.
// Very efficient because it doesn't store anything. It keeps looping until slow matches fast implying a cycle. Space complexity O(1)
private static bool HasCycle(ListNode head)
{
	if (head == null) return false;

	ListNode fast = head;
	ListNode slow = head;

	while (fast != null && fast.next != null)
	{
		slow = slow.next;
		fast = fast.next.next;
		if (fast == slow)
		{
			return true;
		}
	}

	return false;

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


////////////

var slow= head;
var fast=head;
while(fast !=null && fast.next != null){
  slow = slow.next; 
  fast = fast.next.next; 
  if(fast==slow){
	return true; 
  }
}
return false;

