using Shouldly;
using StringCalculator.Application.Operators;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Multiply
{
    public class GetResultUnitTest
    {
        [Theory]
        [InlineData("4*2", 8)]
        [InlineData("14*3", 42)]
        [InlineData("24*4", 96)]
        [InlineData("4*256", 1024)]
        [InlineData("100*100", 10000)]
        public void ReturnMultipliedValues(string operationText, int expectedResult)
        {
            // Arrange
            IOperator SystemUnderTest = new Multiplication(operationText);

            // Act
            decimal result = SystemUnderTest.GetResult();

            // Assert
            result.ShouldBe(expectedResult);
        }
    }
}