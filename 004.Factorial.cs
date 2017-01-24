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
        [Test]
        public void FactorialOf0ShouldBe1()
        {
            Assert.AreEqual(1, Kata.Factorial(0));
        }

        [Test]
        public void FactorialOf1ShouldBe1()
        {
            Assert.AreEqual(1, Kata.Factorial(1));
        }

        [Test]
        public void FactorialOf2ShouldBe2()
        {
            Assert.AreEqual(2, Kata.Factorial(2));
        }

        [Test]
        public void FactorialOf3ShouldBe6()
        {
            Assert.AreEqual(6, Kata.Factorial(3));
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