/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài: Viết hàm tìm kiếm tuần tự theo kiểu dữ liệu trừu tượng.
*/
using System;
namespace DSA
{
    public class SearchPart3
    {
        public static int LinearSearch<T>(T[] a, T x, out int pos) where T : IComparable<T>
        {
            pos = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].CompareTo(x)==0)
                {
                    pos = i;
                }
            }
            return pos;
        }
        
    }
    
}