using System;
using System.Collections.Generic;

namespace _60_Interview_Questions
{
    public partial class Program
    {
        public static ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode p = null;
            ListNode c = head;
            ListNode n = head.next;

            while (n != null)
            {
                c.next = p;
                p = c;
                c = n;
                n = n.next;
            }
            c.next = p;
            return c;
        }
        
        public static ListNode AddLinkList(ListNode listOne, ListNode listTwo)
        {
            if (listOne == null && listTwo == null)
            {
                return null;
            }
            if (listTwo == null)
            {
                return listOne;
            }
            if (listOne == null)
            {
                return listTwo;
            }

            ListNode dummyNode = new ListNode(0);
            ListNode headSum = dummyNode;
            ListNode currentSum = dummyNode;

            int sum = 0;
            int carryOver = 0;

            while (listOne != null && listTwo != null)
            {
                ListNode newNode = new ListNode(0);
                currentSum.next = newNode;
                currentSum = currentSum.next;
                sum = listOne.val + listTwo.val + carryOver;
                if (sum < 10)
                {
                    currentSum.val = sum;
                    carryOver = 0;
                }
                else
                {
                    currentSum.val = sum - 10;
                    carryOver = 1;

                }
                listOne = listOne.next;
                listTwo = listTwo.next;
            }
            System.Console.WriteLine(currentSum.val);
            currentSum.next = listOne??listTwo??currentSum.next;
            System.Console.WriteLine(currentSum.next.val);

            if (currentSum.next != null)
            {
                while (currentSum.next != null && carryOver > 0)
                {
                    sum = currentSum.val + carryOver;
                    if (sum < 10)
                    {
                        currentSum.val = sum;
                        carryOver = 0;
                    }
                    else
                    {
                        currentSum.val = sum - 10;
                        carryOver = 1;
                        currentSum = currentSum.next;
                    }
                }
                sum = currentSum.val + carryOver;
                if (sum < 10)
                {
                    currentSum.val = sum;
                    carryOver = 0;
                }
                else
                {
                    currentSum.val = sum - 10;
                    carryOver = 1;
                    ListNode newNode = new ListNode(carryOver);
                    currentSum.next = newNode;
                }
            }

            // if (listOne != null)
            // {
            //     currentSum.next = listOne;
            //     while (listOne.next != null && carryOver > 0)
            //     {
            //         sum = listOne.val + carryOver;
            //         if (sum < 10)
            //         {
            //             listOne.val = sum;
            //             carryOver = 0;
            //         }
            //         else
            //         {
            //             listOne.val = sum - 10;
            //             carryOver = 1;
            //             listOne = listOne.next;
            //         }
            //     }
            //     sum = listOne.val + carryOver;
            //     if (sum < 10)
            //     {
            //         listOne.val = sum;
            //         carryOver = 0;
            //     }
            //     else
            //     {
            //         listOne.val = sum - 10;
            //         carryOver = 1;
            //         ListNode newNode = new ListNode(carryOver);
            //         listOne.next = newNode;
            //     }
            // }
            // else if (listTwo != null)
            // {
            //     currentSum.next = listTwo;
            //     while (listTwo.next != null && carryOver > 0)
            //     {
            //         sum = listTwo.val + carryOver;
            //         if (sum < 10)
            //         {
            //             listTwo.val = sum;
            //             carryOver = 0;
            //         }
            //         else
            //         {
            //             listTwo.val = sum - 10;
            //             carryOver = 1;
            //             listTwo = listTwo.next;
            //         }
            //     }
            //     sum = listTwo.val + carryOver;
            //     if (sum < 10)
            //     {
            //         listTwo.val = sum;
            //         carryOver = 0;
            //     }
            //     else
            //     {
            //         listTwo.val = sum - 10;
            //         carryOver = 1;
            //         ListNode newNode = new ListNode(carryOver);
            //         listTwo.next = newNode;
            //     }
            // }
            else if (carryOver > 0)
            {
                ListNode newNode = new ListNode(carryOver);
                currentSum.next = newNode;
            }
            return headSum.next;
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode current = head;
            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;
            head = dummyNode;
            ListNode prev = dummyNode;

            while (current.next != null)
            {
                if (current.val == current.next.val)
                {
                    while (current.next != null && current.val == current.next.val)
                    {
                        current = current.next;
                    }
                    if (current.next != null)
                    {
                        current = current.next;
                        prev.next = current;
                    }
                    else
                    {
                        prev.next = null;
                    }
                }
                else
                {
                    prev = prev.next;
                    current = current.next;
                }
            }
            // remove dummy
            head = head.next;

            return head;
        }
        public static ListNode RemoveDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode current = head;
            while (current.next != null && current.next.next != null)
            {
                if (current.val == current.next.val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            if (current.val == current.next.val)
            {
                current.next = null;
            }
            return head;
        }
        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null && slow.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    return true;
                }
            }
            return false;
        }
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == head)
            {
                return head;
            }
            var nodesVisited = new List<ListNode>();
            ListNode current = head;
            while (current.next != null)
            {
                if (nodesVisited.Contains(current))
                {
                    return current;
                }
                nodesVisited.Add(current);
                current = current.next;
            }
            return null;
        }
        public static bool HasCycleMemo(ListNode head, ref int pos)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            var nodesVisited = new List<ListNode>();
            ListNode current = head;
            int count = 0;
            while (current.next != null)
            {
                if (nodesVisited.Contains(current))
                {
                    pos = nodesVisited.IndexOf(current);
                    return true;
                }
                nodesVisited.Add(current);
                current = current.next;
                count++;
            }
            return false;
        }

        public static ListNode LoopLinkList(ListNode head, int pos)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode current = head;
            ListNode nodeLink = null;
            int count = 0;
            while (current.next != null)
            {
                if (count == pos)
                {
                    nodeLink = current;
                }
                current = current.next;
                count++;
            }

            current.next = nodeLink;

            return head;
        }

        public static ListNode AddToTail(ListNode head, int val)
        {
            ListNode newNode = new ListNode(val);
            if (head == null)
            {
                return newNode;
            }
            ListNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
            return head;
        }
        public static ListNode AddToStart(ListNode head, int val)
        {
            ListNode newNode = new ListNode(val);
            if (head == null)
            {
                return newNode;
            }
            newNode.next = head;
            head = newNode;

            return head;
        }
        public static void Print(ListNode head)
        {
            if (head == null)
            {
                System.Console.WriteLine("No nodes");
                return;
            }
            int count = 0;
            while (head != null && count < 20)
            {
                System.Console.Write(head.val + " => ");
                head = head.next;
                count++;
            }
            System.Console.WriteLine();
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {
            this.val = val;
            next = null;
        }
    }
}