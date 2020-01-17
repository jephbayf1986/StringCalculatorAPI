using StringCalculator.Application.Constants;
using System.Text.RegularExpressions;

namespace StringCalculator.Application.StringHelpers
{
    public class StringModifier : IStringModifier
    {
        private readonly IOperationIdentifier _operationIdentifier;

        public StringModifier(IOperationIdentifier operationIdentifier)
        {
            _operationIdentifier = operationIdentifier;
        }

        public void SubstituteOperationsWithResult(ref string calculationString, OperationSymbol symbol)
        {
            MatchCollection operationMatches = _operationIdentifier.GetOperationMatches(calculationString, symbol);

            foreach (Match match in operationMatches)
            {

            }
        }
    }
}