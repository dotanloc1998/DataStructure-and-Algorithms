/*
// * Họ tên : Đỗ Tấn Lộc
// * MSSV : 16DH110351
// * Đề bài: Viết hàm tìm kiếm tuần tự theo kiểu dữ liệu trừu tượng.
    Viết chương trình:
    Khai báo cấu trúc dữ liệu của một sản phẩm gồm tên có tối đa 50 ký tự và giá là một số nguyên.
    Viết hàm so sánh hai sản phẩm với nhau theo tên sản phẩm.
    Viết hàm nhập danh sách 10 sản phẩm.
    Sử dụng hàm tìm kiếm ở bài 3, tìm giá của sản phẩm có tên là “Nuoc ngot”.
*/

using System;
namespace DSA
{
    public class Product:IComparable<Product>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Product(string name ="",int price=0)
        {
            Name = name;
            Price = price;
        }
        public static bool CompareProduct(Product a, Product b)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Input(out Product[] a)
        {
            Console.Write("Nhap vao so luong san pham: ");
            int n = int.Parse(Console.ReadLine());
            a = new Product[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new Product();
                Console.Write("\nTen san pham: ");
                a[i].Name = Console.ReadLine();
                Console.Write("Gia tien san pham: ");
                a[i].Price = int.Parse(Console.ReadLine());
                
            }
        }

        public virtual void InputTang(out Product[]a)
        {
            Console.Write("Nhap vao so luong san pham: ");
            int n = int.Parse(Console.ReadLine());
            a = new Product[n];
        }
        public int CompareTo(Product other)
        {
            return Name.CompareTo(other.Name);
        }
    }
    public class Bai04:Product
    {
        
        public Bai04()
        {
            Product[] list;
            Input(out list);
            Product x = new Product("Nuoc ngot");
            int pos = SearchPart3.LinearSearch(list, x, out pos);
            if (pos!=-1)
            {
                Console.WriteLine("\nSan pham nuoc ngot nam o vi tri so "+pos+1);
            }
            else
            {
                Console.WriteLine("\nKhong tim thay");
            }
        }
    }
}