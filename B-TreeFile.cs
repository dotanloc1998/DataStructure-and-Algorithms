using System;

namespace DSA
{
    public class BaiBTree
    {
        public BaiBTree()
        {
            Console.Write("Nhap vao Bac cho cay B-Tree : ");
            int bac = int.Parse(Console.ReadLine());
            BTreeInt bTree = new BTreeInt(bac);
            int select = -1;
            while (select != 0)
            {

                Console.WriteLine("\n--1-- Nhap vao 1 phan tu");
                Console.WriteLine("--2-- Xoa di 1 phan tu");
                Console.WriteLine("--0-- De thoat chuong trinh");
                Console.Write("Nhap vao lua chon cua ban: ");
                select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                    {
                        Console.Write("\nNhap vao so can them : ");
                        int k = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Before insert " + k + ":");
                        bTree._Show(1);
                        bTree.Insert(k, k);
                        Console.SetCursorPosition(1, 10);
                        Console.Write("After insert " + k + ":");
                        bTree._Show(11, k);
                        Console.WriteLine("\n\n\n");
                    }
                        break;
                    case 2:
                    {
                        Console.Write("\nNhap vao so can xoa : ");
                        int k = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.Write("Before remove " + k + ":");
                        bTree._Show(1, k);

                        bTree.Remove(k);
                        Console.SetCursorPosition(1, 10);
                        Console.Write("After remove " + k + ":");
                        bTree._Show(11);
                        Console.WriteLine("\n\n\n");
                    }
                        break;

                    default:
                        break;
                }
            }
        }

    }
}