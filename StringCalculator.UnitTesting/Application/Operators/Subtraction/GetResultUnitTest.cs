using Shouldly;
using StringCalculator.Application.Operators;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Subtract
{
    public class GetResultUnitTest
    {
        [Theory]
        [InlineData("8-4", 4)]
        [InlineData("4-8", -4)]
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
    }
}