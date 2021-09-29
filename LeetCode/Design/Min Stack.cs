class Program
{
	static void Main(string[] args)
	{
		MinStack minStack = new MinStack();
		minStack.Push(-2);
		minStack.Print();
		minStack.Push(0);
		minStack.Print();
		minStack.Push(-3);
		minStack.Print();
		System.Console.WriteLine(minStack.GetMin());

		// Returns - 3.
		minStack.Pop();
		minStack.Print();

		System.Console.WriteLine(minStack.Top());

		// Returns 0.
		System.Console.WriteLine(minStack.GetMin());
		minStack.Print();
	}
}
public class Node
{
	public int val { get; set; }
	public Node next { get; set; }
	public Node(int val)
	{
		this.val = val;
	}
}
public class MinStack
{
	private Node head;
	/** initialize your data structure here. */
	public MinStack()
	{
		head = null;
	}

	public void Push(int x)
	{
		if (head == null)
		{
			head = new Node(x);
		}
		else
		{
			Node newNode = new Node(x);
			newNode.next = head;
			head = newNode;
		}
	}

	public void Pop()
	{
		if (head == null)
		{
			return;
		}
		else
		{
			head = head.next;
		}
	}

	public int Top()
	{
		if (head == null)
		{
			return int.MinValue;
		}
		else
		{
			return head.val;
		}
	}

	public int GetMin()
	{
		if (head == null)
		{
			return int.MinValue;
		}
		else
		{
			Node current = head;
			int min = current.val;
			while (current != null)
			{
				if (min > current.val)
				{
					min = current.val;
				}
				current = current.next;
			}
			return min;
		}
	}
	public void Print()
	{
		if (head == null)
		{
			System.Console.WriteLine("Empty stack");
		}
		else
		{
			Node current = head;
			while (current != null)
			{
				System.Console.Write(current.val + " => ");
				current = current.next;
			}
			System.Console.WriteLine();
		}
	}
}