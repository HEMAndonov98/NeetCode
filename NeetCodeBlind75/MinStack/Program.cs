var myStack = new MinStack();

myStack.Push(2147483646);
myStack.Push(2147483646);
myStack.Push(2147483647);


Console.WriteLine(myStack.GetMin());
myStack.Pop();
Console.WriteLine(myStack.GetMin());
myStack.Pop();
Console.WriteLine(myStack.GetMin());
myStack.Pop();
myStack.Push(2147483647);
Console.WriteLine(myStack.GetMin());

public class MinStack {

    private class Node{

        public Node() 
        {
        }

        public Node(int element, Node next){
            this.Element = element;
            this.Next = next;
        }

        public int Element { get; set; }

        public int NodeMinElement { get; set; }
        public Node Next { get; set; }
        
    }

    private Node top;
    private int count;
    private int minElement;

    public MinStack() {
        
    }
    
    public void Push(int val) {
        if(this.count == 0)
        {
            this.top = new Node(val, null);
            this.minElement = int.MaxValue;
        }
        else
        {
            var oldTop = this.top;
            this.top = new Node(val, oldTop);
        }


        if (val < this.minElement)
        {
            this.minElement = val;
            this.top.NodeMinElement = val;
        }
        else
        {
            this.top.NodeMinElement = this.minElement;
        }

        this.count++;
    }
    
    public void Pop()
    {
        this.top = this.top.Next;
        if (top != null)
        {
            this.minElement = this.top.NodeMinElement;
        }
        this.count--;
    }
    
    public int Top()
    {
        return this.top.Element;
    }
    
    public int GetMin()
    {
        return this.minElement;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */