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

        public static void QuickSort(int[] array, int left, int right)
        {
            if (left == right) return;
            int i = left + 1;
            int j = right;
            int pivot = array[left];
            while (i < j)
            {
                if (array[i] <= pivot) i++;
                else if (array[j] > pivot) j--;
                else
                {
                    int m = array[i]; array[i] = array[j]; array[j] = m;
                }
            }

            if (array[j] <= pivot)
            {
                int m = array[left]; array[left] = array[right]; array[right] = m;
                QuickSort(array, left, right - 1);
            }
            else
            {
                QuickSort(array, left, i - 1);
                QuickSort(array, i, right);
            }
        }
        public static int[] GenerateArray(int length)
        {
            int[] array = new int[length];
            Random rand = new Random();
            for (int y = 0; y < length; y++)
            {
                array[y] = rand.Next(0, 50);
            }
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
