using System;
using System.Collections.Generic;

namespace CSharpPractice
{

	internal class Node
	{
		public int Data { get; set; }
		public Node Next { get; set; }

		public Node(int data)
		{
			Data = data;
		}
	}

	public class LinkList
	{
		private Node head;

		public void Find(int data)
		{
			if (head == null)
			{
				Console.WriteLine("List is empty");
			}
			else
			{
				Node current = head;
				while (current != null)
				{
					if (current.Data == data)
					{
						Console.WriteLine("Node value [" + current.Data + "] is in the list.");
						return;
					}
					current = current.Next;
				}
				System.Console.WriteLine("Node value is not in the list");
			}
		}

		public void AddToEnd(int data)
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
		}

		public void AddToStart(int data)
		{
			Node newNode = new Node(data);

			if (head == null)
			{
				head = newNode;
			}
			else
			{
				newNode.Next = head;
				head = newNode;
			}
		}

		public void PrintInOrder()
		{
			if (head == null)
			{
				System.Console.WriteLine("List is empty!");
			}
			else
			{
				Node current = head;
				while (current != null)
				{
					System.Console.Write(current.Data + ", ");
					current = current.Next;
				}
			}
		}

		public void PrintInReverse()
		{
			if (head == null)
			{
				System.Console.WriteLine("List is empty!");
			}
			else
			{
				Node current = head;
				Stack<int> s = new Stack<int>();

				while (current != null)
				{
					s.Push(current.Data);
					current = current.Next;
				}
				while (s.Count > 0)
				{
					System.Console.Write(s.Pop() + ", ");
				}
			}
		}

		public void PrintRecursion()
		{
			if (head == null)
			{
				System.Console.WriteLine("List is empty");
			}
			else
			{
				Node current = head;
				PrintRecursion(current);
			}
		}

		private void PrintRecursion(Node current)
		{
			if (current == null) return;

			System.Console.Write("[" + current.Data + "] ");
			PrintRecursion(current.Next);
		}

		public void PrintRevRecursion()
		{
			if (head == null)
			{
				System.Console.WriteLine("List is empty");
			}
			else
			{
				Node current = head;
				PrintRevRecursion(current);
			}
		}

		private void PrintRevRecursion(Node current)
		{
			if (current == null) return;

			PrintRevRecursion(current.Next);
			System.Console.Write("[" + current.Data + "] ");
		}

		public void DeleteNode(int data)
		{
			// If list is empty.
			if (head == null)
			{
				Console.WriteLine("List is empty");
				return;
			}
			// If the first node is the node to be deleted.
			else if (head.Data == data)
			{
				head = head.Next;
			}
			else
			{
				Node current = head;

				while (current.Next != null)
				{
					if (current.Next.Data == data)
					{
						current.Next = current.Next.Next;
						return;
					}
					current = current.Next;
				}
			}
		}
	}
}

////////////////////////// Main()
// LinkList lList = new LinkList();
// lList.AddToEnd(0);
// lList.AddToStart(6);
// lList.AddToEnd(7);
// lList.AddToStart(5);
// lList.AddToStart(4);
// lList.AddToEnd(8);
// lList.AddToStart(3);
// lList.AddToStart(2);
// lList.AddToEnd(9);
// lList.AddToStart(1);

// lList.PrintInOrder();
// System.Console.Write(" ... ");
// lList.PrintInReverse();
// System.Console.WriteLine();
// lList.PrintRecursion();
// System.Console.Write(" ... ");
// lList.PrintRevRecursion();
// System.Console.WriteLine();
// lList.DeleteNode(0);
// lList.PrintRecursion();
// System.Console.WriteLine();
// lList.Find(9);
// System.Console.WriteLine();



// This implements a generic version of the link list class.
internal class Node<T>
{
	public T Data { get; set; }
	public Node<T> Next { get; set; }

	public Node(T data)
	{
		Data = data;
	}
}

public class LinkList<T>
{
	private Node<T> head;

	public void Find(T data)
	{
		if (head == null)
		{
			Console.WriteLine("List is empty");
		}
		else
		{
			Node<T> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					Console.WriteLine("Node value [" + current.Data + "] is in the list.");
					return;
				}
				current = current.Next;
			}
			System.Console.WriteLine("Node value is not in the list");
		}
	}

	public void AddToEnd(T data)
	{
		Node<T> newNode = new Node<T>(data);

		if (head == null)
		{
			head = newNode;
		}
		else
		{
			Node<T> current = head;
			while (current.Next != null)
			{
				current = current.Next;
			}
			current.Next = newNode;
		}
	}

	public void AddToStart(T data)
	{
		Node<T> newNode = new Node<T>(data);

		if (head == null)
		{
			head = newNode;
		}
		else
		{
			newNode.Next = head;
			head = newNode;
		}
	}

	public void PrintInOrder()
	{
		if (head == null)
		{
			System.Console.WriteLine("List is empty!");
		}
		else
		{
			Node<T> current = head;
			while (current != null)
			{
				System.Console.Write(current.Data + ", ");
				current = current.Next;
			}
		}
	}

}