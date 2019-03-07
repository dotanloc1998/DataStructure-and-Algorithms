/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài :Cài đặt CTDL List dùng cho kiểu dữ liệu trừu tượng:
•	Sử dụng mảng động
•	Cài đặt các phép toán: khởi tạo, hủy, thêm phần tử, xóa phần tử, thêm một danh sách phần tử, xuất danh sách

 */
using System;
using System.Collections.Generic;

namespace DSA
{
    public class ListBai20<T>
    {
        public T[] A { get; set; }
        public ListBai20()
        {
            A = new T[0];
        }

        public ListBai20(int n)
        { 
            A=new T[n];
        }
        public void HuyList()
        {
            A = new T[0];
        }

        public ListBai20<T> AddListBai20(T giaTri)
        {
            ListBai20<T> b = new ListBai20<T>(A.Length + 1);
            for (int i = 0; i < b.A.Length-1; i++)
            {
               b.GanGiaTri(i,A[i]);
            }
            b.GanGiaTri(b.A.Length - 1,giaTri);
            return b;
        }
        public void GanGiaTri(int viTri, T giaTri)
        {
            A[viTri] = giaTri;
        }
        public T Xuat(int viTri)
        {
            return A[viTri];
        }
        public void XuatList()
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("Phan tu thu {0} la {1}", i, Xuat(i));
            }
        }
        public ListBai20<T> ThemVaoViTri(int viTri, T giaTri)
        {
            ListBai20<T> b = new ListBai20<T>(A.Length + 1);
            bool daGan = false;
            for (int i = 0; i < A.Length + 1; i++)
            {
                if (daGan)
                {
                    b.GanGiaTri(i, A[i - 1]);
                    
                }
                else
                {
                    
                    b.GanGiaTri(i, A[i]);
                    if (i == viTri)
                    {
                        b.GanGiaTri(viTri, giaTri);
                        daGan = true;
                    }
                }
            }
            return b;
        }
        public ListBai20<T> XoaPhanTuTheoViTri(int viTri)
        {
            ListBai20<T> b = new ListBai20<T>(A.Length - 1);
            bool daXoa = false;
            for (int i = 0; i < b.A.Length; i++)
            {
                if (daXoa)
                {
                    
                    b.GanGiaTri(i, A[i + 1]);
                }
                else
                {
                    
                    b.GanGiaTri(i, A[i]);
                    if (i == viTri)
                    {
                        
                        b.GanGiaTri(viTri, A[i + 1]);
                        daXoa = true;
                    }
                }
            }
            return b;
        }

        public int TimPhanTu(string ten)
        {
            int viTri = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i].ToString()==ten)
                {
                    viTri = i;
                    return viTri;
                }
            }
            return viTri;
        }
        public ListBai20<T> XoaPhanTuTheoTen(string ten)
        {
            int viTri = TimPhanTu(ten);
            if (viTri!=-1)
            {
                ListBai20<T> b = new ListBai20<T>(A.Length - 1);
                bool daXoa = false;
                for (int i = 0; i < b.A.Length; i++)
                {
                    if (daXoa)
                    {

                        b.GanGiaTri(i, A[i + 1]);
                    }
                    else
                    {
                        b.GanGiaTri(i, A[i]);
                        if (i==viTri)
                        {
                            b.GanGiaTri(i, A[i + 1]);
                            daXoa = true;
                        }
                    }

                }
                return b;
            }
            else
            {
                ListBai20<T> b = new ListBai20<T>(A.Length);
                for (int i = 0; i < b.A.Length; i++)
                {
                    b.GanGiaTri(i, A[i]);
                }
                return b;
            }
        }

        public ListBai20<T> ThemMangMoi(ListBai20<T> b)
        {
            ListBai20<T> c = new ListBai20<T>(A.Length + b.A.Length);
            {
                for (int i = 0; i < A.Length; i++)
                {
                    c.GanGiaTri(i, A[i]);
                   
                }
                for (int i = 0; i < b.A.Length; i++)
                {
                    
                    c.GanGiaTri(A.Length + i, b.Xuat(i));
                }
                return c;
            }
        }
    }
}