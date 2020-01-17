using StringCalculator.Application.Constants;
using System;
using System.Text.RegularExpressions;

namespace StringCalculator.Application.StringHelpers
{
    public class OperationIdentifier : IOperationIdentifier
    {
        public string GetNextOperationMatch(string completeString, string symbol)
        {
            string RegexSymbol = symbol.Replace("+", "\\+").Replace("*", "\\*");

            Regex regex = new Regex($"{RegexPattern.AnyPositive}{RegexSymbol}{RegexPattern.AnyPositive}");

            MatchCollection Matches = regex.Matches(completeString);

            if (Matches.Count == 0)
            {
                throw new ArgumentException("A Valid Operation was not found");
            }

            return Matches[0].Value;
        }
    }
}