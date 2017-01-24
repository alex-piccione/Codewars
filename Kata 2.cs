using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    using NUnit.Framework;
    using System;
    using System.Text.RegularExpressions;

    public static class Kata_2
    {
        public static string Disemvowel(string str) =>
            Regex.Replace(str, "[aeiou]", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        
    }

    [TestFixture]
    public class DisemvowelTest
    {
        [Test]
        public void ShouldRemoveAllVowels()
        {
            Assert.AreEqual("Ths wbst s fr lsrs LL!", Kata_2.Disemvowel("This website is for losers LOL!") );
        }
    }

}
