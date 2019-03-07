/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài :Viết hàm xóa phần tử có giá trị 5 trong stack chứa số nguyên
           Viết hàm đảo ngược thứ tự của stack
           Viết hàm đảo ngược thứ tự của queue
           Viết hàm xóa 2 phần tử đầu tiên của một danh sách đặc
           Viết hàm thêm hai số x, y vào danh sách đặc có thứ tự tăng dần
           Viết hàm đảo ngược thứ tự của một danh sách liên kết
           Viết hàm đảo ngược thứ tự của một danh sách đặc
 */
using System;

namespace DSA
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int a, Node bNext)
        {
            data = a;
            next = bNext;
        }
    }
    public class StackBai49
    {
        public Node head;

        public int Top()
        {
            return head.data;
        }

        public void Push(int a)
        {
            Node temp = new Node(a, head);
            head = temp;
        }

        public void Pop()
        {
            head = head.next;
        }

        public void DeleteValue5(StackBai49 a)
        {
            StackBai49 b = new StackBai49();
            Node temp = a.head;
            while (temp != null)
            {
                if (temp.data != 5)
                {
                    b.Push(temp.data);
                    a.Pop();
                    temp = temp.next;
                }
                else
                {
                    a.Pop();
                    temp = temp.next;
                }
            }
            temp = b.head;
            while (temp != null)
            {
                a.Push(temp.data);
                temp = temp.next;
            }
        }

        public StackBai49 ReverseStack()
        {
            StackBai49 b = new StackBai49();
            Node temp = head;
            while (temp != null)
            {
                b.Push(temp.data);
                temp = temp.next;
            }
            return b;
        }

        public void PrintStack()
        {
            Node run = head;
            while (run != null)
            {
                Console.Write("{0} ", run.data);
                run = run.next;
            }
            Console.WriteLine();
        }
    }

    public class QueueBai51
    {
        private Node head;
        private Node tail;

        public int Front()
        {
            return tail.data;
        }

        public void Enqueue(int a)
        {
            if (head == null && tail == null)
            {
                Node temp = new Node(a, null);
                head = tail = temp;
            }
            else
            {
                Node temp = new Node(a, null);
                head.next = temp;
                head = temp;
            }
        }

        public void Dequeue()
        {
            tail = tail.next;
        }

        public void PrintQueue()
        {
            Node run = tail;
            while (run != null)
            {
                Console.Write("{0} ", run.data);
                run = run.next;
            }
            Console.WriteLine();
        }

        public QueueBai51 ReverseQueue(QueueBai51 a)
        {
            StackBai49 b = new StackBai49();
            Node run = a.tail;
            while (run != null)
            {
                b.Push(run.data);
                a.Dequeue();
                run = run.next;
            }
            a = new QueueBai51();
            run = b.head;
            while (run != null)
            {
                a.Enqueue(run.data);
                run = run.next;
            }
            return a;
        }

        public Node GetTail()
        {
            return tail;
        }
    }

    public class ThickList
    {
        private int[] a { get; set; }

        public ThickList()
        {
            a = new int[0];
        }

        public ThickList(int n)
        {
            a = new int[n];
        }
        public int Xuat(int viTri)
        {
            return a[viTri];
        }
        public void XuatList()
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("Phan tu thu {0} la {1}", i, Xuat(i));
            }
        }
        public void GanGiaTri(int viTri, int giaTri)
        {
            a[viTri] = giaTri;
        }
        public ThickList AddThickList(int giaTri)
        {
            ThickList b = new ThickList(a.Length + 1);
            for (int i = 0; i < b.a.Length - 1; i++)
            {
                b.GanGiaTri(i, a[i]);
            }
            b.GanGiaTri(b.a.Length - 1, giaTri);
            return b;
        }
        public ThickList XoaPhanTuTheoViTri(int viTri)
        {
            ThickList b = new ThickList(a.Length - 1);
            bool daXoa = false;
            for (int i = 0; i < b.a.Length; i++)
            {
                if (daXoa)
                {

                    b.GanGiaTri(i, a[i + 1]);
                }
                else
                {

                    b.GanGiaTri(i, a[i]);
                    if (i == viTri)
                    {

                        b.GanGiaTri(viTri, a[i + 1]);
                        daXoa = true;
                    }
                }
            }
            return b;
        }
        public void Delete2HeadValues(ref ThickList b)
        {
            b = b.XoaPhanTuTheoViTri(0);
            b = b.XoaPhanTuTheoViTri(0);
        }

        public void Add2SortedValues(ref ThickList b, int c, int d)
        {
            ThickList a = new ThickList(b.a.Length + 2);
            int e = Math.Min(c, d);
            int f = Math.Max(c, d);
            bool ganE = true;
            bool ganF = false;
            for (int i = 0; i < a.a.Length; i++)
            {
                if (ganE)
                {
                    if (b.Xuat(i) < e)
                    {
                        a.GanGiaTri(i, b.Xuat(i));
                    }
                    else
                    {
                        a.GanGiaTri(i, e);
                        i++;
                        a.GanGiaTri(i, b.Xuat(i - 1));
                        ganE = false;
                        ganF = true;
                    }
                }
                else if (ganF)
                {
                    if (b.Xuat(i - 1) < f)
                    {
                        a.GanGiaTri(i, b.Xuat(i - 1));
                    }
                    else
                    {
                        a.GanGiaTri(i, f);
                        i++;
                        a.GanGiaTri(i, b.Xuat(i - 2));
                        ganF = false;
                    }
                }
                else
                {
                    for (int j = i; j < a.a.Length; j++)
                    {
                        a.GanGiaTri(j, b.Xuat(j - 2));
                    }
                }
            }

        }

        public ThickList ReverseThickList(ThickList a)
        {
            ThickList b = new ThickList();

            for (int i = a.a.Length - 1; i >= 0; i--)
            {
                b = b.AddThickList(a.Xuat(i));
            }
            return b;
        }
    }

    public class LinkedListBai54
    {
        private Node first;
        private Node last;

        public void AddTop(int a)
        {
            Node temp = new Node(a,first);
            if (first==null && last==null)
            {
                first = last = temp;
            }
            else
            {
                first = temp;
            }
        }

        public int GetTop()
        {
            return first.data;
        }

        public void PrintLinkedList()
        {
            Node run = first;
            while (run!=null)
            {
                Console.Write("{0} ",run.data);
                run = run.next;
            }
            Console.WriteLine();
        }

        public void DeleteTop()
        {
            first = first.next;
        }

        public void ReverseLinkedList(ref LinkedListBai54 a)
        {
            Node run = first;
            QueueBai51 b = new QueueBai51();
            while (run!=null)
            {
                b.Enqueue(run.data);
                run = run.next;
                a.DeleteTop();
            }
            run = b.GetTail();
            while (run!=null)
            {
                a.AddTop(run.data);
                run = run.next;
            }
        }
    }
    public class Bai49Den55
    {
        public Bai49Den55()
        {
            //StackBai49 a = new StackBai49();
            //a.Push(7);
            //a.Push(6);
            //a.Push(5);
            //a.Push(4);
            //a.Push(3);
            //a.Push(2);
            //a.DeleteValue5(a);
            //a = a.ReverseStack();
            //a.PrintStack();
            //QueueBai51 b = new QueueBai51();
            //b.Enqueue(1);
            //b.Enqueue(2);
            //b.Enqueue(3);
            //b.Enqueue(4);
            //b.Enqueue(5);
            //b.Enqueue(6);
            //b=b.ReverseQueue(b);
            //b.PrintQueue();

            //ThickList a = new ThickList();
            //a = a.AddThickList(23);
            //a = a.AddThickList(29);
            //a = a.AddThickList(35);
            //a = a.AddThickList(47);
            //a = a.AddThickList(53);
            //a = a.AddThickList(69);
            //a = a.AddThickList(73);
            //a = a.AddThickList(85);
            //a = a.AddThickList(92);
            //a = a.AddThickList(100);
            //a = a.AddThickList(105);
            //a = a.AddThickList(109);
            //a.XuatList();
            //a.Delete2HeadValues(ref a);
            //Console.WriteLine();
            //a.XuatList();
            //Console.WriteLine();
            //a.Add2SortedValues(ref a, 36, 102);
            //a.XuatList();
            //Console.WriteLine();
            //a = a.ReverseThickList(a);
            //a.XuatList();

            LinkedListBai54 a = new LinkedListBai54();
            a.AddTop(69);
            a.AddTop(82);
            a.AddTop(35);
            a.AddTop(47);
            a.AddTop(78);
            a.AddTop(52);
            a.PrintLinkedList();
            Console.WriteLine();
            a.ReverseLinkedList(ref a);
            a.PrintLinkedList();
        }
    }
}