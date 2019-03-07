/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết thành chương trình:
•	Nhập biểu thức từ bàn phím
•	In ra màn hình biểu thức dạng hậu tố
•	Tính kết quả của biểu thức
 */
using System;
using System.Runtime.InteropServices;

namespace DSA
{
    public class Bai26b
    {
        public Bai26b()
        {
            try
            {
                string ketQuaHauTo = MidtoPosfix();
                if (ketQuaHauTo!= "\nBieu thuc sai")
                {
                    Console.WriteLine("\nBieu thuc sau khi chuyen thanh danh hau to");
                    Console.WriteLine(ketQuaHauTo);
                    SolvePosfix(ketQuaHauTo);
                }
                else
                {
                    Console.WriteLine(ketQuaHauTo);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("\nSyntax error");
            }

        }

        public string MidtoPosfix()
        {
            Stack<string> a = new Stack<string>();
            string ketQuaHauTo = "";
            string tokken;
            Console.Write("Nhap vao bieu thuc: ");
            string nhap = Console.ReadLine();
            nhap = nhap.Trim();
            string s = "";
            for (int i = 0; i < nhap.Length; i++)
            {
                if (nhap[i]!=' ')
                {
                    s += nhap[i];
                } 
            }
            int demMoNgoac = 0;
            int demDongNgoac = 0;
            int demToanTu = 0;
            int demToanHang = 0;
            for (int i = 0; i < s.Length;)
            {
                GetTokken(s, out tokken, ref i);
                if (tokken[0]=='(')
                {
                    demMoNgoac++;
                }
                else if (tokken[0] == ')')
                {
                    demDongNgoac++;
                }
                else if (LaToanTu(tokken[0]))
                {
                    demToanTu++;
                }
                else
                {
                    demToanHang++;
                }
            }
            if (demDongNgoac == demMoNgoac && demToanHang - 1 == demToanTu)
            {
                for (int i = 0; i < s.Length;)
                {
                    GetTokken(s, out tokken, ref i);
                    if (!LaToanTu(tokken[0]))
                    {
                        ketQuaHauTo += tokken + " ";
                    }
                    else
                    {
                        if (tokken[0] == '(')
                        {
                            a.Push(tokken);
                        }
                        else if (tokken[0] == ')')
                        {
                            while (a.Top()[0] != '(')
                            {
                                ketQuaHauTo += a.Top() + " ";
                                a.Pop();
                            }
                            if (a.Top()[0] == '(')
                            {
                                a.Pop();
                            }
                        }
                        else
                        {
                            if (!a.IsEmpty() && DoUuTien(a.Top()[0]) < DoUuTien(tokken[0]))
                            {
                                a.Push(tokken);
                                continue;
                            }
                            else if (a.IsEmpty())
                            {
                                a.Push(tokken);
                                continue;
                            }
                            while (!a.IsEmpty() && DoUuTien(a.Top()[0]) >= DoUuTien(tokken[0]))
                            {
                                ketQuaHauTo += a.Top() + " ";
                                a.Pop();
                            }
                            a.Push(tokken);
                        }
                    }
                }
                while (!a.IsEmpty())
                {
                    if (a.Top()[0] == '(')
                    {
                        a.Pop();
                        continue;
                    }
                    ketQuaHauTo += a.Top() + " ";
                    a.Pop();

                }
                return ketQuaHauTo;
            }
            else
            {
                return "\nBieu thuc sai";
            }
        }

        public void SolvePosfix(string posfix)
        {
            string[] containValues = posfix.Split(' ');
            Stack<string> containResult = new Stack<string>();
            for (int i = 0; i < containValues.Length - 1; i++)
            {
                if (!LaToanTu(containValues[i][0]))
                {
                    containResult.Push(containValues[i]);
                }
                else
                {
                    string a = containResult.Top();
                    containResult.Pop();
                    string b = containResult.Top();
                    containResult.Pop();
                    containResult.Push(Calculate(containValues[i], b, a));
                }
            }
            double kq = Convert.ToDouble(containResult.Top());
            Console.WriteLine("\nKet qua cua bieu thuc la {0:0.00}", kq);
        }

        public string Calculate(string toanTu, string toanHang, string toanHang2)
        {
            double a = Convert.ToDouble(toanHang);
            double b = Convert.ToDouble(toanHang2);
            if (toanTu[0] == '+')
            {
                return Convert.ToString(a + b);
            }
            else if (toanTu[0] == '-')
            {
                return Convert.ToString(a - b);
            }
            else if (toanTu[0] == '*')
            {
                return Convert.ToString(a * b);
            }
            else if (toanTu[0] == '/' && b != 0)
            {
                return Convert.ToString(a / b);
            }
            return "?";
        }
        public void GetTokken(string chuoiNhap, out string tokken, ref int start)
        {
            tokken = "";
            for (; start < chuoiNhap.Length; start++)
            {
                if (LaToanTu(chuoiNhap[start]))
                {
                    if (tokken == "")
                    {
                        tokken += chuoiNhap[start];
                        start++;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    tokken += chuoiNhap[start];
                }
            }
        }
        public int DoUuTien(char a)
        {
            if (a == '+' || a == '-')
            {
                return 1;
            }
            else if (a == '*' || a == '/')
            {
                return 2;
            }
            return 0;
        }
        public bool LaToanTu(char a)
        {
            if (a == '+' || a == '-' || a == '*' || a == '/' || a == '(' || a == ')')
            {
                return true;
            }
            return false;
        }
    }
}