using NUnit.Framework;
using System;
using System.Linq;

namespace Tdd.RomanNumbers.Lib.Tests
{
    [TestFixture]
    public class ChunkFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void WHEN_provided_string_is_null_or_empty_THEN_throws_exception(string inputString)
        {
            var sut = new ChunkFactory();
            Assert.Throws<ArgumentException>(() => sut.ParseString(inputString).ToList());
        }

        [Test]
        public void WHEN_provided_single_letter_THEN_returns_SingleLetterChunk()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("L");

            Assert.That(result.First(), Is.InstanceOf<SingleLetterChunk>());
        }

        [Test]
        public void WHEN_provided_letter_is_invalid_THEN_throws_exception()
        {
            var invalidLetter = "Z";

            var sut = new ChunkFactory();
            Assert.Throws<ArgumentException>(() => sut.ParseString(invalidLetter).ToList());
        }
    }
}
