using StringCalculator.Application.Constants;
using StringCalculator.Application.StringHelpers;
using System;

namespace StringCalculator.Application
{
    public class Calculator : ICalculator
    {
        private readonly IStringModifier _stringModifier;

        public Calculator(IStringModifier stringModifier)
        {
            _stringModifier = stringModifier;
        }

        public decimal Calculate(string calculationString)
        {
            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperatorSymbol.Divide);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperatorSymbol.Multiply);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperatorSymbol.Add);

            _stringModifier.SubstituteOperationsWithResult(ref calculationString, OperatorSymbol.Subtract);

            bool numericResult = decimal.TryParse(calculationString, out decimal result);

            if (!numericResult)
            {
                throw new ArgumentException("The text entered was not a valid calculation");
            }

            return result;
        }
    }
}