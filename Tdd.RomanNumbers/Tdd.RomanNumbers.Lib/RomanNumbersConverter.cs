using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return romanNumberCapitalized.Sum(c=>CharToValueMapping[c]);
        }

        private bool AreAllCharactersValid(string romanNumber)
        {
            return romanNumber.ToUpper().All(CharToValueMapping.Keys.Contains);
        }
    }    
}
