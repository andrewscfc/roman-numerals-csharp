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
        private const string TallyCase = "tally case";

        [SetUp]
        public void Setup()
        {
            _testObj = new RomanNumeralGenerator();
        }
        
        public static (int number, string expectedNumeral)[] Numbers1To10ValueSource = {
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
        
        [Test]
        public void Generate_Numbers1To9_ExpectedNumerals(
            [ValueSource(nameof(Numbers1To10ValueSource))](int number, string expectedNumeral) valueToExpected)
        {
            TestAlgorithm(valueToExpected);
        }
        
        public static (int number, string expectedNumeral)[] TensValueSource = {
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
        
        [Test]
        public void Generate_Tens_ExpectedNumerals(
            [ValueSource(nameof(TensValueSource))](int number, string expectedNumeral) valueToExpected)
        {
            TestAlgorithm(valueToExpected);
        }
        
        public static (int number, string expectedNumeral)[] HundredsValueSource = {
            (100, "X"),
            (200, "XX"),
            (300, "XXX"),
            (400, "XL"),
            (500, "L"),
            (600, "LX"),
            (700, "LXX"),
            (800, "LXXX"),
            (900, "XC")
        };
        
        [Test]
        public void Generate_Hundreds_ExpectedNumerals(
            [ValueSource(nameof(TensValueSource))](int number, string expectedNumeral) valueToExpected)
        {
            TestAlgorithm(valueToExpected);
        }
        
        public static (int number, string expectedNumeral)[] ThousandsValueSource = {
            (1000, "X"),
            (2000, "XX"),
            (3000, "XXX")
        };
        
        [Test]
        public void Generate_Thousands_ExpectedNumerals(
            [ValueSource(nameof(ThousandsValueSource))](int number, string expectedNumeral) valueToExpected)
        {
            TestAlgorithm(valueToExpected);
        }
        
        public static (int number, string expectedNumeral)[] SubtractivePatternsValueSource = {
            (14, "XIV"),
            (19, "XIX"),
            (44, "XLIV"),
            (49, "XLIL"),
            (99, "XCIX"),
            
        };
        
        [Test]
        public void Generate_SubtractivePatterns_ExpectedNumerals(
            [ValueSource(nameof(SubtractivePatternsValueSource))](int number, string expectedNumeral) valueToExpected)
        {
            TestAlgorithm(valueToExpected);
        }
        

        private void TestAlgorithm((int number, string expectedNumeral) valueToExpected)
        {
            //Arrange

            //Act
            var result = _testObj.Generate(valueToExpected.number);

            //Assert
            result.Should().Be(valueToExpected.expectedNumeral);
        }
    }
}