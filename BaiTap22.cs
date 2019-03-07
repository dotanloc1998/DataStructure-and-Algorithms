/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài :Cài đặt CTDL SinhVien để quản lý một sinh viên gồm có: 
 * họ tên (50 ký tự), địa chỉ (70 ký tự), lớp (10 ký tự), khóa (số nguyên). 
 * Cài đặt 4 hàm so sánh 2 sinh viên theo từng tiêu chí. Viết hàm nhập một sinh viên, hàm xuất một sinh viên.
 */
using System;

namespace DSA
{
    public class SinhVienBai22
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }

        public SinhVienBai22(string ho, string ten, string diaChi, string lop, string khoa)
        {
            Ho = ho;
            Ten = ten;
            DiaChi = diaChi;
            Lop = lop;
            Khoa = khoa;
        }

        public SinhVienBai22()
        {
            
        }
        public static bool SoSanhSVTheoTen(string tenSV, string tenSV2)
        {
            if (tenSV.CompareTo(tenSV2) >= 0)
            {
                return true;
            }
            return false;
        }

        public static bool SoSanhSVTheoDiaChi(string diaChiSV, string diaChiSv2)
        {
            if (diaChiSV.CompareTo(diaChiSv2) >= 0)
            {
                return true;
            }
            return false;
        }
        public static bool SoSanhSVTheoLop(string lopSV, string lopSv2)
        {
            if (lopSV.CompareTo(lopSv2) >= 0)
            {
                return true;
            }
            return false;
        }
        public static bool SoSanhSVTheoKhoa(string khoaSV, string khoaSV2)
        {
            if (khoaSV.CompareTo(khoaSV2) >= 0)
            {
                return true;
            }
            return false;
        }

        public void NhapSV()
        {
            Console.Write("Nhap vao ho sinh vien: ");
            Ho = Console.ReadLine();
            Console.Write("Nhap vao ten sinh vien: ");
            Ten = Console.ReadLine();
            Console.Write("Nhap vao dia chi sinh vien: ");
            DiaChi = Console.ReadLine();
            Console.Write("Nhap vao lop cua sinh vien: ");
            Lop = Console.ReadLine();
            Console.Write("Nhap vao khoa cua sinh vien: ");
            Khoa = Console.ReadLine();
        }

        public void XuatSV()
        {
            Console.WriteLine("Ho va Ten sinh vien: " + Ho + ' ' + Ten);
            Console.WriteLine("Dia chi sinh vien: " + DiaChi);
            Console.WriteLine("Lop cua sinh vien: " + Lop);
            Console.WriteLine("Khoa cua sinh vien: " + Khoa);
        }
    }

}