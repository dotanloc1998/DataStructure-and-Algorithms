/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài: Viết chương trình nhập vào danh sách 10 số nguyên, 
 * sử dụng hàm tìm ở bài 1 để xuất ra vị trí của số 5 trong danh sách số đã nhập.
*/
using System;
namespace DSA
{
    public class SearchPart2
    {
        static void Input(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
        }
        public SearchPart2()
        {
            Console.Write("Nhap vao so luong phan tu : ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            Input(a);
            int pos;
            pos = Search.LinearSearch(a, 5, out pos);
            if (pos != -1)
            {
                Console.WriteLine("Vi tri cua so 5 nam o {0}", pos+1);
            }
            else
            {
                Console.WriteLine("Khong co so 5 trong danh sach");
            }
        }
    }
}