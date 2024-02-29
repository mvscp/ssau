
using System;

int RepeatedElement(int[] arr)
{
    int temp = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != i)
        {
            if (arr[i] != arr[arr[i]])
            {
                temp = arr[arr[i]];
                arr[arr[i]] = arr[i];
                arr[i] = temp;
            }
            else
                return arr[i];
        }
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != i)
        {
            if (arr[i] != arr[arr[i]])
            {
                temp = arr[arr[i]];
                arr[arr[i]] = arr[i];
                arr[i] = temp;
            }
            else
                return arr[i];
        }
    }
    return 0;
}

task1();
Console.WriteLine();
task2();
Console.WriteLine();
task3();
Console.WriteLine();
task4();
Console.WriteLine();
task5();
Console.WriteLine();
task6();

void task1()
{
    Stack<char> stack = new Stack<char>();
    string str = "skg(dgl)k((m,sd)LSDF)dfgjs";
    int i = 0;
    Console.WriteLine(str);
    for (; i < str.Length; i++)
    {
        if (str[i] == '(')
            stack.Push(str[i]);
        else if (str[i] == ')')
        {
            if (stack.Count > 0)
                stack.Pop();
            else
                break;
        }
    }
    if (stack.Count == 0 && i == str.Length)
        Console.WriteLine("Скобки расставлены правильно");
    else
        Console.WriteLine("Скобки расставлены неправильно");
    stack.Clear();
    i = 0;
    string str1 = "([)}";
    Console.WriteLine(str1);
    for (; i < str1.Length; i++)
    {
        if (str1[i] == '(' || str1[i] == '[' || str1[i] == '{')
            stack.Push(str1[i]);
        else if (str1[i] == ')')
        {
            if (stack.Count > 0)
            {
                if (stack.Pop() == '(')
                    continue;
                else
                    break;
            }
            else
                break;
        }
        else if (str1[i] == ']')
        {
            if (stack.Count > 0)
            {
                if (stack.Pop() == '[')
                    continue;
                else
                    break;
            }
            else
                break;
        }
        else if (str1[i] == '}')
        {
            if (stack.Count > 0)
            {
                if (stack.Pop() == '{')
                    continue;
                else
                    break;
            }
            else
                break;
        }
    }
    if (stack.Count == 0 && i == str1.Length)
        Console.WriteLine("Скобки расставлены правильно");
    else
        Console.WriteLine("Скобки расставлены неправильно");
}
void task2()
{
    Random random = new Random();
    MinStack minStack = new MinStack();
    for (int i = 0; i < 10; i++)
    {
        minStack.Push(random.Next(0, 20));
        Console.Write(minStack.Peek() + " min: " + minStack.getMin() + "  ");
    }
    Console.WriteLine();
}
void task3()
{
    int n = 10;
    int k = 3;
    Random random = new Random();
    Deque<int> dq = new Deque<int>(k);
    int[] arr = new int[n];
    for (int j = 0; j < n; j++)
        arr[j] = random.Next(1, n);
    Console.WriteLine(String.Join(' ', arr));
    for (int i = 0; i < n; i++)
    {
        if (!dq.IsEmpty && dq.PeekFirst() == i-k)
            dq.PopFirst();
        while (!dq.IsEmpty && arr[i] > arr[dq.PeekLast()])
            dq.PopLast();
        dq.AddLast(i);
        if (i >= k-1)
            Console.Write(arr[dq.PeekFirst()] + " ");
    }
    Console.WriteLine();
}
void task4()
{
    int n = 10;
    Random random = new Random();
    int[] arr = new int[n];
    //int[] arr = {1, 4, 5, 2, 7, 4, 2, 1};
    //int[] arr = {7, 6, 5, 4, 3, 2, 1, 1};
    for (int i = 0; i < n; i++)
        arr[i] = random.Next(1, n);
    Console.WriteLine(String.Join(' ', arr));
    Console.WriteLine(RepeatedElement(arr));
}
void task5()
{
    int n = 10;
    Random random = new Random();
    int[] arr = new int[n];
    for (int i = 0; i < n; i++)
        arr[i] = random.Next(-20, 20);
    Console.WriteLine(String.Join(", ", arr));
    int highest;
    int lowest;
    if (arr[0] > arr[1])
    {
        highest = arr[0];
        lowest = arr[1];
    }
    else
    {
        highest = arr[1];
        lowest = arr[0];
    }
    int highestProductOf2 = arr[0] * arr[1];
    int lowestProductOf2 = arr[0] * arr[1];
    int highestProductOf3 = arr[0] * arr[1] * arr[2];
    for (int i = 2; i < n; i++)
    {
        if (arr[i] * highestProductOf2 > highestProductOf3)
            highestProductOf3 = arr[i] * highestProductOf2;
        else if (arr[i] * lowestProductOf2 > highestProductOf3)
            highestProductOf3 = arr[i] * lowestProductOf2;
        if (arr[i] * highest > highestProductOf2)
            highestProductOf2 = arr[i] * highest;
        else if (arr[i] * lowest > highestProductOf2)
            highestProductOf2 = arr[i] * lowest;
        if (arr[i] * highest < lowestProductOf2)
            lowestProductOf2 = arr[i] * highest;
        else if (arr[i] * lowest < lowestProductOf2)
            lowestProductOf2 = arr[i] * lowest;
        if (arr[i] > highest)
            highest = arr[i];
        else if (arr[i] < lowest)
            lowest = arr[i];
    }
    Console.WriteLine(highestProductOf3);
}
void task6()
{
    int n = 5;
    int m = 6;
    Random random = new Random();
    int[,] matrix = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            matrix[i, j] = random.Next(0, 10);
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    bool[] strings = new bool[n];
    bool[] columns = new bool[m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (matrix[i, j] == 0)
            {
                strings[i] = true;
                columns[j] = true;
            }
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (strings[i] || columns[j])
            {
                matrix[i, j] = 0;
            }
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}
class MinStack
{
    private Stack<int> stack;
    private Stack<int> minStack;
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    public void Push(int x)
    {
        stack.Push(x);
        if (minStack.Count != 0)
            if (minStack.Peek() > x)
                minStack.Push(x);
            else
                minStack.Push(minStack.Peek());
        else
            minStack.Push(x);
    }
    public void Pop()
    {
        stack.Pop();
        minStack.Pop();
    }
    public int Peek()
    {
        return stack.Peek();
    }
    public int getMin()
    {
        return minStack.Peek();
    }
}
