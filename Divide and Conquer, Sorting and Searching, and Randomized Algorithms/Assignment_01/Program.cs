using System;
using System.Numerics;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
            var b = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");
            Console.WriteLine(BigIntExt.KaratsubaMutiply(a, b));

        }
    }
}
