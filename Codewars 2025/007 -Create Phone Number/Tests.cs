using FluentAssertions;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void SimpleNumber()
    {
        int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        string expectedOutput = "(123) 456-7890";

        Kata.CreatePhoneNumber(input)
            .Should().Be(expectedOutput);
    }
}