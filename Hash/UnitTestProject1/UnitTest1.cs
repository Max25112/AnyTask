using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ThreeElements()
        {
            var test = new Hash();
            test.CreateHashTable(3);
            test.PutPair(37, 73);
            test.PutPair(00, "hello world");
            test.PutPair("yolo", "17");
            var keys = new object[] { 37, 00, "yolo" };
            var values = new object[] { 73, "hello world", "17" };
            for (int i = 0; i < 3; i++)
            {
                var check = test.GetKeyValue(keys[i]);
                var check2 = values[i];
                if (!(check).Equals(check2)) throw new Exception();
            }
        }

        [TestMethod]
        public void OneElement()
        {
            var test = new Hash();
            test.CreateHashTable(3);
            test.PutPair(37, 73);
            test.PutPair(37, "37");

            var key = 37;
            var value = "37";
            var check = test.GetKeyValue(key);
            if (!(check).Equals(value)) throw new Exception();
        }

        [TestMethod]
        public void OneSearch()
        {
            var test = new Hash();
            test.CreateHashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                Random rand = new Random();
                var key = i + "007";
                var value = rand.Next(1, 90000);
                test.PutPair(key, value);
            }
            test.PutPair("37007", 73);

            var check = test.GetKeyValue(37);
            if (check != null)
            {
                if (!(check).Equals(73)) throw new Exception();
            }
        }

        [TestMethod]
        public void BigSearch()
        {
            var test = new Hash();
            test.CreateHashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                Random rand = new Random();
                var key = i + "007";
                var value = rand.Next(1, 90000);
                test.PutPair(key, value);
            }


            for (int i = 0; i < 11000; i++)
            {
                if (!(test.GetKeyValue(i) == null)) throw new Exception();
            }
        }
    }
}