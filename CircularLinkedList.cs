#pragma warning disable

using System.Drawing;

public class CircularLinkedList  // кольцевой связный список
{
    Node head; // головной/первый элемент
    Node tail; // последний/хвостовой элемент
    int count;  // количество элементов в списке
    public CircularLinkedList(int[] a) : this()
    {
        for (int i = 0; i < a.Length; i++)
            AddLast(a[i]);
    }
    public CircularLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }
    // добавление элемента
    public void AddLast(int data)
    {
        Node node = new Node(data);
        // если список пуст
        if (head == null)
        {
            head = node;
            tail = node;
            tail.Next = head;
        }
        else
        {
            node.Next = head;
            tail.Next = node;
            tail = node;
        }
        count++;
    }
    public void AddFirst(int data)
    {
        Node node = new(data);
        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.Next = head;
            head = node;
        }
        tail.Next = head;
        count++;
    }
    public void AddAfter(int exist, int new_item)
    {
        Node current = head;
        for (int i = 0; i < count; i++)
        {
            if (current.Data.Equals(exist))
            {
                Node node = new(new_item);
                node.Next = current.Next;
                current.Next = node;
                if (current == tail)
                    tail = node;
                count++;
                return;
            }
            current = current.Next;
        }
    }
    public void AddBefore(int exist, int new_item)
    {
        if (head.Data.Equals(exist))
        {
            AddFirst(new_item);
            return;
        }
        Node current = head.Next;
        Node previous = head;
        for (int i = 1; i < count; i++)
        {
            if (current.Data.Equals(exist))
            {
                Node node = new(new_item);
                node.Next = current;
                previous.Next = node;
                count++;
                return;
            }
            previous = current;
            current = current.Next;
        }
    }
    public void AddArrayAfter(int targetData, CircularLinkedList otherList, int startIndex)
    {
        Node currentNode = head;
        do
        {
            if (currentNode.Data.Equals(targetData))
            {
                Node firstNodeToInsert = otherList.GetNodeAtIndex(startIndex);

                if (firstNodeToInsert != null)
                {
                    Node lastNodeToInsert = otherList.tail;

                    lastNodeToInsert.Next = currentNode.Next;
                    currentNode.Next = firstNodeToInsert;

                    if (lastNodeToInsert.Next == head)
                    {
                        tail = lastNodeToInsert;
                    }
                    count += otherList.Count - startIndex;
                    return;
                }
            }
            currentNode = currentNode.Next;
        } while (currentNode != head);
    }
    private Node GetNodeAtIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            return null;
        }
        Node currentNode = head;
        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
    public bool Remove(int data)
    {
        Node current = head;
        Node previous = null;

        if (IsEmpty) return false;

        do
        {
            if (current.Data.Equals(data))
            {
                // Если узел в середине или в конце
                if (previous != null)
                {
                    // убираем узел current, теперь previous ссылается не на current, а на current.Next
                    previous.Next = current.Next;

                    // Если узел последний,
                    // изменяем переменную tail
                    if (current == tail)
                        tail = previous;
                }
                else // если удаляется первый элемент
                {

                    // если в списке всего один элемент
                    if (count == 1)
                    {
                        head = tail = null;
                    }
                    else
                    {
                        head = current.Next;
                        tail.Next = current.Next;
                    }
                }
                count--;
                return true;
            }

            previous = current;
            current = current.Next;
        } while (current != head);

        return false;
    }
    public Node Head { get { return head; } }
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
        Node current = head;
        if (current == null) return false;
        do
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        while (current != head);
        return false;
    }
    public int[] Array()
    {
        int[] array = new int[count];
        Node current = head;
        for (int i = 0; i < count; i++)
        {
            array[i] = current.Data;
            current = current.Next;
        }
        return array;
    }
    public override string ToString()
    {
        if (head == null)
        {
            return "";
        }
        Node currentNode = head;
        string result = "";
        do
        {
            result += currentNode.Data + "\n";
            currentNode = currentNode.Next;
        } while (currentNode != head);
        return result.TrimEnd();
    }
}
