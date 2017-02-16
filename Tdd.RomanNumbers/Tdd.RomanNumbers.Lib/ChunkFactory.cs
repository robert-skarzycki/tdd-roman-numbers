using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdd.RomanNumbers.Lib
{
    class ChunkFactory
    {
    }

    internal interface IChunk
    {
        ILetter MainLetter { get; }
        int Value { get; }     
    }

    internal class SingleLetterChunk : IChunk
    {
        public SingleLetterChunk(ILetter letter)
        {
            this.MainLetter = letter;
        }

        public ILetter MainLetter { get; }

        public int Value => this.MainLetter.Value;
    }

    internal class SubtractionChunk : IChunk
    {
        public SubtractionChunk(ILetter minuend, ILetter subtrahend, int repetitionsCount)
        {
            if (minuend.AllowedNeighbour != subtrahend)
            {
                throw new ArgumentException($"{subtrahend} must not be a subtrahend to {minuend}.");
            }
        }

        public int Value { get; }

        public ILetter MainLetter { get; }
    }
}
