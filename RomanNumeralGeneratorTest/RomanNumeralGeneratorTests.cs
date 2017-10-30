using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumeralGenerator = RomanNumerals.RomanNumeralGenerator;

namespace RomanNumeralGeneratorTest
{
    [TestFixture]
    public class RomanNumeralGeneratorTests
    {
        private RomanNumeralGenerator _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new RomanNumeralGenerator();
        }

        public static (int unitPortion, string numeralPortion)[] Units = new[]
        {
            (0, string.Empty),
            (1, "I"),
            (2, "II"),
            (3, "III"),
            (4, "IV"),
            (5, "V"),
            (6, "VI"),
            (7, "VII"),
            (8, "VIII"),
            (9, "IX")
        };
        
        public static (int tenPortion, string numeralPortion)[] Tens = new[]
        {
            (0, string.Empty),
            (10, "X"),
            (20, "XX"),
            (30, "XXX"),
            (40, "XL"),
            (50, "L"),
            (60, "LX"),
            (70, "LXX"),
            (80, "LXXX"),
            (90, "XC")
        };

        public static (int hundredPortion, string numeralPortion)[] Hundreds = new[]
        {
            (0, string.Empty),
            (100, "C"),
            (200, "CC"),
            (300, "CCC"),
            (400, "CD"),
            (500, "D"),
            (600, "DC"),
            (700, "DCC"),
            (800, "DCCC"),
            (900, "CM")
        };
        
        public static (int thousandPortion, string numeralPortion)[] Thousands = new[]
        {
            (0, string.Empty),
            (1000, "M"),
            (2000, "MM"),
            (3000, "MMM")
        };
        
        [Test]
        public void Test(
            [ValueSource(nameof(Thousands))](int thousandPortion, string numeralPortion) thousandValues,
            [ValueSource(nameof(Hundreds))](int hundredPortion, string numeralPortion) hundredValues,
            [ValueSource(nameof(Tens))](int tenPortion, string numeralPortion) tensValues,
            [ValueSource(nameof(Units))](int unitPortion, string numeralPortion) unitValues
            )
        {
            //Arrange
            var testValue = thousandValues.thousandPortion +
                            hundredValues.hundredPortion +
                            tensValues.tenPortion +
                            unitValues.unitPortion;

            var expectedValue = thousandValues.numeralPortion +
                                hundredValues.numeralPortion +
                                tensValues.numeralPortion +
                                unitValues.numeralPortion;
            
            //Act
            var result = _testObj.Generate(testValue);
            
            //Assert
            result.Should().Be(expectedValue);
        }
    }
}