public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public void ReorderList(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            // second half start
            slow = slow.next;
            // check if end of list is reached
            fast = fast.next.next;
        }

        // Reverse second half of list
        ListNode? curr = slow.next;
        ListNode? prev = slow.next = null;

        while (curr != null)
        {
            ListNode? next = curr.next;
            curr.next = prev;
            prev = curr;

            curr = next;
        }

        ListNode? first = head;
        ListNode? second = prev;
        while (second != null)
        {
            // save references to original list
            ListNode? temp1 = first.next;
            ListNode? temp2 = second.next;

            // break links(reorder)
            first.next = second;
            second.next = temp1;
            // move to next node
            first = temp1;
            second = temp2;
        }

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create the linked list 2 -> 4 -> 6 -> 8
        ListNode head = new ListNode(2, new ListNode(4, new ListNode(6, new ListNode(8))));

        // Print the original list
        Console.WriteLine("Original List:");
        PrintList(head);

        // Reorder the list
        Solution solution = new Solution();
        solution.ReorderList(head);

        // Print the reordered list
        Console.WriteLine("Reordered List:");
        PrintList(head);
    }

    public static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
            {
                Console.Write(" -> ");
            }
            current = current.next;
        }
        Console.WriteLine();
    }
}