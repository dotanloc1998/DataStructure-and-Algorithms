/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt stack chứa số nguyên và sau đó phát triển thành stack trừu tượng.
 */
using System;
namespace DSA
{
    public class Stack
    {
        class Node
        {
            public int data;
            public Node next;
            public Node(int a , Node b)
            {
                data = a;
                next = b;
            }
        }
        private Node head;
        public int CountStack()
        {
            Node temp = head;
            int i = 0;
            for (; temp != null; temp = temp.next)
            {
                i++;
            }
            return i;
        }
        public int Top()
        {
            return head.data;
        }
        public void Push(int a)
        {
            Node temp = new Node(a,head);
            head = temp;
        }
        public void Pop()
        {
            head = head.next;
        }
    }
    public class Stack<T>
    {
        class Node
        {
            public T data;
            public Node next;
            public Node(T a, Node b)
            {
                data = a;
                next = b;
            }
        }
        private Node head;
        public int CountStack()
        {
            Node temp = head;
            int i = 0;
            for (; temp != null; temp = temp.next)
            {
                i++;
            }
            return i;
        }
        public T Top()
        {
            return head.data;
        }
        public void Push(T a)
        {
            Node temp = new Node(a, head);
            head = temp;
        }
        public void Pop()
        {
            head = head.next;
        }
        public bool IsEmpty()
        {
            if (head==null)
            {
                return true;
            }
            return false;
        }
    }
}