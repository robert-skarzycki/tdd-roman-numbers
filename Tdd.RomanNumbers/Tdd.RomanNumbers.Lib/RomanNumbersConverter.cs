using System;
using System.Collections.Generic;
using System.Linq;

namespace Tdd.RomanNumbers.Lib
{
    public class RomanNumbersConverter : IRomanNumbersConverter
    {
        private static readonly Dictionary<char, int> CharToValueMapping = new Dictionary<char, int>
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },            
        };

        public int ToInteger(string romanNumber)
        {
            if (romanNumber == null)
                throw new ArgumentNullException(nameof(romanNumber));
            
            if (string.Equals(romanNumber,string.Empty))
                return 0;

            if (!this.AreAllCharactersValid(romanNumber))
                throw new ArgumentException(nameof(romanNumber));

            var romanNumberCapitalized = romanNumber.ToUpper();
            var chunks = this.SplitIntoChunks(romanNumberCapitalized);

            return chunks.Sum(c=>CharToValueMapping[c]);
        }

        private IEnumerable<char> SplitIntoChunks(string romanNumberCapitalized)
        {
            var letters = romanNumberCapitalized.ToArray();
            if(!this.AreChunksCorrectlyOrdered(letters))
            {
                throw new ArgumentException("Invalid order of roman numbers in the provided string.");
            }

            return letters;
        }

        private bool AreChunksCorrectlyOrdered(IList<char> chunks)
        {
            if(chunks.Count <= 1)
            {
                return true;
            }

            var chunksMappedToIndices = chunks.Select(c => CharToValueMapping.Keys.ToList().IndexOf(c)).ToArray();
            
            for(var i = 1; i < chunksMappedToIndices.Length; i++)
            {
                if(chunksMappedToIndices[i] > chunksMappedToIndices[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreAllCharactersValid(string romanNumber)
        {
            return romanNumber.ToUpper().All(CharToValueMapping.Keys.Contains);
        }
    }    
}
