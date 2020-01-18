using Moq;
using Shouldly;
using StringCalculator.Application.Operators;
using StringCalculator.Application.StringHelpers;
using Xunit;

namespace StringCalculator.UnitTesting.Application.StringHelpers.StringModify
{
    public class SubstituteOperationsWithResultUnitTest
    {
        private readonly Mock<IOperationIdentifier> _operationIdentifier;
        private readonly Mock<IOperatorFactory> _operationFactory;
        private readonly Mock<IOperator> _operator;

        public SubstituteOperationsWithResultUnitTest()
        {
            _operationIdentifier = new Mock<IOperationIdentifier>();

            _operationFactory = new Mock<IOperatorFactory>();

            _operator = new Mock<IOperator>();

            _operationIdentifier.Setup(x => x.GetNextOperationMatch("4+6/2*3-8", "/"))
                .Returns("6/2")
                .Verifiable("Get Division Verified");

            _operationFactory.Setup(x => x.Create("6/2"))
                .Returns(_operator.Object)
                .Verifiable("Create Division Verified");

            _operator.Setup(x => x.GetResult())
                .Returns(3)
                .Verifiable("Get Result Verified");
        }

        [Fact]
        public void ReplaceOperationWithResult()
        {
            // Arrange
            string CalculationString = "4+6/2*3-8";
            string OperatorToCalculate = "/";

            StringModifier SystemUnderTest = new StringModifier(_operationIdentifier.Object, _operationFactory.Object);

            // Act
            SystemUnderTest.SubstituteOperationsWithResult(ref CalculationString, OperatorToCalculate);

            // Assert
            CalculationString.ShouldBe("4+3*3-8");

            _operationFactory.Verify(x => x.Create("6/2"), Times.Once());
            _operator.Verify(x => x.GetResult(), Times.Once());
        }

        [Fact]
        public void DoNothingWithSingleNegative()
        {
            // Arrange
            string CalculationString = "-20";
            string OperatorToCalculate = "-";

            StringModifier SystemUnderTest = new StringModifier(_operationIdentifier.Object, _operationFactory.Object);

            // Act
            SystemUnderTest.SubstituteOperationsWithResult(ref CalculationString, OperatorToCalculate);

            // Assert
            CalculationString.ShouldBe("-20");

            _operationFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Never());
            _operator.Verify(x => x.GetResult(), Times.Never());
        }

        [Fact]
        public void ReturnPositiveIfDoubleNegative()
        {
            // Arrange
            string CalculationString = "--20";
            string OperatorToCalculate = "-";

            StringModifier SystemUnderTest = new StringModifier(_operationIdentifier.Object, _operationFactory.Object);

            // Act
            SystemUnderTest.SubstituteOperationsWithResult(ref CalculationString, OperatorToCalculate);

            // Assert
            CalculationString.ShouldBe("20");

            _operationFactory.Verify(x => x.Create(It.IsAny<string>()), Times.Never());
            _operator.Verify(x => x.GetResult(), Times.Never());
        }
    }
}