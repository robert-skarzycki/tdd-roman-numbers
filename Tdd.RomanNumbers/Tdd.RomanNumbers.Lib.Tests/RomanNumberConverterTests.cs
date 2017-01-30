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

        [Test]
        public void WHEN_invalid_character_passed_THEN_throws_ArgumentException()
        {
            var sut = new RomanNumbersConverter();
            Assert.Throws<ArgumentException>(() => sut.ToInteger("IIzI"));
        }

        [Test]
        public void WHEN_valid_characters_passed_THEN_doesnt_throw_exception()
        {
            var validNumber = "CIX";

            var sut = new RomanNumbersConverter();
            Assert.DoesNotThrow(() => sut.ToInteger(validNumber));
        }

        [Test]
        public void SHOULD_validate_characters_case_insensitive()
        {
            var validNumber = "cIx";

            var sut = new RomanNumbersConverter();
            Assert.DoesNotThrow(() => sut.ToInteger(validNumber));
        }
    }
}
