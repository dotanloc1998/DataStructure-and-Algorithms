/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Cài đặt cây AVL chứa số nguyên gồm các phép toán: khởi tạo, hủy, tìm kiếm, thêm khóa, xóa khóa, duyệt khóa tăng, duyệt khóa giảm, duyệt khóa theo mức.
 */
using System;
namespace DSA
{
    public class AVLTree
    {

        public class Node
        {
            public int data;
            public int balance;
            public Node left, right;
            public Node(int a)
            {
                data = a;
                left = right = null;
            }

            public Node()
            {

            }
        }
        private Node root;
        public AVLTree()
        {
            root = null;
        }
        public void Destroy()
        {
            root = null;
        }


        //Hàm đo chiều cao của cây
        private int HeightMeasure(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(HeightMeasure(node.left), HeightMeasure(node.right)) + 1;
            }
        }

        //Hàm tính giá trị cân bằng
        private int BalanceCalculatorValue(Node node)
        {
            int conPhai = HeightMeasure(node.right);
            int conTrai = HeightMeasure(node.left);
            return conPhai - conTrai;
        }

        /*Hàm này ra đời vì mục đích copy giá trị của node trên cây ra các node 
        tạm rồi thao tác trên các node tạm đó sau đó gán lại các giá trị vào node thuộc cây tránh trường hợp thao tác trực tiếp các node thuộc cây*/
        private void CopyNodeValues(ref Node copied, Node original)
        {
            copied.data = original.data;
            copied.balance = original.balance;
            copied.left = original.left;
            copied.right = original.right;
        }

        /*Hàm xoay cây */
        private void AdjustTree(ref Node node)
        {

            if (node.balance == 2 && node.right.balance == 1 || node.balance == 2 && node.right.balance == 0)
            {
                /*Biến node là một biến thuộc cây tác động vào biến này sẽ tác động được vào this.AVLTree vì thế ta copy 
                 * các giá trị ra các node tạm rồi thao tác trong các node tạm đó */
                Node a = new Node();
                CopyNodeValues(ref a, node);
                Node b = new Node();
                CopyNodeValues(ref b, node.right);
                /*Thao tác xoay trên node tạm*/
                a.right = b.left;
                b.left = a;
                /*Gán lại giá trị vào node thuộc cây để tác động làm thay đổi cây*/
                CopyNodeValues(ref node, b);

            }
            else if (node.balance == -2 && node.left.balance == -1 || node.balance == -2 && node.left.balance == 0)
            {
                /*Tương tự như trên*/
                Node a = new Node();
                CopyNodeValues(ref a, node);
                Node b = new Node();
                CopyNodeValues(ref b, node.left);
                a.left = b.right;
                b.right = a;
                CopyNodeValues(ref node, b);
            }
            else if (node.balance == 2 && node.right.balance == -1 && node.right.left.balance == -1 || node.balance == 2 && node.right.balance == -1 && node.right.left.balance == 0 || node.balance == 2 && node.right.balance == -1 && node.right.left.balance == 1)
            {
                /*Tương tự như trên*/
                Node a = new Node();
                Node b = new Node();
                Node c = new Node();
                CopyNodeValues(ref a, node);
                CopyNodeValues(ref b, node.right);
                CopyNodeValues(ref c, b.left);
                a.right = c.left;
                b.left = c.right;
                c.left = a;
                c.right = b;
                CopyNodeValues(ref node, c);
            }
            else
            {
                /*Tương tự như trên*/
                Node a = new Node();
                Node b = new Node();
                Node c = new Node();
                CopyNodeValues(ref a, node);
                CopyNodeValues(ref b, node.left);
                CopyNodeValues(ref c, b.right);
                a.left = c.right;
                b.right = c.left;
                c.right = a;
                c.left = b;
                CopyNodeValues(ref node, c);
            }
        }
        public void Insert(int a)
        {
            Node add = new Node(a);
            if (root == null) root = add;
            else
            {
                Node run = root;
                Node pre = null;
                while (run != null)
                {
                    pre = run;
                    if (a > run.data) run = run.right;
                    else if (a < run.data) run = run.left;
                    else run = null;
                }
                if (a > pre.data) pre.right = add;
                else if (a < pre.data) pre.left = add;
                else return;
            }
            /*Mỗi lần thêm vào một giá trị mới vào cây ta tính lại hết giá trị balance trên đường từ gốc đến node vừa được thêm vào*/
            BalanceFinder(ref root, add);
            /*Ta kiểm tra xem có node nào bị mất cân bằng vào thực hiện thao tác xoay tại node đó*/
            CheckBalance(add);
        }
        /*Hàm gán giá trị balance kiếm được vào "node.balance" */
        private void BalanceFinder(ref Node node, Node added)
        {
            Node run = node;
            while (run != null)
            {
                run.balance = BalanceCalculatorValue(run);
                if (added.data > run.data) run = run.right;
                else run = run.left;
            }
        }

        /*Hàm kiểm tra xem node có cân bằng không*/
        private void CheckBalance(Node added)
        {
            Node run = root;
            Node imbalancenode = null;
            /*Dòng lặp này giúp chúng ta tìm được node mất cân bằng gần node vừa được thêm vào nhất*/
            while (run != added)
            {
                if (run.balance != -1 && run.balance != 0 && run.balance != 1)
                {
                    imbalancenode = run;
                }
                if (added.data > run.data) run = run.right;
                else run = run.left;
            }

            /*Nêu có node nào bị mất cân bằng sẽ chạy điều kiện này */
            if (imbalancenode != null)
            {
                AdjustTree(ref imbalancenode);
            }
        }

        /*Hàm kiểm tra dành cho hàm xóa node*/
        private void CheckBalanceForDeleteMethod(Node added)
        {
            Node run = root;
            Node imbalancenode = null;
            while (run != null)
            {
                if (run.balance != -1 && run.balance != 0 && run.balance != 1)
                {
                    imbalancenode = run;
                }
                if (added.data > run.data) run = run.right;
                else run = run.left;
            }
            if (imbalancenode != null)
            {
                AdjustTree(ref imbalancenode);
            }
        }
        private Node Search(Node a, int x)
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
        public bool SearchT(int x)
        {
            if (Search(root, x) != null)
            {
                return true;
            }
            return false;
        }
        private void NLR(Node a)
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
        // Xóa đi một Node coi như thằng trước nó mới được thêm vào
        //Chạy từ root đến "Node trước Node đã xóa"
        public void DeleteNode(int a)
        {
            if (root == null) Console.WriteLine("Empty Tree");
            else
            {
                if (SearchT(a))
                {
                    Node run = root;
                    Node pre = null;
                    while (run.data != a)
                    {
                        pre = run;
                        if (a > run.data) run = run.right;
                        else run = run.left;
                    }
                    Node condition = run;
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
                        BalanceFinder(ref root, condition);//Gan lai gia tri can bang
                        CheckBalanceForDeleteMethod(condition);//Kiem tra va xoay
                    }
                    else if (condition.left == null && condition.right != null || condition.right == null && condition.left != null)
                    {
                        if (condition == pre.left)
                        {
                            if (condition.left != null)
                            {
                                pre.left = condition.left;
                                BalanceFinder(ref root, condition);
                                CheckBalanceForDeleteMethod(condition);
                            }

                            else
                            {
                                pre.left = condition.right;
                                BalanceFinder(ref root, condition);
                                CheckBalanceForDeleteMethod(condition);
                            }
                        }
                        else
                        {
                            if (condition.left != null)
                            {
                                pre.right = condition.left;
                                BalanceFinder(ref root, condition);
                                CheckBalanceForDeleteMethod(condition);
                            }
                            else
                            {
                                pre.right = condition.right;
                                BalanceFinder(ref root, condition);
                                CheckBalanceForDeleteMethod(condition);
                            }
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
                            BalanceFinder(ref root, condition);
                            CheckBalanceForDeleteMethod(condition);
                        }
                        else
                        {
                            run = condition.left;
                            run.right = condition.right;
                            CopyNodeValues(ref condition, run);
                            BalanceFinder(ref root, condition);
                            CheckBalanceForDeleteMethod(condition);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Khong co trong danh sach");
                }
            }
        }

        private static void PrintTree(Node root, int muc)
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

        private void RNL(Node a)
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

        private void LNR(Node a)
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
    }

    public class Bai28
    {
        public Bai28()
        {
            AVLTree a = new AVLTree();
            a.Insert(6);
            a.Insert(2);
            a.Insert(3);
            a.Insert(1);
            a.Insert(8);
            a.Insert(4);
            a.Insert(7);
            a.Insert(5);
            a.Insert(9);
            a.Insert(0);

            a.DeleteNode(0);
            a.DeleteNode(1);
            a.Print(-1);
            Console.WriteLine();



        }
    }
}