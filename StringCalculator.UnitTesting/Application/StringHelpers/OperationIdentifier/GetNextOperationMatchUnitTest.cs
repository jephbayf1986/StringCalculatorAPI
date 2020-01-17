using Shouldly;
using StringCalculator.Application.Constants;
using StringCalculator.Application.StringHelpers;
using System;
using Xunit;

namespace StringCalculator.UnitTesting.Application.StringHelpers.OperationIdentify
{
    public class GetNextOperationMatchUnitTest
    {
        [Theory]
        [InlineData("1+1+2+2+3", OperatorSymbol.Add, "1+1")]
        [InlineData("11-11+2+2+3", OperatorSymbol.Subtract, "11-11")]
        [InlineData("111*111+2+2+3", OperatorSymbol.Multiply, "111*111")]
        [InlineData("2222/1111+2+2+3", OperatorSymbol.Divide, "2222/1111")]
        [InlineData("AAAAA1111+1111+2+2+3", OperatorSymbol.Add, "1111+1111")]
        public void ShouldCollectAllDigitsEitherSide(string stringInput, string symbol, string expectedFirst)
        {
            // Arrange
            OperationIdentifier systemUnderTest = new OperationIdentifier();

            // Act
            var result = systemUnderTest.GetNextOperationMatch(stringInput, symbol);

            // Assert
            result.ShouldBe(expectedFirst);
        }

        [Theory]
        [InlineData("1*1", OperatorSymbol.Add)]
        [InlineData("111", OperatorSymbol.Divide)]
        [InlineData("+/*-", OperatorSymbol.Subtract)]
        public void ThrowExceptionGivenInvalidString(string stringInput, string symbol)
        {
            // Arrange
            OperationIdentifier systemUnderTest = new OperationIdentifier();

            Should.Throw<ArgumentException>(() => systemUnderTest.GetNextOperationMatch(stringInput, symbol));
        }
    }
}