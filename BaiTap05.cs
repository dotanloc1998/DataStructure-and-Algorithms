/*
// * Họ tên : Đỗ Tấn Lộc
// * MSSV : 16DH110351
// * Đề bài: Viết hàm tìm kiếm nhị phân cho kiểu dữ liệu trừu trượng.
*/
using System;

namespace DSA
{
    public class BinarySearch:IComparable<BinarySearch>
    {
        public static int BinSearch<T>(T[] a,T x) where T : IComparable<T>
        {
            int left = 0;
            int right = a.Length - 1;
            int pos = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (x.CompareTo(a[mid])==0)
                {
                    return mid;

                }
                else if (x.CompareTo(a[mid]) < 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return pos;
        }

        public int CompareTo(BinarySearch other)
        {
            throw new NotImplementedException();
        }
    }

    public class Bai05
    {
        public Bai05()
        {
            Console.Write("Nhap vao so luong phan tu: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Console.WriteLine("Nhap vao day so tang dan");
            Console.Write("Nhap vao phan tu a[0] = ");
            a[0] = int.Parse(Console.ReadLine());
            for (int i = 1; i < a.Length; i++)
            {
                Console.Write("\nNhap vao phan tu a[{0}] = ",i);
                a[i] = int.Parse(Console.ReadLine());
                while (a[i] < a[i - 1])
                {
                    Console.WriteLine("\nPhai nhap vao phan tu lon hon so truoc");
                    Console.WriteLine("Vui long nhap lai");
                    Console.Write("Nhap vao phan tu a[{0}] = ", i);
                    a[i] = int.Parse(Console.ReadLine());
                }
            }
            Console.Write("\nNhap vao so can tim: ");
            int x = int.Parse(Console.ReadLine());
            int pos = BinarySearch.BinSearch(a, x);
            if (pos==0)
            {
                Console.WriteLine("\nKhong tim thay so "+x);
            }
            else
            {
                Console.WriteLine("\nSo {0} cua ban nam o vi tri {1}",x,pos);
            }
        }
    }
}
