using StringCalculator.Application.Constants;
using StringCalculator.Application.Operators;

namespace StringCalculator.Application.StringHelpers
{
    public class StringModifier : IStringModifier
    {
        private readonly IOperationIdentifier _operationIdentifier;
        private readonly IOperatorFactory _operationFactory;

        public StringModifier(IOperationIdentifier operationIdentifier, IOperatorFactory operationFactory)
        {
            _operationIdentifier = operationIdentifier;
            _operationFactory = operationFactory;
        }

        public void SubstituteOperationsWithResult(ref string calculationString, string symbol)
        {
            do
            {
                if (!calculationString.Contains(symbol))
                {
                    break;
                }

                // Break if Negative Result, with no other calculations eg. -50
                if (symbol == OperatorSymbol.Subtract && calculationString.Substring(0, 1) == symbol && !calculationString.Substring(1).Contains(symbol))
                {
                    break;
                }

                // Break if Double Negative Result, with no other calculations eg. --50
                if (symbol == OperatorSymbol.Subtract && calculationString.Substring(0, 2) == (symbol + symbol) && !calculationString.Substring(2).Contains(symbol))
                {
                    calculationString = calculationString.Replace((symbol + symbol), "");

                    break;
                }

                string operationString = _operationIdentifier.GetNextOperationMatch(calculationString, symbol);

                IOperator Operation = _operationFactory.Create(operationString);

                decimal Result = Operation.GetResult();

                calculationString = calculationString.Replace(operationString, Result.ToString());
            }
            while (calculationString.Contains(symbol));
        }
    }
}