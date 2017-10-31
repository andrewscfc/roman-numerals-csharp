using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanNumeralGenerator : IRomanNumeralGenerator
    {
        private readonly PlaceValueNumeralMapping _thousandMappings = new PlaceValueNumeralMapping(1000,
             new Dictionary<int, string>
            {
                {0, String.Empty},
                {1, "M"},
                {2, "MM"},
                {3, "MMM"}
            });

        private readonly PlaceValueNumeralMapping _hundredMappings = new PlaceValueNumeralMapping(100,
            new Dictionary<int, string>
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
            });



        private readonly PlaceValueNumeralMapping _tenMappings = new PlaceValueNumeralMapping(10,
            new Dictionary<int, string>
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
            });

        private readonly PlaceValueNumeralMapping _unitMappings = new PlaceValueNumeralMapping(1,
            new Dictionary<int, string>
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
            });

        /// <summary>
        /// Represents mapping between a place value and the numerals that represent each digit
        /// in that place value
        /// </summary>
        private class PlaceValueNumeralMapping
        {
            public int PlaceValue { get; }
            public Dictionary<int, string> DigitNumeralMappings { get; }

            public PlaceValueNumeralMapping(int placeValue, Dictionary<int, string> digitalNumeralMappings)
            {
                PlaceValue = placeValue;
                DigitNumeralMappings = digitalNumeralMappings;
            }           
        }
        
        public string Generate(int number)
        {
            if(number < 1 || number > 3999)
            {
                throw new ArgumentException("Only numbers between 1 and 3999 (inclusive) supported", nameof(number));
            }

            var thousandPortion = ResolveNumeralPortion(_thousandMappings, number);
            var hundredPortion = ResolveNumeralPortion(_hundredMappings, number);
            var tenPortion = ResolveNumeralPortion(_tenMappings, number);
            var unitPortion = ResolveNumeralPortion(_unitMappings, number);

            return $"{thousandPortion}{hundredPortion}{tenPortion}{unitPortion}";
        }

        private static string ResolveNumeralPortion(PlaceValueNumeralMapping placeValueNumeralMapping, int number)
        {
            var portionStep = (number / placeValueNumeralMapping.PlaceValue) % 10;
            return placeValueNumeralMapping.DigitNumeralMappings[portionStep];
        }
        
       
    }
}