/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết hàm sắp xếp danh sách số nguyên tăng dần sử dụng giải thuật quicksort.
 */
using System;
using System.Collections.Concurrent;

namespace DSA
{
    public class QuickSort
    {
        public static void Swap(ref int a, ref int b)
        {
            int phu = a;
            a = b;
            b = phu;
        }
        public static int Partition(int[] a, int lo, int hi)
        {
            int pi = (lo + hi) / 2;
            if (pi >= 0)
            {
                Swap(ref a[pi], ref a[hi]);
                pi = lo;
                for (int i = lo; i < hi - 1; i++)
                {
                    if (a[i] <= a[hi])
                    {
                        Swap(ref a[i], ref a[hi]);
                        pi++;
                    }
                }
                Swap(ref a[pi], ref a[hi]);
            }
            return pi;
        }

        public static void QuickSortMethod(ref int[] a, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(a, lo, hi);
                if (p >= 0)
                {
                    QuickSortMethod(ref a, lo, p - 1);
                    QuickSortMethod(ref a, p + 1, hi);
                }
            }
        }

        public static void QuickSortMethod2(ref int[] a, int lo, int hi)
        {
            if (lo >= hi)
                return;
            int p = a[(lo + hi) / 2];
            int i = lo;
            int j = hi;
            while (i < j)
            {
                while (a[i] < p)
                {
                    i++;
                }
                while (a[j] > p)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref a[i],ref a[j]);
                    i++;
                    j--;
                }
            }
            QuickSortMethod2(ref a, lo, j);
            QuickSortMethod2(ref a, i, hi);

        }
    }

    public class Bai10
    {
        public Bai10()
        {
            int[] a = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 10 - i;
            }
            QuickSort.QuickSortMethod2(ref a, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
        }
    }
}