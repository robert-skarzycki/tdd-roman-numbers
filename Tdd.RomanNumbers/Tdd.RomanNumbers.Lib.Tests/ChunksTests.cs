using NUnit.Framework;

namespace Tdd.RomanNumbers.Lib.Tests
{
    [TestFixture]
    public class ChunksTests
    {
        [Test]
        public void SingleLetterChunk_should_return_value_of_provided_letter()
        {
            var letter = Letters.X;

            var sut = new SingleLetterChunk(letter);

            Assert.That(sut.Value, Is.EqualTo(letter.Value));
        }
    }
}
