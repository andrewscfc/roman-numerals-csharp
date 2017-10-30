using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanNumeralGenerator : IRomanNumeralGenerator
    {
        private Dictionary<int, string> _thousandPortions = new Dictionary<int, string>
        {
            {0, String.Empty},
            {1, "M"},
            {2, "MM"},
            {3, "MMM"}
        };
        
        private Dictionary<int, string> _hundredPortions = new Dictionary<int, string>
        {
            {0, String.Empty},
            {1, "C"},
            {2, "CC"},
            {3, "CCC"},
            {4, "CD"},
            {5, "D"},
            {6, "DC"},
            {7, "DCC"},
            {8, "DCCC"},
            {9, "CM"},
        };
        
        private Dictionary<int, string> _tenPortions = new Dictionary<int, string>
        {
            {0, String.Empty},
            {1, "X"},
            {2, "XX"},
            {3, "XXX"},
            {4, "XL"},
            {5, "L"},
            {6, "LX"},
            {7, "LXX"},
            {8, "LXXX"},
            {9, "XC"},
        };
        
        private Dictionary<int, string> _unitPortions = new Dictionary<int, string>
        {
            {0, String.Empty},
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {4, "IV"},
            {5, "V"},
            {6, "VI"},
            {7, "VII"},
            {8, "VIII"},
            {9, "IX"},
        };
        
        public string Generate(int number)
        {
            var thousandPortion = ResolvePortion(1000, _thousandPortions, number);
            var hundredPortion = ResolvePortion(100, _hundredPortions, number);
            var tenPortion = ResolvePortion(10, _tenPortions, number);
            var unitPortion = ResolvePortion(1, _unitPortions, number);

            return $"{thousandPortion}{hundredPortion}{tenPortion}{unitPortion}";
        }

        private static string ResolvePortion(int portionStepSize, Dictionary<int, string> portionStepMappings, int number)
        {
            var portionStep = (number / portionStepSize) % 10;
            return portionStepMappings[portionStep];
        }
        
       
    }
}