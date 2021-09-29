using System;
using System.Collections.Generic;

namespace CSharpPractice
{

	internal class DNode
	{
		public int Data { get; set; }
		public DNode Next { get; set; }
		public DNode Prev { get; set; }

		public DNode(int data)
		{
			Data = data;
		}
	}

	public class DLinkList
	{
		private DNode head;

		public void AddToEnd(int data)
		{
			DNode newNode = new DNode(data);

			if (head == null)
			{
				head = newNode;
			}

			else
			{
				DNode current = head;
				while (current.Next != null)
				{
					current = current.Next;
				}
				current.Next = newNode;
				newNode.Prev = current;
			}
		}

		public void AddToStart(int data)
		{
			DNode newNode = new DNode(data);

			if (head == null)
			{
				head = newNode;
			}
			else
			{
				newNode.Next = head;
				head.Prev = newNode;
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
				DNode current = head;
				while (current != null)
				{
					System.Console.Write(current.Data + ", ");
					current = current.Next;
				}
			}
		}

		public void PrintInReverseFrom(int data)
		{
			if (head == null)
			{
				System.Console.WriteLine("List is empty!");
			}
			else if (head.Data == data)
			{
				Console.WriteLine("There are no nodes before [" + head.Data + "].");
			}
			else
			{
				DNode current = head;
				while (current != null)
				{
					if (current.Data == data)
					{
						while (current != head)
						{
							current = current.Prev;
							Console.Write("[" + current.Data + "]");
						}

						return;
					}

					current = current.Next;
				}
				Console.WriteLine("The number " + data + " could not be fount in the list");
			}
		}
	}
}


///////////////////////////////////// Main()

// DLinkList dList = new DLinkList();
// dList.AddToEnd(0);
// dList.AddToStart(6);
// dList.AddToEnd(7);
// dList.AddToStart(5);
// dList.AddToStart(4);
// dList.AddToEnd(8);
// dList.AddToStart(3);
// dList.AddToStart(2);
// dList.AddToEnd(9);
// dList.AddToStart(1);

// dList.PrintInOrder();
// System.Console.Write(" ... ");
// dList.PrintInReverseFrom(1);

