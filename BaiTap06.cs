/*
 * Họ tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài:
 *  Viết lại chương trình ở bài 4 với các yêu cầu sau:
    Khi nhập thì nhập danh sách sản phẩm theo giá tăng dần.
    Viết hàm so sánh hai sản phẩm theo giá.
    Sử dụng hàm tìm kiếm nhị phân trừu tượng, cho biết tên sản phẩm có giá là 1000.
*/
using System;

namespace DSA
{
    public class ProductBai06:Product
    {
        public override void InputTang(out Product[] a)
        {
            base.InputTang(out a);
            a[0] = new Product();
            Console.Write("\nTen san pham: ");
            a[0].Name = Console.ReadLine();
            Console.Write("Gia tien san pham: ");
            a[0].Price = int.Parse(Console.ReadLine());
            for (int i = 1; i < a.Length; i++)
            {
                a[i] = new Product();
                Console.Write("\nTen san pham: ");
                a[i].Name = Console.ReadLine();
                Console.Write("Gia tien san pham: ");
                a[i].Price = int.Parse(Console.ReadLine());
                while (a[i].Price<a[i-1].Price)
                {
                    Console.WriteLine("\nVui long nhap gia san pham cao hon san pham truoc: ");
                    a[i].Price = int.Parse(Console.ReadLine());
                }
            }
        }

        public void SoSanhSanPham(Product[]a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("\nSan pham {0} co ten {1} va co gia {2}",i,a[i].Name,a[i].Price);
            }
            Console.Write("Chon san pham 1: ");
            int sanPham =int.Parse(Console.ReadLine());
            Console.Write("Chon san pham 2: ");
            int sanPham1 = int.Parse(Console.ReadLine());
            if (a[sanPham].Price>a[sanPham1].Price)
            {
                Console.WriteLine("San pham {0} co gia dat hon san pham {1} la {2}",a[sanPham].Name,a[sanPham1].Name,a[sanPham].Price-a[sanPham1].Price);
            }
            else if (a[sanPham].Price < a[sanPham1].Price)
            {
                Console.WriteLine("San pham {0} co gia re hon san pham {1} la {2}", a[sanPham].Name, a[sanPham1].Name, a[sanPham1].Price - a[sanPham].Price);
            }
            else
            {
                Console.WriteLine("San pham {0} co gia bang san pham {1}", a[sanPham].Name, a[sanPham1].Name);
            }
        }


        public string TimSanPham(Product[]a)
        {
            int []b = new int[a.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = a[i].Price;
            }
            int pos = BinarySearch.BinSearch(b, 1000);
            return a[pos].Name;
        }
    }

    public class Bai06:ProductBai06
    {
        public Bai06()
        {
            Console.WriteLine("Nhap vao danh sach san pham");
            Product[] a;
            InputTang(out a);
            int chon = -1;
            while (chon!=0)
            {
                Console.WriteLine("\n--1--So Sanh San Pham");
                Console.WriteLine("\n--2--Tim san pham co gia 1000");
                Console.WriteLine("\n--0--Thoat chuong trinh");
                Console.Write("\nLua chon cua ban: ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                    {
                        SoSanhSanPham(a);
                    }
                        break;
                    case 2:
                    {
                        Console.WriteLine("San pham co gia 1000 la : "+TimSanPham(a));

                    }
                        break;
                }
            }
        }
    }
}