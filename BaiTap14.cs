/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết các hàm sắp xếp danh sách số nguyên tăng dần theo các giải thuật: selection sort, heap sort, insertion sort.
 */
using System;
namespace DSA
{
    public class SelecSort
    {
        public static void Swap(ref int a, ref int b)
        {
            int phu = a;
            a = b;
            b = phu;
        }
        public static void SelectionSort(ref int[] a)
        {
            for (int i = 1; i <= a.Length; i++)
            {
                int imax = 0;
                for (int j = 1; j <= a.Length - i; j++)
                {
                    if (a[imax] < a[j])
                    {
                        imax = j;
                    }
                }
                Swap(ref a[imax], ref a[a.Length - 1]);
            }
        }

        public static void SelectionSort2(ref int[] a)
        {
            int min;
            for (int i = 0; i < a.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])//Nếu giảm dần là if (a[j] > a[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(ref a[i], ref a[min]);
                }
            }
        }
    }

    public class HeapSort
    {
        public static void Swap(ref int a, ref int b)
        {
            int phu = a;
            a = b;
            b = phu;
        }

        public static void HeapSortMethod(ref int[] a)
        {
            Heapify(ref a);
            for (int i = a.Length; i >= 1; i--)
            {
                Swap(ref a[0], ref a[i - 1]);
                SiftDown(ref a, 0, i - 1);
            }
        }

        public static void SiftDown(ref int[] a, int s, int m)
        {
            int parent = s;
            int iMax = s;
            while (true)
            {
                int c1 = parent * 2 + 1;
                int c2 = c1 + 1;
                if (c1 < m && a[c1] > a[iMax])//Nếu giảm dần là if (c1 < m && a[c1] < a[iMax])
                {
                    iMax = c1;
                }
                if (c2 < m && a[c2] > a[iMax])//Nếu giảm dần là if (c2 < m && a[c2] < a[iMax])
                {
                    iMax = c2;
                }
                if (parent == iMax)
                {
                    break;
                }
                else
                {
                    Swap(ref a[parent], ref a[iMax]);
                    parent = iMax;
                }
            }

        }

        public static void Heapify(ref int[] a)
        {
            int s = a.Length / 2 - 1;
            for (int i = s; i >= 0; i--)
            {
                SiftDown(ref a, i, a.Length);
            }
        }
    }

    public class InsertionSort
    {
        public static void InsertionSortMethod(ref int[] a)
        {
            for (int i = 1; i <= a.Length - 1; i++)
            {
                int j = i - 1;
                int t = a[i];
                while (j >= 0 && a[j] > t)//Nếu giảm dần là while (j >= 0 && a[j] < t)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = t;
            }
        }
        public static void InsertionSortMethod2(ref int[] a)
        {
            int pos = 0;
            int x;
            for (int i = 1; i < a.Length; i++)
            {
                x = a[i];
                for (pos = i; (pos > 0) && (a[pos - 1] > x); pos--)
                {
                    a[pos] = a[pos - 1];
                }
                a[pos] = x;
            }
        }
    }
    public class Bai14
    {

    }
}