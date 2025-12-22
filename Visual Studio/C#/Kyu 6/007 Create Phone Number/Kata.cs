using NUnit.Framework;

namespace _007_Create_Phone_Number
{

    public class Kata
    {
        public static string CreatePhoneNumber(int[] numbers)
        {
            int[] v = [.. numbers];

            return $"({v[0]}{v[1]}{v[2]}) {v[3]}{v[4]}{v[5]}-{v[6]}{v[7]}{v[8]}{v[9]}";
        }
    }


    public class Tests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
        public static string SimpleNumber(int[] numbers) =>
            Kata.CreatePhoneNumber(numbers);
    }

}