using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ChangeCalculatorApp;

namespace ChangeCalculatorApp.Tests
{
    public class CalculateChangeTests
    {
        [Fact]
        public void CalculateChange_ValidInputs_CorrectChange1()
        {
            // Test case using £1.15 to check that the correct change is given for a simple case
            int amount = 115;
            List<(string, int)> expected = new List<(string, int)>();
            expected.Add(("£1", 1));
            expected.Add(("10p", 1));
            expected.Add(("5p", 1));
            List<(string, int)> result = ChangeCalculator.CalculateChange(amount);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateChange_ValidInputs_CorrectChange2()
        {
            // Test case using £14.5 to check higher denominations
            int amount = 1450;
            List<(string, int)> expected = new List<(string, int)>();
            expected.Add(("£10", 1));
            expected.Add(("£2", 2));
            expected.Add(("50p", 1));
            List<(string, int)> result = ChangeCalculator.CalculateChange(amount);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateChange_ValidInputs_NoChange()
        {
            // Checks that an empty array is returned when no change is needed
            int amount = 0;
            List<(string, int)> expected = new List<(string, int)>();
            List<(string, int)> result = ChangeCalculator.CalculateChange(amount);
            Assert.Equal(expected, result);
        }
    }
}
