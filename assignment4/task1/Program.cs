using System;

public class LinkedList<T>
{
    private Node<T> head;

    private class Node<U>
    {
        public U Data { get; set; }
        public Node<U> Next { get; set; }
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T> { Data = data };
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // 添加ForEach方法
    public void ForEach(Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(3);
        list.Add(5);
        list.Add(1);
        list.Add(4);

        // 打印元素
        Console.Write("元素：");
        list.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        // 求最大值
        int max = int.MinValue;
        list.ForEach(x => { if (x > max) max = x; });
        Console.WriteLine("最大值：" + max);

        // 求最小值
        int min = int.MaxValue;
        list.ForEach(x => { if (x < min) min = x; });
        Console.WriteLine("最小值：" + min);

        // 求和
        int sum = 0;
        list.ForEach(x => sum += x);
        Console.WriteLine("和：" + sum);
    }
}