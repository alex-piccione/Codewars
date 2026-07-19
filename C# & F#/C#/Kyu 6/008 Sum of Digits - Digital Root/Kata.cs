using NUnit.Framework;
using System;
using System.Linq;

namespace _008_Sum_of_Digits___Digital_Root
{
    public class Number
    {
        public static int DigitalRoot(long n)
        {
            if (n < 10) return (int)n;

            var numbers = n.ToString().ToArray();
            var sum = 0L;
            for (int i = 0; i < numbers.Length; i++)
                sum += (int)Char.GetNumericValue(numbers[i]);

            return DigitalRoot(sum);
        }
    }


    [TestFixture]
    public class NumberTest
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(16, ExpectedResult = 7)]
        [TestCase(195, ExpectedResult = 6)]
        [TestCase(992, ExpectedResult = 2)]
        [TestCase(167346, ExpectedResult = 9)]
        [TestCase(999999999999, ExpectedResult = 9)]
        [Order(1)]
        public int Tests(long n)
        {
            return Number.DigitalRoot(n);
        }
    }

}