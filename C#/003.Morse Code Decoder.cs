using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Collections;

namespace CodeWars
{
    class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            StringBuilder finalText = new StringBuilder();
            string[] morseWords = Regex.Split(morseCode, "   ");            
            
            foreach (var morseWord in morseWords)
            {
                if (finalText.Length > 0)
                    finalText.Append(' ');
                string[] morseLetters = morseWord.Split(' ');
                foreach(var morseLetter in morseLetters)               
                    finalText.Append(MorseCode.Get(morseLetter));
            }
            return finalText.ToString();
        }
    }


    class MorseCode
    {
        private static Dictionary<string, char> morseCode = new Dictionary<string, char>()
        {
            { "....", 'H'},
            { ".", 'E'},
            { "-.--", 'Y'},
            { ".---", 'J'},
            { "..-", 'U'},
            { "-..", 'D'}
        };

        public static char Get(string morse) {
            return morseCode[morse];
        }       
    }


    [TestFixture]
    public class MorseCodeDecoderTests
    {
        [Test]
        public void MorseCodeDecoderTest()
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
