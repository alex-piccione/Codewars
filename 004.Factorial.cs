using System;
using NUnit.Framework;

namespace Codewars.Factorial
{
    public static class Kata
    {
        public static int Factorial(int n)
        {
            if (n < 0 || n > 12) throw new ArgumentOutOfRangeException("The given number must be in the range [0..12]");
            return n == 0 ? 1 :
                n * Factorial(n - 1);
        }
    }
    

    [TestFixture, Category("Kata 004: Factorial")]
    public class FactorialTests
    {
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 6)]
        public int FactorialShouldReturnTheRightValue(int number)
        {
            return Kata.Factorial(number);
        }

        [Test]
        public void FactorialOfNegativeShouldRaiseAnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => Kata.Factorial(-1));
        }
        
        [Test]
        public void FactorialOfNumberAbove12ShouldRaiseAnException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Kata.Factorial(13));
        }
    }
}