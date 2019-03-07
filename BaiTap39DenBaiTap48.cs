/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Viết hàm đếm số node lá có khóa chẵn của cây nhị phân
            Viết hàm đếm số node lá có khóa lẻ của cây nhị phân
            Viết hàm tính tổng các khóa chẵn của cây nhị phân
            Viết hàm tính tổng các khóa lẻ của cây nhị phân
            Viết hàm đếm số node có khóa lớn hơn 5 trong cây nhị phân
            Viết hàm đếm số node có khóa nhỏ hơn 0 trong cây nhị phân
            Viết hàm đếm số node giữa chứa khóa chẵn trong cây nhị phân
            Viết hàm tính tổng các khóa lẻ của các node giữa trong cây nhị phân
            Viết hàm đếm số node giữa chứa khóa lẻ của cây nhị phân
            Viết hàm in ra các khóa lớn hơn k của cây nhị phân tìm kiếm theo thứ tự giảm dần
 */
using System;

namespace DSA
{
    public class BinTreeBai39
    {
        public class TNode
        {
            public int data;
            public TNode left;
            public TNode right;

            public TNode(int giaTri)
            {
                data = giaTri;
                left = right = null;
            }
        }
        private TNode root;
        public BinTreeBai39()
        {
            root = null;
        }
        public void Insert(int a)
        {
            TNode current = new TNode(a);
            if (root == null) root = current;
            else
            {
                TNode run = root;
                TNode pre = null;
                while (run != null)
                {
                    pre = run;
                    if (a > run.data) run = run.right;
                    else run = run.left;
                }
                if (a > pre.data) pre.right = current;
                else pre.left = current;
            }
        }


        //Hàm đếm số node lá có khóa chẵn của cây nhị phân
        private int DemNodeLaChan(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (node.data % 2 == 0 && node.left == null && node.right == null)
                {
                    sum++;
                    sum += DemNodeLaChan(node.right);
                    sum += DemNodeLaChan(node.left);
                    return sum;
                }
                return DemNodeLaChan(node.right) + DemNodeLaChan(node.left);
            }
            return 0;
        }
        public int DemNodeLaChan()
        {
            return DemNodeLaChan(root);
        }
        //Hàm đếm số node lá có khóa lẻ của cây nhị phân
        private int DemNodeLaLe(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (node.data % 2 != 0 && node.left == null && node.right == null)
                {
                    sum++;
                    sum += DemNodeLaLe(node.right);
                    sum += DemNodeLaLe(node.left);
                    return sum;
                }
                return DemNodeLaLe(node.right) + DemNodeLaLe(node.left);
            }
            return 0;
        }
        public int DemNodeLaLe()
        {
            return DemNodeLaLe(root);
        }
        //Hàm tính tổng các khóa chẵn của cây nhị phân
        private int TinhTongCuaKhoaChan(TNode node)
        {

            if (node != null)
            {
                int sum = 0;
                if (node.data % 2 == 0)
                {
                    sum += node.data;
                    sum += TinhTongCuaKhoaChan(node.right);
                    sum += TinhTongCuaKhoaChan(node.left);
                    return sum;
                }
                //return TinhTongCuaKhoaChan(node.right) + TinhTongCuaKhoaChan(node.left); Hoac la ghi cach nay

                // Hoac la cach nay 
                // Day la dieu kien de cho De Qui chay tiep khi khong dung dieu kien
                else
                {
                    sum += TinhTongCuaKhoaChan(node.right);
                    sum += TinhTongCuaKhoaChan(node.left);
                    return sum;
                }
            }
            return 0;
        }
        public int TinhTongCuaKhoaChan()
        {
            return TinhTongCuaKhoaChan(root);
        }
        //Hàm tính tổng các khóa lẻ của cây nhị phân
        private int TinhTongCuaKhoaLe(TNode node)
        {

            if (node != null)
            {
                int sum = 0;
                if (node.data % 2 != 0)
                {
                    sum += node.data;
                    sum += TinhTongCuaKhoaLe(node.right);
                    sum += TinhTongCuaKhoaLe(node.left);
                    return sum;
                }
                //return TinhTongCuaKhoaLe(node.right) + TinhTongCuaKhoaLe(node.left); Hoac la ghi cach nay

                // Hoac la cach nay 
                // Day la dieu kien de cho De Qui chay tiep khi khong dung dieu kien
                else
                {
                    sum += TinhTongCuaKhoaLe(node.right);
                    sum += TinhTongCuaKhoaLe(node.left);
                    return sum;
                }
            }
            return 0;
        }
        public int TinhTongCuaKhoaLe()
        {
            return TinhTongCuaKhoaLe(root);
        }
        //Hàm đếm số node có khóa lớn hơn 5 trong cây nhị phân
        private int DemNodeCoKhoaLonHon5(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (node.data > 5)
                {
                    sum++;
                    sum += DemNodeCoKhoaLonHon5(node.right);
                    sum += DemNodeCoKhoaLonHon5(node.left);
                    return sum;
                }
                return DemNodeCoKhoaLonHon5(node.right) + DemNodeCoKhoaLonHon5(node.left);
            }
            return 0;
        }
        public int DemNodeCoKhoaLonHon5()
        {
            return DemNodeCoKhoaLonHon5(root);
        }
        //Hàm đếm số node có khóa nhỏ hơn 0 trong cây nhị phân
        private int DemNodeCoKhoaNhoHon0(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (node.data < 0)
                {
                    sum++;
                    sum += DemNodeCoKhoaNhoHon0(node.right);
                    sum += DemNodeCoKhoaNhoHon0(node.left);
                    return sum;
                }
                return DemNodeCoKhoaNhoHon0(node.right) + DemNodeCoKhoaNhoHon0(node.left);
            }
            return 0;
        }
        public int DemNodeCoKhoaNhoHon0()
        {
            return DemNodeCoKhoaNhoHon0(root);
        }
        //Hàm đếm số node giữa chứa khóa chẵn trong cây nhị phân
        private int DemNodeChanGiua(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (!(node.right == null && node.left == null) && node.data % 2 == 0)
                {
                    sum++;
                    sum += DemNodeChanGiua(node.left);
                    sum += DemNodeChanGiua(node.right);
                    return sum;
                }
                return DemNodeChanGiua(node.left) + DemNodeChanGiua(node.right);
            }
            return 0;
        }
        public int DemNodeChanGiua()
        {
            if (root.data % 2 == 0)
            {
                return DemNodeChanGiua(root) - 1;
            }
            return DemNodeChanGiua(root);
        }
        //Hàm tính tổng các khóa lẻ của các node giữa trong cây nhị phân
        private int TongNodeLeGiua(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (!(node.right == null && node.left == null) && node.data % 2 != 0)
                {
                    sum += node.data;
                    sum += TongNodeLeGiua(node.left);
                    sum += TongNodeLeGiua(node.right);
                    return sum;
                }
                return TongNodeLeGiua(node.left) + TongNodeLeGiua(node.right);
            }
            return 0;
        }
        public int TongNodeLeGiua()
        {
            if (root.data % 2 != 0)
            {
                return TongNodeLeGiua(root) - root.data;
            }
            return TongNodeLeGiua(root);
        }
        //Hàm đếm số node giữa chứa khóa lẻ của cây nhị phân
        private int DemNodeLeGiua(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (!(node.right == null && node.left == null) && node.data % 2 != 0)
                {
                    sum++;
                    sum += DemNodeLeGiua(node.left);
                    sum += DemNodeLeGiua(node.right);
                    return sum;
                }
                return DemNodeLeGiua(node.left) + DemNodeLeGiua(node.right);
            }
            return 0;
        }
        public int DemNodeLeGiua()
        {
            if (root.data % 2 != 0)
            {
                return DemNodeLeGiua(root) - 1;
            }
            return DemNodeLeGiua(root);
        }
        //Hàm in ra các khóa lớn hơn k của cây nhị phân tìm kiếm theo thứ tự giảm dần
        private void RNL(TNode a, int k)
        {
            if (a != null)
            {
                RNL(a.right, k);
                if (a.data > k)
                {
                    Console.Write(a.data + " ");
                }
                RNL(a.left, k);
            }
        }
        public void DuyetKhoaGiam(int k)
        {
            RNL(root, k);
        }
        //Hàm đếm số node trong cây
        private int DemNode(TNode node)
        {
            if (node != null)
            {
                int sum = 0;
                if (true)
                {
                    sum++;
                    sum += DemNode(node.right);
                    sum += DemNode(node.left);
                    return sum;
                }
                return DemNode(node.right) + DemNode(node.left);
            }
            return 0;
        }

        public int DemNode()
        {
            return DemNode(root);
        }
        //Hàm liệt kê các Node lớn hơn 15 giảm dần
        private void LietKe(TNode a, int b)
        {
            if (a!=null)
            {
                LietKe(a.right,b);
                if (a.data>b)
                {
                    Console.Write("{0} ",a.data);
                }
                LietKe(a.left,b);
            }
        }
        public void LietKe()
        {
            LietKe(root,15);
        }
    }

    public class Bai39Den48
    {
        public Bai39Den48()
        {
            BinTreeBai39 a = new BinTreeBai39();
            a.Insert(8);
            a.Insert(4);
            a.Insert(23);
            a.Insert(92);
            a.Insert(9);
            a.Insert(6);
            a.Insert(7);
            a.Insert(15);
            a.Insert(12);
            a.Insert(16);
            a.Insert(-7);
            a.Insert(-32);
            //Console.WriteLine("So Luong Node La Chan: " + a.DemNodeLaChan());
            //Console.WriteLine("So Luong Node La Le: " + a.DemNodeLaLe());
            //Console.WriteLine("Tong Node La Chan: " + a.TinhTongCuaKhoaChan());
            //Console.WriteLine("Tong Node La Le: " + a.TinhTongCuaKhoaLe());
            //Console.WriteLine("So Luong Node La > 5: " + a.DemNodeCoKhoaLonHon5());
            //Console.WriteLine("So Luong Node La < 0: " + a.DemNodeCoKhoaNhoHon0());
            //Console.WriteLine("So Luong Node Chan Giua: " + a.DemNodeChanGiua());
            //Console.WriteLine("Tong Node Le Giua: " + a.TongNodeLeGiua());
            //Console.WriteLine("So Luong Node La Le Giua: " + a.DemNodeLeGiua());
            //Console.Write("Nhap k : ");
            //int k = int.Parse(Console.ReadLine());
            //Console.WriteLine("Cac Node > k theo thu tu giam dan");
            //a.DuyetKhoaGiam(k);
            //Console.WriteLine();
            //Console.WriteLine("So Luong Node trong cay: "+a.DemNode());
            a.LietKe();
        }
    }
}