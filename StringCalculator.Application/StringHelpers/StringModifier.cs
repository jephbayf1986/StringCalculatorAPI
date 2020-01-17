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

                string operationString = _operationIdentifier.GetNextOperationMatch(calculationString, symbol);

                IOperator Operation = _operationFactory.Create(operationString);

                decimal Result = Operation.GetResult();

                calculationString = calculationString.Replace(operationString, Result.ToString());
            }
            while (calculationString.Contains(symbol));
        }
    }
}