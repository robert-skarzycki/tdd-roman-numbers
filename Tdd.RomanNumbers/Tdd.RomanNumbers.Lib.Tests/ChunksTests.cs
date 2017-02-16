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

            public void WHEN_compared_greater_and_smaller_letters_THEN_should_recognize_first_is_greater()
            {
                var firstLetter = Letters.X;
                var secondLetter = Letters.X;

                var firstChunk = new Lib.SingleLetterChunk(firstLetter);
                var secondChunk = new Lib.SingleLetterChunk(secondLetter);
                var result = firstChunk.CompareTo(secondChunk);

                Assert.That(result, Is.EqualTo(1));
            }
        }

        public class SubtractionChunk
        {
            [Test]
            public void SHOULD_return_minuend_as_main_letter()
            {
                var minuend = Letters.X;
                var subtrahend = Letters.I;

                var sut = new Lib.SubtractionChunk(minuend, subtrahend, 1);
                Assert.That(sut.MainLetter, Is.EqualTo(minuend));
            }

            [Test]
            public void SHOULD_throw_exception_if_subtrahend_is_not_valid_neighbour()
            {
                var minuend = Letters.M;
                var subtrahend = Letters.I;

                Assert.Throws<ArgumentException>(() =>
                {
                    var sut = new Lib.SubtractionChunk(minuend, subtrahend, 1);
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

            [TestCase(0)]
            [TestCase(2)]
            public void SHOULD_throw_ArgumentOutOfRange_exception_if_repetitions_count_not_1(int repetitionsCount)
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var sut = new Lib.SubtractionChunk(mainLetter, addition, repetitionsCount);
                });
            }
        }

        public class AdditionChunk
        {
            [Test]
            public void SHOULD_return_provided_main_letter_as_main_letter()
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                var sut = new Lib.AdditionChunk(mainLetter, addition, 1);
                Assert.That(sut.MainLetter, Is.EqualTo(mainLetter));
            }

            [Test]
            public void SHOULD_throw_exception_if_addition_is_not_valid_neighbour()
            {
                var mainLetter = Letters.M;
                var addition = Letters.I;

                Assert.Throws<ArgumentException>(() =>
                {
                    var sut = new Lib.AdditionChunk(mainLetter, addition, 1);
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

            [Test]
            public void SHOULD_add_addition_as_many_times_as_provided_repetition()
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                var sut = new Lib.AdditionChunk(mainLetter, addition, 2);
                Assert.That(sut.Value, Is.EqualTo(12));
            }

            [TestCase(-1)]
            [TestCase(3)]
            public void SHOULD_throw_ArgumentOutOfRange_exception_if_repetitions_count_less_1_or_greater_2(int repetitionsCount)
            {
                var mainLetter = Letters.X;
                var addition = Letters.I;

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var sut = new Lib.AdditionChunk(mainLetter, addition, repetitionsCount);
                });                
            }
        }
    }
}
