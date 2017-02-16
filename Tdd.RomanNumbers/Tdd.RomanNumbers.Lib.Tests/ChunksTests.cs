using NUnit.Framework;
using System;

namespace Tdd.RomanNumbers.Lib.Tests
{
    [TestFixture]
    public class ChunksTests
    {
        public class SingleLetterChunk
        {
            [Test]
            public void SHOULD_return_value_of_provided_letter()
            {
                var letter = Letters.X;

                var sut = new Lib.SingleLetterChunk(letter);

                Assert.That(sut.Value, Is.EqualTo(letter.Value));
            }
        }

        public class SubtractionChunk
        {
            [Test]
            public void SHOULD_return_minuend_as_main_letter()
            {
                var minuend = Letters.X;
                var subtrahend = Letters.I;

                var sut = new Lib.SubtractionChunk(minuend, subtrahend, default(int));
                Assert.That(sut.MainLetter, Is.EqualTo(minuend));
            }

            [Test]
            public void SHOULD_throw_exception_if_subtrahend_is_not_valid_neighbour()
            {
                var minuend = Letters.M;
                var subtrahend = Letters.I;

                Assert.Throws<ArgumentException>(() =>
                {
                    var sut = new Lib.SubtractionChunk(minuend, subtrahend, default(int));
                });
            }
        }
    }
}
