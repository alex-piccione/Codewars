using NUnit.Framework;
using System;

namespace Kyu_5.Mean_Square_Error
{
    public class Kata
    {
        /// <summary>
        /// Calculates the mean square error between two integer arrays.
        /// </summary>
        /// <param name="firstArray">The first integer array.</param>
        /// <param name="secondArray">The second integer array.</param>
        /// <returns>The mean square error as a double.</returns>
        public static double Solution(int[] firstArray, int[] secondArray)
        {
            var errorAccumulator = 0d;
            for (var i=0;  i<firstArray.Length; i++)
            {
                var error = Math.Abs(secondArray[i] - firstArray[i]);
                errorAccumulator += error * error;
            }

            return errorAccumulator / firstArray.Length;
        }
    }

    // Note 1: could have been solved using .Select() .Average()   or .Zip()...Average()
    // Note 2: x*x  is more performant than Pow(x, 2)



    [TestFixture]
    public class SolutionTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.That(Kata.Solution([1, 2, 3], [4, 5, 6]), Is.EqualTo(9));
            Assert.That(Kata.Solution([10, 20, 10, 2 ], [ 10, 25, 5, -2 ]), Is.EqualTo(16.5));
            Assert.That(Kata.Solution([ 0, -1], [-1, 0 ]), Is.EqualTo(1));
        }
    }
}

