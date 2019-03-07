using System;
using System.Runtime.CompilerServices;

namespace DSA
{
    public class Shaker
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static void ShakerSort(int[] a)
        {
            int left, right, k;

            left = 0;
            right = a.Length - 1;
            k = a.Length - 1;

            while (left < right)
            {
                for (int i = right; i > left; i--)
                {
                    if (a[i] < a[i - 1])//Nếu giảm dần là if (a[i] > a[i - 1])
                    {
                        Swap(ref a[i], ref a[i - 1]);
                        k = i;
                    }
                }
                left = k;

                for (int i = left; i < right; i++)
                {
                    if (a[i] > a[i + 1]) //Nếu giảm dần là if (a[i] < a[i - 1])
                    {
                        Swap(ref a[i],ref a[i + 1]);
                        k = i;
                    }
                }
                right = k;
            }
        }

    }

    public class BaiShake
    {
        public BaiShake()
        {
            int[]a=new int[7];
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Nhap so :");
                a[i] = int.Parse(Console.ReadLine());
            }
            Shaker.ShakerSort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ",a[i]);
            }
            Console.WriteLine();
        }
    }

}