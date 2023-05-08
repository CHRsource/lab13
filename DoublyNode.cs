#pragma warning disable
public class DoublyNode
{
    public DoublyNode(int data)
    {
        Data = data;
    }
    public int Data { get; set; }
    public DoublyNode Previous { get; set; }
    public DoublyNode Next { get; set; }
}
