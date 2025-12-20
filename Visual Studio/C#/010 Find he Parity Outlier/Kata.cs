using NUnit.Framework;
using System;

namespace _010_Find_The_Parity_Outlier
{
    public class Kata
    {
        public static int Find(int[] integers)
        {
            static bool isEven(int x) => x % 2 == 0;

            var _1 = isEven(integers[0]);
            var _2 = isEven(integers[1]);
            var _3 = isEven(integers[2]);

            if (_1 != _2 || _1 != _3)
            {
                return 
                    _1 == _2 ? integers[2] :
                    _1 == _3 ? integers[1] :
                    integers[0];
            }

            bool majorityIsEven = _1 & _2 || _1 & _3;

            foreach (int i in integers)
                if (isEven(i) != majorityIsEven) return i;

            throw new System.Exception("No outlier found");
        }
    }


    [TestFixture]
    public class Tests
    {
        private static void DoTest(int expected, int[] input)
        {
            String message = "for array { " + string.Join(", ", input) + " }\n";
            int actual = Kata.Find(input);
            Assert.That(actual, Is.EqualTo(expected), message);
        }

        [Test]
        public static void Test1()
        {
            DoTest(3, [2, 6, 8, -10, 3]);
        }

        [Test]
        public static void Test2()
        {
            DoTest(206847684, [206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781]);
        }

        [Test]
        public static void Test3()
        {
            DoTest(0, [int.MaxValue, 0, 1]);
        }

        [Test]
        public static void Test4()
        {
            DoTest(-5, [-5, 6, 6]);
        }

        [Test]
        public static void Test5()
        {
            DoTest(-3286, [-6577, -13963, -3286]);
        }

        [Test]
        public static void Test6()
        {
            DoTest(-3286, [-6577, -13963, 11847, 18307, -3179, 18875, 785, -6435, 481, 15183, 6665, -13437, -11875, 17141, 13345, 3063, -14433, -15001, -16981, 3411, 3135, -8977, -13099, 453, -17777, -10183, 2379, 16415, -3286, -8337, -17217, -2619, -14161, 15195, 17847, 9459, -12805, 19569, -8891, -16547, -14301, -12253, 9881, 6381, -18387, 15079, -1717, -3481]);
        }
    }

}