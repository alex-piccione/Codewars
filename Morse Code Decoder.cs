using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace CodeWars
{
    class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            string[] morseWords = Regex.Split(morseCode, "   ");
            StringBuilder finalText = new StringBuilder();
            foreach (var morseWord in morseWords)
            {
                string[] morseLetters = morseWord.Split(' ');
                if(finalText.Length == 0)
                    finalText.Append(morseCode.Get())
            }
            return string.Join(" ", words);
            

            //MorseCode.Get()
        }
    }


    class MorseCode
    {
        static string Get(string a) { return "a"; }
    }


    [TestFixture]
    public class MorseCodeDecoderTests
    {
        [Test]
        public void MorseCodeDecoderBasicTest_1()
        {
            try
            {
                string input = ".... . -.--   .--- ..- -.. .";
                string expected = "HEY JUDE";

                string actual = MorseCodeDecoder.Decode(input);

                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("There seems to be an error somewhere in your code. Exception message reads as follows: " + ex.Message);
            }
        }
    }
}
