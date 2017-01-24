using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Codewars.WeAreTheRobots
{
    class Kata
    {
        public static String[] CountRobots(String[] a)
        {
            int automatik = 0;
            int mechanik = 0;

            string regex = CreateRegex();

            foreach (string phrase in a)
            {
                int robots = CountRobots(phrase, regex);
                if (phrase.Contains("automatik"))
                    automatik += robots;
                else if(phrase.Contains("mechanik"))
                    mechanik += robots;
            }

            return new string[] {
                $"{automatik} robots functioning automatik",
                $"{mechanik} robots dancing mechanik"
            };
        }
        private static int CountRobots(string phrase, string regex)
        {            
            var matches = Regex.Matches(phrase, regex);
            return matches.Count;
        }

        private static string CreateRegex()
        {
            // the robot have this form: {leg}{body}{eye}{body}{eye}{body}{leg}
            // eye: it is a "0"
            // body: it is composed by 2 occurence of one of this: |};&#[]/><()*
            // leg: it can be one of this: abcdefghijklmnopqrstuvwxyz
            string leg = @"[\w]";
            string body = @"[\[\]()]{2}";
            string regex = $"{leg}{body}0{body}0{body}{leg}";
            return regex;
        }
    }

    [TestFixture, Category("Kata 006: We are the robots")]
    public class KataTests
    {
        [Test]
        public void BasicTest1()
        {
            String[] a = { };
            String[] expected = { "0 robots functioning automatik", "0 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest2()
        {
            String[] a = { "We're functioning automatik", "And we are dancing mechanik" };
            String[] expected = { "0 robots functioning automatik", "0 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest3()
        {
            String[] a = { "We're functioning automatik d[(0)(0)]b", "And we are dancing mechanik d[(0)(0)]b d[(0)(0)]b" };
            String[] expected = { "1 robots functioning automatik", "2 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest4()
        {
            String[] a = { "d[(0)(0)]b We're functioning automatik d[(0)(0)]b", "And we are d[(0)(0)]b dancing mechanik d[(0)(0)]b d[(0)(0)]b" };
            String[] expected = { "2 robots functioning automatik", "3 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }

        [Test]
        public void BasicTest5()
        {
            String[] a = { "d[(0)(0)}b We're functioning automatik D[(0)(0)]b", "And we are d[(0)(0}]b dancing mechanik d[(0)(0)]b c[(0)(0)]b" };
            String[] expected = { "2 robots functioning automatik", "3 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest6()
        {
            String[] a = { "d*(0)(0)}b We're functioning e(<0/>0]#m Automatik Roboter0%1 D[(0)(0)]b", "And we are d[(0)(0}]b dancing mechanik d[(0)(0)]b c[(0)(0)]b" };
            String[] expected = { "3 robots functioning automatik", "3 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest7()
        {
            String[] a = { "d*(0)(0)}b We're functioning d>[0;;0&&f automatik D[(0)(0)]b", "and m><0(;0[;a we dancing are Mechanic" };
            String[] expected = { "3 robots functioning automatik", "0 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest8()
        {
            String[] a = {"We're charging our battery","And now we're full of energy","We are the robots","We're functioning automatik",
                       "And we are dancing mechanik","We are the robotororo robots","Ja tvoi sluga","Ja tvoi Rabotnik robotnik",
                       "We are programmed just to do","anything you want us to","we are the robots","We're functioning Automatic",
                       "and we are dancing Mechanic","we are the robots","Ja tvoi sluga","Ja tvoi Rabotnik robotnik",
                       "We are the robots","d*(0)(0)}b We're functioning automatik D[(0)(0)]b",
                       "And we are d[(0)(0}]b dancing mechanik Roboter0%1 d[(0)(0)]b c[(0)(0)]b"};


            String[] expected = { "2 robots functioning automatik", "3 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
        [Test]
        public void BasicTest9()
        {
            String[] a = { "d (0)(0)}b We're functioning &>[0;;0&&f automatik D[(0 (0)]b", "and m><0(;0 ;a we dancing are Mechanic" };
            String[] expected = { "0 robots functioning automatik", "0 robots dancing mechanik" };
            Assert.AreEqual(expected, Kata.CountRobots(a));
        }
    }
}
