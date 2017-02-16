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

            [Test]
            public void SHOULD_return_value_subtracted_from_main_letter_by_subtrahend()
            {             
                var minuend = Letters.X;
                var subtrahend = Letters.I;

                var sut = new Lib.SubtractionChunk(minuend, subtrahend, 1);
                Assert.That(sut.Value, Is.EqualTo(9));
            }            
        }

        public class AdditionChunk
        {
            [Test]
            public void SHOULD_return_provided_main_letter_as_main_letter()
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                var sut = new Lib.AdditionChunk(mainLetter, addition, default(int));
                Assert.That(sut.MainLetter, Is.EqualTo(mainLetter));
            }

            [Test]
            public void SHOULD_throw_exception_if_addition_is_not_valid_neighbour()
            {
                var mainLetter = Letters.M;
                var addition = Letters.I;

                Assert.Throws<ArgumentException>(() =>
                {
                    var sut = new Lib.AdditionChunk(mainLetter, addition, default(int));
                });
            }

            [Test]
            public void SHOULD_return_value_added_from_main_letter_and_subtrahend()
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                var sut = new Lib.AdditionChunk(mainLetter, addition, 1);
                Assert.That(sut.Value, Is.EqualTo(11));
            }
        }
    }
}
