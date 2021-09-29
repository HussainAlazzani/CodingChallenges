using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPractice
{
class Program
{
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
	l1 = AddToStart(l1, 3);
	l1 = AddToStart(l1, 2);
	l1 = AddToStart(l1, 1);
	l1 = AddToStart(l1, 2);
	l1 = AddToStart(l1, 3);
	l1 = AddToStart(l1, 4);

	Print(l1);
	System.Console.WriteLine(IsPalindrome(l1));

}
private static bool IsPalindrome(ListNode head)
{
	if (head == null) return true;

	ListNode fast = head;
	ListNode slow = head;
	Stack<int> stack = new Stack<int>();
	while (fast != null && fast.next != null)
	{
		stack.Push(slow.val);
		fast = fast.next.next;
		slow = slow.next;
	}

	// If list is odd
	if (fast != null)
	{
		slow = slow.next;
	}
	
	while (slow != null)
	{
		if (slow.val != stack.Pop())
		{
			return false;
		}
		
		slow = slow.next;
	}

	return true;

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
}
}