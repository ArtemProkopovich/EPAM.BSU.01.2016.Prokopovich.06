using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2_Sort;

namespace Task2_Tests
{
    [TestFixture]
    public class SortTest
    {
        static Random random = new Random();

        static int[][] RandomArray()
        {
            int[][] result = new int[random.Next(1, 10)][];
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = new int[random.Next(1, 10)];
                for (int j = 0; j < result[i].Length; j++)
                    result[i][j] = random.Next(20);
            }
            return result;
        }

        static int[][] CopyArray(int[][] array)
        {
            int[][] result = new int[array.Count()][];
            for (int i = 0; i < array.Count(); i++)
            {
                result[i] = new int[array[i].Length];
                for (int j = 0; j < result[i].Length; j++)
                    result[i][j] = array[i][j];
            }
            return result;
        }

        [Test]
        public void Sort_TestMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                int[][] array1 = RandomArray();
                int[][] array2 = CopyArray(array1);
                ArraySortDelegate.Sort(array1, new MaxArray());
                ArraySortDelegate.Sort(array2, new MaxArray().Compare);
                Assert.AreEqual(array1, array2);


                array1 = RandomArray();
                array2 = CopyArray(array1);
                ArraySortDelegate.Sort(array1, new SumArray());
                ArraySortDelegate.Sort(array2, new SumArray().Compare);
                Assert.AreEqual(array1, array2);

                array1 = RandomArray();
                array2 = CopyArray(array1);
                ArraySortInterface.Sort(array1, new SumArray());
                ArraySortInterface.Sort(array2, new SumArray().Compare);
                Assert.AreEqual(array1, array2);

                array1 = RandomArray();
                array2 = CopyArray(array1);
                ArraySortInterface.Sort(array1, new MaxArray());
                ArraySortInterface.Sort(array2, new MaxArray().Compare);
                Assert.AreEqual(array1, array2);
            }
        }

        public class MaxArray : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                int resultY = y.Max();
                int resultX = x.Max();
                return resultX.CompareTo(resultY);
            }
        }
    }

    public class SumArray : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            int resultY = y.Sum();
            int resultX = x.Sum();
            return resultX.CompareTo(resultY);
        }
    }
}
