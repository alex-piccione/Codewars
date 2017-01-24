using System;
using NUnit.Framework;

namespace Codewars.FindTheNextPErfectSquare
{
    public class Kata
    {
        public static long FindNextSquare(long num)
        {
            // your code here
            double sqrtOfNum = Math.Sqrt(num);
            return sqrtOfNum % 1 != 0 ?  // not a square 
                -1 : 0;
        }
    }
    
    [TestFixture, Category("Kata 005: Find the next perfect square")]
    public class Tests
    {
        [Test]
        [TestCase(155, ExpectedResult = -1)]
        [TestCase(121, ExpectedResult = 144)]
        [TestCase(625, ExpectedResult = 676)]
        [TestCase(319225, ExpectedResult = 320356)]
        [TestCase(15241383936, ExpectedResult = 15241630849)]
        public static long FixedTest(long num)
        {
            return Kata.FindNextSquare(num);
        }
    }
}
