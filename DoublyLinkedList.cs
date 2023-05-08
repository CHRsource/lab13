#pragma warning disable
public class DoublyLinkedList // двусвязный список
{
    DoublyNode head; // головной/первый элемент
    DoublyNode tail; // последний/хвостовой элемент
    int count;  // количество элементов в списке
    public int HeadData { get { return head.Data; } }
    public int TailData { get { return tail.Data; } }
    public DoublyNode Head { get { return head; } }
    public DoublyNode Tail { get { return tail; } }

    // добавление элемента
    public void Add(int data)
    {
        DoublyNode node = new DoublyNode(data);

        if (head == null)
            head = node;
        else
        {
            tail.Next = node;
            node.Previous = tail;
        }
        tail = node;
        count++;
    }
    public void AddFirst(int data)
    {
        DoublyNode node = new DoublyNode(data);
        DoublyNode temp = head;
        node.Next = temp;
        head = node;
        if (count == 0)
            tail = head;
        else
            temp.Previous = node;
        count++;
    }
    // удаление
    public bool Remove(int data)
    {
        DoublyNode current = head;

        // поиск удаляемого узла
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                break;
            }
            current = current.Next;
        }
        if (current != null)
        {
            // если узел не последний
            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                // если последний, переустанавливаем tail
                tail = current.Previous;
            }

            // если узел не первый
            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                // если первый, переустанавливаем head
                head = current.Next;
            }
            count--;
            return true;
        }
        return false;
    }

    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public bool Contains(int data)
    {
        DoublyNode current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }
    public override string ToString()
    {
        DoublyNode current = head;
        string s = "";
        if (current == null) return "empty";
        s += current.Data;
        current = current.Next;
        while (current != null)
        {
            s = s + " " + current.Data;
            current = current.Next;
        }
        return s;
    }
}