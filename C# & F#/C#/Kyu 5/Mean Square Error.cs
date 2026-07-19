using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;


namespace Kyu5_Mean_Square_Error
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
            // TODO
            return 0;
        }
    }



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

