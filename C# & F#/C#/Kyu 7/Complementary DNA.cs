using NUnit.Framework;
using System;

namespace Kyu_7
{
    public class DnaStrand
    {
        public static string MakeComplement(string dna)
        {
            // StringBuilder allocates internally a char[] anyway, and does a bound check at any append.
            // We can avoid that work since we know the length in advance

            var chars = new char[dna.Length];

            var dnaSpan = dna.AsSpan();
            for (var i = 0; i < dna.Length; i++)
                chars[i] = dnaSpan[i] switch
                {
                    'A' => 'T',
                    'T' => 'A',
                    'C' => 'G',
                    'G' => 'C',
                    _ => throw new Exception($"DNA cannot have 'dnaSpan[i]' (found at position {i}).")
                };

            return new string(chars);
        }
    }

    [TestFixture]
    public class DnaStrandTest
    {
        [TestCase("AAAA", "TTTT")]
        [TestCase("ATTGC", "TAACG")]
        [TestCase("GTAT", "CATA")]
        [TestCase("AAGG", "TTCC")]
        [TestCase("CGCG", "GCGC")]
        [TestCase("ATTGC", "TAACG")]
        [TestCase("GTATCGATCGATCGATCGATTATATTTTCGACGAGATTTAAATATATATATATACGAGAGAATACAGATAGACAGATTA", "CATAGCTAGCTAGCTAGCTAATATAAAAGCTGCTCTAAATTTATATATATATATGCTCTCTTATGTCTATCTGTCTAAT")]
        public void SampleTests(string dna, string expected)
        {
            Assert.That(DnaStrand.MakeComplement(dna), Is.EqualTo(expected));
        }
    }
}
