
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
    public bool HasCycle(ListNode head)
    {

        ListNode slowPointer = head;
        ListNode fastPointer = head;

        while (slowPointer != null && fastPointer != null)
        {
            slowPointer = slowPointer.next;

            if (slowPointer == null)
            {
                break;
            }

            fastPointer = fastPointer.next.next;

            if (slowPointer == fastPointer)
            {
                return true;
            }
        }

        return false;
    }
}