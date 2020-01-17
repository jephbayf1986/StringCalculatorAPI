using Shouldly;
using StringCalculator.Application.Operators;
using System;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Subtract
{
    public class GetResultUnitTest
    {
        [Theory]
        [InlineData("8-4", 4)]
        [InlineData("24-12", 12)]
        [InlineData("512-256", 256)]
        public void ReturnSubtractedValues(string operationText, int expectedResult)
        {
            // Arrange
            IOperator SystemUnderTest = new Subtraction(operationText);

            // Act
            decimal result = SystemUnderTest.GetResult();

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Fact]
        public void ThrowExceptionWhenResultNegative()
        {
            // Arrange
            IOperator SystemUnderTest = new Subtraction("5-10");

            // Act + Assert
            Should.Throw<ArgumentOutOfRangeException>(() => SystemUnderTest.GetResult());
        }
    }
}