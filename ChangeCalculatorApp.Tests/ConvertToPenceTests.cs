using Xunit;
using System.Collections.Generic;
using ChangeCalculatorApp;

namespace ChangeCalculatorApp.Tests
{

    public class ConvertToPenceTests
    {
        [Theory]
        [InlineData("20.105")]
        [InlineData(".5")]
        public void ConvertToPence_InvalidInputs_WrongFormatting(string input)
        {
            // Checks that -1 is returned when the values are inputted wrong i.e triple digit pence or missing whole pounds
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData("$20")]
        [InlineData("20q")]
        public void ConvertToPence_InvalidInputs_InvalidCharacters(string input)
        {
            // Checks that -1 is returned when the values are inputted with invalid characters such as wrong currency symbols
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ConvertToPence_InvalidInputs_NullorEmpty(string input)
        {
            // Checks that -1 is returned when the values are inputted with null or empty string and crashes are avoided
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData("20", 2000)]
        [InlineData("85250", 8525000)]
        [InlineData("1", 100)]
        [InlineData("0", 0)]
        public void ConvertToPence_ValidInputs_WholePounds(string input, int expected)
        {
            // Checks that the correct output is given when the input is in whole pounds with no symbols
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("20.5", 2050)]
        [InlineData("20.50", 2050)]
        [InlineData("20.55", 2055)]
        [InlineData("0.5", 50)]
        [InlineData("0.55", 55)]
        public void ConvertToPence_ValidInputs_PoundsPence(string input, int expected)
        {
            // Checks that the correct output is given when the input is in pounds and pence with no symbols
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("£20.5", 2050)]
        [InlineData("£5", 500)]
        [InlineData("£20.50p", 2050)]
        [InlineData("£20.5p", 2050)]
        public void ConvertToPence_ValidInputs_CorrectOutputWithSymbols(string input, int expected)
        {
            // Checks that symbols have no effect on output
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("250p", 250)]
        [InlineData("1p", 1)]
        [InlineData("0p", 0)]
        public void ConvertToPence_ValidInputs_OnlyPence(string input, int expected)
        {
            // Checks that inputs with only pence are handled correctly
            int result = ChangeCalculator.ConvertToPence(input);
            Assert.Equal(expected, result);
        }
    }
}
