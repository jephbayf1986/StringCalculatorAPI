using StringCalculator.Application.Constants;
using StringCalculator.Application.StringHelpers;
using System;

namespace StringCalculator.Application
{
    public class Calculation : ICalculation
    {
        private readonly IStringModifier _stringModifier;

        public Calculation(IStringModifier stringModifier)
        {
            _stringModifier = stringModifier;
        }

        public decimal Result(string calculationString)
        {
            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperationSymbol.Divide);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperationSymbol.Multiply);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperationSymbol.Add);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperationSymbol.Subtract);

            bool numericResult = int.TryParse(calculationString, out int result);

            if (!numericResult)
            {
                throw new ArgumentException("The text entered was not a valid calculation");
            }

            return result;
        }
    }
}