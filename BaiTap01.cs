/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài: Viết hàm tìm kiếm tuần tự một số nguyên trong một danh sách số nguyên, 
 * trả về vị trí nếu tìm thấy, trả về -1 nếu không tìm thấy.
*/

using System;

namespace DSA
{
    public class Search
    {
      public static int LinearSearch(int [] a, int x, out int pos)
        {
            pos = -1;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i]==x)
                {
                    pos = i;
                    return pos;
                }
            }
            return pos;
        }
    }
}