/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài :Viết thành chương trình:
•	Nhập 10 chuỗi và đưa vào danh sách
•	In danh sách ra màn hình
•	Nhập một số k và xóa số k trong danh sách
•	In danh sách sau khi xóa phần tử
•	Nhập 5 chuỗi vào một danh sách thứ hai
•	Thêm danh sách thứ hai vào danh sách thứ nhất
•	In danh sách thứ nhất ra màn hình
 */
using System;
using System.Collections.Generic;
namespace DSA
{
    public class Bai21
    {
        public Bai21()
        {
            ListBai20<string> a = new ListBai20<string>();
            Console.WriteLine("Nhap 10 chuoi vao danh sach");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Nhap vao chuoi {0} : ", i);
                string s = Console.ReadLine();
                a = a.AddListBai20(s);
            }
            Console.WriteLine();
            a.XuatList();
            Console.Write("\nNhap vao chu can xoa : ");
            string s2 = Console.ReadLine();
            a = a.XoaPhanTuTheoTen(s2);
            Console.WriteLine("\nDanh sach sau khi xoa");
            a.XuatList();

            ListBai20<string> b= new ListBai20<string>();
            Console.WriteLine("\nNhap 5 chu so vao list 2");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Nhap vao chuoi {0} : ", i);
                string s = Console.ReadLine();
                b = b.AddListBai20(s);
            }
            a = a.ThemMangMoi(b);
            Console.WriteLine("\nMang moi sau khi them");
            a.XuatList();
        }
    }
}
