using System;
using System.Collections.Generic;

class CustomLinkedList<T>
{
    public class Node
    {
        public T Data;
        public Node Next;
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public void Add(T data)
    {
        if (head == null)
            head = new Node(data);
        else
        {
            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = new Node(data);
        }
    }

    // ForEach 方法
    public void ForEach(Action<T> action)
    {
        Node temp = head;
        while (temp != null)
        {
            action(temp.Data); // 执行传入的 Lambda 表达式
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        CustomLinkedList<int> list = new CustomLinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(5);
        list.Add(15);

        Console.WriteLine("链表元素:");
        list.ForEach(x => Console.Write(x + " ")); // 打印元素
        Console.WriteLine();

        int max = int.MinValue, min = int.MaxValue, sum = 0;

        // 使用 Lambda 表达式计算最大值、最小值、总和
        list.ForEach(x =>
        {
            if (x > max) max = x;
            if (x < min) min = x;
            sum += x;
        });

        Console.WriteLine($"最大值: {max}");
        Console.WriteLine($"最小值: {min}");
        Console.WriteLine($"总和: {sum}");
    }
}
