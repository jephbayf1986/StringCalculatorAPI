using Shouldly;
using StringCalculator.Application.StringHelpers;
using System;
using Xunit;

namespace StringCalculator.UnitTesting.Application.StringHelpers.OperationSplit
{
    public class SplitUnitTest
    {
        [Theory]
        [InlineData("1+1", 1, 1)]
        [InlineData("111+11", 111, 11)]
        [InlineData("6-2", 6, 2)]
        [InlineData("666-22", 666, 22)]
        [InlineData("4*8", 4, 8)]
        [InlineData("55*11", 55, 11)]
        [InlineData("8/2", 8, 2)]
        [InlineData("110/11", 110, 11)]
        public void Assign2Values(string operationText, int expectedValueA, int expectedValueB)
        {
            OperationSplitter.Split(operationText, out decimal ValueA, out decimal ValueB);

            ValueA.ShouldBe(expectedValueA);
            ValueB.ShouldBe(expectedValueB);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("1+1+1")]
        [InlineData("Text")]
        public void ThrowExceptionGivenInvalidString(string operationText)
        {
            Should.Throw<ArgumentException>(() => OperationSplitter.Split(operationText, out decimal v1, out decimal v2));
        }
    }
}