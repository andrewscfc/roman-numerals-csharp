using System;

namespace RomanNumerals
{
    public interface IRomanNumeralGenerator
    {
        /// <summary>
        /// Generates a roman numeral representation of any integer between 1 and 3999 inclusive 
        /// </summary>
        /// <param name="number">Number to convert to a roman numeral</param>
        /// <returns>Roman numeral represenation</returns>
        /// <exception cref="ArgumentException">Thrown when a number is passed in below 1 or above 3999</exception>
        string Generate(int number);
    }
}