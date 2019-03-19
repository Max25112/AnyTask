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
        private static void swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public static bool IsSorted(int[] array)
        {
            var len = array.Length;
            if (len == 0 || len == 1) return true;
            var num = 0;
            var rand = new Random();

            for (var i = 0; i <= 8; i++)
            {
                var x = rand.Next(0, len - 1);
                if (array[x] < array[x + 1])
                {
                    num++;
                    if (len >= num) break;
                }
            }
            return len >= num || num <= 8;
        }

        static void Sort(int[] array, int begin, int end)
        {
            if (end == begin) return;
            var pivot = array[end];
            var storeIndex = begin;
            for (int i = begin; i <= end - 1; i++)
            {
                if (array[i] <= pivot)
                {
                    swap(ref array[i], ref array[storeIndex]);
                    storeIndex++;
                }
            }

            swap(ref array[storeIndex], ref array[end]);

            if (storeIndex > begin) Sort(array, begin, storeIndex - 1);
            if (storeIndex < end) Sort(array, storeIndex + 1, end);
        }
        static void QuickSortTwoTables(int[] array, object[] array2, int begin, int end)
        {
            if (end == begin) return;
            var pivot = array[end];
            var storeIndex = begin;
            for (int i = begin; i <= end - 1; i++)
            {
                if (array[i] <= pivot)
                {
                    swap(ref array[i], ref array[storeIndex]);
                    swap(ref array2[i], ref array2[storeIndex]);
                    storeIndex++;
                }
            }

            swap(ref array[storeIndex], ref array[end]);
            swap(ref array2[storeIndex], ref array2[end]);

            if (storeIndex > begin) QuickSortTwoTables(array, array2, begin, storeIndex - 1);
            if (storeIndex < end) QuickSortTwoTables(array, array2, storeIndex + 1, end);
        }
        public static void QuickSortTwoTables(int[] array, object[] array2)
        {
            var len = array.Length;
            QuickSortTwoTables(array, array2, 0, len == 0 ? len : len - 1);
        }
    }
}
