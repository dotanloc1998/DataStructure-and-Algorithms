/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết hàm quicksort cho kiểu dữ liệu trừu tượng
 */
using System;

namespace DSA
{
    public class AbstractQuickSort : IComparable<AbstractQuickSort>
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T phu = a;
            a = b;
            b = phu;
        }
        public static void QuickSortA<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (lo.CompareTo(hi) == 0 || lo.CompareTo(hi) > 0)
            {
                return;
            }
            T p = a[(lo + hi) / 2];
            int i = lo;
            int j = hi;
            while (i < j)
            {
                while (a[i].CompareTo(p) < 0)
                {
                    i++;
                }
                while (a[j].CompareTo(p) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref a[i], ref a[j]);
                    i++;
                    j--;
                }
            }
            QuickSortA(a, lo, j);
            QuickSortA(a, i, hi);
        }
        int IComparable<AbstractQuickSort>.CompareTo(AbstractQuickSort other)
        {
            throw new NotImplementedException();
        }
    }

}