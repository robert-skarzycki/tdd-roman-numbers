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

            for(var i=0;i<romanNumber.Length;i++)
            {
                var currentChar = romanNumber[i];
                var currentLetter = this.ConvertCharToLetter(currentChar);

                yield return new SingleLetterChunk(currentLetter);
            }
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
