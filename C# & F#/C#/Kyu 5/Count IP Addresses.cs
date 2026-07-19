using NUnit.Framework;
using System.Linq;

namespace Kyu_5
{
    public class CountIPAddresses
    {
        public static long IpsBetween(string start, string end)
        {
            var start_subs = start.Split('.').Select(x => int.Parse(x)).ToArray();
            var end_subs = end.Split('.').Select(x => int.Parse(x)).ToArray();

            return
                (end_subs[3] - start_subs[3]) +
                (end_subs[2] - start_subs[2]) * 256L +
                (end_subs[1] - start_subs[1]) * 256L * 256L +
                (end_subs[0] - start_subs[0]) * 256L * 256L * 256L
                ;
        }
    }

    public class CountIPAddressesTest
    {
        [Test]
        public void SmapleTest()
        {
            Assert.That(CountIPAddresses.IpsBetween("10.0.0.0", "10.0.0.50"), Is.EqualTo(50));
            Assert.That(CountIPAddresses.IpsBetween("20.0.0.10", "20.0.1.0"), Is.EqualTo(246));
            Assert.That(CountIPAddresses.IpsBetween("0.0.0.0", "255.255.255.255"), Is.EqualTo((1L << 32) - 1L));
        }
    }
}
