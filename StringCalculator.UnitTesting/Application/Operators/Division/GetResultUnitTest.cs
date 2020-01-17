using Shouldly;
using StringCalculator.Application.Operators;
using System;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Divide
{
    public class GetResultUnitTest
    {
        [Theory]
        [InlineData("8/2", 4)]
        [InlineData("10/4", 2.5)]
        [InlineData("120/20", 6)]
        [InlineData("1024/8", 128)]
        public void ReturnDividedValues(string operationText, decimal expectedResult)
        {
            // Arrange
            IOperator SystemUnderTest = new Division(operationText);

            // Act
            decimal result = SystemUnderTest.GetResult();

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData("7/3", 2.3333)]
        [InlineData("5/18", 0.2778)]
        public void ReturnRoundedValuesGivenComplexDivision(string operationText, decimal expectedResult)
        {
            // Arrange
            IOperator SystemUnderTest = new Division(operationText);

            // Act
            decimal result = SystemUnderTest.GetResult();

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void ReturnExceptionGivenZeroDivisor()
        {
            // Arrange
            IOperator SystemUnderTest = new Division("10/0");

            // Act + Assert
            Should.Throw<DivideByZeroException>(() => SystemUnderTest.GetResult());
        }
    }
}