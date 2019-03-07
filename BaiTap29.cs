/*
 * Họ Tên : Đỗ Tấn Lộc
 * MSSV : 16DH110351
 * Đề bài : Chuyển đổi cây AVL trong bài 28 thành cây AVL sử dụng kiểu dữ liệu trừu tượng.
 */
using System;

namespace DSA
{
    public class AVLTreeBai29<T>
    {

        public class Node
        {
            public T data;
            public int balance;
            public Node left, right;
            public Node(T a)
            {
                data = a;
                left = right = null;
            }

            public Node()
            {

            }
        }
        private Node root;
        public AVLTreeBai29()
        {
            root = null;
        }
        public void DestroyBai29()
        {
            root = null;
        }

        //Hàm dùng để so sánh các giá trị trừu tượng
        private double CompareToBai29(T a, T b)
        {
            if (a is char)
            {
                return Convert.ToDouble(a) - Convert.ToDouble(b);
            }
            else if (a is string)
            {
                string c = a.ToString();
                string d = b.ToString();
                double doubleA = 0;
                double doubleB = 0;
                for (int i = 0; i <c.Length ; i++)
                {
                    doubleA += Convert.ToInt32(c[i]);
                }
                for (int i = 0; i < d.Length; i++)
                {
                    doubleB += Convert.ToInt32(d[i]);
                }
                return doubleA - doubleB;
            }
            else
            {
                return Convert.ToDouble(a) - Convert.ToDouble(b);
            }
        }
        //Hàm đo chiều cao của cây
        private int HeightMeasureBai29(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(HeightMeasureBai29(node.left), HeightMeasureBai29(node.right)) + 1;
            }
        }

        //Hàm tính giá trị cân bằng
        private int BalanceCalculatorValueBai29(Node node)
        {
            int conPhai = HeightMeasureBai29(node.right);
            int conTrai = HeightMeasureBai29(node.left);
            return conPhai - conTrai;
        }

        /*Hàm này ra đời vì mục đích copy giá trị của node trên cây ra các node 
        tạm rồi thao tác trên các node tạm đó sau đó gán lại các giá trị vào node thuộc cây tránh trường hợp thao tác trực tiếp các node thuộc cây*/
        private void CopyNodeValuesBai29(ref Node copied, Node original)
        {
            copied.data = original.data;
            copied.balance = original.balance;
            copied.left = original.left;
            copied.right = original.right;
        }

        /*Hàm xoay cây */
        private void AdjustTreeBai29(ref Node node)
        {

            if (node.balance == 2 && node.right.balance == 1 || node.balance == 2 && node.right.balance == 0)
            {
                /*Biến node là một biến thuộc cây tác động vào biến này sẽ tác động được vào this.AVLTree vì thế ta copy 
                 * các giá trị ra các node tạm rồi thao tác trong các node tạm đó */
                Node a = new Node();
                CopyNodeValuesBai29(ref a, node);
                Node b = new Node();
                CopyNodeValuesBai29(ref b, node.right);
                /*Thao tác xoay trên node tạm*/
                a.right = b.left;
                b.left = a;
                /*Gán lại giá trị vào node thuộc cây để tác động làm thay đổi cây*/
                CopyNodeValuesBai29(ref node, b);

            }
            else if (node.balance == -2 && node.left.balance == -1 || node.balance == -2 && node.left.balance == 0)
            {
                /*Tương tự như trên*/
                Node a = new Node();
                CopyNodeValuesBai29(ref a, node);
                Node b = new Node();
                CopyNodeValuesBai29(ref b, node.left);
                a.left = b.right;
                b.right = a;
                CopyNodeValuesBai29(ref node, b);
            }
            else if (node.balance == 2 && node.right.balance == -1 && node.right.left.balance == -1 || node.balance == 2 && node.right.balance == -1 && node.right.left.balance == 0 || node.balance == 2 && node.right.balance == -1 && node.right.left.balance == 1)
            {
                /*Tương tự như trên*/
                Node a = new Node();
                Node b = new Node();
                Node c = new Node();
                CopyNodeValuesBai29(ref a, node);
                CopyNodeValuesBai29(ref b, node.right);
                CopyNodeValuesBai29(ref c, b.left);
                a.right = c.left;
                b.left = c.right;
                c.left = a;
                c.right = b;
                CopyNodeValuesBai29(ref node, c);
            }
            else
            {
                /*Tương tự như trên*/
                Node a = new Node();
                Node b = new Node();
                Node c = new Node();
                CopyNodeValuesBai29(ref a, node);
                CopyNodeValuesBai29(ref b, node.left);
                CopyNodeValuesBai29(ref c, b.right);
                a.left = c.right;
                b.right = c.left;
                c.right = a;
                c.left = b;
                CopyNodeValuesBai29(ref node, c);
            }
        }

        public void InsertBai29(T a)
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
                    if (CompareToBai29(a, run.data) > 0) run = run.right;
                    else if (CompareToBai29(a, run.data) < 0) run = run.left;
                    else run = null;
                }
                if (CompareToBai29(a, pre.data) > 0) pre.right = add;
                else if (CompareToBai29(a, pre.data) < 0) pre.left = add;
                else return;
            }
            /*Mỗi lần thêm vào một giá trị mới vào cây ta tính lại hết giá trị balance trên đường từ gốc đến node vừa được thêm vào*/
            BalanceFinderBai29(ref root, add);
            /*Ta kiểm tra xem có node nào bị mất cân bằng vào thực hiện thao tác xoay tại node đó*/
            CheckBalanceBai29(add);
        }

        /*Hàm gán giá trị balance kiếm được vào "node.balance" */
        private void BalanceFinderBai29(ref Node node, Node added)
        {
            Node run = node;
            while (run != null)
            {
                run.balance = BalanceCalculatorValueBai29(run);
                if (CompareToBai29(added.data, run.data) > 0) run = run.right;
                else run = run.left;
            }
        }

        /*Hàm kiểm tra xem node có cân bằng không*/
        private void CheckBalanceBai29(Node added)
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
                if (CompareToBai29(added.data, run.data) > 0) run = run.right;
                else run = run.left;
            }

            /*Nêu có node nào bị mất cân bằng sẽ chạy điều kiện này */
            if (imbalancenode != null)
            {
                AdjustTreeBai29(ref imbalancenode);
            }
        }

        /*Hàm kiểm tra dành cho hàm xóa node*/
        private void CheckBalanceForDeleteMethodBai29(Node added)
        {
            Node run = root;
            Node imbalancenode = null;
            while (run != null)
            {
                if (run.balance != -1 && run.balance != 0 && run.balance != 1)
                {
                    imbalancenode = run;
                }
                if (CompareToBai29(added.data, run.data) > 0) run = run.right;
                else run = run.left;
            }
            if (imbalancenode != null)
            {
                AdjustTreeBai29(ref imbalancenode);
            }
        }

        private Node SearchBai29(Node a, T x)
        {
            if (a == null)
            {
                return null;
            }
            if (CompareToBai29(a.data, x) == 0)
            {
                return a;
            }
            if (CompareToBai29(x, a.data) > 0)
            {
                return SearchBai29(a.right, x);
            }
            return SearchBai29(a.left, x);
        }

        public bool SearchTBai29(T x)
        {
            if (SearchBai29(root, x) != null)
            {
                return true;
            }
            return false;
        }

        private void NLRBai29(Node a)
        {
            if (a != null)
            {
                Console.Write(a.data + " ");
                NLRBai29(a.left);
                NLRBai29(a.right);
            }
        }

        public void DuyetTheoMuc()
        {
            NLRBai29(root);
        }

        // Xóa đi một Node coi như thằng trước nó mới được thêm vào
        //Chạy từ root đến "Node trước Node đã xóa"
        public void DeleteNodeBai29(T a)
        {
            if (root == null) Console.WriteLine("Empty Tree");
            else
            {
                if (SearchTBai29(a))
                {
                    Node run = root;
                    Node pre = null;
                    while (CompareToBai29(run.data, a) != 0)
                    {
                        pre = run;
                        if (CompareToBai29(a, run.data) > 0) run = run.right;
                        else run = run.left;
                    }
                    Node condition = run;
                    if (condition.left == null && condition.right == null)
                    {
                        run = root;
                        pre = null;
                        while (CompareToBai29(run.data, a) != 0)
                        {
                            pre = run;
                            if (CompareToBai29(a, run.data) > 0) run = run.right;
                            else run = run.left;
                        }
                        if (CompareToBai29(a, pre.data) > 0) pre.right = null;
                        else pre.left = null;
                        BalanceFinderBai29(ref root, condition);//Gan lai gia tri can bang
                        CheckBalanceForDeleteMethodBai29(condition);//Kiem tra va xoay
                    }
                    else if (condition.left == null && condition.right != null || condition.right == null && condition.left != null)
                    {
                        if (condition == pre.left)
                        {
                            if (condition.left != null)
                            {
                                pre.left = condition.left;
                                BalanceFinderBai29(ref root, condition);
                                CheckBalanceForDeleteMethodBai29(condition);
                            }

                            else
                            {
                                pre.left = condition.right;
                                BalanceFinderBai29(ref root, condition);
                                CheckBalanceForDeleteMethodBai29(condition);
                            }
                        }
                        else
                        {
                            if (condition.left != null)
                            {
                                pre.right = condition.left;
                                BalanceFinderBai29(ref root, condition);
                                CheckBalanceForDeleteMethodBai29(condition);
                            }
                            else
                            {
                                pre.right = condition.right;
                                BalanceFinderBai29(ref root, condition);
                                CheckBalanceForDeleteMethodBai29(condition);
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
                            BalanceFinderBai29(ref root, condition);
                            CheckBalanceForDeleteMethodBai29(condition);
                        }
                        else
                        {
                            run = condition.left;
                            run.right = condition.right;
                            CopyNodeValuesBai29(ref condition, run);
                            BalanceFinderBai29(ref root, condition);
                            CheckBalanceForDeleteMethodBai29(condition);
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
    }

    public class Bai29
    {
        public Bai29()
        {
            //AVLTreeBai29<double> a = new AVLTreeBai29<double>();
            //a.InsertBai29(7);
            //a.InsertBai29(6.2);
            //a.InsertBai29(3.8);
            //a.InsertBai29(4.9);
            //a.InsertBai29(5.3);
            //a.InsertBai29(6.9);
            //a.InsertBai29(10.8);
            //a.InsertBai29(12.7);
            //a.InsertBai29(1.5);
            //a.InsertBai29(2.9);
            //a.Print(-1);
            //Console.WriteLine();

            AVLTreeBai29<string> b = new AVLTreeBai29<string>();
            b.InsertBai29("Cong");
            b.InsertBai29("thuc");
            b.InsertBai29("cua");
            b.InsertBai29("su");
            b.InsertBai29("chien");
            b.InsertBai29("thang");
            b.InsertBai29("da");
            b.InsertBai29("duoc");
            b.InsertBai29("xac");
            b.InsertBai29("dinh");

            
            b.Print(-1);
            Console.WriteLine();


            //a.DeleteNodeBai29(1.5);
            //a.Print(-1);
            //Console.WriteLine();


            //a.DeleteNodeBai29(2.9);
            //a.Print(-1);
            //Console.WriteLine();

            //a.DeleteNodeBai29(3.8);
            //a.Print(-1);
            //Console.WriteLine();


            //a.DeleteNodeBai29(5.3);
            //a.Print(-1);
            //Console.WriteLine();

            //a.InsertBai29(7);
            //a.InsertBai29(6);
            //a.InsertBai29(3);
            //a.InsertBai29(4);
            //a.InsertBai29(5);
            //a.InsertBai29(10);
            //a.InsertBai29(12);
            //a.InsertBai29(1);
            //a.InsertBai29(2);
            //a.DuyetTheoMuc();
            //Console.WriteLine();
        }
    }

}