using System;
using System.IO;

namespace Assignment_02
{
    class Program
    {
        private static readonly string FILENAME = @".\IntegerArray.txt";
        static void Main(string[] args)
        {
            var arr = Array.ConvertAll(File.ReadAllLines(FILENAME), int.Parse);
            int[] temp = new int[arr.Length];
            var result = CountInversion(arr, temp, 0, arr.Length - 1);
            Console.WriteLine($"Total inversion pair in file IntegerArray.txt: {result}");
        }

        static long CountInversion(int[] arr, int[] temp, int left, int right)
        {
            var c = 0L;
            if (left < right)
            {
                var mid = (left + right) / 2;
                c += CountInversion(arr, temp, left, mid);
                c += CountInversion(arr, temp, mid + 1, right);
                c += MergeAndCountSplitInversion(arr, temp, left, mid + 1, right);
            }
            return c;
        }

        static long MergeAndCountSplitInversion(int[] arr, int[] temp, int left, int mid, int right)
        {
            var i = left; var j = mid; var k = left; var c = 0L;

            while ((i <= mid - 1) && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    c += (mid - i);
                }
            }

            while (i <= mid - 1)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return c;
        }
    }
}
