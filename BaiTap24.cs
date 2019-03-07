/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết thành chương trình:
•	Nhập 10 sinh viên và đưa vào danh sách
•	In danh sách ra màn hình
•	Xóa sinh viên có tên “Nguyen Van Teo” trong danh sách
•	Xóa sinh viên có địa chỉ “155 Su Van Hanh” trong danh sách
•	Thêm sinh viên có tên “Tran Thi Mo”, địa chỉ “25 Hong Bang”, lớp “TT0901”, khóa 2009 vào danh sách.
•	In danh sách ra màn hình
 */
using System;

namespace DSA
{
    public class Bai24
    {
        public Bai24()
        {
            LinkedList dSachSV = new LinkedList();
            SinhVienBai22 sv = new SinhVienBai22();

            Console.WriteLine("Nhap vao 3 sinh vien");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nNhap thong tin sinh vien {0}", i);
                sv = new SinhVienBai22();
                sv.NhapSV();
                dSachSV.AddNodeLast(sv);
            }
            //dSachSV.SelectionSortTheoTenSV(ref dSachSV);
            //Console.WriteLine();
            //dSachSV.XuatDS();
            Console.WriteLine("\nDanh sach sinh vien");
            dSachSV.XuatDS();

            Console.WriteLine("\nXoa SV co ten Nguyen Van Teo");
            dSachSV.XoaKhiBietTen(ref dSachSV, "Teo");
            Console.WriteLine("\nCap nhat danh sach");
            dSachSV.XuatDS();

            Console.WriteLine("\nXoa SV co dia chi 155 Su Van Hanh");
            dSachSV.XoaKhiBietDiaChi(ref dSachSV, "155 Su Van Hanh");
            Console.WriteLine("\nCap nhat danh sach");
            dSachSV.XuatDS();

            Console.WriteLine("\nThem sinh vien co thong tin chi dinh");
            sv = new SinhVienBai22();
            sv.NhapSV();
            dSachSV.AddNodeFirst(sv);
            Console.WriteLine("\nCap nhat danh sach");
            dSachSV.XuatDS();
        }
    }

}