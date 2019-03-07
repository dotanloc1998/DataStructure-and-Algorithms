/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Sử dụng lại chương trình bài 11 để kiểm tra các hàm trong bài 16.
 */
using System;

namespace DSA
{
    public class Bai17
    {
        public Bai17()
        {
            int[] a = new int[10] { 25, 46, 52, 13, 69, 47, 85, 23, 14, 25 };
            int[] b = new int[10];
            int[] c = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                //Console.Write("Nhap vao phan tu thu {0}: ", i + 1);
                //a[i] = int.Parse(Console.ReadLine());
                //a[i] = 10 - i;
                b[i] = a[i];
                c[i] = a[i];
            }
            Console.WriteLine();
            Console.WriteLine("Sap xep bang QuickSort ");
            QuickSort.QuickSortMethod2(ref a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sap xep bang ShellSort ");
            ShellSort.ShellSortMethod(ref b);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", b[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sap xep bang MergeSort");
            MergeSort.MergeShortMethod(ref c,0,c.Length-1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", c[i]);
            }
            Console.WriteLine();
        }
    }
}