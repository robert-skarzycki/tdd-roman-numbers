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

        [Test]
        public void WHEN_multiple_single_letters_THEN_should_return_in_preserved_order()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("CLI");
            var letters = result.Select(c => c.MainLetter);

            CollectionAssert.AreEqual(new[] { Letters.C, Letters.L, Letters.I }, letters);            
        }

        [Test]
        public void SHOULD_recognize_subtraction()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("IX");

            Assert.That(result.First(), Is.InstanceOf<SubtractionChunk>());
        }

        [Test]
        public void SHOULD_recognize_main_letter_of_subtraction()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("IX");

            Assert.That(result.First().MainLetter, Is.EqualTo(Letters.X));
        }

        [Test]
        public void SHOULD_recognize_addition()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("LX");

            Assert.That(result.First(), Is.InstanceOf<AdditionChunk>());
        }

        [Test]
        public void SHOULD_recognize_double_addition()
        {
            var sut = new ChunkFactory();
            var result = sut.ParseString("LXX").ToList();

            Assert.That(result.First(), Is.InstanceOf<AdditionChunk>());
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}
