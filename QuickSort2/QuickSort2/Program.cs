using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace QuickSort2
{
    public class Program
    {
        public static  void QuickSort(int[] ar)
        {
            if (ar.Length > 1) QuickSort(ar, 0, ar.Length - 1);
        }

        public static void QuickSort(int[] ar, int left, int right)
        {
            if (left == right) return;
            int i = left + 1;
            int j = right;
            int pivot = ar[left];
            while (i < j)
            {
                if (ar[i] <= pivot) i++;
                else if (ar[j] > pivot) j--;
                else
                {
                    int m = ar[i]; ar[i] = ar[j]; ar[j] = m;
                }
            }

            if (ar[j] <= pivot)
            {
                int m = ar[left]; ar[left] = ar[right]; ar[right] = m;
                QuickSort(ar, left, right - 1);
            }
            else
            {
                QuickSort(ar, left, i - 1);
                QuickSort(ar, i, right);
            }
        }
        static Random random = new Random();
        public static int[] GenerateArray(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, 1000);
            return array;
        }
        static void Main(string[] args)
        {
            var array = GenerateArray(10000);
            QuickSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("[" + i + "]=" + array[i]);
            }
            Console.ReadKey();
        }
    }
}
