/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt cây nhị phân tìm kiếm chứa số nguyên gồm các phép toán: khởi tạo, hủy, tìm kiếm, thêm khóa, xóa khóa, duyệt khóa tăng, duyệt khóa giảm, duyệt khóa theo mức.
 */
using System;

namespace DSA
{
    public class BinTree
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
        private void CopyNodeValues27(ref TNode copied,TNode original)
        {
            copied.data = original.data;
            copied.left = original.left;
            copied.right = original.right;
        }
        private TNode root;
        public BinTree()
        {
            root = null;
        }
        public void Destroy()
        {
            root = null;
        }
        private void NLR(TNode a)
        {
            if (a != null)
            {
                Console.Write(a.data + " ");
                NLR(a.left);
                NLR(a.right);
            }
        }
        public void DuyetTheoMuc()
        {
            NLR(root);
        }

        private void RNL(TNode a)
        {
            if (a != null)
            {
                RNL(a.right);
                Console.Write(a.data + " ");
                RNL(a.left);
            }
        }
        public void DuyetKhoaGiam()
        {
            RNL(root);
        }
        private void LNR(TNode a)
        {
            if (a != null)
            {
                LNR(a.left);
                Console.Write(a.data + " ");
                LNR(a.right);
            }
        }
        public void DuyetKhoaTang()
        {
            LNR(root);
        }

        private TNode Search(TNode a, int x)
        {
            if (a == null)
            {
                return null;
            }
            if (a.data == x)
            {
                return a;
            }
            if (x > a.data)
            {
                return Search(a.right, x);
            }
            return Search(a.left, x);
        }
        public void Search(int x)
        {
            if (Search(root, x) != null)
            {
                Console.WriteLine("Exist");
                return;
            }
            Console.WriteLine("Not Exist");

        }
        public bool SearchT(int x)
        {
            if (Search(root, x) != null)
            {
                return true;
            }
            return false;
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
                    else if (a < run.data) run = run.left;
                    else run = null;
                }
                if (a > pre.data) pre.right = current;
                else if (a < pre.data) pre.left = current;
                else return;
            }
        }
        public void DeleteTNode(int a)
        {
            if (root == null) Console.WriteLine("Empty Tree");
            else
            {
                if (SearchT(a))
                {
                    TNode run = root;
                    TNode pre = null;
                    while (run.data != a)
                    {
                        pre = run;
                        if (a > run.data) run = run.right;
                        else run = run.left;
                    }
                    TNode condition = run;
                    if (condition.left == null && condition.right == null)
                    {
                        run = root;
                        pre = null;
                        while (run.data != a)
                        {
                            pre = run;
                            if (a > run.data) run = run.right;
                            else run = run.left;
                        }
                        if (a > pre.data) pre.right = null;
                        else pre.left = null;
                    }
                    else if (condition.left == null && condition.right != null || condition.right == null && condition.left != null)
                    {
                        if (condition == pre.left)
                        {
                            if (condition.left != null)
                                pre.left = condition.left;
                            else
                                pre.left = condition.right;
                        }
                        else
                        {
                            if (condition.left != null)
                                pre.right = condition.left;
                            else
                                pre.right = condition.right;
                        }
                    }
                    else
                    {
                        if (condition.left.right != null)
                        {
                            run = condition.left;
                            while (run.right != null)
                            {
                                pre = run;
                                run = run.right;
                            }
                            condition.data = run.data;
                            pre.right = run.left;
                        }
                        else
                        {
                            run = condition.left;
                            run.right = condition.right;
                            CopyNodeValues27(ref condition , run);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Khong co trong danh sach");
                }
            }
        }
        private int HeightMeasure(TNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(HeightMeasure(node.left), HeightMeasure(node.right))+1;
            }
        }
        private static void PrintTree(TNode root, int muc)
        {
            int i;

            if (root != null)
            {
                PrintTree(root.right, muc + 1);
                for (i = 0; i <= muc; i++) Console.Write("    ");
                Console.Write("   " + root.data + "\n\n");
                PrintTree(root.left, muc + 1);
            }
        }

        public void Print(int muc)
        {
            PrintTree(root, muc);
        }

        private void RLN(TNode root)
        {
            if (root!=null)
            {
                RLN(root.right);
                RLN(root.left);
                Console.Write("{0} ", root.data);
            }
        }

        public void RLN()
        {
            RLN(root);
            Console.WriteLine();
        }
    }
    public class Bai27
    {
        public Bai27()
        {
            BinTree a = new BinTree();
            //a.Insert(43);
            //a.Insert(62);
            //a.Insert(58);
            //a.Insert(28);
            //a.Insert(61);
            //a.Insert(55);
            //a.Insert(52);
            //a.Insert(53);
            //a.Insert(13);
            //a.Insert(30);
            //a.Insert(18);
            //a.Insert(40);
            
            //a.Print(-1);
            //Console.WriteLine();

            a.Insert(12);
            a.Insert(9);
            a.Insert(15);
            a.Insert(5);
            a.Insert(10);
            a.Insert(4);
            a.Insert(7);
            a.Insert(13);
            a.Insert(19);
            a.Insert(16);
            a.Print(-1);
            Console.WriteLine();

            a.DuyetTheoMuc();
            Console.WriteLine();

            //a.Insert(6);
            //a.Insert(5);
            //a.Insert(7);
            //a.Insert(4);
            //a.DeleteTNode(6);
            //a.Print(-1);
            //Console.WriteLine();
        }
    }
}