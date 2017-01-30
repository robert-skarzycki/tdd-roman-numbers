using NUnit.Framework;
using System;


namespace Tdd.RomanNumbers.Lib.Tests
{
    [TestFixture]
    public class RomanNumberConverterTests
    {
        [Test]
        public void WHEN_empty_string_passed_THEN_returns_zero()
        {
            var sut = new RomanNumbersConverter();
            var result = sut.ToInteger(string.Empty);

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void WHEN_null_string_passed_THEN_throws_ArgumentNullException()
        {
            var sut = new RomanNumbersConverter();
            Assert.Throws<ArgumentNullException>(() => sut.ToInteger(null));
        }
    }
}
