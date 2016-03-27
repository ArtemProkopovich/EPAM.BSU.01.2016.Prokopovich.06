using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Sort
{
    public class ArraySortInterface
    {
        public static void Sort<T>(T[][] array, IComparer<T[]> comparer)
        {
            for (int i = 0; i < array.Count() - 1; i++)
            {
                for (int j = i + 1; j < array.Count(); j++)
                {
                    if (comparer.Compare(array[j], array[i]) < 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        public static void Sort<T>(T[][] array, Func<T[], T[], int> comparer)
        {
            Sort(array, new DelClass<T>(comparer));
        }

        private class DelClass<T> : IComparer<T[]>
        {
            private readonly Func<T[], T[], int> comparer;

            public DelClass(Func<T[], T[], int> comparer)
            {
                this.comparer = comparer;
            }

            public int Compare(T[] arr1, T[] arr2) => comparer(arr1, arr2);
        }

        private static void Swap<T>(ref T obj1, ref T obj2)
        {
            T temp = obj2;
            obj2 = obj1;
            obj1 = temp;
        }
    }
}
