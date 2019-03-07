/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài:
 *  7.Viết hàm sắp xếp danh sách số nguyên theo giải thuật bubblesort theo nguyên tắc số lớn dịch chuyển về sau.
*/
using System;

namespace DSA
{
    public class BubbleShort
    {
        public static void BBShort(ref int[]a,int n)
        {
            
            while (n>0)
            {
                int newN = 0;
                for (int i = 0; i < n-2; i++)
                {
                    if (a[i]>a[i+1])
                    {
                        int phu = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = phu;
                        newN = i + 1;
                    }
                }
                n = newN;
            }
        }

        public static void BBShort2(ref int[]a, int n)
        {
            for (int i = 0; i < n-1; i++)
            {
                for (int j = n-1; j >i ; j--)
                {
                    if (a[j]<a[j-1])
                    {
                        int phu = a[j];
                        a[j] = a[j -1];
                        a[j - 1] = phu;
                    }
                }
            }
        }
        public static void BBShort3(ref int[] a, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int phu = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = phu;
                        for (int k = 0; k < a.Length; k++)
                        {
                            Console.Write("{0} ",a[k]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
    public class Bai07
    {
        public Bai07()
        {
            Console.Write("Nhap vao so luong phan tu: ");
            int n = int.Parse(Console.ReadLine());
            int []a=new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            BubbleShort.BBShort2(ref a,n);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ",a[i]);
            }
            Console.WriteLine();
        }
    }
}