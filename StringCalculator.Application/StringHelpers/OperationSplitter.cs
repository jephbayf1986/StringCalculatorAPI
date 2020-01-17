using StringCalculator.Application.Constants;
using System;
using System.Text.RegularExpressions;

namespace StringCalculator.Application.StringHelpers
{
    public static class OperationSplitter
    {
        public static void Split(string operationText, out decimal valueA, out decimal valueB) 
        {
            Regex regex = new Regex(RegexPattern.AnyPositive);

            MatchCollection Matches = regex.Matches(operationText);

            if (Matches.Count != 2)
            {
                throw new ArgumentException("No valid numbers were found");
            }

            decimal.TryParse(Matches[0].Value, out valueA);
            decimal.TryParse(Matches[1].Value, out valueB);
        }
    }
}