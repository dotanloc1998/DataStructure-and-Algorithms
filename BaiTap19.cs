/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt CTDL ListInt dùng để chứa các số nguyên, trong đó:
•	Sử dụng mảng tĩnh
•	Cài đặt các phép toán: Nhập 10 số nguyên và đưa vào danh sách
•	In danh sách ra màn hình
•	Nhập một số k và xóa số k trong danh sách
•	In danh sách sau khi xóa phần tử
•	Nhập 5 số nguyên vào một danh sách thứ hai
•	Thêm danh sách thứ hai vào danh sách thứ nhất
•	In danh sách thứ nhất ra màn hình
 */
using System;
using System.Collections.Generic;
namespace DSA
{
    public class Bai19
    {
        public Bai19()
        {
            ArrayBai18 a = new ArrayBai18(10);
            for (int i = 0; i < a.A.Length; i++)
            {
                Console.Write("Nhap vao phan tu thu {0} : ", i);
                a.Nhap(i, int.Parse(Console.ReadLine()));
            }
            Console.WriteLine();
            a.XuatDanhSach();
            //for (int i = 0; i < a.A.Length; i++)
            //{
            //    Console.WriteLine("Gia tri phan tu thu {0} la {1}",i,a.Xuat(i));
            //}
            Console.WriteLine();
            Console.Write("Nhap vao so k can xoa: ");
            int k = int.Parse(Console.ReadLine());
            a = a.XoaPhanTu(k);
            Console.WriteLine("\nMang moi sau khi xoa");
            a.XuatDanhSach();
            //for (int i = 0; i < a.A.Length; i++)
            //{
            //    Console.WriteLine("Gia tri phan tu thu {0} la {1}",i,a.Xuat(i));
            //}
            Console.Write("\nNhap vao so luong phan tu can them vao danh sach : ");
            int n = int.Parse(Console.ReadLine());
            ArrayBai18 b = new ArrayBai18(n);
            for (int i = 0; i < b.A.Length; i++)
            {
                Console.Write("Nhap vao phan tu thu {0} : ", i);
                b.Nhap(i, int.Parse(Console.ReadLine()));
            }
            a = a.ThemMangMoi(b);
            Console.WriteLine("\nMang moi sau khi them");
            a.XuatDanhSach();
        }
    }
}