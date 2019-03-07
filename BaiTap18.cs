/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt CTDL ListInt dùng để chứa các số nguyên, trong đó:
•	Sử dụng mảng tĩnh
•	Cài đặt các phép toán: khởi tạo, hủy, thêm phần tử, xóa phần tử, thêm một danh sách phần tử, xuất danh sách

 */
using System;
using System.Collections.Generic;

namespace DSA
{
    public class ArrayBai18
    {
        public int N { get; set; }
        public int[] A { get; set; }
        public ArrayBai18(int n)
        {
            N = n;
            A = new int[N];
        }

        public void Nhap(int viTri, int giaTri)
        {
            A[viTri] = giaTri;
        }

        public int Xuat(int viTri)
        {
            return A[viTri];
        }

        public void XoaMang()
        {
            A = new int[A.Length];
        }

        public ArrayBai18 ThemPhanTu(int viTri, int giaTri)
        {
            ArrayBai18 b = new ArrayBai18(A.Length + 1);
            bool daGan = false;
            for (int i = 0; i < b.A.Length; i++)
            {
                if (daGan)
                {
                    b.Nhap(i, A[i - 1]);
                    //b[i] = A[i - 1];
                }
                else
                {
                    //b[i] = A[i];
                    b.Nhap(i, A[i]);
                    if (i == viTri)
                    {
                        b.Nhap(viTri, giaTri);
                        daGan = true;
                    }
                }
            }
            return b;
        }
        public int TimPhanTu(int so)
        {
            int viTri = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i]== so)
                {
                    viTri = i;
                    return viTri;
                }
            }
            return viTri;
        }
        public ArrayBai18 XoaPhanTuTheoGiaTri(int so)
        {
            int viTri = TimPhanTu(so);
            if (viTri != -1)
            {
                ArrayBai18 b = new ArrayBai18(A.Length - 1);
                bool daXoa = false;
                for (int i = 0; i < b.A.Length; i++)
                {
                    if (daXoa)
                    {

                        b.Nhap(i, A[i + 1]);
                    }
                    else
                    {
                        b.Nhap(i, A[i]);
                        if (i == viTri)
                        {
                            b.Nhap(i, A[i + 1]);
                            daXoa = true;
                        }
                    }

                }
                return b;
            }
            else
            {
                ArrayBai18 b = new ArrayBai18(A.Length);
                for (int i = 0; i < b.A.Length; i++)
                {
                    b.Nhap(i, A[i]);
                }
                return b;
            }
        }
        public ArrayBai18 XoaPhanTu(int viTri)
        {
            ArrayBai18 b = new ArrayBai18(A.Length-1);
            bool daXoa = false;
            for (int i = 0; i < b.A.Length; i++)
            {
                if (daXoa)
                {
                    
                    b.Nhap(i, A[i + 1]);
                }
                else
                {
                    
                    b.Nhap(i, A[i]);
                    if (i == viTri)
                    {
                        
                        b.Nhap(viTri, A[i + 1]);
                        daXoa = true;
                    }
                }
            }
            return b;
        }

        public ArrayBai18 ThemMangMoi(ArrayBai18 b)
        {
            ArrayBai18 c = new ArrayBai18(A.Length + b.A.Length);
            {
                for (int i = 0; i < A.Length; i++)
                {
                    c.Nhap(i, A[i]);
                    //c[i] = A[i];
                }
                for (int i = 0; i < b.A.Length; i++)
                {
                    //c[A.Length + 1 + i] = b[i];
                    c.Nhap(A.Length+i, b.Xuat(i));
                }
                return c;
            }
        }

        public void XuatDanhSach()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("Phan tu thu {0} co gia tri la {1} ",i,A[i]);
            }
            Console.WriteLine();
        }
    }

    public class Bai18
    {
        public Bai18()
        {

        }
    }

}