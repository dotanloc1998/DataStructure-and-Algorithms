/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài:
 *  8.Viết chương trình nhập danh sách 10 số nguyên, sử dụng hàm bubblesort trong bài 7 để sắp xếp danh sách tăng dần.
 */
 using System;

namespace DSA
{
    public class InputBai08
    {
        public static void NhapDuLieu(out int []a, int n)
        {
            a=new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Nhap vao phan tu thu {0} : ",i+1);
                a[i] = int.Parse(Console.ReadLine());
            }
        }
    }

    public class Bai08
    {
        public Bai08()
        {
            int[] a;
            Console.Write("Nhap vao so luong phan tu : ");
            int n = int.Parse(Console.ReadLine());
            InputBai08.NhapDuLieu(out a,n);
            BubbleShort.BBShort2(ref a,n);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }
    }
}