using Shouldly;
using StringCalculator.Application.Operators;
using System;
using Xunit;

namespace StringCalculator.UnitTesting.Application.Operators.Factory
{
    public class CreateUnitTest
    {
        [Theory]
        [InlineData("8+4", typeof(Addition))]
        [InlineData("8-4", typeof(Subtraction))]
        [InlineData("8*4", typeof(Multiplication))]
        [InlineData("8/4", typeof(Division))]
        public void CreateCorrectType(string operationText, Type createdType)
        {
            // Arrange
            OperatorFactory SystemUnderTest = new OperatorFactory();
            
            // Act
            IOperator createdOperator = SystemUnderTest.Create(operationText);

            // Assert
            createdOperator.ShouldBeOfType(createdType);
        }

        [Fact]
        public void ThrowExceptionGivenNoOperator()
        {
            // Arrange
            OperatorFactory SystemUnderTest = new OperatorFactory();

            string InvalidOperation = "1242&213124";

            // Act + Assert
            Should.Throw<ArgumentException>(() => SystemUnderTest.Create(InvalidOperation));
        }
    }
}