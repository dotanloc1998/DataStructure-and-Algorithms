/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết hàm quicksort cho kiểu dữ liệu trừu tượng
 */
using System;
using System.Collections.Generic;

namespace DSA
{
    public class SinhVien
    {
        public SinhVien()
        {

        }

        public SinhVien(string ho, string lop, string ten, int diem)
        {
            Ho = ho;
            Lop = lop;
            Diem = diem;
            Ten = ten;
        }
        public string Ho { get; set; }
        public string Lop { get; set; }
        public int Diem { get; set; }
        public string Ten { get; set; }
        public void Input()
        {

            Console.Write("Nhap vao Ho va Ten Lot cua sinh vien: ");
            Ho = Console.ReadLine();
            Console.Write("Nhap vao Ten sinh vien: ");
            Ten = Console.ReadLine();
            Console.Write("Nhap vao Lop cua sinh vien: ");
            Lop = Console.ReadLine();
            Console.Write("Nhap vao diem cua sinh vien: ");
            Diem = int.Parse(Console.ReadLine());
        }
        public void Output()
        {

            Console.WriteLine("Ho va Ten Lot cua sinh vien: " + Ho);
            Console.WriteLine("Ten sinh vien: " + Ten);
            Console.WriteLine("Lop cua sinh vien: " + Lop);
            Console.WriteLine("Diem cua sinh vien: " + Diem);
        }
        public static void Swap(SinhVien a, SinhVien b)
        {
            SinhVien phu = a;
            a = b;
            b = phu;
        }
        public static void QuickSortMethodSinhVienTen(ref List<SinhVien> a, int lo, int hi)
        {
            if (lo >= hi)
                return;
            char p = a[(lo + hi) / 2].Ten[0];
            int i = lo;
            int j = hi;
            while (i < j)
            {
                while (a[i].Ten[0].CompareTo(p) < 0)
                {
                    i++;
                }
                while (a[j].Ten[0].CompareTo(p) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    //Swap(a[i],a[j]);
                    SinhVien phu = a[i];
                    a[i] = a[j];
                    a[j] = phu;
                    i++;
                    j--;
                }
            }
            QuickSortMethodSinhVienTen(ref a, lo, j);
            QuickSortMethodSinhVienTen(ref a, i, hi);

        }
        public static void QuickSortMethodSinhVienLop(ref List<SinhVien> a, int lo, int hi)
        {
            if (lo >= hi)
                return;
            char p = a[(lo + hi) / 2].Lop[0];
            int i = lo;
            int j = hi;
            while (i < j)
            {
                while (a[i].Lop[0].CompareTo(p) < 0)
                {
                    i++;
                }
                while (a[j].Lop[0].CompareTo(p) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    //Swap( a[i], a[j]);
                    SinhVien phu = a[i];
                    a[i] = a[j];
                    a[j] = phu;
                    i++;
                    j--;
                }
            }
            QuickSortMethodSinhVienLop(ref a, lo, j);
            QuickSortMethodSinhVienLop(ref a, i, hi);
        }
        public static int SoSanhTen(string tenA, string tenB)
        {
            return tenA.CompareTo(tenB);
        }
        public static int SoSanhLop(string lopA, string lopB)
        {
            return lopA.CompareTo(lopB);
        }
    }
    public class Bai13
    {
        public Bai13()
        {
            List<SinhVien> listSV = new List<SinhVien>();
            SinhVien a = new SinhVien();
            int selection = -1;
            while (selection != 0)
            {
                Console.WriteLine("\n--1--Nhap vao 1 sinh vien");
                Console.WriteLine("\n--2--So sanh ten cua 2 sinh vien");
                Console.WriteLine("\n--3--So sanh lop cua 2 sinh vien");
                Console.WriteLine("\n--4--Sap xep va in ra danh sach sinh vien theo ten");
                Console.WriteLine("\n--5--Sap xep va in ra danh sach sinh vien theo lop");
                Console.WriteLine("\n--0-- Thoat chuong trinh");
                Console.Write("Nhap vao lua chon cua ban: ");
                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        {
                            a = new SinhVien();
                            a.Input();
                            listSV.Add(a);
                        }
                        break;
                    case 2:
                        {
                            foreach (var item in listSV)
                            {
                                Console.WriteLine("\nThong tin sinh vien thu {0}", listSV.IndexOf(item));
                                item.Output();
                            }
                            Console.WriteLine("Chon 2 sinh vien can so sanh ten");
                            Console.WriteLine("Sinh vien A: ");
                            int sinhVien = int.Parse(Console.ReadLine());
                            Console.WriteLine("Sinh vien B: ");
                            int sinhVien2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Tra ve : {0}", SinhVien.SoSanhTen(listSV[sinhVien].Ten, listSV[sinhVien2].Ten));
                        }
                        break;
                    case 3:
                        {
                            foreach (var item in listSV)
                            {
                                Console.WriteLine("\nThong tin sinh vien thu {0}", listSV.IndexOf(item));
                                item.Output();
                            }
                            Console.WriteLine("Chon 2 sinh vien can so sanh lop");
                            Console.WriteLine("Sinh vien A: ");
                            int sinhVien = int.Parse(Console.ReadLine());
                            Console.WriteLine("Sinh vien B: ");
                            int sinhVien2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Tra ve : {0}", SinhVien.SoSanhTen(listSV[sinhVien].Lop, listSV[sinhVien2].Lop));
                        }
                        break;
                    case 4:
                        {
                            SinhVien.QuickSortMethodSinhVienTen(ref listSV, 0, listSV.Count - 1);
                            foreach (var item in listSV)
                            {
                                item.Output();
                            }
                        }
                        break;
                    case 5:
                        {
                            SinhVien.QuickSortMethodSinhVienLop(ref listSV, 0, listSV.Count - 1);
                            foreach (var item in listSV)
                            {
                                item.Output();
                            }
                        }
                        break;
                }
            }
        }
    }
}