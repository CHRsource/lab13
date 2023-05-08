#pragma warning disable
// I. Двусвязные списки

// задание 1
//DoublyLinkedList linkedlist = new();
//Console.WriteLine("Вводите целые числа:");
//while (true)
//{
//    string s = Console.ReadLine();
//    if (s == "") break;
//    if (linkedlist.Count < 2)
//        linkedlist.Add(int.Parse(s));
//    else if (Math.Abs(int.Parse(s) - linkedlist.HeadData) < Math.Abs(int.Parse(s) - linkedlist.TailData))
//        linkedlist.AddFirst(int.Parse(s));
//    else linkedlist.Add(int.Parse(s));
//}
//Console.WriteLine("Размер: " + linkedlist.Count);
//Console.WriteLine("Список: " + linkedlist.ToString());


// задание 2

//string path = @"..\..\..\data13.txt";
//File.WriteAllText(path, "4 -4 84 0 -43 -24 -9 95 71 -24 74 -43 32 78\n");
//string[] text = File.ReadAllLines(path)[0].Split();

//DoublyLinkedList positives = new();
//DoublyLinkedList negatives = new();
//foreach (string str in text)
//{
//    int num = int.Parse(str);
//    if (num >= 0) positives.Add(num);
//    else negatives.Add(num);
//}

//// а)
//DoublyLinkedList new1 = new();
//DoublyNode current = positives.Head;
//int count = 0;
//while (current != null)
//{
//    if (count == positives.Count / 2)
//    {
//        DoublyNode neg_ = negatives.Head;
//        for (int i = 0; i < negatives.Count; i++)
//        {
//            new1.Add(neg_.Data);
//            neg_ = neg_.Next;
//        }
//        count++;
//    }
//    else
//    {
//        new1.Add(current.Data);
//        current = current.Next;
//        count++;
//    }
//}
//Console.WriteLine("Пункт а): " + new1);

//// б)
//DoublyLinkedList new2 = new();
//DoublyNode pos = positives.Head;
//DoublyNode neg = negatives.Head;
//int min;
//for (int i = 0; i < (min = Math.Min(positives.Count, negatives.Count)); i++)
//{
//    new2.Add(pos.Data);
//    pos = pos.Next;
//    new2.Add(neg.Data);
//    neg = neg.Next;
//}
//if (positives.Count != negatives.Count)
//{
//    if (positives.Count == min)
//    {
//        for (int i = 0; i < negatives.Count - min; i++)
//        {
//            new2.Add(neg.Data);
//            neg = neg.Next;
//        }
//    }
//    else
//    {
//        for (int i = 0; i < positives.Count - min; i++)
//        {
//            new2.Add(pos.Data);
//            pos = pos.Next;
//        }
//    }
//}
//Console.WriteLine("Пункт б): " + new2);


// задание 3

//LinkedList<int> linkedlist = new();
//Console.WriteLine("Вводите целые числа:");
//while (true)
//{
//    string s = Console.ReadLine();
//    if (s == "") break;
//    if (linkedlist.Count < 2)
//        linkedlist.AddLast(int.Parse(s));
//    else if (Math.Abs(int.Parse(s) - linkedlist.First.Value) < Math.Abs(int.Parse(s) - linkedlist.Last.Value))
//        linkedlist.AddFirst(int.Parse(s));
//    else linkedlist.AddLast(int.Parse(s));
//}
//Console.WriteLine("Размер: " + linkedlist.Count);
//Console.Write("Список: ");
//for (int i = 0; i < linkedlist.Count; i++)
//    Console.Write(linkedlist.ElementAt<int>(i) + " ");
//Console.WriteLine();


// II. Циклические(кольцевые) списки

// задание 1

Console.Write("Введите количество чисел в списке: ");
int n = int.Parse(Console.ReadLine());

Console.WriteLine("Введите список:");
int[] nums = new int[n];
for (int i = 0; i < n; i++)
    nums[i] = int.Parse(Console.ReadLine());
CircularLinkedList list = new(nums);
Node current = list.Head;

Console.Write("Введите количество команд: ");
int k = int.Parse(Console.ReadLine());

Console.WriteLine("Введите команды:");
for (int i = 0; i < k; i++)
{
    string[] command = Console.ReadLine().Split(' ');
    if (command[0] == "R")
    {
        int count = int.Parse(command[1]);
        for (int j = 0; j < count; j++)
            list.Remove(current.Next.Data);
    }
    else if (command[0] == "L")
    {
        int count = int.Parse(command[1]);
        for (int j = 0; j < list.Count - 1 - count; j++)
            current = current.Next;
        for (int j = 0; j < count; j++)
            list.Remove(current.Next.Data);
    }
    current = current.Next;
}

Console.Write("Найти число: ");
int num = int.Parse(Console.ReadLine());
Console.WriteLine("Список:");
Console.WriteLine(list);
if (list.Contains(num))
    Console.WriteLine($"Число {num} есть в списке");
else Console.WriteLine($"Числа {num} нет в списке");






