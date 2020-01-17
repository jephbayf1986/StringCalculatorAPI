using StringCalculator.Application.Constants;
using System.Text.RegularExpressions;

namespace StringCalculator.Application.StringHelpers
{
    public class OperationIdentifier : IOperationIdentifier
    {
        public MatchCollection GetOperationMatches(string completeString, OperationSymbol symbol)
        {
            Regex regex = new Regex("");

            return regex.Matches(completeString);
        }
    }
}