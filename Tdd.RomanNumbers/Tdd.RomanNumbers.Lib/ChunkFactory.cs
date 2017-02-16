using System;
using System.Collections.Generic;
using System.Linq;

namespace Tdd.RomanNumbers.Lib
{
    internal class ChunkFactory
    {
        public IEnumerable<IChunk> ParseString(string romanNumber)
        {
            if(string.IsNullOrEmpty(romanNumber))
            {
                throw new ArgumentException("Provided string must not be empty nor null.");
            }

            for (var i = 0; i < romanNumber.Length; i++)
            {
                var currentChar = romanNumber[i];
                var currentLetter = this.ConvertCharToLetter(currentChar);

                var nextLetter = this.GetNextLetter(romanNumber, i);
                if (nextLetter != null)
                {
                    if (currentLetter.AllowedNeighbour == nextLetter)
                    {
                        yield return new AdditionChunk(currentLetter, nextLetter, 1);
                        i++;
                    }
                    else if (nextLetter.AllowedNeighbour == currentLetter)
                    {
                        yield return new SubtractionChunk(nextLetter, currentLetter, 1);
                        i++;
                    }
                }

                yield return new SingleLetterChunk(currentLetter);
            }
        }

        private ILetter GetNextLetter(string romanNumber, int currentIndex)
        {
            if (currentIndex + 1 >= romanNumber.Length)
            {
                return null;
            }

            var nextChar = romanNumber[currentIndex + 1];
            return this.ConvertCharToLetter(nextChar);
        }

        private ILetter ConvertCharToLetter(char character)
        {
            var letter = Letters.Available.FirstOrDefault(l => l.Character == character);

            if(letter == null)
            {
                throw new ArgumentException($"Given character is not valid: {character}");
            }

            return letter;
        }
    }         
}
