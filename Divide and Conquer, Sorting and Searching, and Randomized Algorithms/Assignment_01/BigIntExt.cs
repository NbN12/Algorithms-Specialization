using System;
using System.Numerics;

namespace Assignment_01
{
    public class BigIntExt
    {
        private static readonly BigInteger TEN = new BigInteger(10);

        public static BigInteger KaratsubaMutiply(BigInteger lhs, in BigInteger rhs)
        {
            if (lhs < 10 || rhs < 10)
                return lhs * rhs;

            var m = Math.Min(lhs.ToString().Length, rhs.ToString().Length);
            var m2 = m / 2;

            var x = BigInteger.Pow(TEN, m2);
            var h1 = lhs / x;
            var l1 = lhs % x;
            var h2 = rhs / x;
            var l2 = rhs % x;

            var z0 = KaratsubaMutiply(l1, l2);
            var z1 = KaratsubaMutiply((l1 + h1), (l2 + h2));
            var z2 = KaratsubaMutiply(h1, h2);

            return (z2 * BigInteger.Pow(TEN, m2 * 2)) + ((z1 - z2 - z0) * BigInteger.Pow(TEN, m2)) + z0;
        }
    }
}