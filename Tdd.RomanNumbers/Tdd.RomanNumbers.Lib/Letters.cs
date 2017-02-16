using System.Collections.Generic;
using System.Linq;

namespace Tdd.RomanNumbers.Lib
{
    internal class Letters
    {
        public static readonly ILetter I = new Letter('I', 1);
        public static readonly ILetter V = new Letter('V', 5, Letters.I);
        public static readonly ILetter X = new Letter('X', 10, Letters.I);
        public static readonly ILetter L = new Letter('L', 50, Letters.X);
        public static readonly ILetter C = new Letter('C', 100, Letters.X);
        public static readonly ILetter D = new Letter('D', 500, Letters.C);
        public static readonly ILetter M = new Letter('M', 1000, Letters.C);

        public static IEnumerable<ILetter> Available = new[] {
            I, V, X, L, C, D, M
        };
    }

    internal interface ILetter
    {
        char Character { get; }
        int Value { get; }
        ILetter AllowedNeighbour { get; }        
    }

    internal class Letter : ILetter
    {
        public Letter(char character, int value, ILetter allowedNeighbour = null)
        {
            this.Character = character.ToString().ToUpper().First();
            this.AllowedNeighbour = allowedNeighbour;
            this.Value = value;
        }

        public char Character { get; }
        public ILetter AllowedNeighbour { get; }
        public int Value { get; }

        public override string ToString()
        {
            return this.Character.ToString();
        }
    }    
}
