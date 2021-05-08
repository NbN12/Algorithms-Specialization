using System;
using System.IO;
using System.Linq;

namespace Assignment_03
{
    class Program
    {
        private static readonly string FILENAME = @".\QuickSort.txt";
        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(File.ReadAllLines(FILENAME), int.Parse);
            var c = QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine($"Total comparisions = {c}");
        }

        static int QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return 0;
            var c = right - left;
            // var p = PivotPartitionUsingFirstElement(arr, left, right); 
            // var p = PivotPartitionUsingLastElement(arr, left, right); 
            var p = PivotPartitionUsingMedianOfThreeElement(arr, left, right);
            c += QuickSort(arr, left, p - 1);
            c += QuickSort(arr, p + 1, right);
            return c;
        }

        static int PivotPartitionUsingMedianOfThreeElement(int[] arr, int left, int right)
        {
            var mid = (right + left) / 2;
            var median = -1;

            // Reference link: https://stackoverflow.com/questions/1582356/fastest-way-of-finding-the-middle-value-of-a-triple/14676309#14676309 

            if ((arr[left] - arr[mid]) * (arr[right] - arr[left]) >= 0)
                median = left;
            else if ((arr[mid] - arr[left]) * (arr[right] - arr[mid]) >= 0)
                median = mid;
            else
                median = right;

            Swap(ref arr[left], ref arr[median]);
            var p = arr[left];
            var i = left + 1;
            for (var j = left + 1; j <= right; j++)
            {
                if (arr[j] < p)
                {
                    Swap(ref arr[j], ref arr[i]);
                    ++i;
                }
            }
            Swap(ref arr[left], ref arr[i - 1]);
            return i - 1;
        }

        static int PivotPartitionUsingLastElement(int[] arr, int left, int right)
        {
            Swap(ref arr[left], ref arr[right]);
            var p = arr[left];
            var i = left + 1;
            for (var j = left + 1; j <= right; j++)
            {
                if (arr[j] < p)
                {
                    Swap(ref arr[j], ref arr[i]);
                    ++i;
                }
            }
            Swap(ref arr[left], ref arr[i - 1]);
            return i - 1;
        }

        static int PivotPartitionUsingFirstElement(int[] arr, int left, int right)
        {
            var p = arr[left];
            var i = left + 1;
            for (var j = left + 1; j <= right; j++)
            {
                if (arr[j] < p)
                {
                    Swap(ref arr[j], ref arr[i]);
                    ++i;
                }
            }
            Swap(ref arr[left], ref arr[i - 1]);
            return i - 1;
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
