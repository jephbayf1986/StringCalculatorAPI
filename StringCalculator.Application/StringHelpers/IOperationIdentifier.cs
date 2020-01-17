using StringCalculator.Application.Constants;
using System.Text.RegularExpressions;

namespace StringCalculator.Application.StringHelpers
{
    public interface IOperationIdentifier
    {
        MatchCollection GetOperationMatches(string completeString, OperationSymbol symbol);
    }
}