using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void Elements1000()
        {
            var array = QuickSort2.Program.GenerateArray(1000);
            bool b = false;
            QuickSort2.Program.QuickSort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }

        [TestMethod]
        public void Elements3()
        {
            int[] array = new int[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = i + 1;
            }
            bool b = false;
            QuickSort2.Program.QuickSort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }

        [TestMethod]
        public void ElementsNull()
        {
            int[] array = { };

            bool b = false;
            QuickSort2.Program.QuickSort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }

        [TestMethod]
        public void Elements100()
        {
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = 1;
            }
            bool b = false;
            QuickSort2.Program.QuickSort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])
                {
                    b = true;
                }
                Assert.AreEqual(b, true);
                b = false;
            }
        }
    }
}
