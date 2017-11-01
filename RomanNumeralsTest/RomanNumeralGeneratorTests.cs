using System;
using FluentAssertions;
using NUnit.Framework;
using RomanNumerals;

namespace RomanNumeralsTest
{
    /// <summary>
    /// Tests written before implemenation driven by the specification and nature of 
    /// Roman numerals
    /// </summary>
    [TestFixture]
    public class RomanNumeralGeneratorTests
    {
        private RomanNumeralGenerator _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj = new RomanNumeralGenerator();
        }

        public static (int number, string numeral)[] SpecificationExamples = new[]
        {
            (1, "I"),
            (5, "V"),
            (10, "X"),
            (20, "XX"),
            (3999, "MMMCMXCIX")
        };

        /// <summary>
        /// Test against examples provided in the specification given
        /// </summary>
        /// <param name="numberToNumeral"></param>
        [Test]
        public void Generate_SpecificationExamples_ExpectedNumerals(
            [ValueSource(nameof(SpecificationExamples))](int number, string numeral) numberToNumeral)
        {
            //Arrange
            
            //Act
            var result = _testObj.Generate(numberToNumeral.number);
            
            //Assert
            result.Should().Be(numberToNumeral.numeral);
        }


        public static (int number, string numeral)[] SubtractiveExamples = new[]
        {
            (4, "IV"),
            (44, "XLIV"),
            (495, "CDXCV"),
            (999, "CMXCIX"),
            (1449, "MCDXLIX")
        };

        /// <summary>
        /// Examples that use subtractive notation
        /// </summary>
        /// <param name="numberToNumeral"></param>
        [Test]
        public void Generate_SubtractiveExamples_ExpectedNumerals(
            [ValueSource(nameof(SubtractiveExamples))](int number, string numeral) numberToNumeral)
        {
            //Arrange
            
            //Act
            var result = _testObj.Generate(numberToNumeral.number);
            
            //Assert
            result.Should().Be(numberToNumeral.numeral);
        }

        public static (int number, string numeral)[] TallyExamples = new[]
        {
            (11, "XI"),
            (23, "XXIII"),
            (333, "CCCXXXIII"),
            (676, "DCLXXVI"),
            (2366, "MMCCCLXVI"),
            (3787, "MMMDCCLXXXVII")
        };

        /// <summary>
        /// Examples that use tally notation
        /// </summary>
        /// <param name="numberToNumeral"></param>
        [Test]
        public void Generate_TallyExamples_ExpectedNumerals(
            [ValueSource(nameof(TallyExamples))](int number, string numeral) numberToNumeral)
        {
            //Arrange
            
            //Act
            var result = _testObj.Generate(numberToNumeral.number);
            
            //Assert
            result.Should().Be(numberToNumeral.numeral);
        }

        /// <summary>
        /// Numbers below 1 throw exception
        /// </summary>
        /// <param name="number"></param>
        [Test]
        public void Generate_Below1_ThrowArgumentException([Values(int.MinValue, -1000, 0)]int number)
        {
            //Arrange
            
            //Act
            Action actToAssert = () => _testObj.Generate(number);
            
            //Assert
            actToAssert.ShouldThrowExactly<ArgumentException>().WithMessage("Only numbers between 1 and 3999 (inclusive) supported\r\nParameter name: number");
        }
        
        /// <summary>
        /// Numbers above 3999 throw exception
        /// </summary>
        /// <param name="number"></param>
        [Test]
        public void Generate_Above3999_ThrowArgumentException([Values(4000, 11111, int.MaxValue)]int number)
        {
            //Arrange
            
            //Act
            Action actToAssert = () => _testObj.Generate(number);
            
            //Assert
            actToAssert.ShouldThrowExactly<ArgumentException>().WithMessage("Only numbers between 1 and 3999 (inclusive) supported\r\nParameter name: number");
        }
        
    }
}