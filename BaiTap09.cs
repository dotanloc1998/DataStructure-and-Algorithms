/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài:
 *  9.	Bổ sung vào chương trình ở bài 8: in ra danh sách mỗi khi có sự thay đổi trong quá trình sắp xếp.
 */
 using System;

namespace DSA
{
    public class InputBai09
    {
        public static void NhapDuLieu(out int[] a, int n)
        {
            a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Nhap vao phan tu thu {0} : ", i + 1);
                a[i] = int.Parse(Console.ReadLine());
            }
        }
    }

    public class Bai09
    {
        public Bai09()
        {
            int[] a;
            Console.Write("Nhap vao so luong phan tu : ");
            int n = int.Parse(Console.ReadLine());
            InputBai09.NhapDuLieu(out a, n);
            BubbleShort.BBShort3(ref a, n);
        }
    }
}