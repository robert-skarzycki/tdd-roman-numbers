using System;
using System.Collections.Generic;
using System.Linq;

namespace Tdd.RomanNumbers.Lib
{
    public class RomanNumbersConverter : IRomanNumbersConverter
    {
        private readonly ChunkFactory chunkFactory;

        public RomanNumbersConverter()
            :this(new ChunkFactory())
        {
        }

        internal RomanNumbersConverter(ChunkFactory chunkFactory)
        {
            this.chunkFactory = chunkFactory;
        }

        public int ToInteger(string romanNumber)
        {
            if (romanNumber == null)
                throw new ArgumentNullException(nameof(romanNumber));
            
            if (string.Equals(romanNumber,string.Empty))
                return 0;

            var romanNumberCapitalized = romanNumber.ToUpper();
            var chunks = this.chunkFactory.ParseString(romanNumberCapitalized).ToList();

            if(!this.IsChunksOrderValid(chunks))
            {
                throw new Exception("Invalid order of roman letters in provided string.");
            }

            return chunks.Sum(c=>c.Value);
        }       

        private bool IsChunksOrderValid(IList<IChunk> chunks)
        {
            if(chunks.Count == 0)
            {
                throw new Exception("None of the letters were properly parsed or empty string provided.");
            }

            if(chunks.Count == 1)
            {
                return true;
            }

            for(var i=1;i<chunks.Count;i++)
            {
                if(chunks[i].CompareTo(chunks[i-1]) == 1)
                {
                    return false;
                }
            }

            return true;
        }       
    }    
}
