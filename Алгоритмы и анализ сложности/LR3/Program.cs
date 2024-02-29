using System.Collections;
using System.Xml.Linq;

Console.WriteLine("2 Задание: ");
task1();
Console.WriteLine("4 Задание: ");
task2();
Console.WriteLine("6 Задание: ");
task3();

void task1(){
    Random rand = new Random();
    LinkedList<int> list = new LinkedList<int>();
    LinkedList<int> list2 = new LinkedList<int>();
    for (int i = 0; i < 20; i++)
    {
        list.AddLast(rand.Next(101));
    }
    foreach (int j in list)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
    foreach (int i in list)
    {
        list2.AddLast(i);
    }
    foreach (int j in list2)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}

void task2(){
    Random rand = new Random();
    LinkedList<int> list = new LinkedList<int>();
    LinkedList<int> list2 = new LinkedList<int>();
    for (int i = 0; i < 20; i++)
    {
        list.AddLast(rand.Next(101));
    }
    foreach (int j in list)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
    Console.WriteLine("Введите число, вокруг которого нужно разбить список: ");
    int num = int.Parse(Console.ReadLine());
    foreach (int i in list)
    {
        if (i >= num)
            list2.AddLast(i);
        else
            list2.AddFirst(i);
    }
    foreach (int j in list2)
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}

void task3(){
    SCList list = new SCList();
    SCList list2 = new SCList();
    Random rand = new Random();
    structure struct1 = new structure();
    for (int i = 0; i < 20; i++)
    {
        struct1.val = rand.Next(101);
        list.Add(struct1);
    }
    for (int i = 0; i < 20; i++)
    {
        list[i, true].Random = list[rand.Next(0, 20), true];
    }
    Console.WriteLine("Исходный список: ");
    for (int j = 0; j < 20; j++)
    {
        Console.Write(list[j].val + " ");
    }
    Console.WriteLine();
    for (int j = 0; j < 20; j++)
    {
        Console.Write(list[j].val + "-\"{0}\" ", list[j, true].Random.Num);
    }
    Console.WriteLine();
    Node node = list.head;
    for (int i = 0; i < 20; i++)
    {
        list2.Add(node.Data);
        node = node.Next;
    }
    node = list.head;
    Node node2 = list2.head;
    for (int i = 0; i < 20; i++)
    {
        node2.Random = node.Random;
        node2 = node2.Next;
        node = node.Next;
    }
    Console.WriteLine("Скопированный список: ");
    for (int j = 0; j < 20; j++)
    {
        Console.Write(list2[j].val + " ");
    }
    Console.WriteLine();
    for (int j = 0; j < 20; j++)
    {
        Console.Write(list2[j].val + "-\"{0}\" ", list2[j, true].Random.Num);
    }
}

internal class SCList
{
    public Node? head; // головной/первый элемент
    Node? tail; // последний/хвостовой элемент
    int count;  // количество элементов в списке
    public structure this[int index]
    {
        get
        {
            if (index >= 0 && index < count)
            {
                Node node = head;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                return node.Data;
            }
            else
                throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
        set
        {
            if (index >= 0 && index < count)
            {
                Node node = head;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                node.Data = value;
            }
            else throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
    }
    public Node this[int index, bool x]
    {
        get
        {
            if (index >= 0 && index < count)
            {
                Node node = head;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                return node;
            }
            else
                throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
        set
        {
            if (index >= 0 && index < count)
            {
                Node node = head;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                node = value;
            }
            else throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
    }
    public void Add(structure data)
    {
        Node node = new Node(data);

        if (head == null)
            head = node;
        else
            tail.Next = node;
        tail = node;

        count++;
    }
}

struct structure
{
    public int val;
}

class Node
{
    private structure data;
    public Node? Random { get; set; }
    public Node? Next { get; set; }
    public Node(structure struct1)
    {
        data = struct1;
    }
    public structure Data
    {
        get { return data; }
        set { data = value; }
    }
    public int Num
    {
        get { return data.val; }
        set { data.val = value; }
    }
}
