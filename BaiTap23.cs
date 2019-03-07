/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt CTDL ListSV dùng để chứa các sinh viên, trong đó:
•	Sử dụng danh sách liên kết
•	Cài đặt các phép toán: khởi tạo, hủy, thêm phần tử, xóa phần tử, thêm một danh sách phần tử, xuất danh sách, sắp xếp danh sách sử dụng selection sort và con trỏ hàm so sánh.
 */
using System;
using System.Runtime.Remoting.Messaging;

namespace DSA
{
    public class LinkedList
    {
        class Node
        {
            public SinhVienBai22 data;
            public Node next;

            public Node(SinhVienBai22 a, Node next)
            {
                data = a;
                this.next = next;
            }
        }

        private Node first;
        private Node last;


        public LinkedList()
        {
            first = last = null;

        }
        public void Destroy()
        {
            first = last = null;
        }

        public void AddNodeFirst(SinhVienBai22 b)
        {
            Node temp = new Node(b, first);
            first = temp;
            if (last == null)
            {
                last = first;
            }
        }

        public void AddNodeLast(SinhVienBai22 a)
        {
            Node temp = new Node(a, null);
            if (last == null)
            {
                first = last = temp;
            }
            last.next = temp;
            last = temp;
        }

        public void RemoveFirst()
        {
            first = first.next;
        }

        public void RemoveLast()
        {
            if (first != null)
            {
                if (first == last)
                {
                    first = last = null;
                }
                else
                {
                    Node temp = first;
                    for (; temp.next != last; temp = temp.next) { }
                    temp.next = null;
                    last = temp;
                }
            }
        }

        public void AddNodeAtPosition(int pos, SinhVienBai22 a)
        {
            Node current = first;
            for (int i = 0; i < pos && current != null; i++)
            {
                current = current.next;
            }
            Node gan = new Node(a, current.next);
            current.next = gan;
        }

        public void RemoveNodeAtPosition(int pos)
        {
            Node current = first;
            for (int i = 0; i < pos - 1 && current != null; i++, current = current.next)
            {
                current = current.next;
            }
            current.next = current.next.next;
        }

        public void AddLinkedList(LinkedList a)
        {
            last.next = a.first;
        }

        public SinhVienBai22 GetIt(int viTri)
        {
            Node current = first;
            for (int i = 0; i < viTri; i++)
            {
                current = current.next;
            }
            if (current.data != null)
            {
                return current.data;
            }
            return new SinhVienBai22();
        }

        public void SetIt(int viTri, SinhVienBai22 a)
        {
            Node current = first;
            for (int i = 0; i < viTri; i++)
            {
                current = current.next;
            }
            if (current.data != null)
            {
                current.data = a;
            }
        }

        public int CountLinkedList()
        {
            int i = 0;
            Node current = first;
            for (;current.next!=null;)
            {
                current = current.next;
                i++;
            }
            return i;
        }
        public void SelectionSortTheoTenSV(ref LinkedList a)
        {
            int min;
            for (int i = 0;i<a.CountLinkedList()-1 ; i++ )
            {
                min = i;
                for (int j = i + 1; j<a.CountLinkedList(); j++)
                {
                    if (a.GetIt(j).Ten[0].CompareTo(a.GetIt(min).Ten[0]) < 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    SinhVienBai22 tam = a.GetIt(i);
                    a.SetIt(i, a.GetIt(min));
                    a.SetIt(min, tam);
                }
            }
        }

        public int VitriTen(LinkedList a, string name)
        {
            Node current = first;
            for (int i = 0; current != null; current = current.next, i++)
            {
                if (current.data.Ten.CompareTo(name) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public void XoaKhiBietTen(ref LinkedList a, string name)
        {
            int viTri = VitriTen(a, name);
            if (viTri == -1)
            {
                Console.WriteLine("Khong tim thay");
            }
            else
            {
                RemoveNodeAtPosition(viTri);
            }

        }
        public int VitriDiaChi(LinkedList a, string name)
        {
            Node current = first;
            for (int i = 0; current != null; current = current.next, i++)
            {
                if (current.data.DiaChi.CompareTo(name) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void XoaKhiBietDiaChi(ref LinkedList a, string name)
        {
            int viTri = VitriDiaChi(a, name);
            if (viTri == -1)
            {
                Console.WriteLine("Khong tim thay");
            }
            else
            {
                RemoveNodeAtPosition(viTri);
            }

        }

        public void XuatDS()
        {
            for (Node current = first; current != null; current = current.next)
            {
                current.data.XuatSV();
                Console.WriteLine();
            }

        }
    }

    public class Bai23
    {
        public Bai23()
        {

        }
    }
}