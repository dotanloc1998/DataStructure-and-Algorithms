/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài :Viết chương trình nhập vào 10 số nguyên, sử dụng quicksort để sắp xếp danh sách tăng dần.
 */
 using System;

namespace DSA
{
    public class Bai11
    {
        public Bai11()
        {
            int[] a = new int[10];
            Console.WriteLine("Nhap vao 10 so can sap xep");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Nhap vao so thu {0} : ",i+1);
                a[i] = int.Parse(Console.ReadLine());
            }
            QuickSort.QuickSortMethod2(ref a, 0, a.Length - 1);
            //AbstractQuickSort.QuickSortA(a, 0, a.Length - 1);
            Console.WriteLine("\nMang sau khi sap xep");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ",a[i]);
            }
            Console.WriteLine();
        }
    }

}