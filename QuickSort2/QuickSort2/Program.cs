using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort2
{
    class Program
    {
        static void Swap(int a, int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }

        static public void QuickSort(int[] ar)
        {
            if (ar.Length > 1) QuickSort(ar, 0, ar.Length - 1);
        }

        static private void QuickSort(int[] ar, int left, int right)
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
        static void Main(string[] args)
        {
            var rnd = new Random();
            // rnd.Next(); // возвращает случайное число от 0 до int.MaxValue
            //int[] array = new int[100];
            int[] array = new int[] {1,2,3 };
            if (array.Length == 0)
                return;
            for (int i = 0; i < array.Length; i++)
            {
                // array[i]= rnd.Next(0, 10000);
                // array[i] =1;
            }

            QuickSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("[" + i + "]=" + array[i]);
            }
            Console.ReadKey();
        }
    }
}
