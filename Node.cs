#pragma warning disable
public class Node
{
    public Node(int data)
    {
        Data = data;
    }
    public int Data { get; set; }
    public Node Next { get; set; }
}
