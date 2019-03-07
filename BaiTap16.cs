/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết các hàm sắp xếp danh sách số nguyên tăng dần theo các giải thuật: shell sort, merge sort.
 */
 using System;

namespace DSA
{
    public class ShellSort
    {
        public static void ShellSortMethod(ref int[] a)
        {
            int gap = a.Length / 2;
            while (gap > 0)
            {
                for (int i = gap; i <= a.Length - 1; i++)
                {
                    int j = i - gap;
                    int t = a[i];
                    while (j >= 0 && a[j] > t)//Nếu giảm dần là while (j >= 0 && a[j] < t)
                    {
                        a[j + gap] = a[j];
                        j -= gap;
                    }
                    a[j + gap] = t;
                }
                gap /=2;
            }
        }
    }

    public class MergeSort
    {
        public static void Merge(ref int[] a, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int pos = 0;
            int i = left;
            int j = mid + 1;


            //!(i>mid&&j>right) <= Neu nhu khong ghi kieu nay
            //i<mid&&j>right||i<mid&&j<right||i>mid&&j<right||i==mid&&j>right||i==mid&&j<right||i>mid&&j==right||i<mid&&j==right||i==mid&&j==right <= Thi phai ghi kieu nay
            // Y nghia cua no la Ngoai tru truong hop trong dau !() thi con lai chay het
            
            while (!(i > mid && j > right))
            {
                if (i <= mid && j <= right && a[i] < a[j] || j > right)//Nếu giảm dần là if (i <= mid && j <= right && a[i] > a[j] || j > right)
                {
                    temp[pos++] = a[i++];
                }
                else
                {
                    temp[pos++] = a[j++];
                }
            }
            for (int k = 0; k < temp.Length; k++)
            {
                a[left + k] = temp[k];
            }
        }

        public static void MergeShortMethod(ref int[] a, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int mid = (left + right) / 2;
            MergeShortMethod(ref a, left, mid);
            MergeShortMethod(ref a, mid + 1, right);
            Merge(ref a, left, mid, right);
        }
    }

}