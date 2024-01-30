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
// Iterative approach with pointers
public class Solution {
    public ListNode ReverseList(ListNode head)
    {
        //This will be used to traverse the list
        ListNode current = head;
        //this will defacto represent the new current value
        ListNode previous = null;
        //temporary value for saving the link in the list
        ListNode next;

        while (current != null)
        {
            //We save the link to the next node in the list
            next = current.next;

            //We reverse the direction of our list
            current.next = previous;
            //we save our new list to this variable
            previous = current;
            //we continue forward with our temporary saved variable
            current = next;
        }

        head = previous;

        return head;
    }
}