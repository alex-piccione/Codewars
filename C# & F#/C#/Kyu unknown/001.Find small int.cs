using NUnit.Framework;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        public static int FindSmallestInt(int[] args)
        {
            int minValue = int.MaxValue;
            foreach (int value in args)
            {
                if (value < minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }

        public static int FindSmallestInt_2(int[] args)
        {
            return args.Min();
        }

        public static int FindSmallestInt_3(int[] args) => args.Min();
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new int[] { 78, 56, 232, 12, 11, 43 }, ExpectedResult = 11)]
        [TestCase(new int[] { 78, 56, -2, 12, 8, -33 }, ExpectedResult = -33)]
        public static int FindSmallestInt(int[] args)
        {
            return Kata.FindSmallestInt(args);
        }
    }
}
