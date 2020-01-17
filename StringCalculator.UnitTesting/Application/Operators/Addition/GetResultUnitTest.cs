using Shouldly;
using StringCalculator.Application.Operators;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Add
{
    public class GetResultUnitTest
    {
        [Theory]
        [InlineData("4+8", 12)]
        [InlineData("14+8", 22)]
        [InlineData("24+12", 36)]
        [InlineData("256+256", 512)]
        public void ShouldAddValues(string operationText, int expectedResult)
        {
            // Arrange
            IOperator SystemUnderTest = new Addition(operationText);

            // Act
            decimal result = SystemUnderTest.GetResult();

            // Assert
            result.ShouldBe(expectedResult);
        }
    }
}