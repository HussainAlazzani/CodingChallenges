using System;
using System.Collections.Generic;

namespace CSharpPractice
{

	internal class CNode
	{
		public int Data { get; set; }
		public CNode Next { get; set; }

		public CNode(int data)
		{
			Data = data;
		}
	}

	public class CList
	{
		private CNode head;

		public void AddToEnd(int data)
		{
			CNode newNode = new CNode(data);

			if (head == null)
			{
				head = newNode;
				newNode.Next = head;
			}
			else if (head.Next == head)
			{
				head.Next = newNode;
				newNode.Next = head;
			}
			else
			{
				CNode current = head;

				while (current.Next != head)
				{
					current = current.Next;
				}
				current.Next = newNode;
				newNode.Next = head;

			}
		}

		public void AddToStart(int data)
		{
			CNode newNode = new CNode(data);

			if (head == null)
			{
				head = newNode;
				newNode.Next = head;
			}
			else if(head.Next == head)
			{
				newNode.Next = head;
				head.Next = newNode;
				head = newNode;
			}
			else
			{
				CNode current = head;

				while (current.Next != head)
				{
					current = current.Next;
				}
				newNode.Next = head;
				current.Next = newNode;
				head = newNode;
			}
		}

		public void PrintOrdered()
		{
			if (head == null)
			{
				Console.WriteLine("List is empty");
			}
			else
			{
				CNode current = head;
				do
				{
					Console.Write("[" + current.Data + "] ");
					current = current.Next;

				} while (current != head);

			}
		}

	}
}


///////////////////////////// Main()
// CList cList = new CList();

// cList.AddToStart(4);
// cList.AddToEnd(7);
// cList.AddToStart(3);
// cList.AddToEnd(8);
// cList.AddToStart(2);
// cList.AddToEnd(9);
// cList.AddToStart(1);

// cList.PrintOrdered();

