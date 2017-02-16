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
            var validNumber = "CX";

            var sut = new RomanNumbersConverter();
            Assert.DoesNotThrow(() => sut.ToInteger(validNumber));
        }

        [Test]
        public void SHOULD_validate_characters_case_insensitive()
        {
            var validNumber = "cX";

            var sut = new RomanNumbersConverter();
            Assert.DoesNotThrow(() => sut.ToInteger(validNumber));
        }

        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        public void SHOULD_map_single_chars(string romanNumber, int expected)
        {
            var sut = new RomanNumbersConverter();
            var result = sut.ToInteger(romanNumber);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("CC", 200)]
        [TestCase("III", 3)]
        public void SHOULD_sum_repeated_characters(string romanNumber, int expected)
        {
            var sut = new RomanNumbersConverter();
            var result = sut.ToInteger(romanNumber);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("VX")]
        [TestCase("LM")]
        public void WHEN_invalid_order_THEN_should_throw_exception(string romanNumber)
        {
            var sut = new RomanNumbersConverter();
            Assert.Throws<Exception>(() => sut.ToInteger(romanNumber));
        }

        [Test]
        public void SHOULD_allow_reverted_order_for_subtraction()
        {
            var numberWithSubtraction = "LIX";

            var sut = new RomanNumbersConverter();
            Assert.DoesNotThrow(() => sut.ToInteger(numberWithSubtraction));
        }
    }
}
