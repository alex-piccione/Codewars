using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kyu_5_Geometric_Series_Events
{
    //enum Day { Mo = 0, Tu = 1, We = 2, Th = 3, Fr = 4, Sa = 5, Su = 6 }


    //internal readonly struct Patterna
    //{
    //    public int R { get; init; }
    //    public int[] Sequence { get; init; }
    //}

    //internal record Pattern(int R, int[] Sequence);


    public static class Extensions
    {
        public static int ToIndex(this String day) => day switch
        {
            "Mo" => 0,
            "Tu" => 1,
            "We" => 2,
            "Th" => 3,
            "Fr" => 4,
            "Sa" => 5,
            "Su" => 6,
            _ => throw new ArgumentException("Invalid day string"),
        };

        public static string ToDay(this int index) => (index % 7) switch
        {
            0 => "Mo",
            1 => "Tu",
            2 => "We",
            3 => "Th",
            4 => "Fr",
            5 => "Sa",
            6 => "Su",
            _ => throw new ArgumentException("Invalid day index"),
        };
    }

    public static class GeometricSeriesOfEvents
    {
        // There can be only 7 possible patterns for the r values mod 7.
        // Pre-calculating it allows to quick identify the cycle and avoid some computations.

        //private static readonly Dictionary<int, int[]> patterns = new() {
        //    { 1, new[] {1, 2, 3, 4, 5, 6, 7} },
        //    { 2, new[] {1, 3, 7} },
        //    { 3, new[] {1, 4, 6} },
        //    { 4, new[] {1, 5, 7} },
        //    { 5, new[] {1, 6, 3, 2, 4, 7} },
        //    { 6, new[] {1, 7} },
        //    { 7, new[] {1 } },
        //};

        // key:r, value: 0-index pattern
        private static readonly Dictionary<int, int[]> patterns = new() {
            { 0, new[] {0} },
            { 1, new[] {0, 1, 2, 3, 4, 5, 6} },
            { 2, new[] {0, 2, 6} },
            { 3, new[] {0, 3, 5, 4, 1, 6} },
            { 4, new[] {0, 4, 6} },
            { 5, new[] {0, 5, 2, 1, 3, 6} },
            { 6, new[] {0, 6} },
        };

        public static BigInteger FindNthOccurrence(string startDay, int r, BigInteger n, string targetDay)
        {
            Console.WriteLine($"Start: {startDay}, r={r}, n={n}, Target: {targetDay}");
            var pattern = patterns[r % 7];

            // normalize the days to star form 0
            var startIndex = startDay.ToIndex();
            var targetIndex = targetDay.ToIndex();
            if (targetIndex < startIndex)
                targetIndex += 7;
            targetIndex = targetIndex - startIndex;
            startIndex = 0;

            if (startIndex == targetIndex && n == 1)
                return 1;

            // check if target day is in the pattern
            if (!pattern.Contains(targetIndex))
                return -1;

            var eventsBeforeLastCycle = (n - 1) * pattern.Length; 

            var remainingEvents = pattern.TakeWhile(x => x != targetIndex).Count();

            return eventsBeforeLastCycle + remainingEvents + 1; // add initial event

            /*
            if (n == 1)
                return pattern.Count(x => x != targetIndex) + 1;




            var nextEvent = startDay.ToIndex();
            var prevEvent = nextEvent;

            var eventsCount = 1;
            var matchingDaysCount = startDay == targetDay ? 1 : 0;

            if (n == 1 && matchingDaysCount == 1) return 1;

            for(int i=1; i<Double.MaxValue; i++) 
            //while (n > matchingDays)
            {
                prevEvent = nextEvent; // temp
                eventsCount++;

                BigInteger days = BigInteger.Pow(r, i); // (long)Math.Pow(r, i);

                //if (days >= long.MaxValue) return -1;
                

                // increase r exponentially and get the steps for the next event
                nextEvent += (int)(days % 7);

                //string a = nextEvent.ToDay(); 


                if (nextEvent.ToDay() == targetDay)
                {
                    matchingDaysCount++;

                    if (n == matchingDaysCount)
                    {
                        //Console.WriteLine($"Found {n} occurrence(s) of {targetDay} at event {eventsCount}");
                        Console.WriteLine($"Event {eventsCount}: {prevEvent.ToDay()} + {days} = {nextEvent.ToDay()} (Index {nextEvent % 7} because r={i})");
                        return eventsCount;
                    }
                }
            }

            return -1;
            */
        }
    }

    [TestFixture]
    public class GeometricSeriesOfEventsTests
    {
        private readonly BigInteger one = BigInteger.One;
        private readonly BigInteger two = new(2);
        private readonly BigInteger negativeOne = new(-1);

        [Test]
        public void Test_rEquals1() // r=1; Events on consecutive days
        {
            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Tu", 1, one, "Th"), Is.EqualTo(new BigInteger(3)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Fr", 1, one, "Th"), Is.EqualTo(new BigInteger(7)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 1, one, "Mo"), Is.EqualTo(new BigInteger(1)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 1, two, "Mo"), Is.EqualTo(new BigInteger(8)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 1, new BigInteger(1000001), "Mo"),
                                                Is.EqualTo(new BigInteger(7000001)));
        }

        [Test]
        public void Test_rEquals2()
        {
            // r=2; event 2 occurs 2 days after event 1, event 3 happens 4 days after event 2, event 4 follows 8 days after event 3, and so on.

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 2, one, "Su"),
                        Is.EqualTo(new BigInteger(3))); // example 1 from description

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 2, two, "Mo"),
                        Is.EqualTo(new BigInteger(4))); // event 4 is 8 days after event 3

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Mo", 2, one, "Tu"),
                        Is.EqualTo(negativeOne));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Fr", 2, new BigInteger(5), "Fr"),
                        Is.EqualTo(new BigInteger(13)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Sa", 2, new BigInteger(5555), "Fr"),
                        Is.EqualTo(new BigInteger(16665)));
        }

        [Test]
        public void Test_rEquals7() // r=7; starting day is only day in sequence
        {
            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Su", 7, one, "Su"),
                        Is.EqualTo(new BigInteger(1)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Su", 7, two, "Su"),
                        Is.EqualTo(new BigInteger(2)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Su", 7, BigInteger.Parse("98765432101234567890"), "Su"),
                        Is.EqualTo(BigInteger.Parse("98765432101234567890")));

            // No other days occur in the sequence.
            foreach (var targetDay in new[] { "Mo", "Tu", "We", "Th", "Fr", "Sa" })
            {
                Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Su", 7, one, targetDay),
                            Is.EqualTo(negativeOne));
            }
        }

        [Test]
        public void TestOtherValues()
        {
            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("We", 3, two, "We"),
                        Is.EqualTo(new BigInteger(7))); // example 2 from description

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Th", 4, new BigInteger(4), "Fr"),
                        Is.EqualTo(negativeOne));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Sa", 10, new BigInteger(311), "We"),
                        Is.EqualTo(new BigInteger(1864)));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Sa", 10, new BigInteger(4), "Mo"),
                        Is.EqualTo(negativeOne));

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Su", 12345, BigInteger.Parse("260968428977388166"), "Th"),
                        Is.EqualTo(BigInteger.Parse("782905286932164497")));

            // max values for r and n
            var ten = new BigInteger(10);
            var n = BigInteger.Pow(ten, 100); // 10^100

            // result = 3 + 7 * (10^100 - 1)
            var result = new BigInteger(3) + new BigInteger(7) * (n - BigInteger.One);

            Assert.That(GeometricSeriesOfEvents.FindNthOccurrence("Tu", 1000000, n, "Th"),
                        Is.EqualTo(result));
        }
    }

}
